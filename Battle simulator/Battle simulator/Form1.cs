using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battle_simulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Engine.initgraf(pictureBox1);
            Engine.initdemo();
            Engine.DrawMap();
        }

        private void BtnBattle_Click(object sender, EventArgs e)
        {
            Engine.grp.Clear(Engine.backcolor);
            Engine.BattleCycle();
            Engine.DrawMap();
        }
    }
}
