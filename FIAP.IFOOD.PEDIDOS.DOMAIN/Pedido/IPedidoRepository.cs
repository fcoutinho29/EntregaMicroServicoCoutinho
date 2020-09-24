using System;
using System.Collections.Generic;
using System.Text;

namespace FIAP.IFOOD.PEDIDOS.DOMAIN.Pedido
{
    public interface IPedidoRepository
    {
        PedidoModel criar(PedidoModel pedido);
        void atualizar(PedidoModel pedido);
        PedidoModel pedidoById(int idPedido);
        bool cancelarPedido(int idPedido);

    }
}
