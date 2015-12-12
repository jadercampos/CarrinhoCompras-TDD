using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

  namespace CarrinhoCompras
  {
      public class ItensCarrinho
      {
          public int Quantidade { get; set; }
          public string Descricao { get; set; }
          public decimal PrecoUnitario { get; set; }
          public ItensCarrinho(int qtd, string desc, decimal precoUnitario)
          {
              Quantidade = qtd;
              Descricao = desc;
              PrecoUnitario = precoUnitario;
          }
          // Método responsável por realizar o cálculo do valor do produto pela quantidade de itens.
          public decimal PrecoQtdProduto()
          {
              return Quantidade* PrecoUnitario;
          }
      }
  }