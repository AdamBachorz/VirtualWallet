using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VirtualWallet.DesktopApp.Classes;
using VirtualWallet.Model.Domain;

namespace VirtualWallet.DesktopApp.OtherForms
{
    public partial class SpendingGroupForm : Form
    {
        private readonly IList<SpendingGroup> _spendingGroups;
        private readonly LoginForm _loginForm;
        private readonly DataGridView _dataGridViewSpendings;

        public SpendingGroupForm(IList<SpendingGroup> spendingGroups, LoginForm loginForm, DataGridView dataGridViewSpendings)
        {
            InitializeComponent();
            _spendingGroups = spendingGroups;
            _loginForm = loginForm;
            _dataGridViewSpendings = dataGridViewSpendings;
        }

        private void SpendingGroupForm_Load(object sender, EventArgs e)
        {
            dataGridViewSpendingGroup.DataSource = _spendingGroups;
            buttonSelect.Enabled = false;
        }

        private void dataGridViewSpendingGroup_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonSelect.Enabled = dataGridViewSpendingGroup.SelectedRows.Count == 1;
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            if (dataGridViewSpendingGroup.SelectedRows.Count == 1)
            {
                var index = dataGridViewSpendingGroup.SelectedRows[0].Index;
                var spendingGroup = _spendingGroups[index];
                if (spendingGroup == null)
                {
                    MessageBox.Show("Coś poszło nie tak");
                }

                CommonPool.SpendingGroup = spendingGroup;

                var now = DateTime.Now;
                var currentMonthlySpending = CommonPool.SpendingGroup.MonthlySpendings
                    .FirstOrDefault(ms => ms.Month == now.Month && ms.Year == now.Year);
                var spendingsForCurrentMonth = currentMonthlySpending.Spendings;
                _dataGridViewSpendings.DataSource = spendingsForCurrentMonth;

                _loginForm.Dispose();
                Dispose();
            }
        }

        
    }
}
