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

namespace JBot
{
    public partial class Form1 : Form
    {
        Process p;
        ReaderClass Read = new ReaderClass();
        ControlWindow Ctrl = new ControlWindow();
        public Form1()
        {
            InitializeComponent();
        }

        public void setWindow(Process Tibia)
        {
            Read.Tibia = Tibia;
            Ctrl.Tibia = Tibia;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            setWindow(Read.getFirstClient());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HealthLabel.Text = "HP: " + Convert.ToString(Read.Hp()) + "/" + Convert.ToString(Read.MaxHp());
            ManaLabel.Text = "MP: " + Convert.ToString(Read.Mp()) + "/" + Convert.ToString(Read.MaxMp());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LocationDisplay.Rows.Add(Convert.ToString(Read.X()), Convert.ToString(Read.Y()), Convert.ToString(Read.Z()));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Objects.BList[] myBlist = Read.BlGet();
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
            foreach (char c in textBox1.Text)
            {
                int charValue = c;
                string hexValue = charValue.ToString("X");
                IntPtr val = new IntPtr(c);
                MessageBox.Show(Convert.ToString(val));
            }
            Ctrl.SendKeys(textBox1.Text);
        }

    }
}
