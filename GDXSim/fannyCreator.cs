using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDXSim
{
    public partial class ExponentialForm
    {
        List<PictureBox> fannys = new List<PictureBox>();

        public void createfannys(int fannyNum)
        {
            
            //panel1.Controls.Clear();
            fannys.Clear();
            int yMod = 0;
            int xMod = 0;
            int sizeMod = 30;
           
            // int yBounds = 390; 
            if (fannyNum > 2090)
            {
                sizeMod = sizeMod / 5;
            }
            else if (fannyNum > 468)
            {
                sizeMod = sizeMod / 4;
            }
            else if (fannyNum > 117)
            {
                sizeMod = sizeMod / 2;
            }

            int xLocation = 0;
            for (int j = 0; j < fannyNum; j++)
            {





                if (xMod == 270 / sizeMod)
                {
                    yMod++;
                    xMod = 0;
                }

                xLocation = sizeMod * xMod;
                int yLocation = sizeMod * yMod;
                /*if (j % 9 == 0)
                {
                    yLocation = sizeMod * (j / 9);
                }*/
                /*if (fannyNum > 117)
                {
                    sizeMod = sizeMod / 2;
                }*/
                // 9 fannys across at 30x30
                // 13 fannys down

                PictureBox pictureBox = new System.Windows.Forms.PictureBox();
                fannys.Add(pictureBox);

                pictureBox.Size = new System.Drawing.Size(sizeMod, sizeMod);

                pictureBox.Location = new Point(xLocation, yLocation);

                pictureBox.Name = "fanny" + fannyNum;

                pictureBox.TabIndex = 0;
                pictureBox.TabStop = false;
                pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
                pictureBox.Parent = panel1;
                pictureBox.Image = global::GDXSim.Properties.Resources.fanny_left;
                xMod++;
            }
        }
    }
}

