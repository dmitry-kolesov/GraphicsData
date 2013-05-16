using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GraphicsData
{
    public partial class Form1 : Form
    {
        Data data = new Data();
        IOFile fileReader = new IOFile();

        int from = 0;

        public Form1()
        {
            InitializeComponent();
            trackBar1.Scroll += new EventHandler(trackBar1_Scroll);
            label1.Text = "From: " + trackBar1.Value.ToString();
            trackBar1.Enabled = false;
            getGraphicButton.Enabled = false;
            buttonNext.Enabled = false;
            buttonPrevious.Enabled = false;
            
        }


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openDatFileDialog.ShowDialog() == DialogResult.OK)
            {
                data = new Data();
                int res = fileReader.Read(openDatFileDialog.FileName, data);
                trackBar1.Maximum = (data.X.Count * 3) / 100 + 1;

                if (res == 0)
                {
                    trackBar1.Enabled = true;
                    getGraphicButton.Enabled = true;
                    buttonNext.Enabled = true;
                    buttonPrevious.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Data file doesnt exist or wrong data file, please select other file with data in well format");
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }

        private void getGraphicButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataGraphic dg = new DataGraphic(data, graphPictureBox, from);
                dg.Draw(from, from + 100);
            }
            catch (Exception ex)
            {

            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            from += 10;
            if (from + 100 > data.X.Count)
                from = data.X.Count - 100;
            try
            {

                DataGraphic dg = new DataGraphic(data, graphPictureBox, from);
                dg.Draw(from, from + 100);
            }
            catch (Exception ex)
            {

            }
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            from -= 10;
            if (from < 0)
                from = 0;
            try
            {
                DataGraphic dg = new DataGraphic(data, graphPictureBox, from);
                dg.Draw(from, from + 100);
            }
            catch (Exception ex)
            {

            }

        }

        void trackBar1_Scroll(object sender, EventArgs e)
        {
            from = data.X.Count / trackBar1.Maximum * trackBar1.Value;

            label1.Text = "From: " + from.ToString();
            //if (from + 100 > data.X.Count)
            //    from = data.X.Count - 100;
            try
            {
                DataGraphic dg = new DataGraphic(data, graphPictureBox, from);
                dg.Draw(from, from + 100);
            }
            catch (Exception ex)
            {

            }
        }
    }
}