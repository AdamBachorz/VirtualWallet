using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;
using VirtualWallet.ApiConsumer.Interfaces;
using VirtualWallet.DesktopApp.Classes;

namespace VirtualWallet.DesktopApp.OtherForms
{
    public partial class LoginForm : Form
    {
        private readonly IUserApiConsumer _userApiConsumer;
        private readonly Action _onSuccessLogIn;

        public LoginForm(IUserApiConsumer userApiConsumer, Action onSuccessLogIn)
        {
            InitializeComponent();
            _userApiConsumer = userApiConsumer;
            _onSuccessLogIn = onSuccessLogIn;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            var login = textBoxLogin.Text;
            var password = textBoxPassword.Text;
            var credential = new NetworkCredential(login, password);

            _userApiConsumer.SetAuthorization(credential);
            var user = _userApiConsumer.GetByCredentials(login, password);

            if (user != null)
            {
                CommonPool.Credential = credential;
                CommonPool.CurrentUser = user;
                _onSuccessLogIn();
                Dispose();
            }
            else
            {
                MessageBox.Show("Błędny login lub hasło");
            }

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
