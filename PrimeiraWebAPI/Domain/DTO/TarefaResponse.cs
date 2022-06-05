using PrimeiraWebAPI.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeiraWebAPI.Domain.DTO
{
    public class TarefaResponse
    {
        public TarefaResponse(Tarefa tarefa)
        {
            IdTarefa = tarefa.IdTarefa;
            Titulo = tarefa.Titulo;
            Descricao = tarefa.Descricao;
            Concluido = tarefa.Concluido;
            Prioridade = tarefa.Prioridade;

            /*if (album.Avaliacoes != null && album.Avaliacoes.Any())
            {

                Avaliacoes = new List<AvaliacaoResponse>();
                Avaliacoes.AddRange(album.Avaliacoes.Select(x => new AvaliacaoResponse(x)));
                AvaliacaoMedia = album.Avaliacoes.Average(x => x.Nota).ToString("F2");
            }*/
        }

        public int IdTarefa { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public bool Concluido { get; set; }
        public int? Prioridade { get; set; }
        //public List<AvaliacaoResponse> Avaliacoes { get; set; }
    }

}

