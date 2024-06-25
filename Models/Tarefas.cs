using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorApi.Models
{
    public class Tarefas
    {
        public int Id { get; set;}

        public string Titulo {get; set; } = string.Empty;

        public string Descricao {get; set; } = string.Empty;

        public string Status {get; set; } = string.Empty;

        public string Prioridade {get; set; } = string.Empty;

        public decimal TempoEstimado {get; set; }

        public DateTime DataCriacao {get; set; }

        public DateTime DataConclusao {get; set; }
    }
}