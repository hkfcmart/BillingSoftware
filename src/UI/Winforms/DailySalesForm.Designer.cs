
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvDaliySalesData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DailySalesData)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDailySalesData
            // 
            this.lblDailySalesData.AutoSize = true;
            this.lblDailySalesData.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDailySalesData.Location = new System.Drawing.Point(318, 9);
            this.lblDailySalesData.Name = "lblDailySalesData";
            this.lblDailySalesData.Size = new System.Drawing.Size(184, 32);
            this.lblDailySalesData.TabIndex = 0;
            this.lblDailySalesData.Text = "Daily Sales Data";
            // 
            // dgvDaliySalesData
            // 
            this.dgvDaliySalesData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDaliySalesData.Location = new System.Drawing.Point(12, 44);
            this.dgvDaliySalesData.Name = "dgvDaliySalesData";
            this.dgvDaliySalesData.RowTemplate.Height = 25;
            this.dgvDaliySalesData.Size = new System.Drawing.Size(776, 350);
            this.dgvDaliySalesData.TabIndex = 1;
            // 
            // lblMRP
            // 
            this.lblMRP.AutoSize = true;
            this.lblMRP.Location = new System.Drawing.Point(14, 415);
            this.lblMRP.Name = "lblMRP";
            this.lblMRP.Size = new System.Drawing.Size(32, 15);
            this.lblMRP.TabIndex = 2;
            this.lblMRP.Text = "MRP";
            // 
            // txtMRP
            // 
            this.txtMRP.Location = new System.Drawing.Point(47, 411);
            this.txtMRP.Name = "txtMRP";
            this.txtMRP.Size = new System.Drawing.Size(100, 23);
            this.txtMRP.TabIndex = 3;
            // 
            // lblPurchased
            // 
            this.lblPurchased.AutoSize = true;
            this.lblPurchased.Location = new System.Drawing.Point(159, 415);
            this.lblPurchased.Name = "lblPurchased";
            this.lblPurchased.Size = new System.Drawing.Size(62, 15);
            this.lblPurchased.TabIndex = 4;
            this.lblPurchased.Text = "Purchased";
            // 
            // txtPurchased
            // 
            this.txtPurchased.Location = new System.Drawing.Point(221, 411);
            this.txtPurchased.Name = "txtPurchased";
            this.txtPurchased.Size = new System.Drawing.Size(100, 23);
            this.txtPurchased.TabIndex = 5;
            // 
            // txtSales
            // 
            this.txtSales.Location = new System.Drawing.Point(367, 411);
            this.txtSales.Name = "txtSales";
            this.txtSales.Size = new System.Drawing.Size(100, 23);
            this.txtSales.TabIndex = 7;
            // 
            // lblSales
            // 
            this.lblSales.AutoSize = true;
            this.lblSales.Location = new System.Drawing.Point(335, 415);
            this.lblSales.Name = "lblSales";
            this.lblSales.Size = new System.Drawing.Size(33, 15);
            this.lblSales.TabIndex = 6;
            this.lblSales.Text = "Sales";
            // 
            // txtSaving
            // 
            this.txtSaving.Location = new System.Drawing.Point(517, 411);
            this.txtSaving.Name = "txtSaving";
            this.txtSaving.Size = new System.Drawing.Size(100, 23);
            this.txtSaving.TabIndex = 9;
            // 
            // lblSaving
            // 
            this.lblSaving.AutoSize = true;
            this.lblSaving.Location = new System.Drawing.Point(475, 415);
            this.lblSaving.Name = "lblSaving";
            this.lblSaving.Size = new System.Drawing.Size(42, 15);
            this.lblSaving.TabIndex = 8;
            this.lblSaving.Text = "Saving";
            // 
            // txtIncome
            // 
            this.txtIncome.Location = new System.Drawing.Point(682, 412);
            this.txtIncome.Name = "txtIncome";
            this.txtIncome.Size = new System.Drawing.Size(100, 23);
            this.txtIncome.TabIndex = 11;
            // 
            // lblIncome
            // 
            this.lblIncome.AutoSize = true;
            this.lblIncome.Location = new System.Drawing.Point(633, 415);
            this.lblIncome.Name = "lblIncome";
            this.lblIncome.Size = new System.Drawing.Size(47, 15);
            this.lblIncome.TabIndex = 10;
            this.lblIncome.Text = "Income";
            // 
            // DailySalesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}