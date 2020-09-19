using System;
using System.Collections.Generic;
using System.Collections;

using System.Linq;
using System.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace ef_async.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListaFofaController:ControllerBase
    {
        Business.ListaFofaBusiness Busi=new Business.ListaFofaBusiness();
        Utils.ConversorListaFofa conversor=new Utils.ConversorListaFofa();

        [HttpGet]
        public async Task<List<Models.Response.ListaFofaResponse>> Listar()
        {
            List<Models.TbListaFofa> tbLista= await Busi.ValidarListaFofa();
            List<Models.Response.ListaFofaResponse> response= await Task.Run(()=>conversor.ParaResponse(tbLista));

            return response;
        }
        
    }
}