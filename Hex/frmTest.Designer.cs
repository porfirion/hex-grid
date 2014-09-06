namespace Hex {
	partial class frmTest {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.valueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.chanceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.resultColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.valueColumn,
            this.chanceColumn,
            this.resultColumn});
			this.dataGridView1.Location = new System.Drawing.Point(68, 23);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(385, 377);
			this.dataGridView1.TabIndex = 0;
			this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
			// 
			// valueColumn
			// 
			this.valueColumn.HeaderText = "Value";
			this.valueColumn.Name = "valueColumn";
			// 
			// chanceColumn
			// 
			this.chanceColumn.HeaderText = "Chance";
			this.chanceColumn.Name = "chanceColumn";
			// 
			// resultColumn
			// 
			this.resultColumn.HeaderText = "Count";
			this.resultColumn.Name = "resultColumn";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(582, 23);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(94, 58);
			this.button1.TabIndex = 1;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// frmTest
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(866, 647);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.dataGridView1);
			this.Name = "frmTest";
			this.Text = "frmTest";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridViewTextBoxColumn valueColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn chanceColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn resultColumn;
		private System.Windows.Forms.Button button1;
	}
}