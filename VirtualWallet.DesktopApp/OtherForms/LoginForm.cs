using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Windows.Forms;
using VirtualWallet.ApiConsumer.Interfaces;
using VirtualWallet.DesktopApp.Classes;
using VirtualWallet.Common.Extensions;

namespace VirtualWallet.DesktopApp.OtherForms
{
    public partial class LoginForm : Form
    {
        private readonly IUserApiConsumer _userApiConsumer; 
        private readonly ISpendingApiConsumer _spendingApiConsumer;
        private readonly ISpendingGroupApiConsumer _spendingGroupApiConsumer;
        private readonly Action _onSuccessLogIn;
        private readonly Action _onSuccessSpendingGroupPick;

        public LoginForm(IUserApiConsumer userApiConsumer, ISpendingApiConsumer spendingApiConsumer, ISpendingGroupApiConsumer spendingGroupApiConsumer, 
            Action onSuccessLogIn, Action onSuccessSpendingGroupPick)
        {
            InitializeComponent();
            _userApiConsumer = userApiConsumer;
            _spendingApiConsumer = spendingApiConsumer;
            _spendingGroupApiConsumer = spendingGroupApiConsumer;
            _onSuccessLogIn = onSuccessLogIn;
            _onSuccessSpendingGroupPick = onSuccessSpendingGroupPick;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            var login = textBoxLogin.Text;
            SecureString password = null;
            unsafe
            {
                fixed (char* s = textBoxPassword.Text)
                {
                   password = new SecureString(s, textBoxPassword.Text.Length);  
                }
            }
            var credential = new NetworkCredential(login, password);

            _userApiConsumer.SetAuthorization(credential);
            var user = _userApiConsumer.GetByToken(credential.BuildBase64Token());

            if (user != null)
            {
                CommonPool.Credential = credential;
                CommonPool.CurrentUser = user;
                _onSuccessLogIn();

                _spendingGroupApiConsumer.SetAuthorization(CommonPool.Credential);
                var spengingGroups = _spendingGroupApiConsumer.GetForUser(CommonPool.CurrentUser.Id).ToList();

                var spendingGroupForm = new SpendingGroupForm(_spendingApiConsumer, spengingGroups, this, _onSuccessSpendingGroupPick);
                spendingGroupForm.Show();
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
