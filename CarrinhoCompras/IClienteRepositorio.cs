using System.Collections.Generic;

namespace CarrinhoCompras
{
    public interface IClienteRepositorio
    {
        IList<Cliente> BuscarTodos();
        Cliente FindByNome(string clienteNome);
        Cliente BuscaPorId(int clienteId);
        bool Salvar(Cliente cliente);
    }
}