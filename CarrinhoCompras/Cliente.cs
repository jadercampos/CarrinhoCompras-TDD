﻿using System;

namespace CarrinhoCompras
 {
     public class Cliente
     {
         public int ClienteId { get; set; }
         public string Email { get; set; }
         public string Endereco { get; set; }
         public string Telefone { get; set; }
         public string Nome { get; set; }
         public string Profissao { get; set; }
         public DateTime DataCadastro { get; set; }
     }
 }