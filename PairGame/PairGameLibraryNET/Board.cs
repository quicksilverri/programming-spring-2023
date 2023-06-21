using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace PairGameLibraryNET
{
    public class Board
    {
        int left = 20;
        int top = 20; 

        int picWidth = 100;
        int picHeight = 100;

        public int tickBegin = 30;
        public int tickDelete = 1;
        public int tickClose = 15;

        public List<int> cardTypes = new List<int> { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
        public List<PictureBox> pictures = new List<PictureBox>();
        public Image back = Image.FromFile(Application.StartupPath + @"\pics\back.jpg");

        public ActionType action; 

        public List<PictureBox> LoadPictures()
        {
            int leftPos = left;
            int topPos = top;
            int counter = 0;

            List<PictureBox> boxes = new List<PictureBox>();

            for (int i = 0; i < 16; i++)
            {
                PictureBox newPic = CreateBox();
                pictures.Add(newPic);

                if (counter < 4)
                {
                    counter++;
                    newPic.Left = leftPos;
                    newPic.Top = topPos;
                    boxes.Add(newPic);
                    leftPos += (picWidth + 10);
                }

                if (counter == 4)
                {
                    leftPos = 20;
                    topPos += (picHeight + 10);
                    counter = 0;
                }
            }

            return boxes;
        }

        public PictureBox CreateBox()
        {
            PictureBox newPic = new PictureBox();
            newPic.Width = picWidth;
            newPic.Height = picHeight;
            newPic.SizeMode = PictureBoxSizeMode.StretchImage;
            newPic.BackColor = Color.Violet;
            newPic.Image = back;

            return newPic;
        }

    }
}
