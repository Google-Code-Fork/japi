using System;
using System.Collections.Generic;
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

using JAPI;

namespace TestProgram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ReaderClass Read = new ReaderClass();
        ControlWindow Ctrl = new ControlWindow();
        Thread Updater;
        Thread Healer;
        Objects.HealRule[] rulelist;
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void UpdateStatus()
        {
            this.Dispatcher.Invoke(delegate {
                this.Title = Read.getMyName();
                XpDisplay.Content = "Xp: " + Read.Exp();
                HpDisplay.Content = "Hp: " + Read.Hp();
                MpDisplay.Content = "Mp: " + Read.Mp();
            });

        }

        private void Startup(object sender, RoutedEventArgs e)
        {
            Util.Tibia = Read.getFirstClient();
            UpdateStatus();
            Updater = new Thread(UpdateTick);
            Updater.Start();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Updater.Abort();
        }

        private void UpdateTick()
        {
            while (true)
            {
                UpdateStatus();
                Thread.Sleep(500);
            }
        }

        private void HealTick()
        {
            /*while (true)
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
            }*/
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            if (checkBox1.IsChecked == true)
            {
                int i = 0;
                rulelist = new Objects.HealRule[listBox1.Items.Count];
                foreach (string healrule in listBox1.Items)
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
            else
            {
                Healer.Abort();
            }
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
    }
}
