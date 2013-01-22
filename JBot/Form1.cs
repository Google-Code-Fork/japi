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
        public Form1()
        {
            InitializeComponent();
        }

        public void setTibia(Process Tibia)
        {
            Read.Tibia = Tibia;
            Ctrl.Tibia = Tibia;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            setTibia(Read.getFirstClient());
            this.Text = Read.getMyName();
            ticker = new Thread(UpdateStats);
            ticker.IsBackground = true;
            ticker.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Objects.Player p = Read.GetPlayerInfo();
            HealthLabel.Text = "HP: " + Convert.ToString(p.Hp) + "/" + Convert.ToString(p.HpMax);
            ManaLabel.Text = "MP: " + Convert.ToString(p.Mp) + "/" + Convert.ToString(p.MpMax);
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

        private void button5_Click(object sender, EventArgs e)
        {
            Thread ticker = new Thread(UpdateStats);
            ticker.Start();
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Unchecked)
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

    }
}
