using System;
using System.ComponentModel.DataAnnotations;

namespace PrimeiraWebAPI.Domain.DTO
{
    public class TarefaCreateRequest
    {
		[Required]
		public string Titulo { get; set; }
		public string Descricao { get; set; }
		[Required(AllowEmptyStrings = false)]
		public bool Concluido { get; set; }
		[Range(1, 5,ErrorMessage = "O valor de {0} deve estar entre {1} e {2}.")]
		public int? Prioridade { get; set; }
		//int? e Required????
		//Sem isso este erro nunca vai acontecer.
		//Com um int normal, o valor padrão vai sempre ser 0
		//e nunca vamos saber se é o valor passado ou o padrão
	}
}
