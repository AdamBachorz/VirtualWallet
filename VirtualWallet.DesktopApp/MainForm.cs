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
using VirtualWallet.Model.Domain;

namespace VirtualWallet.DesktopApp
{
    public partial class MainForm : Form
    {
        private readonly ISpendingGroupApiConsumer _spendingGroupApiConsumer;

        public MainForm(ISpendingGroupApiConsumer spendingGroupApiConsumer)
        {
            InitializeComponent();

            _spendingGroupApiConsumer = spendingGroupApiConsumer;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var t = _spendingGroupApiConsumer.GetAll();

        }
    }
}
