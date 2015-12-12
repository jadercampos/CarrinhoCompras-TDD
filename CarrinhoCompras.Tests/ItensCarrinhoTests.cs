using System;
using NUnit.Framework;
namespace CarrinhoCompras.Tests
{
    [TestFixture]
    public class ItensCarrinhoTests
    {
        private int _quantidade;
        private string _descricao;
        private ItensCarrinho _itemCarrinho;
        private decimal _precoUnitario;
        private decimal _precoItem;
        [SetUp]
        public void SetUp()
        {
            _quantidade = 2;
            _precoUnitario = 3.00m;
            _precoItem = _quantidade * _precoUnitario;
            _descricao = "Teste de descrição do produto";
            _itemCarrinho = new ItensCarrinho(_quantidade, _descricao, _precoUnitario);
        }
        [Test]
        public void QtdItens()
        {
            Assert.AreEqual(_itemCarrinho.Quantidade, _quantidade);
        }
        [Test]
        public void DescricaoItem()
        {
            Assert.AreEqual(_itemCarrinho.Descricao, _descricao);
        }
        [Test]
        public void PrecoUnitario()
        {
            Assert.AreEqual(_itemCarrinho.PrecoUnitario, _precoUnitario);
        }
        [Test]
        public void ValorProdutoQtd()
        {
            var valorAtual = _itemCarrinho.PrecoQtdProduto();
            Assert.AreEqual(valorAtual, _precoItem);
        }
    }
}