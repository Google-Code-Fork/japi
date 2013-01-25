﻿using System;
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
        public ClientChooser()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            foreach (Process p in Readar.getClients())
            {
                Readar.Tibia = p;
                Readar.BaseAddress = Convert.ToUInt32(p.MainModule.BaseAddress.ToInt32());
                listBox1.Items.Add(Readar.getMyName());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (Process p in Readar.getClients())
            {
                Readar.Tibia = p;
                Readar.BaseAddress = Convert.ToUInt32(p.MainModule.BaseAddress.ToInt32());
                listBox1.Items.Add(Readar.getMyName());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Client = selectClient();
        }

        private Process selectClient()
        {
            foreach (Process p in Readar.getClients())
            {
                Readar.Tibia = p;
                Readar.BaseAddress = Convert.ToUInt32(p.MainModule.BaseAddress.ToInt32());
                listBox1.Items.Add(Readar.getMyName());
                if (listBox1.SelectedItem.ToString() == Readar.getMyName())
                {
                    return p;
                }
            }
            return null;
        }
    }
}