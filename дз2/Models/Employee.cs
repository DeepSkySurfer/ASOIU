using System;

namespace ДЗ3_6.Models
{
    /// <summary>
    /// Работник (основная таблица, сторона «много»)
    /// </summary>
    public class Employee
    {
        /// <summary>Идентификатор работника (первичный ключ)</summary>
        public int Id { get; set; }

        /// <summary>Идентификатор должности (внешний ключ)</summary>
        public int PositionId { get; set; }

        /// <summary>Навигационное свойство: должность работника</summary>
        public Position? Position { get; set; }

        /// <summary>Имя работника</summary>
        public string Name { get; set; } = "";

        private decimal _salary;

        /// <summary>Зарплата в тыс. руб./мес. (не может быть отрицательной)</summary>
        public decimal Salary
        {
            get => _salary;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Зарплата не может быть отрицательной");
                _salary = value;
            }
        }
    }
}