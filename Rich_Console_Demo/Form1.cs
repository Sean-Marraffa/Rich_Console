using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rich_Console;

namespace Rich_Console_Demo
{
    public partial class Form1 : Form
    {
        RichConsole richConsole = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richConsole = new RichConsole(richTextBox1);
            Console.SetOut(richConsole);

            Console.WriteLine("Hello World!");
        }
    }
}
