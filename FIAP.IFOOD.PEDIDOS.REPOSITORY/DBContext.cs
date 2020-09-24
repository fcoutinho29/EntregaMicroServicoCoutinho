using FIAP.IFOOD.PEDIDOS.DOMAIN.Pedido;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FIAP.IFOOD.PEDIDOS.REPOSITORY
{
    class DBContext: DbContext
    {
        
    

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer("");
            }
        }

        public DbSet<PedidoModel> pedido { get; set; }
    }
}
