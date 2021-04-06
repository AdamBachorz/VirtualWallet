using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualWallet.ApiConsumer.Interfaces;

namespace VirtualWallet.DesktopApp
{
    public partial class MainForm : Form
    {
        private readonly ITestEntityApiConsumer _testEntityApiConsumer;

        public MainForm(ITestEntityApiConsumer testEntityApiConsumer)
        {
            InitializeComponent();

            _testEntityApiConsumer = testEntityApiConsumer;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var t = _testEntityApiConsumer.GetTest();
        }
    }
}
