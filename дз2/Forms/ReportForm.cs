using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using ДЗ3_6.Data;

namespace ДЗ3_6.Forms
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
            LoadReports();
        }

        private void LoadReports()
        {
            using var context = new AppDbContext();

            // Отчёт 1: Полный список работников с должностями
            var report1 = context.Employees
                .Include(e => e.Position)
                .OrderBy(e => e.Name)
                .Select(e => new
                {
                    e.Name,
                    PositionName = e.Position != null ? e.Position.Name : "",
                    e.Salary
                })
                .ToList();

            dgvReport1.DataSource = null;
            dgvReport1.DataSource = report1;
            dgvReport1.Columns["Name"].HeaderText = "Имя работника";
            dgvReport1.Columns["PositionName"].HeaderText = "Должность";
            dgvReport1.Columns["Salary"].HeaderText = "Зарплата (тыс. руб.)";
            dgvReport1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Отчёт 2: Количество работников по должностям
            var report2 = context.Employees
                .Include(e => e.Position)
                .GroupBy(e => e.Position != null ? e.Position.Name : "Без должности")
                .Select(g => new
                {
                    PositionName = g.Key,
                    Count = g.Count()
                })
                .OrderBy(r => r.PositionName)
                .ToList();

            dgvReport2.DataSource = null;
            dgvReport2.DataSource = report2;
            dgvReport2.Columns["PositionName"].HeaderText = "Должность";
            dgvReport2.Columns["Count"].HeaderText = "Количество работников";
            dgvReport2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Отчёт 3: Средняя зарплата по должностям
            var report3 = context.Employees
                .Include(e => e.Position)
                .Where(e => e.Position != null)
                .GroupBy(e => e.Position!.Name)
                .Select(g => new
                {
                    PositionName = g.Key,
                    AvgSalary = g.Average(e => e.Salary)
                })
                .OrderByDescending(r => r.AvgSalary)
                .ToList();

            dgvReport3.DataSource = null;
            dgvReport3.DataSource = report3;
            dgvReport3.Columns["PositionName"].HeaderText = "Должность";
            dgvReport3.Columns["AvgSalary"].HeaderText = "Средняя зарплата (тыс. руб.)";
            dgvReport3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}