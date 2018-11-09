namespace WindowsFormsApp1
{
	partial class About_AiR
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
			this.CloseButton = new System.Windows.Forms.Button();
			this.Project = new System.Windows.Forms.Label();
			this.Version = new System.Windows.Forms.Label();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 91.2654F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.734603F));
			this.tableLayoutPanel1.Controls.Add(this.CloseButton, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.Project, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.Version, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.710744F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.28925F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(893, 520);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// CloseButton
			// 
			this.CloseButton.Dock = System.Windows.Forms.DockStyle.Right;
			this.CloseButton.Location = new System.Drawing.Point(817, 487);
			this.CloseButton.Name = "CloseButton";
			this.CloseButton.Size = new System.Drawing.Size(73, 30);
			this.CloseButton.TabIndex = 1;
			this.CloseButton.Text = "OK";
			this.CloseButton.UseVisualStyleBackColor = true;
			this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
			// 
			// Project
			// 
			this.Project.AutoSize = true;
			this.Project.Dock = System.Windows.Forms.DockStyle.Left;
			this.Project.Location = new System.Drawing.Point(3, 0);
			this.Project.Name = "Project";
			this.Project.Size = new System.Drawing.Size(83, 47);
			this.Project.TabIndex = 2;
			this.Project.Text = "Project : AiR";
			// 
			// Version
			// 
			this.Version.AutoSize = true;
			this.Version.Dock = System.Windows.Forms.DockStyle.Left;
			this.Version.Location = new System.Drawing.Point(3, 47);
			this.Version.Name = "Version";
			this.Version.Size = new System.Drawing.Size(149, 437);
			this.Version.TabIndex = 3;
			this.Version.Text = "Version : 3.0.0 GUI BETA";
			// 
			// About_AiR
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(893, 520);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "About_AiR";
			this.Text = "About_AiR";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Button CloseButton;
		private System.Windows.Forms.Label Project;
		private System.Windows.Forms.Label Version;
	}
}