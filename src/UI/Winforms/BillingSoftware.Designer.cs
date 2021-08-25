
namespace Winforms
{
    partial class BillingSoftware
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
            this.btnGenerateBill = new System.Windows.Forms.Button();
            this.btnInventry = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnDailySalesReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGenerateBill
            // 
            this.btnGenerateBill.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGenerateBill.AutoSize = true;
            this.btnGenerateBill.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnGenerateBill.Location = new System.Drawing.Point(358, 144);
            this.btnGenerateBill.Name = "btnGenerateBill";
            this.btnGenerateBill.Size = new System.Drawing.Size(108, 31);
            this.btnGenerateBill.TabIndex = 1;
            this.btnGenerateBill.Text = "Generate Bill";
            this.btnGenerateBill.UseVisualStyleBackColor = true;
            this.btnGenerateBill.Click += new System.EventHandler(this.BtnGenerateBill_Click);
            // 
            // btnInventry
            // 
            this.btnInventry.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnInventry.AutoSize = true;
            this.btnInventry.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnInventry.Location = new System.Drawing.Point(187, 144);
            this.btnInventry.Name = "btnInventry";
            this.btnInventry.Size = new System.Drawing.Size(77, 31);
            this.btnInventry.TabIndex = 2;
            this.btnInventry.Text = "Inventry";
            this.btnInventry.UseVisualStyleBackColor = true;
            this.btnInventry.Click += new System.EventHandler(this.BtnInventry_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblWelcome.Location = new System.Drawing.Point(282, 67);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(205, 21);
            this.lblWelcome.TabIndex = 3;
            this.lblWelcome.Text = "Welcome to Billing Software";
            // 
            // btnDailySalesReport
            // 
            this.btnDailySalesReport.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDailySalesReport.AutoSize = true;
            this.btnDailySalesReport.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDailySalesReport.Location = new System.Drawing.Point(523, 144);
            this.btnDailySalesReport.Name = "btnDailySalesReport";
            this.btnDailySalesReport.Size = new System.Drawing.Size(146, 31);
            this.btnDailySalesReport.TabIndex = 4;
            this.btnDailySalesReport.Text = "Daily Sales Report";
            this.btnDailySalesReport.UseVisualStyleBackColor = true;
            this.btnDailySalesReport.Click += new System.EventHandler(this.btnDailySalesReport_Click);
            // 
            // BillingSoftware
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 375);
            this.Controls.Add(this.btnDailySalesReport);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnInventry);
            this.Controls.Add(this.btnGenerateBill);
            this.Name = "BillingSoftware";
            this.Text = "Billing Software";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BillingSoftware_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerateBill;
        private System.Windows.Forms.Button btnInventry;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnDailySalesReport;
    }
}