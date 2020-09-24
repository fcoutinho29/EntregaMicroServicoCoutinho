using FIAP.IFOOD.PEDIDOS.DOMAIN.Pedido;
using FIAP.IFOOD.PEDIDOS.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace FIAP.IFOOD.PEDIDOS.REPOSITORY.PEDIDO
{
    public class PedidoRepository : IPedidoRepository
    {
        

        public void atualizar(PedidoModel pedido)
        {
            using (var context = new DBContext())
            {
                var _pedido = context.pedido.SingleOrDefault(x => x.idPedido == pedido.idPedido);
                if (_pedido != null)
                {
                    _pedido.produtos = pedido.produtos;
                    _pedido.valorTotal = pedido.valorTotal;

                    context.SaveChanges();
                }
            }
        }

        public bool cancelarPedido(int idPedido)
        {
            using (var context = new DBContext())
            {
                var _pedido = context.pedido.SingleOrDefault(x => x.idPedido == idPedido);
                if (_pedido != null)
                {
                    _pedido.status = StatusEnum.cancelado;
                    context.SaveChanges();

                    return true;
                }

                return false;
            }
        }

        public PedidoModel criar(PedidoModel pedido)
        {
            using (var context = new DBContext())
            {
               
                context.pedido.Add(pedido);
                context.SaveChanges();

                return pedido;
            }
        }


        public PedidoModel pedidoById(int idPedido)
        {
            using (var context = new DBContext())
            {
                return context.pedido.SingleOrDefault(x => x.idPedido == idPedido);
            }

        }
    }
}
