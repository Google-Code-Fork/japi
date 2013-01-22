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
    public partial class Form1 : Form
    {
        ReaderClass Read = new ReaderClass();
        ControlWindow Ctrl = new ControlWindow();
        Thread ticker;
        Thread healtick;
        Objects.HealRule[] rulelist;
        Objects.Player p;
        public Form1()
        {
            InitializeComponent();
        }

        public void setTibia(Process Tibia)
        {
            Read.Tibia = Tibia;
            Read.BaseAddress = Convert.ToUInt32(Tibia.MainModule.BaseAddress.ToInt32());
            Ctrl.Tibia = Tibia;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            setTibia(Read.getFirstClient());
            this.Text = Read.getMyName();
            ticker = new Thread(UpdateStats);
            ticker.IsBackground = true;
            ticker.Start();
            comboBox1.SelectedIndex = 0;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            LocationDisplay.Rows.Add(Convert.ToString(Read.X()), Convert.ToString(Read.Y()), Convert.ToString(Read.Z()));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Objects.BList[] myBlist = Read.BlGet(true);
            foreach (Objects.BList creature in myBlist)
            {
                if (creature.Id != 0 && creature.Visible == 1)
                {
                    blview.Rows.Add(creature.Name, Convert.ToString(creature.Visible), Convert.ToString(creature.Id), Convert.ToString(creature.X), Convert.ToString(creature.Y), Convert.ToString(creature.Z), Convert.ToString(creature.Type));
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
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
            }
        }


        private void toolStripDropDownButton1_ButtonClick(object sender, EventArgs e)
        {
            if (ticker.ThreadState == System.Threading.ThreadState.Background)
            {
                ticker.Abort();
            }
            else
            {
                ticker = new Thread(UpdateStats);
                ticker.IsBackground = true;
                ticker.Start();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ctrl.SendArrow("up");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Ctrl.SendArrow("right");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Ctrl.SendArrow("down");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Ctrl.SendArrow("left");
        }

        private void button8_Click(object sender, EventArgs e)
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
                string mybananas = "";
                foreach (Objects.HealRule rule in rulelist)
                //{
                    //mybananas = mybananas + "HK: " + rule.Hotkey + ", Mana: " + Convert.ToString(rule.Mana) + ", MinHealth: " + Convert.ToString(rule.MinHp) + ", MaxHealth" + Convert.ToString(rule.MaxHp) + "\n";
                //}

                MessageBox.Show(mybananas);
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
                        Ctrl.SendHotkey(rule.Hotkey);
                        Thread.Sleep(200);
                    }
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                int i = listBox1.SelectedIndex;
                listBox1.SelectedItem = null;
                listBox1.Items.RemoveAt(i);
            }
        }
    }
}
