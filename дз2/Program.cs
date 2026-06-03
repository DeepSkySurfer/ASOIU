using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using ДЗ3_6.Forms;

namespace ДЗ3_6
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Устанавливаем инвариантную культуру для всего приложения
            CultureInfo invariantCulture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentCulture = invariantCulture;
            Thread.CurrentThread.CurrentUICulture = invariantCulture;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}