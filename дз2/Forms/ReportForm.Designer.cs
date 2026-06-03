namespace ДЗ3_6.Forms
{
    partial class ReportForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblReport1 = new System.Windows.Forms.Label();
            this.dgvReport1 = new System.Windows.Forms.DataGridView();
            this.lblReport2 = new System.Windows.Forms.Label();
            this.dgvReport2 = new System.Windows.Forms.DataGridView();
            this.lblReport3 = new System.Windows.Forms.Label();
            this.dgvReport3 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport3)).BeginInit();
            this.SuspendLayout();

            // lblReport1
            this.lblReport1.AutoSize = true;
            this.lblReport1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblReport1.Location = new System.Drawing.Point(12, 9);
            this.lblReport1.Name = "lblReport1";
            this.lblReport1.Size = new System.Drawing.Size(357, 25);
            this.lblReport1.TabIndex = 0;
            this.lblReport1.Text = "1. Полный список работников:";

            // dgvReport1
            this.dgvReport1.AllowUserToAddRows = false;
            this.dgvReport1.AllowUserToDeleteRows = false;
            this.dgvReport1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReport1.Location = new System.Drawing.Point(12, 37);
            this.dgvReport1.Name = "dgvReport1";
            this.dgvReport1.ReadOnly = true;
            this.dgvReport1.RowHeadersVisible = false;
            this.dgvReport1.Size = new System.Drawing.Size(760, 150);
            this.dgvReport1.TabIndex = 1;

            // lblReport2
            this.lblReport2.AutoSize = true;
            this.lblReport2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblReport2.Location = new System.Drawing.Point(12, 200);
            this.lblReport2.Name = "lblReport2";
            this.lblReport2.Size = new System.Drawing.Size(297, 25);
            this.lblReport2.TabIndex = 2;
            this.lblReport2.Text = "2. Количество по должностям:";

            // dgvReport2
            this.dgvReport2.AllowUserToAddRows = false;
            this.dgvReport2.AllowUserToDeleteRows = false;
            this.dgvReport2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReport2.Location = new System.Drawing.Point(12, 228);
            this.dgvReport2.Name = "dgvReport2";
            this.dgvReport2.ReadOnly = true;
            this.dgvReport2.RowHeadersVisible = false;
            this.dgvReport2.Size = new System.Drawing.Size(760, 120);
            this.dgvReport2.TabIndex = 3;

            // lblReport3
            this.lblReport3.AutoSize = true;
            this.lblReport3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblReport3.Location = new System.Drawing.Point(12, 370);
            this.lblReport3.Name = "lblReport3";
            this.lblReport3.Size = new System.Drawing.Size(328, 25);
            this.lblReport3.TabIndex = 4;
            this.lblReport3.Text = "3. Средняя зарплата по должностям:";

            // dgvReport3
            this.dgvReport3.AllowUserToAddRows = false;
            this.dgvReport3.AllowUserToDeleteRows = false;
            this.dgvReport3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReport3.Location = new System.Drawing.Point(12, 398);
            this.dgvReport3.Name = "dgvReport3";
            this.dgvReport3.ReadOnly = true;
            this.dgvReport3.RowHeadersVisible = false;
            this.dgvReport3.Size = new System.Drawing.Size(760, 150);
            this.dgvReport3.TabIndex = 5;

            // ReportForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.dgvReport3);
            this.Controls.Add(this.lblReport3);
            this.Controls.Add(this.dgvReport2);
            this.Controls.Add(this.lblReport2);
            this.Controls.Add(this.dgvReport1);
            this.Controls.Add(this.lblReport1);
            this.Name = "ReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Отчёты";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblReport1;
        private System.Windows.Forms.DataGridView dgvReport1;
        private System.Windows.Forms.Label lblReport2;
        private System.Windows.Forms.DataGridView dgvReport2;
        private System.Windows.Forms.Label lblReport3;
        private System.Windows.Forms.DataGridView dgvReport3;
    }
}