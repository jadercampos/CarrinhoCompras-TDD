using NUnit.Framework;
using Moq;
using System;

namespace CarrinhoCompras.Tests
 {
     [TestFixture]
     public class CarrinhoRepositorio
     {
         private MockRepository _mockRepositorio;
         private Mock<ICarrinhoDatabase> _carrinhoBancoDados;
         private Carrinho carrinho;
         [SetUp]
         public void SetUp()
         {
             _mockRepositorio = new MockRepository(MockBehavior.Strict);
             _carrinhoBancoDados = _mockRepositorio.Create<ICarrinhoDatabase>();
             carrinho = new Carrinho();
         }
          [Test]
         public void SalvarCarrinho()
         {
             _carrinhoBancoDados.Setup(c => c.InsereCarrinho(carrinho)).Returns(1001);
             var repositorio = new carrinhoDBRepositorio(_carrinhoBancoDados.Object);
             var resultado = repositorio.salvaCarrinho(carrinho);
             Assert.AreEqual(resultado, 1001);
         }
         [Test]
         public void ErroAoSalvarCarrinhoCompras()
         {
      _carrinhoBancoDados.Setup(c => c.InsereCarrinho(carrinho)).Throws<ApplicationException>();
             var repositorio = new carrinhoDBRepositorio(_carrinhoBancoDados.Object);
             var resultado = repositorio.salvaCarrinho(carrinho);
             Assert.AreEqual(resultado, 0);
         }
     }
     public class carrinhoDBRepositorio
     {
         private ICarrinhoDatabase _carrinhoDB;
         public carrinhoDBRepositorio(ICarrinhoDatabase carrinhoBancoDados)
         {
             _carrinhoDB = carrinhoBancoDados;
         }
         public long salvaCarrinho(Carrinho carrinhoCompras)
         {
             long retorno;
             try
             {
                 retorno = _carrinhoDB.InsereCarrinho(carrinhoCompras);
             }
             catch (Exception ex)
             {
                 retorno = 0;
             }
             return retorno;
         }
     }
 }