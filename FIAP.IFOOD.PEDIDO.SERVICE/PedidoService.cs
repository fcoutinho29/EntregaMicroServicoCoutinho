using FIAP.IFOOD.PEDIDOS.DOMAIN.Pedido;
using FIAP.IFOOD.PEDIDOS.REPOSITORY.PEDIDO;
using System;

namespace FIAP.IFOOD.PEDIDO.SERVICE
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository pedidoRepository;

        public PedidoService()
        {
            pedidoRepository = new PedidoRepository();
        }
        public void atualizar(PedidoModel pedido)
        {
            pedidoRepository.atualizar(pedido);
        }

        public bool cancelarPedido(int idPedido)
        {
            return pedidoRepository.cancelarPedido(idPedido);
        }

        public PedidoModel criar(PedidoModel pedido)
        {
            return pedidoRepository.criar(pedido);
        }

        public PedidoModel pedidoById(int idPedido)
        {
            return pedidoRepository.pedidoById(idPedido);
        }
    }
}
