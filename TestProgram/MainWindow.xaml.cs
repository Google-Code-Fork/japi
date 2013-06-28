using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Drawing;
using System.Drawing.Imaging;

using JAPI;
using System.IO;

namespace TestProgram
{
    public partial class MainWindow : Window
    {
        ReaderClass Read = new ReaderClass();
        ControlWindow Ctrl = new ControlWindow();
        Thread Updater;
        Thread Healer;
        Thread GUIThr;
        Thread ClientUp;
        Objects.HealRule[] rulelist;
        Objects.Hotkey[] HKS;
        Objects.Client[] ActiveClients;
        

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void UpdateStatus()
        {
            Objects.Player p = Read.GetPlayerInfo();
            //updateClients();
            this.Dispatcher.Invoke(delegate {
                this.Title = Read.getMyName();
                XpDisplay.Content = "Xp: " + Read.XpNextLevel() + " / " + Read.Exp();
                HpDisplay.Content = "Hp: " + p.Hp + " / " + Read.MaxHp();
                MpDisplay.Content = "Mp: " + p.Mp + " / " + Read.MaxMp();
                Level.Content = "Level: " + Read.Level();
                LastUsedDisplay.Content = "Last Used: " + Read.LastUsed();
                Util.Hotkeys = Read.getHotkeys();
            });
        }

        private void ErrorCheckChanged(object sender, RoutedEventArgs e)
        {
            if (chbErrors.IsChecked == true)
            {
                GUIThr = new Thread(GUIThrTick);
                GUIThr.IsBackground = true;
                GUIThr.Start();
            }
            else
            {
                GUIThr.Abort();
            }
        }

        private void ClientUpd()
        {
            ActiveClients = Read.getClientsWithNames();
            Thread.Sleep(2500); // Sleep for 2.5s to prevent extra CPU usage.
        }

