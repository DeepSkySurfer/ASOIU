using Microsoft.EntityFrameworkCore;
using ДЗ3_6.Models;

namespace ДЗ3_6.Data
{
    /// <summary>
    /// Контекст базы данных для работы с должностями и работниками
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>Таблица должностей</summary>
        public DbSet<Position> Positions { get; set; }

        /// <summary>Таблица работников</summary>
        public DbSet<Employee> Employees { get; set; }

        /// <summary>Настройка подключения к БД</summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=employees.db");
        }

        /// <summary>Настройка моделей и начальных данных</summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Настройка связи один-ко-многим
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Position)
                .WithMany(p => p.Employees)
                .HasForeignKey(e => e.PositionId)
                .OnDelete(DeleteBehavior.Restrict);

            // Начальные данные: должности (5 записей)
            modelBuilder.Entity<Position>().HasData(
                new Position { Id = 1, Name = "Директор" },
                new Position { Id = 2, Name = "Менеджер" },
                new Position { Id = 3, Name = "Разработчик" },
                new Position { Id = 4, Name = "Тестировщик" },
                new Position { Id = 5, Name = "Аналитик" }
            );

            // Начальные данные: работники (14 записей)
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, PositionId = 1, Name = "Иванов Иван", Salary = 250.5m },
                new Employee { Id = 2, PositionId = 2, Name = "Петров Петр", Salary = 120.0m },
                new Employee { Id = 3, PositionId = 3, Name = "Сидоров Алексей", Salary = 150.0m },
                new Employee { Id = 4, PositionId = 3, Name = "Козлова Мария", Salary = 145.0m },
                new Employee { Id = 5, PositionId = 4, Name = "Новикова Анна", Salary = 90.0m },
                new Employee { Id = 6, PositionId = 2, Name = "Смирнов Дмитрий", Salary = 110.0m },
                new Employee { Id = 7, PositionId = 3, Name = "Васильев Егор", Salary = 160.0m },
                new Employee { Id = 8, PositionId = 5, Name = "Морозова Елена", Salary = 100.0m },
                new Employee { Id = 9, PositionId = 1, Name = "Кузнецов Сергей", Salary = 300.0m },
                new Employee { Id = 10, PositionId = 4, Name = "Соколова Ольга", Salary = 85.0m },
                new Employee { Id = 11, PositionId = 5, Name = "Лебедев Андрей", Salary = 105.0m },
                new Employee { Id = 12, PositionId = 2, Name = "Попова Ирина", Salary = 115.0m },
                new Employee { Id = 13, PositionId = 3, Name = "Павлов Илья", Salary = 170.0m },
                new Employee { Id = 14, PositionId = 4, Name = "Федорова Анна", Salary = 95.0m }
            );
        }
    }
}