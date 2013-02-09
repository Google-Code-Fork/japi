using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Windows;

namespace JAPI
{
    public class MapReading
    {
        public static Objects.Colour[] colourlist;
        public static Objects.Colour[] speedcolourlist;
        public static void fillColourList()
        {
            colourlist = new Objects.Colour[256];
            colourlist[0] = MapReading.getClr(0, 0, 0); // Undiscovered / tar / void / inner cave walls
            colourlist[12] = MapReading.getClr(0, 102, 0); // tree / bush
            colourlist[24] = MapReading.getClr(0, 204, 0); // grass or stone ground
            colourlist[30] = MapReading.getClr(0, 255, 0); // swamp
            colourlist[40] = MapReading.getClr(51, 0, 204); // water
            colourlist[86] = MapReading.getClr(102, 102, 102); // mountain / rock
            colourlist[114] = MapReading.getClr(153, 51, 0); // cave wall
            colourlist[121] = MapReading.getClr(153, 102, 51); // cave mud
            colourlist[129] = MapReading.getClr(153, 153, 153); // normal floor / path
            colourlist[179] = MapReading.getClr(204, 255, 255); // ice wall
            colourlist[186] = MapReading.getClr(255, 51, 0); // wall
            colourlist[192] = MapReading.getClr(255, 102, 0); // lava
            colourlist[207] = MapReading.getClr(255, 204, 153); // sand
            colourlist[210] = MapReading.getClr(255, 255, 0); // portal (or stairs etc)
            colourlist[215] = MapReading.getClr(255, 255, 255); // snow
            colourlist[255] = MapReading.getClr(150, 0, 255); // unknown but appeared once apparently
        }

        public static void fillSpeedColourList()
        {
            speedcolourlist = new Objects.Colour[256];
            for (int i = 0; i < 256; i++)
            {
                speedcolourlist[i] = getClr(i, i, i);
            }

        }

        public static Objects.Colour getClr(int r, int g, int b)
        {
            Objects.Colour Clr = new Objects.Colour();
            Clr.r = r;
            Clr.g = g;
            Clr.b = b;
            return Clr;
        }

        public static byte[] ReadFile(string filePath)
        {
            byte[] buffer;
            using (FileStream fileStream = new FileStream(Environment.ExpandEnvironmentVariables(filePath), FileMode.Open, FileAccess.Read))
            {
                int length = (int)fileStream.Length;  // get file length
                buffer = new byte[length];            // create buffer
                int count;                            // actual number of bytes read
                int sum = 0;                          // total number of bytes read

                // read until Read method returns 0 (end of the stream has been reached)
                while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
                    sum += count;  // sum is a buffer offset for next reading
            }
            return buffer;
        }
        public static Bitmap getMapFile(string fileName)
        {
            fillColourList();
            Bitmap bmp = new Bitmap(256, 256, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            byte[] fileContents = ReadFile(Environment.ExpandEnvironmentVariables(fileName));
            int index = 0;
            Rectangle rect = new Rectangle();
            rect.Height = 256;
            rect.Width = 256;
            rect.X = 0;
            rect.Y = 0;
            Objects.Colour color = new Objects.Colour();
            color = colourlist[0];
            Graphics.FromImage(bmp).FillRectangle(new SolidBrush(Color.FromArgb(color.r, color.g, color.b)), rect);
            for (int x = 0; x < 256; x++)
            {
                for (int y = 0; y < 256; y++)
                {
                    Objects.Colour clr;
                    clr = MapReading.colourlist[fileContents[index]];
                    if (!(clr.r == color.r && clr.g == color.g && clr.b == color.b))
                    {
                        bmp.SetPixel(x, y, System.Drawing.Color.FromArgb((byte)255, (byte)clr.r, (byte)clr.g, (byte)clr.b));
                    }
                    index++;
                }
            }
            return bmp;
        }

        public static Bitmap getMapSpeedFile(string fileName)
        {
            fillSpeedColourList();
            Bitmap bmp = new Bitmap(256, 256, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            byte[] fileContents = ReadFile(Environment.ExpandEnvironmentVariables(fileName));
            int index = 256 * 256;
            Rectangle rect = new Rectangle();
            rect.Height = 256;
            rect.Width = 256;
            rect.X = 0;
            rect.Y = 0;
            Objects.Colour color = new Objects.Colour();
            color = colourlist[0];
            Graphics.FromImage(bmp).FillRectangle(new SolidBrush(Color.FromArgb(color.r, color.g, color.b)), rect);
            for (int x = 0; x < 256; x++)
            {
                for (int y = 0; y < 256; y++)
                {
                    Objects.Colour clr;
                    clr = speedcolourlist[fileContents[index]];
                    if (!(clr.r == color.r && clr.g == color.g && clr.b == color.b))
                    {
                        bmp.SetPixel(x, y, System.Drawing.Color.FromArgb((byte)255, (byte)clr.r, (byte)clr.g, (byte)clr.b));
                    }
                    index++;
                }
            }
            return bmp;
        }

        public static Objects.MiniMapTile[] getMapTiles(string fileName)
        {
            string[] PathSplit = fileName.Split('\\');
            string fName = PathSplit[PathSplit.Length - 1];
            char[] NameInChar = fName.ToCharArray();
            StringBuilder sb = new StringBuilder();
            sb.Append(NameInChar[0] + NameInChar[1] + NameInChar[2]);
            int spotx = Convert.ToInt32(sb.ToString()) * 256;
            sb.Clear();
            sb.Append(NameInChar[3] + NameInChar[4] + NameInChar[5]);
            int spoty = Convert.ToInt32(sb.ToString()) * 256; // LOL SPOTY!
            sb.Clear();
            sb.Append(NameInChar[6] + NameInChar[7]);
            int spotz = Convert.ToInt32(sb.ToString()); // LOL SPOTZ!
            sb.Clear();
            byte[] fileContents = ReadFile(Environment.ExpandEnvironmentVariables(fileName));
            int index = 0;
            Objects.MiniMapTile[] Tiles = new Objects.MiniMapTile[65536];
            for (int x = 0; x < 256; x++)
            {
                for (int y = 0; y < 256; y++)
                {
                    Tiles[index].color = fileContents[index];
                    Tiles[index].speed = fileContents[index + 65536];
                    Tiles[index].x = spotx + x;
                    Tiles[index].y = spoty + y;
                    Tiles[index].z = spotz;
                    Tiles[index].walkable = false;
                    if (fileContents[index + 65536] != 255)
                    {
                        Tiles[index].walkable = true;
                    }
                    Tiles[index].fishable = false;
                    if (fileContents[index] == 40)
                    {
                        Tiles[index].fishable = true;
                    }
                    index++;
                }
            }
            return Tiles;
        }
    }
}
