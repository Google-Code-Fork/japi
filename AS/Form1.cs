using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AS
{
    public partial class Form1 : Form
    {
        public int sq = 25;
        public Bitmap image = new Bitmap(250,250,System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        Objects.Tile[,] map = new Objects.Tile[10,10];
        int xstart = 1, ystart = 4;
        int xend = 7, yend = 4;
        int[] wallx = new int[4];
        int[] wally = new int[4];

        public void setWalls()
        {/*
            wallx[0] = 4;
            wally[0] = 2;
            wallx[1] = 4;
            wally[1] = 3;
            wallx[2] = 4;
            wally[2] = 4;
            wallx[3] = 4;
            wally[3] = 5;
            wallx[4] = 4;
            wally[4] = 6;*/
        }

        public void setMap()
        {
            setWalls();
        }
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            setMap();
            GenerateImage();
            updateImage();
        }

        public void setPixel(int chunkx, int chunky, Color clr)
        {
            int startx = chunkx * sq;
            int starty = chunky * sq;
            int endx = startx + sq;
            int endy = starty + sq;
            for (int x = startx; x < endx; x++)
            {
                for (int y = starty; y < endy; y++)
                {
                    if (x == startx)
                        image.SetPixel(x, y, Color.White);
                    else if (x == endx)
                        image.SetPixel(x, y, Color.White);
                    else if (y == starty)
                        image.SetPixel(x, y, Color.White);
                    else if (y == endy)
                        image.SetPixel(x, y, Color.White);
                    else
                        image.SetPixel(x, y, clr);
                }
            }
        }

        private void GenerateImage()
        {
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    setPixel(x, y, Color.Purple);
                }
            }
            // setPixel(0, 0, Color.Blue); // Set a path node 
            setPixel(4, 2, Color.Black);
            setPixel(4, 3, Color.Black);
            setPixel(4, 4, Color.Black);
            setPixel(4, 5, Color.Black);
            setPixel(4, 6, Color.Black);
            setPixel(7, 4, Color.Red);
            setPixel(1, 4, Color.Green);   
        }

        private void updateImage()
        {
            ImageLoader.Image = image;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    class Objects
    {
        public struct Tile
        {
            int id;
            int x;
            int y;
            int speed;
            int walkable;
            int parentID;
        }
    }
}