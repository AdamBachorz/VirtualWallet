using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VirtualWallet.Model.Domain;

namespace VirtualWallet.DesktopApp.Views
{
    public partial class SpendingView : UserControl
    {
        private readonly Spending _spending;
        //private readonly ISpendingApiConsumer _spendingApiConsumer;
        public SpendingView(Spending spending)
        {
            InitializeComponent();
            _spending = spending;

            labelName.Text = _spending.Name;
            labelValue.Text = _spending.Value.ToString();
            labelCreationDate.Text = _spending.CreationDate.ToString();
            labelUser.Text = _spending.User.UserName;

            //var contextMenu = new ContextMenu();
            //contextMenu.MenuItems.Add(new MenuItem("", new EventHandler(EditItem_Opening)));
            
            
        }


    }
}