        private void Startup(object sender, RoutedEventArgs e)
        {
            ClientUp = new Thread(ClientUpd);
            ClientUp.IsBackground = true;
            ClientUp.Start();
            Updater = new Thread(UpdateTick);
            Updater.IsBackground = true;
            if (Read.getClients().Length >= 1)
            {
                Util.Tibia = Read.getFirstClient();
                Updater.Start();
            }
            else
            {
                foreach (string dir in Directory.GetDirectories(Environment.ExpandEnvironmentVariables("%PROGRAMFILES%")))
                {
                    if (dir.Contains("Tibia") && File.Exists(dir + "\\Tibia.exe"))
                    {
                        if (Util.getFileVersion(Environment.ExpandEnvironmentVariables(dir + "\\Tibia.exe")) == Constants.ClientVersion)
                        {
                            System.Diagnostics.ProcessStartInfo PSI = new System.Diagnostics.ProcessStartInfo();
                            PSI.FileName = dir + "\\Tibia.exe";
                            PSI.WorkingDirectory = dir;
                            System.Diagnostics.Process.Start(PSI);
                            bool launched = false;
                            while (!launched)
                            {
                                if (Read.getClients().Length >= 1)
                                {
                                    Util.Tibia = Read.getFirstClient();
                                    Updater = new Thread(UpdateTick);
                                    Updater.IsBackground = true;
                                    Updater.Start();
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void GUIThrTick(object obj)
        {
            while (true)
            {
                this.Dispatcher.Invoke(delegate
                {
                    ErrorList.Items.Clear();
                    foreach (Objects.Error error in Util.Errors)
                    {
                        if (error.type >= lstErrorDisplay.SelectedIndex)
                        {
                            ErrorList.Items.Add(error.Message);
                        }
                    }
                });
                Thread.Sleep(2000);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Updater.ThreadState == System.Threading.ThreadState.Running)
                Updater.Abort();
        }

        private void updateClientList(object sender, RoutedEventArgs e)
        {
            updateClients();
        }

        private void updateClients()
        {
            this.Dispatcher.Invoke(delegate
            {
                clientList.Items.Clear();
                ActiveClients = Read.getClientsWithNames();
                foreach (Objects.Client cl in ActiveClients)
                {
                    clientList.Items.Add(Read.getNameConnectedToClient(cl.Process));
                }
            });
        }

        private void selectClient(object sender, RoutedEventArgs e)
        {
            if (clientList.Items.Count < 1)
            {
                MessageBox.Show("No clients found.");
            }
            else if (clientList.SelectedItem == null)
            {
                MessageBox.Show("No client selected.");
            }
            else
            {
                foreach (Objects.Client cl in ActiveClients)
                {
                    if (cl.Name == clientList.SelectedItem.ToString())
                    {
                        Util.Tibia = cl.Process;
                    }
                }
            }
        }

        private void UpdateTick()
        {
            while (true)
            {
                if (Util.Tibia.HasExited == true)
                {
                    this.Dispatcher.Invoke(delegate
                    {
                        this.Close();
                    });
                }
                else
                {
                    if (Read.Connected() == true)
                    {
                        UpdateStatus();
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        this.Dispatcher.Invoke(delegate
                        {
                            this.Title = "Disconnected";
                            XpDisplay.Content = "Xp: 0 / 0";
                            HpDisplay.Content = "Hp: 0 / 0";
                            MpDisplay.Content = "Mp: 0 / 0";
                            Level.Content = "Level: 0";
                            LastUsedDisplay.Content = "Last Used: 0";
                        });
                        Thread.Sleep(2000);
                    }
                }
            }
        }

        private void HealTick()
        {
            Objects.Player p;
            while (true)
            {
                p = Read.GetPlayerInfo();
                foreach (Objects.HealRule rule in rulelist)
                {
                    if (p.Hp < rule.MaxHp && p.Hp > rule.MinHp && rule.Mana <= p.Mp)
                    {
                        Ctrl.SendButton(rule.Hotkey);
                        Thread.Sleep(500);
                    }
                }
            }
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            int i = 0;
            rulelist = new Objects.HealRule[HealRuleList.Items.Count];
            foreach (string healrule in HealRuleList.Items)
            {
                string[] rules = healrule.Split(',');
                rulelist[i].MinHp = Convert.ToInt32(rules[0]);
                rulelist[i].MaxHp = Convert.ToInt32(rules[1]);
                rulelist[i].Mana = Convert.ToInt32(rules[2]);
                rulelist[i].Hotkey = rules[3];
                i++;
            }
            Healer = new Thread(HealTick);
            Healer.IsBackground = true;
            Healer.Start();
        }

        private void CheckBox_UnChecked_1(object sender, RoutedEventArgs e)
        {
            Healer.Abort();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            listBox2.Items.Add("Stand: " + Convert.ToString(Read.X()) + ", " + Convert.ToString(Read.Y()) + ", " + (Convert.ToString(Read.Z())));
        }

        private void LeftBtnClick(object sender, RoutedEventArgs e)
        {
            Ctrl.SendButton("left");
        }
        private void RightBtnClick(object sender, RoutedEventArgs e)
        {
            Ctrl.SendButton("right");
        }
        private void UpBtnClick(object sender, RoutedEventArgs e)
        {
            Ctrl.SendButton("up");
        }
        private void DownBtnClick(object sender, RoutedEventArgs e)
        {
            Ctrl.SendButton("down");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ContainerList.Items.Clear();
            ItemList.Items.Clear();
            Objects.Container[] conts = Read.getContainers();
            foreach (Objects.Container container in conts)
            {
                ContainerList.Items.Add("Container ID: " + Convert.ToString(container.Id) + " Open: " + Convert.ToString(container.IsOpen) + ". Container Name: " + container.Name + ". Volume: " + container.Volume);
                foreach (Objects.Item item in container.Items)
                {
                    if (item.Id != 0)
                    {
                        ItemList.Items.Add(Convert.ToString(item.Id) + ", " + Convert.ToString(item.StackCount));
                    }
                }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            StringBuilder SB = new StringBuilder();
            BListView.Items.Clear();
            Objects.BList[] Battles = Read.BlGet(false, false);
            foreach (Objects.BList Battle in Battles)
            {
                BListView.Items.Add("Name: " + Battle.Name +
                    ". CID: " + Battle.Id +
                    ". Type: " + Battle.Type +
                    ". Pos: " + Convert.ToString(Battle.X) +
                    ", " + Convert.ToString(Battle.Y) +
                    ", " + Convert.ToString(Battle.Z) +
                    ". TimeLastMoved: " + Convert.ToString(Battle.TimeLastMoved) + 
                    ". Walking: " + Convert.ToString(Battle.Walking) + 
                    ". Direction: " + Convert.ToString(Battle.Direction) + 
                    ". Previous: " + Convert.ToString(Battle.Previous) +
                    ". Next: " + Convert.ToString(Battle.Next) + 
                    ". Outfit: " + Convert.ToString(Battle.Outfit) +
                    ". Mount: " + Convert.ToString(Battle.MountId) +
                    ". BlackSquare: " + Convert.ToString(Battle.BlackSquare) +
                    ". HPPC: " + Convert.ToString(Battle.Hppc) + 
                    ". Speed: " + Convert.ToString(Battle.Speed) +
                    ". Skull: " + Convert.ToString(Battle.SkullType) + 
                    ". Party: " + Convert.ToString(Battle.Party) +
                    ". War: " + Convert.ToString(Battle.WarIcon) + 
                    ". Visible: " + Convert.ToString(Battle.Visible)
                    );
            }
        }

        private void ReadMap(object sender, RoutedEventArgs e)
        {
            MapView.Items.Clear();
            Objects.MapTile[] MapTiles = Read.getMap();
            foreach (Objects.MapTile Tile in MapTiles)
            {
                foreach (Objects.Item Item in Tile.Items)
                {
                    MapView.Items.Add(Convert.ToString(Item.Id));
                }
                
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            HealRuleList.Items.Add(MinHpBox.Text + "," + MaxHpBox.Text + "," + ManaBox.Text + "," + HotkeyBox.Text);
            if (checkBox1.IsChecked == true)
            {
                Healer.Abort();
                int i = 0;
                rulelist = new Objects.HealRule[HealRuleList.Items.Count];
                foreach (string healrule in HealRuleList.Items)
                {
                    string[] rules = healrule.Split(',');
                    rulelist[i].MinHp = Convert.ToInt32(rules[0]);
                    rulelist[i].MaxHp = Convert.ToInt32(rules[1]);
                    rulelist[i].Mana = Convert.ToInt32(rules[2]);
                    rulelist[i].Hotkey = rules[3];
                    i++;
                }
                Healer = new Thread(HealTick);
                Healer.IsBackground = true;
                Healer.Start();
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            HealRuleList.Items.RemoveAt(HealRuleList.SelectedIndex);
        }

        private void ReadMapImage(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("%APPDATA%\\Tibia\\Automap\\");
            sb.Append(Convert.ToString(Read.X() / 256));
            sb.Append(Convert.ToString(Read.Y() / 256));
            if (Read.Z() < 10)
            {
                sb.Append("0");
            }
            sb.Append(Convert.ToString(Read.Z()));
            sb.Append(".map");
            fileName.Text = sb.ToString();
            Image1.Source = loadBitmap(MapReading.getMapFile(sb.ToString()));
            Image2.Source = loadBitmap(MapReading.getMapSpeedFile(sb.ToString()));
        }

        public static BitmapSource loadBitmap(System.Drawing.Bitmap source)
        {
            return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(source.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty,
                System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
        }

        private void getTilesBtn_Click(object sender, RoutedEventArgs e)
        {
            listBox1.Items.Clear();
            Objects.MiniMapTile[] MapTiles = MapReading.getMapTiles(fileName.Text);
            foreach (Objects.MiniMapTile tile in MapTiles)
            {
                listBox1.Items.Add(Convert.ToString(tile.speed) + ", " + Convert.ToString(tile.color));
            }
        }

        private void getMyTilesBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("%APPDATA%\\Tibia\\Automap\\");
            sb.Append(Convert.ToString(Read.X() / 256));
            sb.Append(Convert.ToString(Read.Y() / 256));
            if (Read.Z() < 10)
            {
                sb.Append("0");
            }
            sb.Append(Convert.ToString(Read.Z()));
            sb.Append(".map");
            listBox1.Items.Clear();
            Objects.MiniMapTile[] MapTiles = MapReading.getMapTiles(sb.ToString());
            foreach (Objects.MiniMapTile tile in MapTiles)
            {
                listBox1.Items.Add(Convert.ToString(tile.speed) + ", " + Convert.ToString(tile.color) + " | Pos: " + Convert.ToString(tile.x) + ", " + Convert.ToString(tile.y) + ", " + Convert.ToString(tile.z) + ".");
            }
        }

        private void readLargeMapFile(object sender, RoutedEventArgs e)
        {            
            Objects.Location loc = new Objects.Location();
            loc.x = Read.X();
            loc.y = Read.Y();
            loc.z = Read.Z();
            LargeImage1.Source = loadBitmap(MapReading.getMapFileAroundMe(loc));
            LargeImage2.Source = loadBitmap(MapReading.getMapSpeedFileAroundMe(loc));
            MapReading.getMapSpeedFileAroundMe(loc).Save("SpeedFile.bmp");
            MapReading.getMapFileAroundMe(loc).Save("ColourFile.bmp");
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Image1.Source = loadBitmap(MapReading.getMapFile(fileName.Text));
            Image2.Source = loadBitmap(MapReading.getMapSpeedFile(fileName.Text));
        }

        public void UpdateHK(object sender, RoutedEventArgs e)
        {
            HKS = Read.getHotkeys();
            foreach (Objects.Hotkey hk in HKS)
            {
                HKLB.Items.Add(hk.Key + ": " + hk.Value);
            }
        }

        public void UpdateCurrentMessageDisplay(object sender, RoutedEventArgs e)
        {
            CurrentMessageDisplay.Content = Read.ReadTypedMessage();
        }
        public void UpdateSize(object sender, RoutedEventArgs e)
        {
            Objects.RECT WindowSize = Read.GetTibiaSize();
            SzBottom.Content = Convert.ToString(WindowSize.Bottom);
            SzRight.Content = Convert.ToString(WindowSize.Right);
            System.Drawing.Point pt = Read.GetWindowTopLeft();
            SzX.Content = Convert.ToString(pt.X);
            SzY.Content = Convert.ToString(pt.Y);
            SzWidth.Content = Convert.ToString(Read.ReadWorldWinWidth());
            SzHeight.Content = Convert.ToString(Read.ReadWorldWinHeight());
            FromLeft.Content = Convert.ToString(Read.ReadWorldFromLeft());
        }

        private void SendClick(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Drawing.Point pt = new System.Drawing.Point();
                pt.X = Convert.ToInt32(XClick.Text);
                pt.Y = Convert.ToInt32(YClick.Text);
                Ctrl.LeftClick(pt);
            }
            catch (Exception ex)
            {
                Util.LogError("Error sending click : " + ex.Message, 3);
            }
        }
    }
}
