using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace ДЗ2_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            string dbPath = "salary.db";
            string positionsCsv = Path.Combine(AppContext.BaseDirectory, "positions.csv");
            string employeesCsv = Path.Combine(AppContext.BaseDirectory, "employees.csv");

            var db = new DatabaseManager(dbPath);
            db.InitializeDatabase(positionsCsv, employeesCsv);

            Console.WriteLine();

            string choice;
            do
            {
                Console.WriteLine("╔══════════════════════════════════════╗");
                Console.WriteLine("║        УПРАВЛЕНИЕ РАБОТНИКАМИ        ║");
                Console.WriteLine("╠══════════════════════════════════════╣");
                Console.WriteLine("║ 1 — Показать все должности           ║");
                Console.WriteLine("║ 2 — Показать всех работников         ║");
                Console.WriteLine("║ 3 — Добавить работника               ║");
                Console.WriteLine("║ 4 — Редактировать работника          ║");
                Console.WriteLine("║ 5 — Удалить работника                ║");
                Console.WriteLine("║ 6 — Отчёты                           ║");
                Console.WriteLine("║ 7 — Фильтр по должности [ГРУППА Г]   ║");
                Console.WriteLine("║ 8 — Экспорт в CSV [ГРУППА Б]         ║");
                Console.WriteLine("║ 0 — Выход                            ║");
                Console.WriteLine("╚══════════════════════════════════════╝");
                Console.Write("Ваш выбор: ");

                choice = Console.ReadLine()?.Trim() ?? "";
                Console.WriteLine();

                switch (choice)
                {
                    case "1": ShowPositions(db); break;
                    case "2": ShowEmployees(db); break;
                    case "3": AddEmployee(db); break;
                    case "4": EditEmployee(db); break;
                    case "5": DeleteEmployee(db); break;
                    case "6": ReportsMenu(db); break;
                    case "7": FilterByPosition(db); break;
                    case "8": ExportCsv(db); break;
                    case "0": Console.WriteLine("До свидания!"); break;
                    default: Console.WriteLine("Неверный пункт меню."); break;
                }
                Console.WriteLine();
            } while (choice != "0");
        }

        static void ShowPositions(DatabaseManager db)
        {
            Console.WriteLine("---- Все должности ----");
            var positions = db.GetAllPositions();
            foreach (var pos in positions)
                Console.WriteLine(" " + pos);
            Console.WriteLine($"Итого: {positions.Count}");
        }

        static void ShowEmployees(DatabaseManager db)
        {
            Console.WriteLine("---- Все работники ----");
            var employees = db.GetAllEmployees();
            foreach (var emp in employees)
                Console.WriteLine(" " + emp);
            Console.WriteLine($"Итого: {employees.Count}");
        }

        static void AddEmployee(DatabaseManager db)
        {
            Console.WriteLine("---- Добавление работника ----");
            Console.WriteLine("Доступные должности:");
            var positions = db.GetAllPositions();
            foreach (var pos in positions)
                Console.WriteLine(" " + pos);

            Console.Write("ID должности: ");
            if (!int.TryParse(Console.ReadLine(), out int positionId))
            {
                Console.WriteLine("Ошибка: введите целое число.");
                return;
            }

            Console.Write("Имя работника: ");
            string name = Console.ReadLine()?.Trim() ?? "";
            if (name.Length == 0)
            {
                Console.WriteLine("Ошибка: имя не может быть пустым.");
                return;
            }

            Console.Write("Зарплата (тыс. руб./мес.): ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal salary))
            {
                Console.WriteLine("Ошибка: введите число.");
                return;
            }

            try
            {
                var emp = new Employee(0, positionId, name, salary);
                db.AddEmployee(emp);
                Console.WriteLine("Работник добавлен.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void EditEmployee(DatabaseManager db)
        {
            Console.WriteLine("---- Редактирование работника ----");
            Console.Write("Введите ID работника: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Ошибка: введите целое число.");
                return;
            }

            var emp = db.GetEmployeeById(id);
            if (emp == null)
            {
                Console.WriteLine($"Работник с ID={id} не найден.");
                return;
            }

            Console.WriteLine($"Текущие данные: {emp}");
            Console.WriteLine("(Нажмите Enter, чтобы оставить значение без изменений)");

            Console.Write($"Имя [{emp.Name}]: ");
            string input = Console.ReadLine()?.Trim() ?? "";
            if (input.Length > 0) emp.Name = input;

            Console.Write($"ID должности [{emp.PositionId}]: ");
            input = Console.ReadLine()?.Trim() ?? "";
            if (input.Length > 0 && int.TryParse(input, out int newPositionId))
                emp.PositionId = newPositionId;

            Console.Write($"Зарплата [{emp.Salary}]: ");
            input = Console.ReadLine()?.Trim() ?? "";
            if (input.Length > 0 && decimal.TryParse(input, out decimal newSalary))
            {
                try
                {
                    emp.Salary = newSalary;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    return;
                }
            }

            db.UpdateEmployee(emp);
            Console.WriteLine("Данные обновлены.");
        }

        static void DeleteEmployee(DatabaseManager db)
        {
            Console.WriteLine("---- Удаление работника ----");
            Console.Write("Введите ID работника: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Ошибка: введите целое число.");
                return;
            }

            var emp = db.GetEmployeeById(id);
            if (emp == null)
            {
                Console.WriteLine($"Работник с ID={id} не найден.");
                return;
            }

            Console.Write($"Удалить «{emp.Name}»? (да/нет): ");
            string confirm = Console.ReadLine()?.Trim().ToLower() ?? "";
            if (confirm == "да")
            {
                db.DeleteEmployee(id);
                Console.WriteLine("Работник удалён.");
            }
            else
            {
                Console.WriteLine("Удаление отменено.");
            }
        }

        static void ReportsMenu(DatabaseManager db)
        {
            string choice;
            do
            {
                Console.WriteLine("  === Отчёты ===");
                Console.WriteLine("  1 - Работники по должностям");
                Console.WriteLine("  2 - Количество работников по должностям");
                Console.WriteLine("  3 - Средняя зарплата по должностям");
                Console.WriteLine("  0 - Назад");
                Console.Write("Ваш выбор: ");
                choice = Console.ReadLine()?.Trim() ?? "";

                switch (choice)
                {
                    case "1": Report1_EmployeesWithPositions(db); break;
                    case "2": Report2_CountByPosition(db); break;
                    case "3": Report3_AvgSalaryByPosition(db); break;
                    case "0": break;
                    default: Console.WriteLine("Неверный пункт."); break;
                }
                Console.WriteLine();
            } while (choice != "0");
        }

        static void Report1_EmployeesWithPositions(DatabaseManager db)
        {
            new ReportBuilder(db)
                .Query(@"SELECT e.employee_name, p.position_name, e.employee_salary
                        FROM employees e
                        JOIN positions p ON e.position_id = p.position_id
                        ORDER BY e.employee_name")
                .Title("Работники по должностям")
                .Header("Имя", "Должность", "Зарплата (тыс. руб.)")
                .ColumnWidths(25, 20, 20)
                .Numbered()
                .Footer("Всего записей")
                .Print();
        }

        static void Report2_CountByPosition(DatabaseManager db)
        {
            new ReportBuilder(db)
                .Query(@"SELECT p.position_name, COUNT(*) AS cnt
                        FROM employees e
                        JOIN positions p ON e.position_id = p.position_id
                        GROUP BY p.position_name
                        ORDER BY p.position_name")
                .Title("Количество работников по должностям")
                .Header("Должность", "Кол-во")
                .ColumnWidths(30, 10)
                .Print();
        }

        static void Report3_AvgSalaryByPosition(DatabaseManager db)
        {
            new ReportBuilder(db)
                .Query(@"SELECT p.position_name, ROUND(AVG(e.employee_salary), 2) AS avg_salary
                        FROM employees e
                        JOIN positions p ON e.position_id = p.position_id
                        GROUP BY p.position_name
                        ORDER BY avg_salary DESC")
                .Title("Средняя зарплата по должностям")
                .Header("Должность", "Средняя зарплата (тыс. руб.)")
                .ColumnWidths(30, 25)
                .Print();
        }

        static void FilterByPosition(DatabaseManager db)
        {
            Console.WriteLine("---- Фильтр по должности ----");
            Console.WriteLine("Доступные должности:");
            var positions = db.GetAllPositions();
            foreach (var pos in positions)
                Console.WriteLine(" " + pos);

            Console.Write("Введите ID должности: ");
            if (!int.TryParse(Console.ReadLine(), out int positionId))
            {
                Console.WriteLine("Ошибка: введите целое число.");
                return;
            }

            var employees = db.GetEmployeesByPosition(positionId);
            if (employees.Count == 0)
            {
                Console.WriteLine("В этой должности нет работников.");
                return;
            }

            Console.WriteLine($"\nРаботники должности #{positionId}:");
            foreach (var emp in employees)
                Console.WriteLine(" " + emp);
            Console.WriteLine($"Итого: {employees.Count}");
        }

        static void ExportCsv(DatabaseManager db)
        {
            string positionsPath = Path.Combine(AppContext.BaseDirectory, "positions_export.csv");
            string employeesPath = Path.Combine(AppContext.BaseDirectory, "employees_export.csv");
            db.ExportToCsv(positionsPath, employeesPath);
            Console.WriteLine($"Должности экспортированы в: {positionsPath}");
            Console.WriteLine($"Работники экспортированы в: {employeesPath}");
        }
    }
}