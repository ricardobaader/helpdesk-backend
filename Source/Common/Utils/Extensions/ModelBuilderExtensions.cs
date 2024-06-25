using Common.Domain.Rooms;
using Microsoft.EntityFrameworkCore;

namespace Common.Utils.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var roomsSeed = new List<Room>
            {
                new Room("A1", "Sala de Aula - Física Avançada"),
                new Room("A2", "Laboratório de Química Orgânica"),
                new Room("B1", "Sala de Conferências - Ciências Sociais"),
                new Room("B2", "Sala de Estudo em Grupo - Matemática"),
                new Room("C1", "Auditório - Palestras de História da Arte"),
                new Room("C2", "Sala de Projeção - Filmes de Literatura"),
                new Room("D1", "Sala de Seminários - Engenharia Civil"),
                new Room("D2", "Laboratório de Informática - Desenvolvimento de Software"),
                new Room("E1", "Biblioteca - Estudos de Filosofia"),
                new Room("E2", "Sala de Reuniões - Administração de Empresas")
            };

            modelBuilder.Entity<Room>().HasData(roomsSeed);
        }
    }
}
