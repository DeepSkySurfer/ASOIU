using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace ДЗ2_6
{
    /// <summary>
    /// Управление базой данных SQLite.
    /// Инкапсулирует все операции с БД: создание таблиц,
    /// импорт CSV, CRUD-операции, выполнение запросов для отчётов.
    /// </summary>
    class DatabaseManager
    {
        private string _connectionString;

        /// <summary>
        /// Конструктор. Принимает путь к файлу БД.
        /// </summary>
        public DatabaseManager(string dbPath)
        {
            _connectionString = $"Data Source={dbPath}";
        }

        // ========== Инициализация ==========

        /// <summary>
        /// Создаёт таблицы (если не существуют) и загружает CSV при первом запуске
        /// </summary>
        public void InitializeDatabase(string positionsCsvPath, string employeesCsvPath)
        {
            CreateTables();

            if (GetAllPositions().Count == 0 && File.Exists(positionsCsvPath))
            {
                ImportPositionsFromCsv(positionsCsvPath);
                Console.WriteLine($"[OK] Загружены должности из {positionsCsvPath}");
            }

            if (GetAllEmployees().Count == 0 && File.Exists(employeesCsvPath))
            {
                ImportEmployeesFromCsv(employeesCsvPath);
                Console.WriteLine($"[OK] Загружены работники из {employeesCsvPath}");
            }
        }

        /// <summary>Создание таблиц</summary>
        private void CreateTables()
        {
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS positions (
                    position_id INTEGER PRIMARY KEY AUTOINCREMENT,
                    position_name TEXT NOT NULL
                );
                CREATE TABLE IF NOT EXISTS employees (
                    employee_id INTEGER PRIMARY KEY AUTOINCREMENT,
                    position_id INTEGER NOT NULL,
                    employee_name TEXT NOT NULL,
                    employee_salary REAL NOT NULL,
                    FOREIGN KEY (position_id) REFERENCES positions(position_id)
                );";
            cmd.ExecuteNonQuery();
        }

        /// <summary>Импорт должностей из CSV</summary>
        private void ImportPositionsFromCsv(string path)
        {
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();
            string[] lines = File.ReadAllLines(path);
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(';');
                if (parts.Length < 2) continue;
                var cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO positions (position_id, position_name) VALUES (@id, @name)";
                cmd.Parameters.AddWithValue("@id", int.Parse(parts[0]));
                cmd.Parameters.AddWithValue("@name", parts[1]);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>Импорт работников из CSV</summary>
        private void ImportEmployeesFromCsv(string path)
        {
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();
            string[] lines = File.ReadAllLines(path);
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(';');
                if (parts.Length < 4) continue;

                string salaryStr = parts[3].Replace(',', '.');
                decimal salary = decimal.Parse(salaryStr, CultureInfo.InvariantCulture);

                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    INSERT INTO employees (employee_id, position_id, employee_name, employee_salary) 
                    VALUES (@id, @positionId, @name, @salary)";
                cmd.Parameters.AddWithValue("@id", int.Parse(parts[0]));
                cmd.Parameters.AddWithValue("@positionId", int.Parse(parts[1]));
                cmd.Parameters.AddWithValue("@name", parts[2]);
                cmd.Parameters.AddWithValue("@salary", salary);
                cmd.ExecuteNonQuery();
            }
        }

        // ========== Чтение данных ==========

        /// <summary>Получить все должности</summary>
        public List<Position> GetAllPositions()
        {
            var result = new List<Position>();
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT position_id, position_name FROM positions ORDER BY position_id";
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Position(reader.GetInt32(0), reader.GetString(1)));
            }
            return result;
        }

        /// <summary>Получить всех работников</summary>
        public List<Employee> GetAllEmployees()
        {
            var result = new List<Employee>();
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT employee_id, position_id, employee_name, employee_salary FROM employees ORDER BY employee_id";
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Employee(
                    reader.GetInt32(0),
                    reader.GetInt32(1),
                    reader.GetString(2),
                    reader.GetDecimal(3)));
            }
            return result;
        }

        /// <summary>Получить работника по Id</summary>
        public Employee GetEmployeeById(int id)
        {
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT employee_id, position_id, employee_name, employee_salary FROM employees WHERE employee_id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Employee(
                    reader.GetInt32(0),
                    reader.GetInt32(1),
                    reader.GetString(2),
                    reader.GetDecimal(3));
            }
            return null;
        }

        // ========== Изменение данных ==========

        /// <summary>Добавить работника</summary>
        public void AddEmployee(Employee emp)
        {
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                INSERT INTO employees (position_id, employee_name, employee_salary) 
                VALUES (@positionId, @name, @salary)";
            cmd.Parameters.AddWithValue("@positionId", emp.PositionId);
            cmd.Parameters.AddWithValue("@name", emp.Name);
            cmd.Parameters.AddWithValue("@salary", emp.Salary);
            cmd.ExecuteNonQuery();
        }

        /// <summary>Обновить данные работника</summary>
        public void UpdateEmployee(Employee emp)
        {
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                UPDATE employees 
                SET position_id = @positionId, employee_name = @name, employee_salary = @salary 
                WHERE employee_id = @id";
            cmd.Parameters.AddWithValue("@id", emp.Id);
            cmd.Parameters.AddWithValue("@positionId", emp.PositionId);
            cmd.Parameters.AddWithValue("@name", emp.Name);
            cmd.Parameters.AddWithValue("@salary", emp.Salary);
            cmd.ExecuteNonQuery();
        }

        /// <summary>Удалить работника по Id</summary>
        public void DeleteEmployee(int id)
        {
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM employees WHERE employee_id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        // ========== Выполнение произвольного запроса (для отчётов) ==========

        /// <summary>
        /// Выполняет SQL-запрос и возвращает имена столбцов и строки результата.
        /// </summary>
        public (string[] columns, List<string[]> rows) ExecuteQuery(string sql)
        {
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            using var reader = cmd.ExecuteReader();

            string[] columns = new string[reader.FieldCount];
            for (int i = 0; i < reader.FieldCount; i++)
                columns[i] = reader.GetName(i);

            var rows = new List<string[]>();
            while (reader.Read())
            {
                string[] row = new string[reader.FieldCount];
                for (int i = 0; i < reader.FieldCount; i++)
                    row[i] = reader.GetValue(i)?.ToString() ?? "";
                rows.Add(row);
            }
            return (columns, rows);
        }

        // ========== [Группа Б] Экспорт в CSV ==========

        public void ExportToCsv(string positionsPath, string employeesPath)
        {
            var positionsLines = new List<string>();
            positionsLines.Add("position_id;position_name");
            foreach (var pos in GetAllPositions())
                positionsLines.Add($"{pos.Id};{pos.Name}");
            File.WriteAllLines(positionsPath, positionsLines.ToArray());

            var employeesLines = new List<string>();
            employeesLines.Add("employee_id;position_id;employee_name;employee_salary");
            foreach (var emp in GetAllEmployees())
                employeesLines.Add($"{emp.Id};{emp.PositionId};{emp.Name};{emp.Salary.ToString(CultureInfo.InvariantCulture)}");
            File.WriteAllLines(employeesPath, employeesLines.ToArray());
        }

        // ========== [Группа Г] Фильтр по должности ==========

        public List<Employee> GetEmployeesByPosition(int positionId)
        {
            var result = new List<Employee>();
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT employee_id, position_id, employee_name, employee_salary 
                FROM employees WHERE position_id = @positionId ORDER BY employee_name";
            cmd.Parameters.AddWithValue("@positionId", positionId);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Employee(
                    reader.GetInt32(0),
                    reader.GetInt32(1),
                    reader.GetString(2),
                    reader.GetDecimal(3)));
            }
            return result;
        }
    }
}