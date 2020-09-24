using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FIAP.IFOOD.PEDIDO.SERVICE;
using FIAP.IFOOD.PEDIDOS.DOMAIN.Pedido;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.IFOOD.PEDIDO.MICROSERVICO.Controllers
{
    [Route("api/pedidos")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService pedidoService;

        public PedidoController()
        {
            pedidoService = new PedidoService();
        }

       [HttpPost]
       public async Task<IActionResult> criar([FromBody]PedidoModel pedido)
       {
            try
            {
                if(!ModelState.IsValid)
                    return BadRequest(ModelState);
                var _criar = pedidoService.criar(pedido);

                return Ok(pedido);
            }
            catch (Exception ex)
            {

                return BadRequest(new { erro = ex.Message});
            }
        }


        [HttpPut]
        public async Task<IActionResult> atualizar([FromBody] PedidoModel pedido)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
               
                pedidoService.atualizar(pedido);

                return Ok(pedido);
            }
            catch (Exception ex)
            {

                return BadRequest(new { erro = ex.Message });
            }
        }

        [HttpGet]
        [Route("{idPedido}")]
        public async Task<IActionResult> get(int idPedido)
        {
            try
            {
                var _pedido = pedidoService.pedidoById(idPedido);
                if (_pedido is null)
                    return NotFound();

                return Ok(_pedido);
            }
            catch (Exception ex)
            {

                return BadRequest(new { erro = ex.Message });
            }
        }

        [HttpPut]
        [Route("cancelar/{idPedido}")]
        public async Task<IActionResult> cancelar(int idPedido)
        {
            try
            {
                
                return Ok(pedidoService.cancelarPedido(idPedido));
            }
            catch (Exception ex)
            {

                return BadRequest(new { erro = ex.Message });
            }
        }
    }
}
