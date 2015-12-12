 using System.Collections.Generic;
 namespace CarrinhoCompras
 {
     public class Carrinho
     {
         public List<ItensCarrinho> itens { get; set; }
         public Carrinho()
         {
             itens = new List<ItensCarrinho>();
         }
         public void AdicionaItem(ItensCarrinho item)
         {
            //  Verifica se a lista já contém um item igual adicionado
             if (itens.Contains(item)) { return; }
             itens.Add(item);
         }
         public void RemoveItem(ItensCarrinho item)
         {
             itens.Remove(item);
         }
         public decimal valorTotalCompras()
         {
             decimal ValorTotal = 0m;
             foreach(var item in itens)
             {
                 ValorTotal += item.PrecoQtdProduto();
             }
             return ValorTotal;
         }
     }
 }