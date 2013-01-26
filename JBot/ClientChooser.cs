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
    public partial class ClientChooser : Form
    {
        Process Client;
        ReaderClass Readar = new ReaderClass();
        public event System.EventHandler CChange;
        public ClientChooser()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            foreach (Process p in Readar.getClients())
            {
                Util.Tibia = p;
                Util.Base = Convert.ToUInt32(p.MainModule.BaseAddress.ToInt32());
                listBox1.Items.Add(Readar.getMyName());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (Process p in Readar.getClients())
            {
                Util.Tibia = p;
                Util.Base = Convert.ToUInt32(p.MainModule.BaseAddress.ToInt32());
                listBox1.Items.Add(Readar.getMyName());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Client = selectClient();
            
            this.Dispose();
        }

        private Process selectClient()
        {
            foreach (Process p in Readar.getClients())
            {
                Util.Tibia = p;
                Util.Base = Convert.ToUInt32(p.MainModule.BaseAddress.ToInt32());
                if (listBox1.SelectedItem.ToString() == Readar.getMyName())
                {
                    return p;
                }
            }
            return null;
        }

        
    }
}
