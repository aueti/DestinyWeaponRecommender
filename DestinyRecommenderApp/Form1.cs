using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DestinyRecommenderApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Test();
        }
        private async void Test()
        {
            AccessDestinyAPI api = new AccessDestinyAPI();

            richTextBox1.Text = await api.GetDestinyDataAsync() + " and " + await api.GetDestinyUserData();
        }
    }
}
