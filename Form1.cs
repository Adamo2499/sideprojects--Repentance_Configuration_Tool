﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repentance_Configuration_Tool
{
    public partial class Form1 : Form
    {
        public string isaacLocation { get; set; }
        public string optionsLocation { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void setOptionsFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void setIsaacFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            openFileDialog1.OpenFile();
            textBox1.Text.Replace("Options folder not found", "Options folder found");
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            string isaacFullLocation = openFileDialog2.FileName;
            string isaacFileName = "\\isaac-ng.exe";
            int index = isaacFullLocation.IndexOf(isaacFileName);
            isaacLocation = isaacFullLocation.Replace(isaacFileName,"");
            textBox1.Text.Replace("Isaac folder not found", "Isaac folder found");
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(domainUpDown1.Text+" Numer indeksu: "+domainUpDown1.SelectedIndex);
            

        }
        private void disableAllModsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
        }
        private void enableAllModsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);
            }
        }

        private void inverseModsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if(checkedListBox1.GetItemChecked(i) == true)
                {
                    checkedListBox1.SetItemChecked(i, false);
                }
                else
                {
                    checkedListBox1.SetItemChecked(i, true);
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control && e.Shift && e.KeyCode.ToString().Equals("D"))
            {
                disableAllModsToolStripMenuItem_Click(sender, e);
            }
            else if(e.Control && e.Shift && e.KeyCode.ToString().Equals("E"))
            {
                enableAllModsToolStripMenuItem_Click(sender, e);
            }
            else if(e.Control && e.KeyCode.ToString().Equals("S"))
            {
              //save values to file
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label8.Text = "Music Volume: " + trackBar1.Value;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label9.Text = "SFX Volume: " + trackBar2.Value;
        }
        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            label10.Text = "Map Opacity: " + trackBar3.Value;
        }
        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            label11.Text = "Exposure: " + trackBar4.Value;
        }
        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            label12.Text = "Gamma: " + trackBar5.Value;
        }
        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            label13.Text = "HUD offset: " + trackBar6.Value;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string isaacExe = isaacLocation + "\\isaac-ng.exe";
            ProcessStartInfo startIsaac = new ProcessStartInfo();
            startIsaac.FileName = isaacExe;
            Process.Start(startIsaac);
        }
    }
}
