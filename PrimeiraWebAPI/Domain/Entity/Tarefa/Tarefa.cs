using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PrimeiraWebAPI.Domain.Entity
{
      
        [Table("Tarefas")]
        public class Tarefa
        {
            [Key]
            public int IdTarefa { get; set; }
            [Required]
            [StringLength(255)]
            public string Titulo { get; set; }
            [StringLength(255)]
            public string Descricao { get; set; }
            public bool Concluido { get; set; } = false;
            [Range(1, 5, ErrorMessage = "O valor de {0} deve estar entre {1} e {2}.")]
            public int? Prioridade { get; set; }
        //public virtual ICollection<Avaliacao> Avaliacoes { get; set; }

    }
    
}
