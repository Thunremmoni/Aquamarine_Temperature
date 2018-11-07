using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public partial class Main_Form : Form
	{
		public Main_Form()
		{
			InitializeComponent();
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (colorDialog1.ShowDialog() == DialogResult.OK)
				pictureBox1.BackColor = colorDialog1.Color;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			pictureBox1.Image = null;
		}

		private void button4_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
				pictureBox1.Load(openFileDialog1.FileName);
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox_Stretch.Checked)
				pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
			else
				pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
		}
	}
}
