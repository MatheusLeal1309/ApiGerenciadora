using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GerenciadorApi.Models;
using GerenciadorApi.Controllers;

namespace GerenciadorApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Usuario> TB_USURARIO {get; set;}

        public DbSet<Tarefas> TB_TAREFAS {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("TB_USURARIO"); //definicao da tabela no banco de dados
            modelBuilder.Entity<Tarefas>().ToTable("TB_TAREFAS");

            modelBuilder.Entity<Tarefas>().HasData
        (
            new Tarefas() { Id = 1, Titulo = "Atividade", Descricao = "Realizar atividade de DS", Status = "Concluído", Prioridade = "Alta", TempoEstimado = 8,/* DataCriacao = new DateTime(2024, 4, 24), DataConclusao = new DateTime(2024, 4, 30)*/ },
            new Tarefas() { Id = 2, Titulo = "Trabalho", Descricao = "Terminar o TCC", Status = "Em Andamento", Prioridade = "Alta", TempoEstimado = 12,/* DataCriacao = new DateTime(2024, 2, 1), DataConclusao = new DateTime(2024, 6, 31)*/},
            new Tarefas() { Id = 3, Titulo = "Arrumar Coisas", Descricao = "Fazer a manutenção doméstica", Status = "Em Atraso", Prioridade = "Baixa", TempoEstimado = 9, /*DataCriacao = new DateTime(2024, 5, 9), DataConclusao = new DateTime(2024, 7, 16)*/},
            new Tarefas() { Id = 4, Titulo = "Organizar", Descricao = "Organizar tabela pessoal", Status = "Em Andamento", Prioridade = "Baixa", TempoEstimado = 1,/* DataCriacao = new DateTime(2024, 2, 6), DataConclusao = new DateTime(2024, 5, 5)*/ },
            new Tarefas() { Id = 5, Titulo = "Separar", Descricao = "Fazer a separação dos materiais", Status = "Concluído", Prioridade = "Média", TempoEstimado = 2, /*DataCriacao = new DateTime(2024, 4, 5), DataConclusao = new DateTime(2024, 5, 12)*/}
        );

        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveColumnType("varchar").HaveMaxLength(200);
        }
    }
}