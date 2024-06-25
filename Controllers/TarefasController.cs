using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GerenciadorApi.Data;
using GerenciadorApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefasController : ControllerBase
    {
        private readonly DataContext _context;

        public TarefasController(DataContext context)
        {
            _context = context;
        }
        private static List<Tarefas> Tarefa = new List<Tarefas>()
        {   
            new Tarefas() { Id = 1, Titulo = "Atividade", Descricao = "Realizar atividade de DS", Status = "Concluído", Prioridade = "Alta", TempoEstimado = 8, /*DataCriacao = new DateTime(2024, 4, 24), DataConclusao = new DateTime(2024, 4, 30)*/ },
            new Tarefas() { Id = 2, Titulo = "Trabalho", Descricao = "Terminar o TCC", Status = "Em Andamento", Prioridade = "Alta", TempoEstimado = 12,/* DataCriacao = new DateTime(2024, 2, 1), DataConclusao = new DateTime(2024, 6, 31)*/ },
            new Tarefas() { Id = 3, Titulo = "Arrumar Coisas", Descricao = "Fazer a manutenção doméstica", Status = "Em Atraso", Prioridade = "Baixa", TempoEstimado = 9,/* DataCriacao = new DateTime(2024, 5, 9), DataConclusao = new DateTime(2024, 7, 16)*/ },
            new Tarefas() { Id = 4, Titulo = "Organizar", Descricao = "Organizar tabela pessoal", Status = "Em Andamento", Prioridade = "Baixa", TempoEstimado = 1, /*DataCriacao = new DateTime(2024, 2, 6), DataConclusao = new DateTime(2024, 5, 5)*/ },
            new Tarefas() { Id = 5, Titulo = "Separar", Descricao = "Fazer a separação dos materiais", Status = "Concluído", Prioridade = "Média", TempoEstimado = 2, /* DataCriacao = new DateTime(2024, 4, 5), DataConclusao = new DateTime(2024, 5, 12)*/ }
        };

        [HttpGet("{id}")]
        public async Task<ActionResult> GetSingle(int id)
        {
            try
            {
                Tarefas t = await _context.TB_TAREFAS.FirstOrDefaultAsync(xBusca => xBusca.Id == id);
                return Ok(t);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Tarefas> lista = await _context.TB_TAREFAS.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Add(Tarefas novaTarefa)
        {
            try
            {
                if (novaTarefa == null)
                {
                    throw new Exception("Dado nulo não permitido");
                }
                await _context.TB_TAREFAS.AddAsync(novaTarefa);
                await _context.SaveChangesAsync();

                return Ok(novaTarefa.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update(Tarefas novaTarefa)
        {
            try
            {
                if(novaTarefa.TempoEstimado > 24)
                {
                    throw new System.Exception("Tempo Acima do limite.");
                }
                _context.TB_TAREFAS.Update(novaTarefa);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Tarefas tRemover = await _context.TB_TAREFAS.FirstOrDefaultAsync(t => t.Id == id);
                _context.TB_TAREFAS.Remove(tRemover);
                int linhasAfetadas = await _context.SaveChangesAsync();
                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}