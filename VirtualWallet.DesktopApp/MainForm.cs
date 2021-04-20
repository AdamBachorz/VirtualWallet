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
using VirtualWallet.Model.Classes;
using VirtualWallet.DAL.Daos.Interfaces;
using System.Net;
using VirtualWallet.DesktopApp.Classes;

namespace VirtualWallet.DesktopApp
{
    public partial class MainForm : Form
    {
        private readonly IUserApiConsumer _userApiConsumer;

        public MainForm(IUserApiConsumer userApiConsumer)
        {
            InitializeComponent();

            _userApiConsumer = userApiConsumer;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var credential = new NetworkCredential("admin", "admintest");

            _userApiConsumer.SetAuthorization(credential);
            var t = _userApiConsumer.GetAll();
        }
    }
}
