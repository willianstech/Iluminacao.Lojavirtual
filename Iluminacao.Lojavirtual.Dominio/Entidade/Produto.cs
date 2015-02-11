﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace Iluminacao.Lojavirtual.Dominio.Entidade
{
    public class Produto
    {
        [HiddenInput(DisplayValue = false)]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Digite o nome do produto" )]
        public string Nome { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Digite a descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage="Digite o valor")]
        [Range(0.01, double.MaxValue, ErrorMessage="Valor inválido")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Digite a categoria")]
        public string Categoria { get; set; }
    }
}
