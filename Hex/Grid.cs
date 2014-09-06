using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Hex {
	class Grid {
		public Dictionary<Point, Cell> cells = new Dictionary<Point, Cell>();
		public List<Cell> nonEmptyCells = new List<Cell>();
		public List<Cell> exits = new List<Cell>();

		public int size = 100;
		public Cell startCell;

		private Random rnd = new Random();

		public Grid(int size) {
			this.size = size;

			for (int x = 0; x < size; x++) {
				for (int y = 0; y < size; y++) {
					Cell cell = new Cell(x, y, null);
					cells.Add(cell.Coords, cell);
				}
			}

			
			foreach (Cell cell in cells.Values) {
				Dictionary<CellDirection, Point> neighbours = new Dictionary<CellDirection, Point>() {
					{CellDirection.Up, new Point(cell.Coords.X - 1, cell.Coords.Y + 1)},
					{CellDirection.UpRight, new Point(cell.Coords.X, cell.Coords.Y + 1)},
					{CellDirection.DownRight, new Point(cell.Coords.X + 1, cell.Coords.Y)},
					{CellDirection.Down, new Point(cell.Coords.X + 1, cell.Coords.Y - 1)},
					{CellDirection.DownLeft, new Point(cell.Coords.X, cell.Coords.Y - 1)},
					{CellDirection.UpLeft, new Point(cell.Coords.X - 1, cell.Coords.Y)},
				};

				foreach (KeyValuePair<CellDirection, Point> pos in neighbours) {
					if (!cellIsOutOfBounds(pos.Value)) {
						Cell neighbour = cells[pos.Value];
						cell.neighbours.Add(neighbour);
						cell.directionedNeighbours.Add(pos.Key, neighbour);
					}
				}
			}

			startCell = cells[new Point(size / 2, size / 2)];
			//Cell startCell = cells.Values.ToList()[rnd.Next(cells.Count)];
			startCell.type = CellType.Entrance;
			
			fillNeighbours(startCell, 10, 0);
			
			createExit(3);
			fillPath(startCell, 7, 0);

			fillMisc();

			fillMines();
		}

		public bool cellIsOutOfBounds(Point coords) {
			if (coords.X < 0 || size <= coords.X || coords.Y < 0 || size <= coords.Y) {
				return true;
			}

			return false;
		}

		public static int distance(Point p1, Point p2) {
			int x1 = p1.X + p1.Y;
			int y1 = p1.Y - p1.X;
			int x2 = p2.X + p2.Y;
			int y2 = p2.Y - p2.X;
			int dx = Math.Abs(x1 - x2);
			int dy = Math.Abs(y1 - y2);

			int dist = dx;
			if (dy > dx) {
				dist += (int)Math.Ceiling((dy - dx) / 2.0);
			}
			return dist;
		}

		private void fillNeighbours(Cell cell, int depth, int steps) {
			if (depth == 0 || cell.type == CellType.Invisible) {
				return;
			}

			foreach (Cell neighbour in cell.neighbours) {
				if (neighbour.type == null) {
					neighbour.type = CellType.Grass;
					nonEmptyCells.Add(neighbour);
					fillNeighbours(neighbour, rnd.Next(depth), steps + 1);
				}
			}
		}

		private void createExit(int num) {
			List<Cell> suitableCells = new List<Cell>();
			foreach (Cell cell in nonEmptyCells) {
				if (cell.type != CellType.Entrance && cell.type != CellType.Exit && distance(cell.Coords, startCell.Coords) > 2) {
					suitableCells.Add(cell);
				}
			}
			num = Math.Min(num, suitableCells.Count);
			for (int i = 0; i < num; i++) {
				Cell exit = suitableCells[rnd.Next(suitableCells.Count)];
				exit.type = CellType.Exit;
				suitableCells.Remove(exit);
			}
		}

		private void fillPath(Cell cell, int depth, int steps) {
			//Logger.AppendText("Trying to create path around cell " + cell.Coords.X + ":" + cell.Coords.Y + "\r\n");
			if (depth == 0) {
				return;
			}

			// решим, сколько мы хотим дорог отсюда
			int neededRoads = Randomizer.getWithPercent(new Dictionary<int, float>() {
				{0, (float)steps / (float)depth / 2.0f},               // в начале это будет почти равно нулю.. под конец более вероятно
				{1, 1},                                                // стабильно. в середине равновероятно с 2мя ходами
				{2, Math.Max(0.1f, (float)depth / (float)steps)},      // в начале - наиболее вероятно.. под конец почти невозможно
			});

			//Logger.AppendText("    needed roads: " + neededRoads + "\r\n");

			if (neededRoads == 2) {
				trytoCreateRoad(cell, depth, steps);
				trytoCreateRoad(cell, depth, steps);
			}
			else if (neededRoads == 1) {
				trytoCreateRoad(cell, depth, steps);
			}
			else {
				//не будет у нас тут продолжения
			}
		}

		private void trytoCreateRoad(Cell cell, int depth, int steps) {
			//Logger.log("Creating road for cell " + cell.Coords.X + ":" + cell.Coords.Y + "\r\n");

			List<Cell> suitableNeighbours = getSuitableNeighboursForRoads(cell);

			if (suitableNeighbours.Count > 0) {
				//переделываем
				int nextCellIndex = rnd.Next(suitableNeighbours.Count);
				//Logger.log("    next cell index: " + nextCellIndex + "\r\n");

				Cell nextCell = suitableNeighbours[nextCellIndex];

				//Logger.log("    next cell is " + nextCell.Coords.X + ":" + nextCell.Coords.Y + "\r\n");

				nextCell.type = CellType.Road;
				fillPath(nextCell, depth - 1, steps + 1);
			}
			else {
				//Logger.log("    no suitable neighbours for this cell..\r\n");
			}
		}

		/// <summary>
		/// возвращает список соседей, которых потенциально можно переделать в дороги
		/// </summary>
		/// <param name="cell"></param>
		/// <returns></returns>
		private List<Cell> getSuitableNeighboursForRoads(Cell cell) {
			List<CellType> notSuitableTypes = new List<CellType>() {
				CellType.Exit, CellType.Entrance, CellType.Road
			};

			List<Cell> suitableNeighbours = new List<Cell>();
			List<string> names = new List<string>();
			foreach (Cell neighbour in cell.neighbours) {
				if (neighbour.type != null && !notSuitableTypes.Contains(neighbour.type) && neighbour.canBeRoad()) {
					suitableNeighbours.Add(neighbour);
					names.Add(neighbour.Coords.X + ":" + neighbour.Coords.Y);
				}
			}
			//Logger.log("    suitable neighbours for cell " + cell.Coords.X + ":" + cell.Coords.Y + " count: " + suitableNeighbours.Count + " (" + string.Join(", ", names) + ")\r\n");
			
			return suitableNeighbours;
		}

		private void fillMisc() {
			foreach (Cell cell in nonEmptyCells) {
				if (cell.type == CellType.Grass) {
					int type = Randomizer.getWithPercent(new Dictionary<int, float>() {
						{11, 7},
						{12, 7},
						{13, 7},
						{14, 80}
					});
					switch(type) {
						case 11:
							cell.type = CellType.Water;
							break;
						case 12:
							cell.type = CellType.Rock;
							break;
						case 13:
							cell.type = CellType.Tree;
							break;
						default: break;

					}
				}
			}
		}

		private void fillMines() {
			foreach (Cell cell in nonEmptyCells) {
				//if the cell is not the entrance - minesCount == 0
				int minesCount = 0;
				if (Grid.distance(startCell.Coords, cell.Coords) == 1) {
					foreach (Cell neighbour in startCell.neighbours) {
						if (neighbour.isMined == true) {
							minesCount++;
						}
					}
				}
				if (cell.type != null && minesCount < 5) {
					int mine = Randomizer.getWithPercent(new Dictionary<int, float>() {
						{1, cell.type.percent},
						{0, 1 - cell.type.percent}
					});
					if (mine == 1) {
						cell.isMined = true;
					}
					else {
						cell.isMined = false;
					}
				}
			}
		}
	}
}
