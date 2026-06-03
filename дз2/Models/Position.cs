using System.Collections.Generic;

namespace ДЗ3_6.Models
{
    /// <summary>
    /// Должность (справочная таблица, сторона «один»)
    /// </summary>
    public class Position
    {
        /// <summary>Идентификатор должности (первичный ключ)</summary>
        public int Id { get; set; }

        /// <summary>Название должности</summary>
        public string Name { get; set; } = "";

        /// <summary>Навигационное свойство: работники этой должности</summary>
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}