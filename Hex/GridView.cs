using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;

namespace Hex {
	class GridView {
		private static float triangleSide = 50;
		private static float triangleHeight = 0;

		public Cell highlightCell;

		private Random rnd = new Random();

		static GridView() {
			triangleHeight = triangleSide * (float)Math.Sin(Math.PI / 3);
		}

		public Game game = null;

		public Point viewportCenter = new Point();
		public Size viewportSize = new Size();

		private Pen mainGridPen = new Pen(Color.Black);

		private List<Point> nearestCells = new List<Point>();
		private Point nearest = new Point();

		public GridView(Game game) { 
			this.game = game;
			viewportCenter.X = (int)((game.settings.cellsCount - 1) * 1.5f * triangleSide);
		}

		public void setViewportSize(Size size) {
			this.viewportSize = size;
		}
		public void setViewportCenter(Point center) {
			this.viewportCenter = center;
		}

		public void draw(Graphics gfx) {
			//Logger.log("draw " + Randomizer.getRandomValue());
			//Draw only on given graphics
			/*
			Image img = pictureBox.Image;
			if (img == null) return;
			Graphics gfx = Graphics.FromImage(img);
			*/
			gfx.Clear(Color.White);

			//Drawing cells
			foreach (Cell cell in game.grid.cells.Values) {
				PointF cellCenter = worldToImageCoords(cellsToWorldCoords(cell.Coords));
				Point worldCoords = new Point((int)cellCenter.X, (int)cellCenter.Y); ;
				Point[] points = getCellPoints(cell.Coords);
				if (cell.type != null && cell.type != CellType.Invisible) {
					Brush brush;
					if (game.openedCells.Contains(cell)) {
						brush = cell.type.getBrush(255);
					}
					else if (game.visibleCells.Contains(cell)) {
						brush = cell.type.getBrush(100);
					}
					else {
						brush = Brushes.DarkGray;
					}
					
					/*gfx.FillClosedCurve(
						new System.Drawing.Drawing2D.HatchBrush(getRandomValue(), randomColor(40), randomColor(40)),
						points,
						System.Drawing.Drawing2D.FillMode.Alternate,
						0
					);*/
						
					
					gfx.FillClosedCurve(
						brush,
						points,
						System.Drawing.Drawing2D.FillMode.Alternate,
						0
					);

					if (game.openedCells.Contains(cell) && cell.isMined) {
						int rad = (int)Math.Round(triangleSide / 2.0f);
						gfx.DrawEllipse(Pens.Black, new Rectangle(worldCoords.X - rad, worldCoords.Y - rad, rad * 2, rad * 2));
					}
					
				}
				gfx.DrawLines(mainGridPen, points);
				

				String cellName = cell.Coords.X.ToString() + ":" + cell.Coords.Y.ToString();
				Font nameFont = new Font("Arial", 10);
				SizeF nameSize = gfx.MeasureString(cellName, nameFont);
				gfx.DrawString(cellName, nameFont, Brushes.Black, new Point((int)(cellCenter.X - nameSize.Width / 2 + 1), (int)(cellCenter.Y - nameSize.Height / 2 + 1)));

				if (cell == game.playerPosition) {
					int rad = (int)Math.Round(triangleSide / 3.0f);
					Pen pen = new Pen(Brushes.Yellow, 3);
					gfx.DrawEllipse(pen, new Rectangle(worldCoords.X - rad, worldCoords.Y - rad, rad * 2, rad * 2));
				}
			}

			if (highlightCell != null) {
				Point[] points = getCellPoints(highlightCell.Coords);
				Pen pen = new Pen(Brushes.White, 2);
				gfx.DrawLines(pen, points);
			}
		}

		public PointF cellsToWorldCoords(PointF cell) {
			PointF res = new PointF((cell.X + cell.Y) * (triangleSide * 1.5f), (-cell.X + cell.Y) * (triangleHeight));
			return res;
		}

		public PointF worldToCellsCoords(PointF coords) {
			float x = coords.X / (3 * triangleSide) - coords.Y / (2 * triangleHeight);
			float y = coords.X / (3 * triangleSide) + coords.Y / (2 * triangleHeight);
			return new PointF(x, y);
		}

