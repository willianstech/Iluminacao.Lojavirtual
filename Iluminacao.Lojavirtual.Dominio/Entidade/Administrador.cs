using System;
using System.ComponentModel.DataAnnotations;

namespace Iluminacao.Lojavirtual.Dominio.Entidade
{
    public class Administrador
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o Login: ")]
        [Display(Name = "Login: ")]
        public string Login  { get; set; }

        [Required(ErrorMessage = "Digite a Senha: ")]
        [DataType(DataType.Password)]
        public string   Senha { get; set; }

        public DateTime UltimoAcesso { get; set; }
    }
}
