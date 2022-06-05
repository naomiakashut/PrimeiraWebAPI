using Microsoft.EntityFrameworkCore;
using PrimeiraWebAPI.DAL;
using PrimeiraWebAPI.Domain.DTO;
using PrimeiraWebAPI.Domain.Entity;
using PrimeiraWebAPI.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimeiraWebAPI.Services
{
	public class TarefasService
	{

		private readonly AppDbContext _dbContext;
		public TarefasService(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IEnumerable<TarefaResponse> ListarTodos()
		{
			// select  * from albuns x
			// left join avaliacoes a on a.idAlbum = x.idAlbum

			var retornoDoBanco = _dbContext.Tarefas.ToList();

			// Conveter para AlbumResponse
			IEnumerable<TarefaResponse> lista = retornoDoBanco.Select(x => new TarefaResponse(x));

			return lista;
		}
		public ServiceResponse<TarefaResponse> PesquisarPorId(int id)
		{
			// Lambda Expression / Expressões lambda
			// Operação em conjunto de dados
			// select top 1 * from albuns x
			// left join avaliacoes a on a.idAlbum = x.idAlbum
			// where x.IdAlbum == id 
			var resultado = _dbContext.Tarefas.FirstOrDefault(x => x.IdTarefa == id);
			if (resultado == null)
				return new ServiceResponse<TarefaResponse>("Não encontrado!");
			else
				return new ServiceResponse<TarefaResponse>(new TarefaResponse(resultado));

		}
		public ServiceResponse<Tarefa> CadastrarNovo(TarefaCreateRequest model)
		{
			//Regra
			
			/*if (!model.AnoLancamento.HasValue || model.AnoLancamento < 1950 || model.AnoLancamento > DateTime.Today.Year)
			{
				return new ServiceResponse<Album>("Somente é possível cadastrar albuns lançados entre 1950 e o ano atual");
			}*/

			//tudo certo, só cadastrar
			var novaTarefa = new Tarefa()
			{
				Titulo = model.Titulo,
				Descricao = model.Descricao,
				Prioridade = model.Prioridade.Value
			};

			_dbContext.Add(novaTarefa);
			_dbContext.SaveChanges();

			return new ServiceResponse<Tarefa>(novaTarefa);
		}
		public ServiceResponse<Tarefa> Editar(int id, TarefaUpdateRequestConcluido model)
		{
			// select top 1 * from albuns x where x.IdAlbum == id 
			var resultado = _dbContext.Tarefas.FirstOrDefault(x => x.IdTarefa == id);

			if (resultado == null)
				return new ServiceResponse<Tarefa>("Tarefa não encontrada!");

			//tudo certo, só atualizar
			resultado.Concluido = model.Concluido;
			_dbContext.Tarefas.Add(resultado).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return new ServiceResponse<Tarefa>(resultado);
		}
		public ServiceResponse<Tarefa> Editar(int id, TarefaUpdateRequestPrioridade model)
		{
			// select top 1 * from albuns x where x.IdAlbum == id 
			var resultado = _dbContext.Tarefas.FirstOrDefault(x => x.IdTarefa == id);

			if (resultado == null)
				return new ServiceResponse<Tarefa>("Tarefa não encontrada!");

			if (!model.Prioridade.HasValue || model.Prioridade < 1 || model.Prioridade > 5)
			{
				return new ServiceResponse<Tarefa>("Estabeleça a prioridade de 1 a 5.");
			}

			//tudo certo, só atualizar

			resultado.Prioridade = model.Prioridade;
			_dbContext.Tarefas.Add(resultado).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return new ServiceResponse<Tarefa>(resultado);
		}
		public ServiceResponse<bool> Deletar(int id)
		{
			// select top 1 * from albuns x where x.IdAlbum == id 
			var resultado = _dbContext.Tarefas.FirstOrDefault(x => x.IdTarefa == id);

			if (resultado == null)
				return new ServiceResponse<bool>("Tarefa não encontrada!");

			//tudo certo, só atualizar
			_dbContext.Tarefas.Remove(resultado);
			_dbContext.SaveChanges();

			return new ServiceResponse<bool>(true);
		}
	}
}
