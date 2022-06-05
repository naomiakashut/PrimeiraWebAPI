using System;
using System.ComponentModel.DataAnnotations;

namespace PrimeiraWebAPI.Domain.DTO
{
    public class TarefaUpdateRequestConcluido
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Indique para concluir a tarefa!")]
        public bool Concluido { get; set; }
    }
    public class TarefaUpdateRequestPrioridade
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Indique para priorizar a tarefa!")]
        public int? Prioridade { get; set; }
    }
}
