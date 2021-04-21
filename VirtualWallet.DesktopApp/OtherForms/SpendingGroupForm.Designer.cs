
namespace VirtualWallet.DesktopApp.OtherForms
{
    partial class SpendingGroupForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewSpendingGroup = new System.Windows.Forms.DataGridView();
            this.buttonSelect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSpendingGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewSpendingGroup
            // 
            this.dataGridViewSpendingGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSpendingGroup.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewSpendingGroup.Name = "dataGridViewSpendingGroup";
            this.dataGridViewSpendingGroup.RowTemplate.Height = 25;
            this.dataGridViewSpendingGroup.Size = new System.Drawing.Size(240, 206);
            this.dataGridViewSpendingGroup.TabIndex = 0;
            this.dataGridViewSpendingGroup.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSpendingGroup_CellClick);
            // 
            // buttonSelect
            // 
            this.buttonSelect.Location = new System.Drawing.Point(87, 224);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(75, 23);
            this.buttonSelect.TabIndex = 1;
            this.buttonSelect.Text = "Wybierz";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // SpendingGroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 256);
            this.Controls.Add(this.buttonSelect);
            this.Controls.Add(this.dataGridViewSpendingGroup);
            this.Name = "SpendingGroupForm";
            this.Text = "SpendingGroupForm";
            this.Load += new System.EventHandler(this.SpendingGroupForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSpendingGroup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSpendingGroup;
        private System.Windows.Forms.Button buttonSelect;
    }
}