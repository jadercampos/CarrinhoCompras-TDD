using NUnit.Framework;
using Moq;
using System.Linq;
using CarrinhoCompras;
using System.Collections.Generic;
using System;

namespace ClienteComprasTestes.Tests
{
    [TestFixture]
    public class ClienteTests
    {
        public IClienteRepositorio mockClienteRepositorio { get; private set; }
        [Test]
        public void ClienteCarrinho()
        {
            // Criando alguns dados de teste
            IList<Cliente> clientes = new List<Cliente>
             {
                 new Cliente { ClienteId = 1, Nome = "Edson Dionisio",
                 Email = "edson.dionisio@gmail.com", Telefone = "8197402803",
                 Endereco = "Rua dos testes Devmedia",
                 Profissao = "Desenvolvedor web",  DataCadastro = DateTime.Now },
                 new Cliente { ClienteId = 2, Nome = "Marilia Kessia",
                 Email = "mkessia@gmail.com", Telefone = "8197499820",
                 Endereco = "Rua dos testes Devmedia",
                 Profissao = "Professora de lingua inglesa",  DataCadastro = DateTime.Now },
                 new Cliente { ClienteId = 3, Nome = "Maitê Dionisio",
                 Email = "maite.dionisio@gmail.com", Telefone = "8197499820",
                 Endereco = "Rua dos testes Devmedia", Profissao = "Analista de softwares",  DataCadastro =DateTime.Now },
                 new Cliente { ClienteId = 4, Nome = "Maitê Dionisio",
                 Email = "maite.dionisio@gmail.com", Telefone = "8197499820",
                 Endereco = "Rua dos testes Devmedia", Profissao = "Analista de softwares",  DataCadastro = DateTime.Now },
                 new Cliente { ClienteId = 5, Nome = "Tatsu Yamashiro",
                 Email = "tatsu.yamashiro@gmail.com", Telefone = "8197490000",
                 Endereco = "Rua dos testes Devmedia", Profissao = "Designer de aplicações",  DataCadastro = DateTime.Now}
             };
            // Simulação com Moq para o repositório
            Mock<IClienteRepositorio> mockClienteRepositorio = new Mock<IClienteRepositorio>();
            // Retornando todos os clientes
            mockClienteRepositorio.Setup(clienteRepo => clienteRepo.BuscarTodos()).Returns(clientes);
            // Retornando os clientes com base no código
            mockClienteRepositorio.Setup(clienteRepo => clienteRepo.BuscaPorId(It.IsAny<int>())).Returns((int i) => clientes.Where(c => c.ClienteId == i).Single());
            // Retornando os clientes por nome
            mockClienteRepositorio.Setup(cliente => cliente.FindByNome(It.IsAny<string>())).Returns((string s) => clientes.Where(c => c.Nome == s).Single());
            // Verificação para a adição do cliente
            mockClienteRepositorio.Setup(cliente => cliente.Salvar(It.IsAny<Cliente>())).Returns(
               (Cliente cliente) =>
                {
                    cliente.DataCadastro = DateTime.Now;
                    if (cliente.ClienteId.Equals(default(int)))
                    {
                        cliente.ClienteId = clientes.Count() + 1;
                        clientes.Add(cliente);
                    }
                    else
                    {
                        var original = clientes.Where(c => c.ClienteId == cliente.ClienteId).Single();
                        if (original == null)
                        {
                            return false;
                        }
                        original.ClienteId = cliente.ClienteId;
                        original.Nome = cliente.Nome;
                        original.Email = cliente.Email;
                        original.Telefone = cliente.Telefone;
                        original.Endereco = cliente.Endereco;
                        original.Profissao = cliente.Profissao;
                        original.DataCadastro = cliente.DataCadastro;
                    }
                    return true;
                });
            this.mockClienteRepositorio = mockClienteRepositorio.Object;
        }
        [Test]
        public void RetornarClientePorNome()
        {
            // Encontrar cliente por nome
            Cliente clienteRetorno = this.mockClienteRepositorio.FindByNome("Edson Dionisio");
            Assert.IsNotNull(clienteRetorno);
            Assert.AreEqual(4, clienteRetorno.ClienteId);
        }
        [Test]
        public void TodosClientesRetornar()
        {
            // Buscar por todos os clientes
            IList<Cliente> clienteRetorno = this.mockClienteRepositorio.BuscarTodos();
            Assert.IsNotNull(clienteRetorno);
            Assert.AreEqual(5, clienteRetorno.Count);
        }
        [Test]
        public void ClientePodeSerInserido()
        {
            // Inserindo um novo cliente
            Cliente insereCliente = new Cliente
            { Nome = "Edson testes 2", Email = "edson.testes@testes.com", Telefone = "97402803", Endereco = "Rua dos testes", Profissao = "Testes", DataCadastro = DateTime.Now};
            // Salvando um novo cliente
            this.mockClienteRepositorio.Salvar(insereCliente);
        }
        [Test]
        public void ClientePodeSerAlterado()
        {
            // Buscando o cliente pelo Id
            Cliente clienteRetorno = this.mockClienteRepositorio.BuscaPorId(1);
            // Realizando a edição do nome do cliente para teste
            clienteRetorno.Nome = "Edson Dionisio 2";
            // Salvando as alterações realizadas para o cliente
            this.mockClienteRepositorio.Salvar(clienteRetorno);
            // Aqui verificamos se todas as informações foram trazidas certas
            Assert.AreEqual("Edson Dionisio 2", this.mockClienteRepositorio.BuscaPorId(1).Nome);
        }
    }
}