
namespace Winforms
{
    partial class DailySalesForm
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
            this.components = new System.ComponentModel.Container();
            this.lblDailySalesData = new System.Windows.Forms.Label();
            this.dgvDaliySalesData = new System.Windows.Forms.DataGridView();
            this.lblMRP = new System.Windows.Forms.Label();
            this.txtMRP = new System.Windows.Forms.TextBox();
            this.lblPurchased = new System.Windows.Forms.Label();
            this.txtPurchased = new System.Windows.Forms.TextBox();
            this.txtSales = new System.Windows.Forms.TextBox();
            this.lblSales = new System.Windows.Forms.Label();
            this.txtSaving = new System.Windows.Forms.TextBox();
            this.lblSaving = new System.Windows.Forms.Label();
            this.txtIncome = new System.Windows.Forms.TextBox();
            this.lblIncome = new System.Windows.Forms.Label();
            this.DailySalesData = new System.Windows.Forms.BindingSource(this.components);
            this.cmbDate = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.txtTotalGST = new System.Windows.Forms.TextBox();
            this.lblTotalGST = new System.Windows.Forms.Label();
            this.txtGST18 = new System.Windows.Forms.TextBox();
            this.lblGST18 = new System.Windows.Forms.Label();
            this.txtGST12 = new System.Windows.Forms.TextBox();
            this.lblGST12 = new System.Windows.Forms.Label();
            this.txtGST5 = new System.Windows.Forms.TextBox();
            this.lblGST5 = new System.Windows.Forms.Label();
            this.txtGST0 = new System.Windows.Forms.TextBox();
            this.lblGST0 = new System.Windows.Forms.Label();
            this.txtTotalSales = new System.Windows.Forms.TextBox();
            this.lblTotalSales = new System.Windows.Forms.Label();
            this.txtGST = new System.Windows.Forms.TextBox();
            this.lblGST = new System.Windows.Forms.Label();
            this.txtWithOutGST = new System.Windows.Forms.TextBox();
            this.lblSalesWithOutGST = new System.Windows.Forms.Label();
            this.txtGST40 = new System.Windows.Forms.TextBox();
            this.lblGST40 = new System.Windows.Forms.Label();
            this.txtGST28 = new System.Windows.Forms.TextBox();
            this.lblGST28 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDaliySalesData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DailySalesData)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDailySalesData
            // 
            this.lblDailySalesData.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDailySalesData.AutoSize = true;
            this.lblDailySalesData.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDailySalesData.Location = new System.Drawing.Point(312, -1);
            this.lblDailySalesData.Name = "lblDailySalesData";
            this.lblDailySalesData.Size = new System.Drawing.Size(184, 32);
            this.lblDailySalesData.TabIndex = 0;
            this.lblDailySalesData.Text = "Daily Sales Data";
            // 
            // dgvDaliySalesData
            // 
            this.dgvDaliySalesData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDaliySalesData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDaliySalesData.Location = new System.Drawing.Point(14, 70);
            this.dgvDaliySalesData.Name = "dgvDaliySalesData";
            this.dgvDaliySalesData.RowTemplate.Height = 25;
            this.dgvDaliySalesData.Size = new System.Drawing.Size(776, 247);
            this.dgvDaliySalesData.TabIndex = 1;
            // 
            // lblMRP
            // 
            this.lblMRP.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblMRP.AutoSize = true;
            this.lblMRP.Location = new System.Drawing.Point(14, 333);
            this.lblMRP.Name = "lblMRP";
            this.lblMRP.Size = new System.Drawing.Size(32, 15);
            this.lblMRP.TabIndex = 2;
            this.lblMRP.Text = "MRP";
            // 
            // txtMRP
            // 
            this.txtMRP.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtMRP.Location = new System.Drawing.Point(47, 329);
            this.txtMRP.Name = "txtMRP";
            this.txtMRP.Size = new System.Drawing.Size(100, 23);
            this.txtMRP.TabIndex = 3;
            // 
            // lblPurchased
            // 
            this.lblPurchased.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblPurchased.AutoSize = true;
            this.lblPurchased.Location = new System.Drawing.Point(159, 333);
            this.lblPurchased.Name = "lblPurchased";
            this.lblPurchased.Size = new System.Drawing.Size(62, 15);
            this.lblPurchased.TabIndex = 4;
            this.lblPurchased.Text = "Purchased";
            // 
            // txtPurchased
            // 
            this.txtPurchased.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtPurchased.Location = new System.Drawing.Point(221, 329);
            this.txtPurchased.Name = "txtPurchased";
            this.txtPurchased.Size = new System.Drawing.Size(100, 23);
            this.txtPurchased.TabIndex = 5;
            // 
            // txtSales
            // 
            this.txtSales.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtSales.Location = new System.Drawing.Point(367, 329);
            this.txtSales.Name = "txtSales";
            this.txtSales.Size = new System.Drawing.Size(100, 23);
            this.txtSales.TabIndex = 7;
            // 
            // lblSales
            // 
            this.lblSales.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblSales.AutoSize = true;
            this.lblSales.Location = new System.Drawing.Point(335, 333);
            this.lblSales.Name = "lblSales";
            this.lblSales.Size = new System.Drawing.Size(33, 15);
            this.lblSales.TabIndex = 6;
            this.lblSales.Text = "Sales";
            // 
            // txtSaving
            // 
            this.txtSaving.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtSaving.Location = new System.Drawing.Point(517, 329);
            this.txtSaving.Name = "txtSaving";
            this.txtSaving.Size = new System.Drawing.Size(100, 23);
            this.txtSaving.TabIndex = 9;
            // 
            // lblSaving
            // 
            this.lblSaving.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblSaving.AutoSize = true;
            this.lblSaving.Location = new System.Drawing.Point(475, 333);
            this.lblSaving.Name = "lblSaving";
            this.lblSaving.Size = new System.Drawing.Size(42, 15);
            this.lblSaving.TabIndex = 8;
            this.lblSaving.Text = "Saving";
            // 
            // txtIncome
            // 
            this.txtIncome.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtIncome.Location = new System.Drawing.Point(682, 330);
            this.txtIncome.Name = "txtIncome";
            this.txtIncome.Size = new System.Drawing.Size(100, 23);
            this.txtIncome.TabIndex = 11;
            // 
            // lblIncome
            // 
            this.lblIncome.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblIncome.AutoSize = true;
            this.lblIncome.Location = new System.Drawing.Point(633, 333);
            this.lblIncome.Name = "lblIncome";
            this.lblIncome.Size = new System.Drawing.Size(47, 15);
            this.lblIncome.TabIndex = 10;
            this.lblIncome.Text = "Income";
            // 
            // cmbDate
            // 
            this.cmbDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbDate.FormattingEnabled = true;
            this.cmbDate.Location = new System.Drawing.Point(355, 41);
            this.cmbDate.Name = "cmbDate";
            this.cmbDate.Size = new System.Drawing.Size(121, 23);
            this.cmbDate.TabIndex = 12;
            this.cmbDate.SelectedIndexChanged += new System.EventHandler(this.cmbDate_SelectedIndexChanged);
            // 
            // lblDate
            // 
            this.lblDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(322, 44);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(31, 15);
            this.lblDate.TabIndex = 13;
            this.lblDate.Text = "Date";
            // 
            // txtTotalGST
            // 
            this.txtTotalGST.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtTotalGST.Location = new System.Drawing.Point(682, 367);
            this.txtTotalGST.Name = "txtTotalGST";
            this.txtTotalGST.Size = new System.Drawing.Size(100, 23);
            this.txtTotalGST.TabIndex = 23;
            // 
            // lblTotalGST
            // 
            this.lblTotalGST.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblTotalGST.AutoSize = true;
            this.lblTotalGST.Location = new System.Drawing.Point(626, 370);
            this.lblTotalGST.Name = "lblTotalGST";
            this.lblTotalGST.Size = new System.Drawing.Size(52, 15);
            this.lblTotalGST.TabIndex = 22;
            this.lblTotalGST.Text = "TotalGST";
            // 
            // txtGST18
            // 
            this.txtGST18.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtGST18.Location = new System.Drawing.Point(517, 366);
            this.txtGST18.Name = "txtGST18";
            this.txtGST18.Size = new System.Drawing.Size(100, 23);
            this.txtGST18.TabIndex = 21;
            // 
            // lblGST18
            // 
            this.lblGST18.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblGST18.AutoSize = true;
            this.lblGST18.Location = new System.Drawing.Point(475, 370);
            this.lblGST18.Name = "lblGST18";
            this.lblGST18.Size = new System.Drawing.Size(39, 15);
            this.lblGST18.TabIndex = 20;
            this.lblGST18.Text = "GST18";
            // 
            // txtGST12
            // 
            this.txtGST12.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtGST12.Location = new System.Drawing.Point(367, 366);
            this.txtGST12.Name = "txtGST12";
            this.txtGST12.Size = new System.Drawing.Size(100, 23);
            this.txtGST12.TabIndex = 19;
            // 
            // lblGST12
            // 
            this.lblGST12.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblGST12.AutoSize = true;
            this.lblGST12.Location = new System.Drawing.Point(326, 370);
            this.lblGST12.Name = "lblGST12";
            this.lblGST12.Size = new System.Drawing.Size(39, 15);
            this.lblGST12.TabIndex = 18;
            this.lblGST12.Text = "GST12";
            // 
            // txtGST5
            // 
            this.txtGST5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtGST5.Location = new System.Drawing.Point(220, 366);
            this.txtGST5.Name = "txtGST5";
            this.txtGST5.Size = new System.Drawing.Size(100, 23);
            this.txtGST5.TabIndex = 17;
            // 
            // lblGST5
            // 
            this.lblGST5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblGST5.AutoSize = true;
            this.lblGST5.Location = new System.Drawing.Point(159, 370);
            this.lblGST5.Name = "lblGST5";
            this.lblGST5.Size = new System.Drawing.Size(33, 15);
            this.lblGST5.TabIndex = 16;
            this.lblGST5.Text = "GST5";
            // 
            // txtGST0
            // 
            this.txtGST0.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtGST0.Location = new System.Drawing.Point(47, 366);
            this.txtGST0.Name = "txtGST0";
            this.txtGST0.Size = new System.Drawing.Size(100, 23);
            this.txtGST0.TabIndex = 15;
            // 
            // lblGST0
            // 
            this.lblGST0.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblGST0.AutoSize = true;
            this.lblGST0.Location = new System.Drawing.Point(14, 370);
            this.lblGST0.Name = "lblGST0";
            this.lblGST0.Size = new System.Drawing.Size(33, 15);
            this.lblGST0.TabIndex = 14;
            this.lblGST0.Text = "GST0";
            // 
            // txtTotalSales
            // 
            this.txtTotalSales.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtTotalSales.Location = new System.Drawing.Point(683, 399);
            this.txtTotalSales.Name = "txtTotalSales";
            this.txtTotalSales.Size = new System.Drawing.Size(100, 23);
            this.txtTotalSales.TabIndex = 33;
            // 
            // lblTotalSales
            // 
            this.lblTotalSales.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblTotalSales.AutoSize = true;
            this.lblTotalSales.Location = new System.Drawing.Point(624, 402);
            this.lblTotalSales.Name = "lblTotalSales";
            this.lblTotalSales.Size = new System.Drawing.Size(58, 15);
            this.lblTotalSales.TabIndex = 32;
            this.lblTotalSales.Text = "TotalSales";
            // 
            // txtGST
            // 
            this.txtGST.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtGST.Location = new System.Drawing.Point(518, 398);
            this.txtGST.Name = "txtGST";
            this.txtGST.Size = new System.Drawing.Size(100, 23);
            this.txtGST.TabIndex = 31;
            // 
            // lblGST
            // 
            this.lblGST.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblGST.AutoSize = true;
            this.lblGST.Location = new System.Drawing.Point(476, 402);
            this.lblGST.Name = "lblGST";
            this.lblGST.Size = new System.Drawing.Size(27, 15);
            this.lblGST.TabIndex = 30;
            this.lblGST.Text = "GST";
            // 
            // txtWithOutGST
            // 
            this.txtWithOutGST.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtWithOutGST.Location = new System.Drawing.Point(382, 398);
            this.txtWithOutGST.Name = "txtWithOutGST";
            this.txtWithOutGST.Size = new System.Drawing.Size(88, 23);
            this.txtWithOutGST.TabIndex = 29;
            // 
            // lblSalesWithOutGST
            // 
            this.lblSalesWithOutGST.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblSalesWithOutGST.AutoSize = true;
            this.lblSalesWithOutGST.Location = new System.Drawing.Point(308, 402);
            this.lblSalesWithOutGST.Name = "lblSalesWithOutGST";
            this.lblSalesWithOutGST.Size = new System.Drawing.Size(72, 15);
            this.lblSalesWithOutGST.TabIndex = 28;
            this.lblSalesWithOutGST.Text = "WithOutGST";
            // 
            // txtGST40
            // 
            this.txtGST40.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtGST40.Location = new System.Drawing.Point(221, 398);
            this.txtGST40.Name = "txtGST40";
            this.txtGST40.Size = new System.Drawing.Size(81, 23);
            this.txtGST40.TabIndex = 27;
            // 
            // lblGST40
            // 
            this.lblGST40.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblGST40.AutoSize = true;
            this.lblGST40.Location = new System.Drawing.Point(160, 402);
            this.lblGST40.Name = "lblGST40";
            this.lblGST40.Size = new System.Drawing.Size(39, 15);
            this.lblGST40.TabIndex = 26;
            this.lblGST40.Text = "GST40";
            // 
            // txtGST28
            // 
            this.txtGST28.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtGST28.Location = new System.Drawing.Point(48, 398);
            this.txtGST28.Name = "txtGST28";
            this.txtGST28.Size = new System.Drawing.Size(100, 23);
            this.txtGST28.TabIndex = 25;
            // 
            // lblGST28
            // 
            this.lblGST28.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblGST28.AutoSize = true;
            this.lblGST28.Location = new System.Drawing.Point(6, 402);
            this.lblGST28.Name = "lblGST28";
            this.lblGST28.Size = new System.Drawing.Size(39, 15);
            this.lblGST28.TabIndex = 24;
            this.lblGST28.Text = "GST28";
            // 
            // DailySalesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 430);
            this.Controls.Add(this.txtTotalSales);
            this.Controls.Add(this.lblTotalSales);
            this.Controls.Add(this.txtGST);
            this.Controls.Add(this.lblGST);
            this.Controls.Add(this.txtWithOutGST);
            this.Controls.Add(this.lblSalesWithOutGST);
            this.Controls.Add(this.txtGST40);
            this.Controls.Add(this.lblGST40);
            this.Controls.Add(this.txtGST28);
            this.Controls.Add(this.lblGST28);
            this.Controls.Add(this.txtTotalGST);
            this.Controls.Add(this.lblTotalGST);
            this.Controls.Add(this.txtGST18);
            this.Controls.Add(this.lblGST18);
            this.Controls.Add(this.txtGST12);
            this.Controls.Add(this.lblGST12);
            this.Controls.Add(this.txtGST5);
            this.Controls.Add(this.lblGST5);
            this.Controls.Add(this.txtGST0);
            this.Controls.Add(this.lblGST0);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.cmbDate);
            this.Controls.Add(this.txtIncome);
            this.Controls.Add(this.lblIncome);
            this.Controls.Add(this.txtSaving);
            this.Controls.Add(this.lblSaving);
            this.Controls.Add(this.txtSales);
            this.Controls.Add(this.lblSales);
            this.Controls.Add(this.txtPurchased);
            this.Controls.Add(this.lblPurchased);
            this.Controls.Add(this.txtMRP);
            this.Controls.Add(this.lblMRP);
            this.Controls.Add(this.dgvDaliySalesData);
            this.Controls.Add(this.lblDailySalesData);
            this.Name = "DailySalesForm";
            this.Text = "DailySalesForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DailySalesForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDaliySalesData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DailySalesData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDailySalesData;
        private System.Windows.Forms.DataGridView dgvDaliySalesData;
        private System.Windows.Forms.Label lblMRP;
        private System.Windows.Forms.TextBox txtMRP;
        private System.Windows.Forms.Label lblPurchased;
        private System.Windows.Forms.TextBox txtPurchased;
        private System.Windows.Forms.TextBox txtSales;
        private System.Windows.Forms.Label lblSales;
        private System.Windows.Forms.TextBox txtSaving;
        private System.Windows.Forms.Label lblSaving;
        private System.Windows.Forms.TextBox txtIncome;
        private System.Windows.Forms.Label lblIncome;
        private System.Windows.Forms.BindingSource DailySalesData;
        private System.Windows.Forms.ComboBox cmbDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.TextBox txtTotalGST;
        private System.Windows.Forms.Label lblTotalGST;
        private System.Windows.Forms.TextBox txtGST18;
        private System.Windows.Forms.Label lblGST18;
        private System.Windows.Forms.TextBox txtGST12;
        private System.Windows.Forms.Label lblGST12;
        private System.Windows.Forms.TextBox txtGST5;
        private System.Windows.Forms.Label lblGST5;
        private System.Windows.Forms.TextBox txtGST0;
        private System.Windows.Forms.Label lblGST0;
        private System.Windows.Forms.TextBox txtTotalSales;
        private System.Windows.Forms.Label lblTotalSales;
        private System.Windows.Forms.TextBox txtGST;
        private System.Windows.Forms.Label lblGST;
        private System.Windows.Forms.TextBox txtWithOutGST;
        private System.Windows.Forms.Label lblSalesWithOutGST;
        private System.Windows.Forms.TextBox txtGST40;
        private System.Windows.Forms.Label lblGST40;
        private System.Windows.Forms.TextBox txtGST28;
        private System.Windows.Forms.Label lblGST28;
    }
}