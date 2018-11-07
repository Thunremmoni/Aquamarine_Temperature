namespace WindowsFormsApp1
{
	partial class Main_Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.checkBox_Stretch = new System.Windows.Forms.CheckBox();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.CloseButton = new System.Windows.Forms.Button();
			this.BackgroundButton = new System.Windows.Forms.Button();
			this.ClearButton = new System.Windows.Forms.Button();
			this.ShowButton = new System.Windows.Forms.Button();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.tableLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
			this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.checkBox_Stretch, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1117, 528);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// pictureBox1
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.pictureBox1, 2);
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox1.Location = new System.Drawing.Point(3, 3);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(1111, 469);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// checkBox_Stretch
			// 
			this.checkBox_Stretch.AutoSize = true;
			this.checkBox_Stretch.Location = new System.Drawing.Point(3, 478);
			this.checkBox_Stretch.Name = "checkBox_Stretch";
			this.checkBox_Stretch.Size = new System.Drawing.Size(66, 16);
			this.checkBox_Stretch.TabIndex = 1;
			this.checkBox_Stretch.Text = "Stretch";
			this.checkBox_Stretch.UseVisualStyleBackColor = true;
			this.checkBox_Stretch.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 4;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.45454F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.54546F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 218F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 206F));
			this.tableLayoutPanel2.Controls.Add(this.CloseButton, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.BackgroundButton, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.ClearButton, 2, 0);
			this.tableLayoutPanel2.Controls.Add(this.ShowButton, 3, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(170, 478);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(944, 47);
			this.tableLayoutPanel2.TabIndex = 2;
			// 
			// CloseButton
			// 
			this.CloseButton.AutoSize = true;
			this.CloseButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.CloseButton.Font = new System.Drawing.Font("等线", 15F);
			this.CloseButton.Location = new System.Drawing.Point(3, 3);
			this.CloseButton.Name = "CloseButton";
			this.CloseButton.Size = new System.Drawing.Size(188, 41);
			this.CloseButton.TabIndex = 0;
			this.CloseButton.Text = "关闭";
			this.CloseButton.UseVisualStyleBackColor = true;
			this.CloseButton.Click += new System.EventHandler(this.button1_Click);
			// 
			// BackgroundButton
			// 
			this.BackgroundButton.AutoSize = true;
			this.BackgroundButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BackgroundButton.Font = new System.Drawing.Font("等线", 15F);
			this.BackgroundButton.Location = new System.Drawing.Point(197, 3);
			this.BackgroundButton.Name = "BackgroundButton";
			this.BackgroundButton.Size = new System.Drawing.Size(319, 41);
			this.BackgroundButton.TabIndex = 1;
			this.BackgroundButton.Text = "设置背景颜色";
			this.BackgroundButton.UseVisualStyleBackColor = true;
			this.BackgroundButton.Click += new System.EventHandler(this.button2_Click);
			// 
			// ClearButton
			// 
			this.ClearButton.AutoSize = true;
			this.ClearButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ClearButton.Font = new System.Drawing.Font("等线", 15F);
			this.ClearButton.Location = new System.Drawing.Point(522, 3);
			this.ClearButton.Name = "ClearButton";
			this.ClearButton.Size = new System.Drawing.Size(212, 41);
			this.ClearButton.TabIndex = 2;
			this.ClearButton.Text = "清除图片";
			this.ClearButton.UseVisualStyleBackColor = true;
			this.ClearButton.Click += new System.EventHandler(this.button3_Click);
			// 
			// ShowButton
			// 
			this.ShowButton.AutoSize = true;
			this.ShowButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ShowButton.Font = new System.Drawing.Font("等线", 15F);
			this.ShowButton.Location = new System.Drawing.Point(740, 3);
			this.ShowButton.Name = "ShowButton";
			this.ShowButton.Size = new System.Drawing.Size(201, 41);
			this.ShowButton.TabIndex = 3;
			this.ShowButton.Text = "显示图片";
			this.ShowButton.UseVisualStyleBackColor = true;
			this.ShowButton.Click += new System.EventHandler(this.button4_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			this.openFileDialog1.Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|All file" +
    "s (*.*)|*.*  ";
			this.openFileDialog1.Title = "选择一个图片文件";
			// 
			// Main_Form
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1117, 528);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "Main_Form";
			this.Text = "Main_Form";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.CheckBox checkBox_Stretch;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Button CloseButton;
		private System.Windows.Forms.Button BackgroundButton;
		private System.Windows.Forms.Button ClearButton;
		private System.Windows.Forms.Button ShowButton;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
	}
}