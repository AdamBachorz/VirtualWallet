using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VirtualWallet.ApiConsumer.Interfaces;
using VirtualWallet.DesktopApp.Classes;
using VirtualWallet.Model.Domain;

namespace VirtualWallet.DesktopApp.Views
{
    public partial class SpendingView : UserControl
    {
        private readonly Spending _spending;
        private readonly ISpendingApiConsumer _spendingApiConsumer;
        public SpendingView(Spending spending, ISpendingApiConsumer spendingApiConsumer)
        {
            InitializeComponent();
            _spending = spending;
            _spendingApiConsumer = spendingApiConsumer;

            labelName.Text = _spending.Name;
            labelValue.Text = _spending.Value.ToString();
            labelCreationDate.Text = _spending.CreationDate.ToString();
            labelUser.Text = _spending.User.UserName;

            //var contextMenu = new ContextMenu();
            //contextMenu.MenuItems.Add(new MenuItem("", new EventHandler(EditItem_Opening)));


        }

        private void labelName_Click(object sender, EventArgs e)
        {
            // Enable text editing
            labelName.Visible = false;

            var oldText = labelName.Text;

            textBoxName.Visible = true;
            textBoxName.Text = oldText;
            textBoxName.Focus();
            SendKeys.Send("{RIGHT}");
        }

        private void textBoxName_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    // Getting old and new text
                    var oldText = labelName.Text;
                    var newText = textBoxName.Text;

                    if (oldText == newText)
                    {
                        BringBack(labelName, textBoxName);
                        return;
                    }

                    try
                    {
                        _spending.Name = newText;
                        _spendingApiConsumer.Update(_spending);
                        labelName.Text = newText;
                    }
                    catch (Exception ex)
                    {
                        labelName.Text = oldText;
                        throw;
                    }
                    finally
                    {
                        BringBack(labelName, textBoxName);
                    }
                    break;

                case Keys.Escape:
                    BringBack(labelName, textBoxName);
                    break;
            }
        }

        private void BringBack(Label label, TextBox textBox)
        {
            textBox.Text = string.Empty;
            textBox.Visible = false;
            label.Visible = true;
        }
    }
}
