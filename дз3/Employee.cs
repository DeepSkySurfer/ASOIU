using System;

namespace ДЗ2_6
{
    /// <summary>
    /// Работник (основная таблица, сторона «много»)
    /// </summary>
    class Employee
    {
        /// <summary>Идентификатор работника</summary>
        public int Id { get; set; }

        /// <summary>Идентификатор должности (внешний ключ)</summary>
        public int PositionId { get; set; }

        /// <summary>Имя работника</summary>
        public string Name { get; set; }

        private decimal _salary;

        /// <summary>
        /// Зарплата в тыс. руб./мес. (не может быть отрицательной)
        /// </summary>
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

        /// <summary>Конструктор с параметрами</summary>
        public Employee(int id, int positionId, string name, decimal salary)
        {
            Id = id;
            PositionId = positionId;
            Name = name;
            Salary = salary;
        }

        /// <summary>Конструктор по умолчанию</summary>
        public Employee() : this(0, 0, "", 0)
        {
        }

        public override string ToString() => $"[{Id}] {Name}, должность #{PositionId}, зарплата: {Salary} тыс. руб.";
    }
}