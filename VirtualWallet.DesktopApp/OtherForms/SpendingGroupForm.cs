﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VirtualWallet.DesktopApp.Classes;
using VirtualWallet.Model.Domain;
using VirtualWallet.Common.Extensions;

namespace VirtualWallet.DesktopApp.OtherForms
{
    public partial class SpendingGroupForm : Form
    {
        private readonly IList<SpendingGroup> _spendingGroups;
        private readonly LoginForm _loginForm;
        private readonly Action _onSuccessSpendingGroupPick;

        public SpendingGroupForm(IList<SpendingGroup> spendingGroups, LoginForm loginForm, Action onSuccessSpendingGroupPick)
        {
            InitializeComponent();
            _spendingGroups = spendingGroups;
            _loginForm = loginForm;
            _onSuccessSpendingGroupPick = onSuccessSpendingGroupPick;
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
                //currentMonthlySpending.Spendings.ForEach(s => s.MonthlySpending = currentMonthlySpending); // Figure out why we have to do that
                CommonPool.MonthlySpending = currentMonthlySpending;


                var spendingsForCurrentMonth = CommonPool.MonthlySpending.Spendings;
                _onSuccessSpendingGroupPick();

                _loginForm.Dispose();
                Dispose();
            }
        }

        
    }
}
