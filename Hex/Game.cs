using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Hex {
	class Game {
		public GameSettings settings;

		public List<Cell> openedCells = new List<Cell>();
		public List<Cell> visibleCells = new List<Cell>();
		
		public Cell playerPosition;
		public int playerEnergy;

		public Grid grid;

		public delegate void SimpleGameHandler();

		public event SimpleGameHandler OnRedraw;
		public event SimpleGameHandler OnPlayerChanged;

		public Game(GameSettings settings) {
			this.settings = settings;
			grid = new Grid(settings.cellsCount);

			playerPosition = grid.startCell;
			playerEnergy = settings.startPlayerEnergy;

			openCells();
		}

		public void restart() {
			Logger.log("Начинаем игру заново");
			openedCells.Clear();
			visibleCells.Clear();

			playerPosition = grid.startCell;
			playerEnergy = settings.startPlayerEnergy;

			openCells();

			raiseRedraw();
			raisePlayerChanged();
		}

		public void stepIntoCell(Cell cell) {
			int distance = Grid.distance(cell.Coords, playerPosition.Coords);
			if (distance == 0) {
				Logger.log("Вы уже находитесь на этой клетке");
			}
			else if (distance == 1) {
				if (openedCells.Contains(cell)) {
					//эта клетка уже была открыта
					playerPosition = cell;
					raiseRedraw();
				}
				else if (playerEnergy > 0) {
					//шагнули на одну вперёд
					if (!cell.isMined) {
						//эта клетка ещё не была открыта и не заминирована
						playerEnergy -= settings.typeEnergy[cell.type];
						playerPosition = cell;
						Logger.log("Вы открыли клетку " + cell.Coords.ToString() + "(-" + settings.typeEnergy[cell.type] + " энергии)");
						if (cell.type == CellType.Exit) {
							//ПОБЕДА
							Logger.log("The END");
						}

						openCells();
						raiseRedraw();
						raisePlayerChanged();
					}
					else {
						//это клетка не была открыта и заминирована
						playerEnergy -= settings.typeEnergy[cell.type];
						playerEnergy -= settings.mineEnergy;
						playerPosition = cell;
						Logger.log("Вы открыли клетку " + cell.Coords.ToString() + "(-" + settings.typeEnergy[cell.type] + " энергии) и подорвались на мине (-" + settings.mineEnergy + " энергии)");
						openCells();
						raiseRedraw();
						raisePlayerChanged();
					}
				}
				else {
					Logger.log("У вас недостаточно энергии для этого действия");
				}
			}
			else {
				Logger.log("Нельзя перешагнуть через несколько клеток");
				//шагнули через несколько клеток
			}
		}

		public void raiseRedraw() {
			SimpleGameHandler handler = OnRedraw;
			if (handler != null) {
				handler();
			}
		}
		public void raisePlayerChanged() {
			SimpleGameHandler handler = OnPlayerChanged;
			if (handler != null) {
				handler();
			}
		}

		public void openCells() {
			if (!openedCells.Contains(playerPosition)) {
				openedCells.Add(playerPosition);
			}
			foreach (Cell neighbour in playerPosition.neighbours) {
				if (!visibleCells.Contains(neighbour)) {
					visibleCells.Add(neighbour);
				}
			}
		}

		public void giveEnergy(int amount) {
			playerEnergy += amount;
			Logger.log("Вам дали " + amount + " энергии");
			raisePlayerChanged();
		}
	}
}
