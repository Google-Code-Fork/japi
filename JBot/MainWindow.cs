using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace JBot
{
    public partial class MainWindow : Form
    {
        ReaderClass Read = new ReaderClass();
        ControlWindow Ctrl = new ControlWindow();
        Thread ticker;
        Thread healtick;
        Objects.HealRule[] rulelist;
        Objects.Player p;
        Objects.BList[] myBlist;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void setTibia(Process Tibia)
        {
            Util.Tibia = Tibia;
        }

        public void setDefaultValues()
        {
            textBox2.Text = Properties.Settings.Default.MinHp;
            textBox3.Text = Properties.Settings.Default.MaxHp;
            textBox4.Text = Properties.Settings.Default.MinMp;
            comboBox1.SelectedItem = Properties.Settings.Default.Hotkey;
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            setDefaultValues();
            setTibia(Read.getFirstClient());
            this.Text = Read.getMyName();
            ticker = new Thread(UpdateStats);
            ticker.IsBackground = true;
            ticker.Start();
        }
        
        private void addLocationButton_Click(object sender, EventArgs e)
        {
            LocationDisplay.Rows.Add(Convert.ToString(Read.X()), Convert.ToString(Read.Y()), Convert.ToString(Read.Z()));
        }

        private void updateBlistBtn_Click(object sender, EventArgs e)
        {
            blview.Rows.Clear();
            myBlist = Read.BlGet(true);
            foreach (Objects.BList creature in myBlist)
            {
                if (creature.Id != 0 && creature.Visible == 1)
                {
                    blview.Rows.Add(creature.Name, Convert.ToString(creature.Visible), Convert.ToString(creature.Id), Convert.ToString(creature.X), Convert.ToString(creature.Y), Convert.ToString(creature.Z), Convert.ToString(creature.Type));
                }
            }
        }

        private void sendStringBtn_Click(object sender, EventArgs e)
        {
            Ctrl.SendKeys(textBox1.Text);
        }

        public void UpdateStats()
        {
            while (true)
            {
                Objects.Player p = Read.GetPlayerInfo();
                HealthLabel.Text = "HP: " + Convert.ToString(p.Hp) + "/" + Convert.ToString(p.HpMax);
                ManaLabel.Text = "MP: " + Convert.ToString(p.Mp) + "/" + Convert.ToString(p.MpMax);
                /*this.Invoke((MethodInvoker)delegate {
                    this.Text = Read.getMyName();
                });*/ // Removed until I've found a way of checking the mainwindow status to make sure this property can be set.
                Thread.Sleep(1000);
            }
        }
        
        private void toolStripStopStartUpdate_Click(object sender, EventArgs e)
        {
            if (ticker.ThreadState == System.Threading.ThreadState.Background)
            {
                ticker.Abort();
                ticker.Join();
            }
            else
            {
                ticker = new Thread(UpdateStats);
                ticker.IsBackground = true;
                ticker.Start();
            }
        }

        private void sendUpWalkBtn_Click(object sender, EventArgs e)
        {
            Ctrl.SendButton("up");
        }

        private void sendRightWalkBtn_Click(object sender, EventArgs e)
        {
            Ctrl.SendButton("right");
        }

        private void sendDownWalkBtn_Click(object sender, EventArgs e)
        {
            Ctrl.SendButton("down");
        }

        private void sendLeftWalkBtn_Click(object sender, EventArgs e)
        {
            Ctrl.SendButton("left");
        }

        private void addHealRuleBtn_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox2.Text + "," + textBox3.Text + "," + textBox4.Text + "," + comboBox1.SelectedItem.ToString());

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
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
                healtick = new Thread(Healer);
                healtick.IsBackground = true;
                healtick.Start();
            }
            else
            {
                healtick.Abort();
            }
        }

        public void Healer()
        {
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

        private void removeHealRuleBtn_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                int i = listBox1.SelectedIndex;
                listBox1.SelectedItem = null;
                listBox1.Items.RemoveAt(i);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.MinHp = textBox2.Text;
            Properties.Settings.Default.Save();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.MaxHp = textBox3.Text;
            Properties.Settings.Default.Save();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.MinMp = textBox4.Text;
            Properties.Settings.Default.Save();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Hotkey = comboBox1.SelectedItem.ToString();
            Properties.Settings.Default.Save();
        }

        private void selectClientBtn_Click(object sender, EventArgs e)
        {
            ClientChooser myform = new ClientChooser();
            myform.Show();
        }
    }
}
