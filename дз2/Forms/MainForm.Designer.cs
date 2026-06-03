namespace ДЗ3_6.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnPositions = new System.Windows.Forms.Button();
            this.btnEmployees = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(120, 30);
            this.lblTitle.Size = new System.Drawing.Size(360, 36);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Управление сотрудниками";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // btnPositions
            this.btnPositions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnPositions.Location = new System.Drawing.Point(180, 100);
            this.btnPositions.Name = "btnPositions";
            this.btnPositions.Size = new System.Drawing.Size(240, 50);
            this.btnPositions.TabIndex = 1;
            this.btnPositions.Text = "Должности (справочник)";
            this.btnPositions.UseVisualStyleBackColor = true;
            this.btnPositions.Click += new System.EventHandler(this.btnPositions_Click);

            // btnEmployees
            this.btnEmployees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnEmployees.Location = new System.Drawing.Point(180, 170);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Size = new System.Drawing.Size(240, 50);
            this.btnEmployees.TabIndex = 2;
            this.btnEmployees.Text = "Работники (основная)";
            this.btnEmployees.UseVisualStyleBackColor = true;
            this.btnEmployees.Click += new System.EventHandler(this.btnEmployees_Click);

            // btnReport
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnReport.Location = new System.Drawing.Point(180, 240);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(240, 50);
            this.btnReport.TabIndex = 3;
            this.btnReport.Text = "Отчёты";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 380);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnEmployees);
            this.Controls.Add(this.btnPositions);
            this.Controls.Add(this.lblTitle);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Система управления сотрудниками";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnPositions;
        private System.Windows.Forms.Button btnEmployees;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Label lblTitle;
    }
}