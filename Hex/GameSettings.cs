using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hex {
	class GameSettings {
		public int cellsCount = 11;
		public int startPlayerEnergy = 30;
		public int mineEnergy = 10;

		public Dictionary<CellType, int> typeEnergy = new Dictionary<CellType, int>() {
			{CellType.Entrance, 0},
			{CellType.Exit, 0}, 
			{CellType.Invisible, 0},
			{CellType.Water, 5},
			{CellType.Rock, 4}, 
			{CellType.Tree, 3},
			{CellType.Grass, 2},
			{CellType.Road, 1},
		};

		public GameSettings() { }
	}
}