		public Point worldToImageCoords(PointF coords) {
			float imageCenterX = viewportSize.Width / 2.0f;
			float imageCenterY = viewportSize.Height / 2.0f;
			float x = coords.X - viewportCenter.X;
			float y = coords.Y - viewportCenter.Y;
			return new Point((int)(imageCenterX + x), (int)(imageCenterY - y));
		}

		public PointF imageToWorldCoords(Point coords) {
			float x =  - viewportSize.Width / 2.0f + coords.X + viewportCenter.X;
			float y = viewportSize.Height / 2.0f - coords.Y + viewportCenter.Y;
			return new PointF(x, y);
		}

		public Cell getCellOnCoords(PointF coords) {
			PointF cellCoords = worldToCellsCoords(coords);
			if (coords.X % 1 == 0 && coords.Y % 1 == 0) {
				if (game.grid.cells.ContainsKey(new Point((int)coords.X, (int)coords.Y))) {
					nearestCells = new List<Point>() { 
						new Point((int)coords.X, (int)coords.Y),
					};
					return game.grid.cells[new Point((int)coords.X, (int)coords.Y)];
				}
				else {
					nearestCells.Clear();
					return null;
				}
			}

			nearestCells = new List<Point>() {
				new Point((int)Math.Floor(cellCoords.X), (int)Math.Floor(cellCoords.Y)),
				new Point((int)Math.Floor(cellCoords.X), (int)Math.Ceiling(cellCoords.Y)),
				new Point((int)Math.Ceiling(cellCoords.X), (int)Math.Floor(cellCoords.Y)),
				new Point((int)Math.Ceiling(cellCoords.X), (int)Math.Ceiling(cellCoords.Y)),
			};
			Dictionary<Point, float> cells = new Dictionary<Point, float>();
			float minDist = triangleSide * 2;
			nearest = nearestCells[0];
			foreach (Point p in nearestCells) {
				PointF cellCenter = cellsToWorldCoords(p);
				float dx = coords.X - cellCenter.X;
				float dy = coords.Y - cellCenter.Y;
				float dist = (float)Math.Sqrt(dx * dx + dy * dy);

				if (dist < minDist || minDist > triangleSide) {
					//либо нашли ещё ближе, либо это первая клетка
					minDist = dist;
					nearest = p;
				}
				else if (dist == minDist && game.grid.cellIsOutOfBounds(nearest) && !game.grid.cellIsOutOfBounds(p)) {
					//нашли равноудалённую и существующую - её и берём
					nearest = p;
				}
			}
			if (game.grid.cellIsOutOfBounds(nearest)) {
				//ближайшей является клетка, которая не находится в области
				return null;
			}
			return game.grid.cells[nearest];
		}

		private Point[] getCellPoints(Cell cell) {
			return getCellPoints(cell.Coords);
		}

		private Point[] getCellPoints(Point cellCoords) {
			PointF center = cellsToWorldCoords(cellCoords);
			Point[] points = new Point[7] {
				worldToImageCoords(center + new SizeF(-triangleSide, 0)),
				worldToImageCoords(center + new SizeF(-triangleSide / 2, triangleHeight)),
				worldToImageCoords(center + new SizeF(triangleSide / 2, triangleHeight)),
				worldToImageCoords(center + new SizeF(triangleSide, 0)),
				worldToImageCoords(center + new SizeF(triangleSide / 2, -triangleHeight)),
				worldToImageCoords(center + new SizeF(-triangleSide / 2, -triangleHeight)),
				worldToImageCoords(center + new SizeF(-triangleSide, 0)),
			};
			return points;
		}

		private HatchStyle getRandomValue() {
			Array values = Enum.GetValues(typeof(HatchStyle));
			return (HatchStyle)values.GetValue(rnd.Next(values.GetLength(0)));
			//return (HatchStyle)values.GetValue(valueNum % values.GetLength(0));
		}

		private HatchStyle getRandomValue(int valueNum) {
			Array values = Enum.GetValues(typeof(HatchStyle));
			//return (HatchStyle)values.GetValue(rnd.Next(values.GetLength(0)));
			return (HatchStyle)values.GetValue(valueNum % values.GetLength(0));
		}

		private Color randomColor(int alpha) {
			return Color.FromArgb(alpha, rnd.Next(255), rnd.Next(255), rnd.Next(255));
		}
	}
}
