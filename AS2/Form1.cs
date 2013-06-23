using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AS2
{
    public partial class Form1 : Form
    {
        #region Vars
        private int _rows;
        private int _cols;
        private int _tilesize;
        int[,] _mapMatrix;
        PF2 pathFinder = new PF2();

        int startX, startY, endX, endY;
        #endregion
        public Form1()
        {
            InitializeComponent();

            InitialiseMap();
        }

        private void InitialiseMap()
        {
            // Configure our map so that we have some shit to draw by and we can change it "on the fly"
            _rows = 9;
            _cols = 9;
            _tilesize = 30; // The tile size is a pixel multiplier to determine the width of each tile
            _mapMatrix = new int[_rows, _cols]; // 1 = start, 2 = finish, 3 = wall, 4 = considered, 5 = path node
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawMap(e.Graphics);
        }

        private void DrawMap(Graphics g)
        {
            // For the X & Y coords of each tile in our map array (_rows, _cols), draw the outline of the tile
            for (int x = 0; x < _rows; x++)
            {
                for (int y = 0; y < _cols; y++)
                {
                    // Draw the rectangle.
                    g.DrawRectangle(new Pen(Brushes.Black), y * _tilesize, x * _tilesize, _tilesize, _tilesize);
                    // Switch the tiles value in the _mapMatrix and if it is a value which we believe to be a wall, start, finish, or map node, fill it
                    // Also once the tile is filled, we will mark it with the coordinates for the tile so it is easier to determine which is which
                    switch (_mapMatrix[x,y])
                    {
                        case 0:
                            g.DrawString(Convert.ToString(x) + "," + Convert.ToString(y), new Font(FontFamily.GenericSansSerif, _tilesize / 3),
                                Brushes.Black, new Point(x * _tilesize + 0, y * _tilesize + 0));
                            break;
                        case 1:
                            g.FillRectangle(Brushes.Green, y * _tilesize + 1, x * _tilesize + 1, _tilesize - 1, _tilesize - 1);
                            g.DrawString(Convert.ToString(x) + "," + Convert.ToString(y), new Font(FontFamily.GenericSansSerif, _tilesize / 3),
                            Brushes.Black, new Point(x * _tilesize + 0, y * _tilesize + 0));
                            break;
                        case 2:
                            g.FillRectangle(Brushes.Aquamarine, y * _tilesize + 1, x * _tilesize + 1, _tilesize - 1, _tilesize - 1);
                            g.DrawString(Convert.ToString(x) + "," + Convert.ToString(y), new Font(FontFamily.GenericSansSerif, _tilesize / 3),
                            Brushes.Black, new Point(x * _tilesize + 0, y * _tilesize + 0));
                            break;
                        case 3:
                            g.FillRectangle(Brushes.Red, y * _tilesize + 1, x * _tilesize + 1, _tilesize - 1, _tilesize - 1);
                            g.DrawString(Convert.ToString(x) + "," + Convert.ToString(y), new Font(FontFamily.GenericSansSerif, _tilesize / 3),
                            Brushes.Black, new Point(x * _tilesize + 0, y * _tilesize + 0));
                            break;
                        case 5:
                            g.FillRectangle(Brushes.DarkViolet, y * _tilesize + 1, x * _tilesize + 1, _tilesize - 1, _tilesize - 1);
                            g.DrawString(Convert.ToString(x) + "," + Convert.ToString(y), new Font(FontFamily.GenericSansSerif, _tilesize / 3),
                            Brushes.White, new Point(x * _tilesize + 0, y * _tilesize + 0));
                            break;
                    }
                }
            }
        }

        private void setStartFinish(int stx, int sty, int fnx, int fny)
        {
            try
            {
                startX = stx;
                startY = sty;
                endX = fnx;
                endY = fny;
                // Reset start and finish tiles
                for (int i = 0; i < _rows; i++)
                {
                    for (int j = 0; j < _cols; j++)
                    {
                        //if (_mapMatrix[i, j] == 1 || _mapMatrix[i, j] == 2)
                        //{
                            _mapMatrix[i, j] = 0;
                        //}
                    }
                }

                // Set start and finish tiles to values expected
                _mapMatrix[stx, sty] = 1;
                _mapMatrix[fnx, fny] = 2;
            }
            catch (Exception ex)
            {
                // This will only be thrown if it cannot draw the tiles, probably because they are OOB
                MessageBox.Show("Could not set start and end pos, check they are within the bounds of the map: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Set the start and finish in the array
            setStartFinish(Convert.ToInt32(sx.Text), Convert.ToInt32(sy.Text), Convert.ToInt32(fx.Text), Convert.ToInt32(fy.Text));
            // Refresh the GUI to force Draw function, as we cannot handle Graphics objects internally
            this.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Clear walls and force a redraw
            wallsList.Items.Clear();
            this.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Cycle through all walls in wall list, and for each wall set the value to 3, then force a redraw
            wallsList.Items.Add(wallx.Text + "," + wally.Text);
            foreach (string st in wallsList.Items)
            {
                string[] coords = st.Split(',');
                _mapMatrix[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1])] = 3;
                this.Refresh();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Structs.Node Start = new Structs.Node();
            Start.X = startX;
            Start.Y = startY;
            Structs.Node End = new Structs.Node();
            End.X = endX;
            End.Y = endY;
            List<Structs.Node> ClosedList = pathFinder.FindPath(Start, End, _mapMatrix);
            List<Structs.Node> Path = pathFinder.ReconstructPath(ClosedList, End, Start);
            pathList.Items.Add("Path:");
            foreach (Structs.Node nd in Path)
            {
                _mapMatrix[nd.X, nd.Y] = 5;
                this.Refresh();
                pathList.Items.Add(Convert.ToString(nd.ID) + ". Pos: " + Convert.ToString(nd.X) + ", " + Convert.ToString(nd.Y) + ". H: " + Convert.ToString(nd.heuristic) + ". PID: " + Convert.ToString(nd.parentID));
            }
            pathList.Items.Add("OpenList:");
            foreach (Structs.Node nd in ClosedList)
            {
                pathList.Items.Add(Convert.ToString(nd.ID) + ". Pos: " + Convert.ToString(nd.X) + ", " + Convert.ToString(nd.Y) + ". H: " + Convert.ToString(nd.heuristic) + ". PID: " + Convert.ToString(nd.parentID));
            }
        }
    }
}
