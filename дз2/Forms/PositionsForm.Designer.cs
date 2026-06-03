namespace ДЗ3_6.Forms
{
    partial class PositionsForm
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
            this.dgvPositions = new System.Windows.Forms.DataGridView();
            this.lblId = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPositions)).BeginInit();
            this.SuspendLayout();

            // dgvPositions
            this.dgvPositions.AllowUserToAddRows = false;
            this.dgvPositions.AllowUserToDeleteRows = false;
            this.dgvPositions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPositions.Location = new System.Drawing.Point(12, 12);
            this.dgvPositions.MultiSelect = false;
            this.dgvPositions.Name = "dgvPositions";
            this.dgvPositions.ReadOnly = true;
            this.dgvPositions.RowHeadersVisible = false;
            this.dgvPositions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPositions.Size = new System.Drawing.Size(560, 250);
            this.dgvPositions.TabIndex = 0;
            this.dgvPositions.SelectionChanged += new System.EventHandler(this.dgvPositions_SelectionChanged);

            // lblId
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(12, 280);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(27, 20);
            this.lblId.TabIndex = 1;
            this.lblId.Text = "ID:";

            // lblName
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 315);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(86, 20);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Название:";

            // txtId
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(104, 277);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(80, 27);
            this.txtId.TabIndex = 3;

            // txtName
            this.txtName.Location = new System.Drawing.Point(104, 312);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(300, 27);
            this.txtName.TabIndex = 4;

            // btnAdd
            this.btnAdd.Location = new System.Drawing.Point(420, 277);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 35);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnSave
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(420, 318);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnDelete
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(528, 277);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 35);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(528, 318);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // PositionsForm
            this.ClientSize = new System.Drawing.Size(684, 381);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.dgvPositions);
            this.Name = "PositionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Управление должностями";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPositions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgvPositions;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
    }
}