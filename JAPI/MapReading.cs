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
            colourlist[30] = MapReading.getClr(0, 255, 0); // old swamp
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
            colourlist[140] = MapReading.getClr(153, 255, 102); // some noob retard fag claimed this was changed from swamp color
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

        public static bool fileExists(string filePath)
        {
            if (File.Exists(Environment.ExpandEnvironmentVariables(filePath)))
            {
                return true;
            }
            return false;
        }

        public static Bitmap getMapFile(string fileName)
        {
            Bitmap bmp = new Bitmap(256, 256, System.Drawing.Imaging.PixelFormat.Format32bppArgb);;
            if (fileExists(fileName))
            {
                fillColourList();
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
            }
            else
            {
                Rectangle rect = new Rectangle();
                rect.Height = 256;
                rect.Width = 256;
                rect.X = 0;
                rect.Y = 0;
                Objects.Colour color = new Objects.Colour();
                color.r = 255;
                color.g = 255;
                color.b = 0;
                Graphics.FromImage(bmp).FillRectangle(new SolidBrush(Color.FromArgb(color.r, color.g, color.b)), rect);
            }
            return bmp;
        }

        public static Bitmap getMapSpeedFile(string fileName)
        { 
            Bitmap bmp = new Bitmap(256, 256, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            if (fileExists(fileName))
            {
                fillSpeedColourList();
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
            }
            return bmp;
        }

        public static StringBuilder[] getFileAroundMeNames(Objects.Location location)
        {
            // Format will be up, upri, ri, rido, do, dole, le, leup, self
            StringBuilder[] sbuild = new StringBuilder[9];
            StringBuilder sb = new StringBuilder();
            sb.Append("%APPDATA%\\Tibia\\Automap\\");

            for (int i = 0; i < 9; i++)
            {
                sbuild[i] = new StringBuilder();
            }

            // TL
            sb.Append(Convert.ToString(location.x / 256 -1)); sb.Append(Convert.ToString(location.y / 256 - 1)); // Set x + Y
            if (location.z < 10) { sb.Append("0"); } sb.Append(Convert.ToString(location.z)); // Set Z
            sb.Append(".map"); sbuild[0].Append(sb.ToString());
            sb.Clear(); // add extension, assign to array, clear
            sb.Append("%APPDATA%\\Tibia\\Automap\\"); // Refresh sb for next string

            // TM
            sb.Append(Convert.ToString(location.x / 256)); sb.Append(Convert.ToString(location.y / 256 - 1)); // Set x + Y
            if (location.z < 10) { sb.Append("0"); } sb.Append(Convert.ToString(location.z)); // Set Z
            sb.Append(".map"); sbuild[1].Append(sb.ToString());
            sb.Clear(); // add extension, assign to array, clear
            sb.Append("%APPDATA%\\Tibia\\Automap\\"); // Refresh sb for next string

            //TR
            sb.Append(Convert.ToString(location.x / 256 + 1)); sb.Append(Convert.ToString(location.y / 256 - 1)); // Set x + Y
            if (location.z < 10) { sb.Append("0"); } sb.Append(Convert.ToString(location.z)); // Set Z
            sb.Append(".map"); sbuild[2].Append(sb.ToString());
            sb.Clear(); // add extension, assign to array, clear
            sb.Append("%APPDATA%\\Tibia\\Automap\\"); // Refresh sb for next string

            // ML
            sb.Append(Convert.ToString(location.x / 256 - 1)); sb.Append(Convert.ToString(location.y / 256)); // Set x + Y
            if (location.z < 10) { sb.Append("0"); } sb.Append(Convert.ToString(location.z)); // Set Z
            sb.Append(".map"); sbuild[3].Append(sb.ToString());
            sb.Clear(); // add extension, assign to array, clear
            sb.Append("%APPDATA%\\Tibia\\Automap\\"); // Refresh sb for next string

            // MM
            sb.Append(Convert.ToString(location.x / 256)); sb.Append(Convert.ToString(location.y / 256)); // Set x + Y
            if (location.z < 10) { sb.Append("0"); } sb.Append(Convert.ToString(location.z)); // Set Z
            sb.Append(".map"); sbuild[4].Append(sb.ToString());
            sb.Clear(); // add extension, assign to array, clear
            sb.Append("%APPDATA%\\Tibia\\Automap\\"); // Refresh sb for next string

            // MR
            sb.Append(Convert.ToString(location.x / 256 + 1)); sb.Append(Convert.ToString(location.y / 256)); // Set x + Y
            if (location.z < 10) { sb.Append("0"); } sb.Append(Convert.ToString(location.z)); // Set Z
            sb.Append(".map"); sbuild[5].Append(sb.ToString());
            sb.Clear(); // add extension, assign to array, clear
            sb.Append("%APPDATA%\\Tibia\\Automap\\"); // Refresh sb for next string

            // BL
            sb.Append(Convert.ToString(location.x / 256 - 1)); sb.Append(Convert.ToString(location.y / 256 + 1)); // Set x + Y
            if (location.z < 10) { sb.Append("0"); } sb.Append(Convert.ToString(location.z)); // Set Z
            sb.Append(".map"); sbuild[6].Append(sb.ToString());
            sb.Clear(); // add extension, assign to array, clear
            sb.Append("%APPDATA%\\Tibia\\Automap\\"); // Refresh sb for next string

            // BM
            sb.Append(Convert.ToString(location.x / 256)); sb.Append(Convert.ToString(location.y / 256 + 1)); // Set x + Y
            if (location.z < 10) { sb.Append("0"); } sb.Append(Convert.ToString(location.z)); // Set Z
            sb.Append(".map"); sbuild[7].Append(sb.ToString());
            sb.Clear(); // add extension, assign to array, clear
            sb.Append("%APPDATA%\\Tibia\\Automap\\"); // Refresh sb for next string

            // BR
            sb.Append(Convert.ToString(location.x / 256 + 1)); sb.Append(Convert.ToString(location.y / 256 + 1)); // Set x + Y
            if (location.z < 10) { sb.Append("0"); } sb.Append(Convert.ToString(location.z)); // Set Z
            sb.Append(".map"); sbuild[8].Append(sb.ToString());
            sb.Clear(); // add extension, assign to array, clear


            return sbuild;
        }

        public static Bitmap getMapFileAroundMe(Objects.Location location)
        {
            fillColourList();
            // Format is up, upri, ri, rido, do, dole, le, leup, self
            StringBuilder[] sb = new StringBuilder[9];
            sb = getFileAroundMeNames(location);
            Bitmap[] bmpList = new Bitmap[9];
            Bitmap bmp = new Bitmap(256 * 3, 256 * 3, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Rectangle rect = new Rectangle();
            rect.Height = 256;
            rect.Width = 256;
            rect.X = 0;
            rect.Y = 0;
            Objects.Colour color = new Objects.Colour();
            color = colourlist[0];
            Graphics.FromImage(bmp).FillRectangle(new SolidBrush(Color.FromArgb(color.r, color.g, color.b)), rect);
            for (int i = 0; i < 9; i++)
            {
                string mapFileName = sb[i].ToString();
                bmpList[i] = getMapFile(mapFileName);
            }

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.DrawImage(bmpList[0], 0, 0, 256, 256); // TL
                g.DrawImage(bmpList[1], 256, 0, 256, 256); // TM
                g.DrawImage(bmpList[2], 512, 0, 256, 256); // TR
                g.DrawImage(bmpList[3], 0, 256, 256, 256); // ML
                g.DrawImage(bmpList[4], 256, 256, 256, 256); // MM
                g.DrawImage(bmpList[5], 512, 256, 256, 256); // MR
                g.DrawImage(bmpList[6], 0, 512, 256, 256); // BL
                g.DrawImage(bmpList[7], 256, 512, 256, 256); // BM
                g.DrawImage(bmpList[8], 512, 512, 256, 256); // BR
            }
            for (int i = 0; i < 9; i++)
            {
                string fileToSave = "C:\\Users\\Owner\\Documents\\MapFiles\\MapFile" + Convert.ToString(i) + ".bmp";
                //bmpList[i].Save(fileToSave);
            }

            return bmp;
        }

        public static Bitmap getMapSpeedFileAroundMe(Objects.Location location)
        {
            fillColourList();
            // Format is up, upri, ri, rido, do, dole, le, leup, self
            StringBuilder[] sb = new StringBuilder[9];
            sb = getFileAroundMeNames(location);
            Bitmap[] bmpList = new Bitmap[9];
            Bitmap bmp = new Bitmap(256 * 3, 256 * 3, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Rectangle rect = new Rectangle();
            rect.Height = 256;
            rect.Width = 256;
            rect.X = 0;
            rect.Y = 0;
            Objects.Colour color = new Objects.Colour();
            color = colourlist[0];
            Graphics.FromImage(bmp).FillRectangle(new SolidBrush(Color.FromArgb(color.r, color.g, color.b)), rect);
            for (int i = 0; i < 9; i++)
            {
                string mapFileName = sb[i].ToString();
                bmpList[i] = getMapSpeedFile(mapFileName);
            }

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.DrawImage(bmpList[0], 0, 0, 256, 256); // TL
                g.DrawImage(bmpList[1], 256, 0, 256, 256); // TM
                g.DrawImage(bmpList[2], 512, 0, 256, 256); // TR
                g.DrawImage(bmpList[3], 0, 256, 256, 256); // ML
                g.DrawImage(bmpList[4], 256, 256, 256, 256); // MM
                g.DrawImage(bmpList[5], 512, 256, 256, 256); // MR
                g.DrawImage(bmpList[6], 0, 512, 256, 256); // BL
                g.DrawImage(bmpList[7], 256, 512, 256, 256); // BM
                g.DrawImage(bmpList[8], 512, 512, 256, 256); // BR
            }
            for (int i = 0; i < 9; i++)
            {
                string fileToSave = "C:\\Users\\Owner\\Documents\\MapFiles\\MapFile" + Convert.ToString(i) + ".bmp";
                //bmpList[i].Save(fileToSave);
            }

            return bmp;
        }

        public static Objects.Location getFileCoordinates(string fileName)
        {
            if (fileExists(fileName))
            {
                Objects.Location pos = new Objects.Location();
                string[] PathSplit = fileName.Split('\\');
                string fName = PathSplit[PathSplit.Length - 1];
                char[] NameInChar = fName.ToCharArray();
                StringBuilder sb = new StringBuilder();
                sb.Append(NameInChar[0]);
                sb.Append(NameInChar[1]);
                sb.Append(NameInChar[2]);
                pos.x = Convert.ToInt32(sb.ToString()) * 256;
                sb.Clear();
                sb.Append(NameInChar[3]);
                sb.Append(NameInChar[4]);
                sb.Append(NameInChar[5]);
                pos.y = Convert.ToInt32(sb.ToString()) * 256; // LOL SPOTY!
                sb.Clear();
                sb.Append(NameInChar[6]);
                sb.Append(NameInChar[7]);
                pos.z = Convert.ToInt32(sb.ToString()); // LOL SPOTZ!
                sb.Clear();
                return pos;
            }
            else
            {
                return new Objects.Location();
            }
        }

        public static Objects.MiniMapTile[] getMapTiles(string fileName)
        {
            if (fileExists(fileName))
            {
                Objects.Location pos = getFileCoordinates(fileName);
                byte[] fileContents = ReadFile(Environment.ExpandEnvironmentVariables(fileName));
                int index = 0;
                Objects.MiniMapTile[] Tiles = new Objects.MiniMapTile[65536];
                for (int x = 0; x < 256; x++)
                {
                    for (int y = 0; y < 256; y++)
                    {
                        Tiles[index].color = fileContents[index];
                        Tiles[index].speed = fileContents[index + 65536];
                        Tiles[index].x = pos.x + x;
                        Tiles[index].y = pos.y + y;
                        Tiles[index].z = pos.z;
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
            else
            {
                return new Objects.MiniMapTile[0];
            }
        }
    }
}
