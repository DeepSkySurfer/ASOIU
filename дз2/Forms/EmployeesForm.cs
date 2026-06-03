using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using ДЗ3_6.Models;
using ДЗ3_6.Data;

namespace ДЗ3_6.Forms
{
    public partial class EmployeesForm : Form
    {
        public EmployeesForm()
        {
            InitializeComponent();
            LoadEmployees();
            LoadPositionsToCombo();
        }

        private void LoadEmployees()
        {
            using var context = new AppDbContext();
            var employees = context.Employees
                .Include(e => e.Position)
                .OrderBy(e => e.Name)
                .Select(e => new
                {
                    e.Id,
                    e.Name,
                    PositionName = e.Position != null ? e.Position.Name : "",
                    e.Salary
                })
                .ToList();

            dgvEmployees.DataSource = null;
            dgvEmployees.DataSource = employees;

            dgvEmployees.Columns["Id"].HeaderText = "ID";
            dgvEmployees.Columns["Name"].HeaderText = "Имя работника";
            dgvEmployees.Columns["PositionName"].HeaderText = "Должность";
            dgvEmployees.Columns["Salary"].HeaderText = "Зарплата (тыс. руб.)";
            dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadPositionsToCombo()
        {
            using var context = new AppDbContext();
            var positions = context.Positions.OrderBy(p => p.Name).ToList();
            cmbPosition.DataSource = positions;
            cmbPosition.DisplayMember = "Name";
            cmbPosition.ValueMember = "Id";
        }

        private void ClearInputs()
        {
            txtId.Clear();
            txtName.Clear();
            if (cmbPosition.Items.Count > 0)
                cmbPosition.SelectedIndex = -1;
            txtSalary.Clear();
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void dgvEmployees_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count > 0 && dgvEmployees.SelectedRows[0].DataBoundItem != null)
            {
                var selectedRow = dgvEmployees.SelectedRows[0];
                var item = selectedRow.DataBoundItem;
                var properties = item.GetType().GetProperties();

                int id = 0;
                string name = "";
                string positionName = "";
                decimal salary = 0;

                foreach (var prop in properties)
                {
                    if (prop.Name == "Id") id = (int)prop.GetValue(item);
                    if (prop.Name == "Name") name = prop.GetValue(item)?.ToString() ?? "";
                    if (prop.Name == "PositionName") positionName = prop.GetValue(item)?.ToString() ?? "";
                    if (prop.Name == "Salary") salary = (decimal)prop.GetValue(item);
                }

                txtId.Text = id.ToString();
                txtName.Text = name;
                txtSalary.Text = salary.ToString();

                using var context = new AppDbContext();
                var position = context.Positions.FirstOrDefault(p => p.Name == positionName);
                if (position != null)
                    cmbPosition.SelectedValue = position.Id;

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
                MessageBox.Show("Имя работника не может быть пустым!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbPosition.SelectedItem == null)
            {
                MessageBox.Show("Выберите должность!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtSalary.Text, out decimal salary))
            {
                MessageBox.Show("Введите корректную зарплату!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (salary < 0)
            {
                MessageBox.Show("Зарплата не может быть отрицательной!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var context = new AppDbContext();

            if (string.IsNullOrEmpty(txtId.Text))
            {
                var employee = new Employee
                {
                    Name = txtName.Text.Trim(),
                    PositionId = (int)cmbPosition.SelectedValue,
                    Salary = salary
                };
                context.Employees.Add(employee);
                context.SaveChanges();
                MessageBox.Show("Работник добавлен!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int id = int.Parse(txtId.Text);
                var employee = context.Employees.Find(id);
                if (employee != null)
                {
                    employee.Name = txtName.Text.Trim();
                    employee.PositionId = (int)cmbPosition.SelectedValue;
                    employee.Salary = salary;
                    context.SaveChanges();
                    MessageBox.Show("Данные работника обновлены!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            LoadEmployees();
            ClearInputs();
            txtId.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Выберите работника для удаления!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = int.Parse(txtId.Text);

            var result = MessageBox.Show($"Удалить работника \"{txtName.Text}\"?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                using var context = new AppDbContext();
                var employee = context.Employees.Find(id);
                if (employee != null)
                {
                    context.Employees.Remove(employee);
                    context.SaveChanges();
                    MessageBox.Show("Работник удалён!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadEmployees();
                    ClearInputs();
                    txtId.Enabled = true;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearInputs();
            txtId.Enabled = true;
        }
    }
}