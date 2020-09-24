using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIAP.IFOOD.PEDIDOS.DOMAIN.Pedido
{
    [Table("pedidos")]
    public class PedidoModel
    {
       
        public int idPedido { get; set; }
        [Required(ErrorMessage = "quantidadeTotal")]
        public int quantidadeTotal { get; set; }
        [Required(ErrorMessage = "valorTotal")]
        public double valorTotal { get; set; }
        [Required(ErrorMessage = "statusEnum")]
        public StatusEnum status { get; set; }
        [Required(ErrorMessage = "produtos")]
        public List<ProdutoModel> produtos{get;set;}
    } 
    public class ProdutoModel
    {
        public int idProduto { get; set; }
        public string descricao { get; set; }
        public int quantidade { get; set; }
        public double valor { get; set; }
    }
}
