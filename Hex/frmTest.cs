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
	public partial class frmTest : Form {
		public frmTest() {
			InitializeComponent();
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {

		}

		private void button1_Click(object sender, EventArgs e) {
			Dictionary<int, float> chances = new Dictionary<int, float>();
			Dictionary<int, DataGridViewCell> values2Cells = new Dictionary<int,DataGridViewCell>();
			foreach (DataGridViewRow row in dataGridView1.Rows) {
				if (row.Cells["valueColumn"].Value != null) {
					int value = int.Parse((string)row.Cells["valueColumn"].Value);
					chances.Add(value, float.Parse((string)row.Cells["chanceColumn"].Value));
					row.Cells["resultColumn"].Value = 0;
					values2Cells.Add(value, row.Cells["resultColumn"]);
				}
			}
			float repeatCount = 10000;
			Dictionary<int, int> results = new Dictionary<int, int>();
			for (int i = 0; i < repeatCount; i++) {
				int res = Randomizer.getWithPercent(chances);
				if (results.ContainsKey(res)) {
					results[res] += 1;
				}
				else {
					results[res] = 1;
				}
			}
			foreach (KeyValuePair<int, int> resultPair in results) {
				values2Cells[resultPair.Key].Value = (resultPair.Value / repeatCount).ToString();
			}
		}
	}
}
