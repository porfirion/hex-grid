using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hex {
	public partial class frmMain : Form {
		private Game game = null;
		private GridView view = null;
		private GridController controller = null;

		public frmMain() {
			InitializeComponent();

			Logger.init(log);

			newGame();
		}

		private void fileToolStripMenuItem_Click(object sender, EventArgs e) {
			this.Refresh();
		}

		private void testToolStripMenuItem_Click(object sender, EventArgs e) {
			frmTest frm = new frmTest();
			frm.Show();
		}

		private void restartToolStripMenuItem_Click(object sender, EventArgs e) {
			newGame();
		}

		private void newGame() {
			Logger.clear();
			log.Clear();
			game = new Game(new GameSettings());
			view = new GridView(game);
			if (controller != null) {
				controller.removeListeners();
			}
			controller = new GridController(view, pictureBox1, statusLabel, infoLabel);
		}

		private void giveEnergyToolStripMenuItem_Click(object sender, EventArgs e) {
			game.giveEnergy(30);
		}

		private void restartToolStripMenuItem1_Click(object sender, EventArgs e) {
			game.restart();
		}

		private void clearLogToolStripMenuItem_Click(object sender, EventArgs e) {
			Logger.clear();
		}
	}
}
