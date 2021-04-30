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
using VirtualWallet.DesktopApp.OtherForms;
using VirtualWallet.DesktopApp.Views;

namespace VirtualWallet.DesktopApp
{
    public partial class MainForm : Form
    {
        private readonly IUserApiConsumer _userApiConsumer;
        private readonly ISpendingApiConsumer _spendingApiConsumer;
        private readonly ISpendingGroupApiConsumer _spendingGroupApiConsumer;

        public MainForm(IUserApiConsumer userApiConsumer, ISpendingApiConsumer spendingApiConsumer, 
            ISpendingGroupApiConsumer spendingGroupApiConsumer)
        {
            InitializeComponent();

            _userApiConsumer = userApiConsumer;
            _spendingApiConsumer = spendingApiConsumer;
            _spendingGroupApiConsumer = spendingGroupApiConsumer;
        }

        private void UpdateControls()
        {
            if (CommonPool.UserIsLoggedIn)
            {
                labelHello.Visible = true;
                labelHello.Text = CommonPool.CurrentUser.Greeting;
                buttonLogOut.Visible = true;
                buttonLogIn.Visible = false;

                _spendingApiConsumer.SetAuthorization(CommonPool.Credential);
            }
            else
            {
                labelHello.Visible = false;
                labelHello.Text = string.Empty;
                buttonLogOut.Visible = false;
                buttonLogIn.Visible = true;
                flowLayoutPanel1.Controls.Clear();
            }
        }

        private void UpdateSpendingTable()
        {

            var spendingViews = CommonPool.MonthlySpending.Spendings.Select(s => new SpendingView(s, _spendingApiConsumer));

            flowLayoutPanel1.Controls.AddRange(spendingViews.ToArray());

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            var loginForm = new LoginForm(_userApiConsumer, _spendingApiConsumer, _spendingGroupApiConsumer, () => UpdateControls(), () => UpdateSpendingTable());
            loginForm.Show();
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            _userApiConsumer.SetAuthorization(null);
            CommonPool.DisposeUser();
            UpdateControls();
        }
    }
}
