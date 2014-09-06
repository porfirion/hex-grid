using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Hex {
	class Cell {
		private Point m_coords = new Point();
		public bool isMined = false;
		public bool isOpened = false;
		
		public CellType type = null;
		
		public Point Coords {
			get {
				return m_coords;
			}
		}

		public List<Cell> neighbours = new List<Cell>();
		public Dictionary<CellDirection, Cell> directionedNeighbours = new Dictionary<CellDirection, Cell>();

		public Cell(Point coords, CellType type) {
			m_coords = coords;
			this.type = type;
		}

		public Cell(int x, int y, CellType type) {
			m_coords = new Point(x, y);
			this.type = type;
		}

		public int nearRoadsCount() {
			int count = 0;
			foreach (Cell neighbour in neighbours) {
				if (neighbour.type == CellType.Road) {
					count++;
				}
			}
			return count;
		}

		public bool canBeRoad() {
			/*
			if (nearRoadsCount() >= 2) {
				//вокруг неё уже и так 2 дороги - её саму делать дорогой уже нельзя
				return false;
			}
			*/
			foreach (Cell neighbour in neighbours) {
				int nearRoadsCount = neighbour.nearRoadsCount();
				
				// useless - to many roads
				//if (neighbour.type == CellType.Road && neighbour.nearRoadsCount() >=3) {

				if (nearRoadsCount >= 3) {
					//у соседа уже есть две тропинки - третью приделывать нельзя
					//Logger.log("        cell " + this.Coords.X + ":" + this.Coords.Y + "can't be a road, because " + neighbour.Coords.X + ":" + neighbour.Coords.Y + " already has two roads\r\n");
					return false;
				}
			}
			//у самой меньше 2х дорожек, у соседей тоже - почему бы и не сделать
			return true;
		}
	}
}
