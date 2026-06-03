using System;
using System.Windows.Forms;

namespace ДЗ3_6.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            using var context = new Data.AppDbContext();
            context.Database.EnsureCreated();
        }

        private void btnPositions_Click(object sender, EventArgs e)
        {
            var form = new PositionsForm();
            form.ShowDialog();
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            var form = new EmployeesForm();
            form.ShowDialog();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            var form = new ReportForm();
            form.ShowDialog();
        }
    }
}