using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using ДЗ3_6.Models;
using ДЗ3_6.Data;

namespace ДЗ3_6.Forms
{
    public partial class PositionsForm : Form
    {
        public PositionsForm()
        {
            InitializeComponent();
            LoadPositions();
        }

        private void LoadPositions()
        {
            using var context = new AppDbContext();
            var positions = context.Positions
                .OrderBy(p => p.Name)
                .ToList();

            dgvPositions.DataSource = null;
            dgvPositions.DataSource = positions;

            dgvPositions.Columns["Id"].HeaderText = "ID";
            dgvPositions.Columns["Name"].HeaderText = "Название должности";
            dgvPositions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvPositions.Columns.Contains("Employees"))
                dgvPositions.Columns["Employees"].Visible = false;
        }

        private void ClearInputs()
        {
            txtId.Clear();
            txtName.Clear();
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void dgvPositions_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPositions.SelectedRows.Count > 0 && dgvPositions.SelectedRows[0].DataBoundItem != null)
            {
                var position = (Position)dgvPositions.SelectedRows[0].DataBoundItem;
                txtId.Text = position.Id.ToString();
                txtName.Text = position.Name;
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearInputs();
            txtId.Enabled = false;
            txtName.Focus();
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Название должности не может быть пустым!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var context = new AppDbContext();

            if (string.IsNullOrEmpty(txtId.Text))
            {
                var position = new Position { Name = txtName.Text.Trim() };
                context.Positions.Add(position);
                context.SaveChanges();
                MessageBox.Show("Должность добавлена!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int id = int.Parse(txtId.Text);
                var position = context.Positions.Find(id);
                if (position != null)
                {
                    position.Name = txtName.Text.Trim();
                    context.SaveChanges();
                    MessageBox.Show("Должность обновлена!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            LoadPositions();
            ClearInputs();
            txtId.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text)) return;

            int id = int.Parse(txtId.Text);

            using var context = new AppDbContext();
            var position = context.Positions
                .Include(p => p.Employees)
                .FirstOrDefault(p => p.Id == id);

            if (position == null) return;

            if (position.Employees != null && position.Employees.Any())
            {
                MessageBox.Show($"Невозможно удалить должность \"{position.Name}\", так как с ней связано {position.Employees.Count} работник(ов)!",
                    "Запрещено", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Удалить должность \"{position.Name}\"?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                context.Positions.Remove(position);
                context.SaveChanges();
                MessageBox.Show("Должность удалена!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPositions();
                ClearInputs();
                txtId.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearInputs();
            txtId.Enabled = true;
        }
    }
}