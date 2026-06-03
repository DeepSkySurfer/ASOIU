using System;

namespace ДЗ2_6
{
    /// <summary>
    /// Должность (справочная таблица, сторона «один»)
    /// </summary>
    class Position
    {
        /// <summary>Идентификатор должности</summary>
        public int Id { get; set; }

        /// <summary>Название должности</summary>
        public string Name { get; set; }

        /// <summary>Конструктор с параметрами</summary>
        public Position(int id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>Конструктор по умолчанию</summary>
        public Position() : this(0, "")
        {
        }

        public override string ToString() => $"[{Id}] {Name}";
    }
}