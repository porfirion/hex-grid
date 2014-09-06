using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Hex {
	class GridController {
		private Game game = null;
		private GridView view = null;
		private PictureBox pictureBox = null;
		private Label statusLabel = null;
		private Label infoLabel = null;

		public GridController(GridView view, PictureBox pictureBox, Label statusLabel, Label infoLabel) {
			this.view = view;
			this.game = view.game;
			this.pictureBox = pictureBox;
			this.statusLabel = statusLabel;
			this.infoLabel = infoLabel;

			pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);
			view.setViewportSize(pictureBox.Size);

			addListeners();

			displayPlayerInfo();
			redraw();
		}

		public void addListeners() {
			pictureBox.MouseMove += this.onMouseMove;
			pictureBox.SizeChanged += this.onSizeChanged;
			pictureBox.Paint += this.onPaint;
			pictureBox.MouseClick += this.onClick;
			
			game.OnRedraw += redraw;
			game.OnPlayerChanged += displayPlayerInfo;
		}

		public void removeListeners() {
			pictureBox.MouseMove -= this.onMouseMove;
			pictureBox.SizeChanged -= this.onSizeChanged;
			pictureBox.Paint -= this.onPaint;
			pictureBox.MouseClick -= this.onClick;

			game.OnRedraw -= redraw;
			game.OnPlayerChanged -= displayPlayerInfo;
		}

		private void onMouseMove(object sender, MouseEventArgs args) {
			PointF worldPos = view.imageToWorldCoords(args.Location);
			Cell current = view.getCellOnCoords(worldPos);
			PointF cellsPos = view.worldToCellsCoords(worldPos);
			string text = "Клеточные координаты: " + cellsPos.X.ToString("F") + ":" + cellsPos.Y.ToString("F") + "\n";
			if (current != null) {
				text += "Активная клетка: " + current.Coords.X.ToString() + ":" + current.Coords.Y.ToString() + "\n";
				if (current.type != null) {
					text += "Тип клетки: " + current.type.translation + "\n";
					text += "Вероятность мины: " + current.type.percent * 100 + "%\n";
					text += "Наличие мины: " + (current.isMined ? "имеется" : "нет") + "\n";
					text += "Расстояние от центра: " + Grid.distance(game.grid.startCell.Coords, current.Coords).ToString();
				}
			}

			if (current != view.highlightCell) {	
				view.highlightCell = current;
				redraw();
			}
			statusLabel.Text = text;
		}

		private void onClick(object sender, MouseEventArgs args) {
			PointF worldPos = view.imageToWorldCoords(args.Location);
			Cell current = view.getCellOnCoords(worldPos);
			
			//just gets coords without cells or anything else
			//PointF cellsPos = view.worldToCellsCoords(worldPos);
			
			/*if (current != null) {
				int dist = Grid.distance(game.grid.startCell.Coords, current.Coords);
				Logger.AppendText("Клетка " + current.Coords.X.ToString("F") + ":" + current.Coords.Y.ToString("F") + " Расстояние от центра" + dist.ToString() + "\n");
			}*/

			if (current != null && current.type != null) {
				//we clicked the cell - trying to step into it
				game.stepIntoCell(current);
			}
		}

		private void onSizeChanged(object sender, EventArgs e) {
			Control control = (Control)sender;
			Image oldImage = pictureBox.Image;

			pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);
			view.setViewportSize(new Size(pictureBox.Width, pictureBox.Height));

			oldImage.Dispose();

			redraw();
		}

		private void onPaint(object sender, PaintEventArgs e) {
			view.draw(e.Graphics);
		}

		public void redraw() {
			pictureBox.Refresh();
		}

		public void displayPlayerInfo() {
			string str = "";
			str += "Текущая энергия: " + game.playerEnergy.ToString() + "\r\n";

			infoLabel.Text = str;
		}
	}
}
