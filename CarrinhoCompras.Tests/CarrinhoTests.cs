 using System;
 using System.Text;
 using System.Collections.Generic;
 using NUnit.Framework;
 namespace CarrinhoCompras.Tests
 {
     [TestFixture]
     public class CarrinhoTests
     {
         private Carrinho _carrinho;
         private ItensCarrinho _itens;
         private ItensCarrinho _itens2;
         [SetUp]
         public void SetUp()
         {
             _carrinho = new Carrinho();
             _itens = new ItensCarrinho(3, "Testes", 8.00m);
             _itens2 = new ItensCarrinho(4, "Testes 2", 6.00m);
         }
         [Test]
         public void CarrinhoComZeroItems()
         {
             Assert.AreEqual(_carrinho.itens.Count, 0);
         }
         [Test]
         public void AdicionaItemCarrinho()
         {
             _carrinho.AdicionaItem(_itens);
             Assert.That(_carrinho.itens, Has.Member(_itens));
         }
         [Test]
         public void ContemItemDuplicado()
         {
             _carrinho.AdicionaItem(_itens);
             _carrinho.AdicionaItem(_itens);
             Assert.That(_carrinho.itens.Count, Is.EqualTo(1));
         }
         [Test]
         public void RemoveItemCarrinho()
         {
             _carrinho.AdicionaItem(_itens);
             _carrinho.RemoveItem(_itens);
             Assert.That(_carrinho.itens.Count, Is.EqualTo(0));
         }
         [Test]
         public void ValorTotalCarrinho()
         {
             _carrinho.AdicionaItem(_itens);
             _carrinho.AdicionaItem(_itens2);
             var _somaProdutos = _carrinho.valorTotalCompras();
             Assert.That(_somaProdutos, Is.EqualTo(48.00m));
         }
     }
 }