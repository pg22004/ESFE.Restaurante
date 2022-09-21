using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//Agregar
using ESFE.Restaurante.EN;
using ESFE.Restaurante.BL;
namespace ESFE.Restaurante.UI.WebAppMVC.Controllers
{
    public class PedidoCController : Controller
    {
        PedidoComidaBL _pedidocBL = new PedidoComidaBL();
        // GET: PedidoC
        public ActionResult Index()
        {
            return View();
        }
        //Devuelve la vista Guardar Pedido Comida
        [HttpGet]
        public ActionResult GuardarPedidoComida()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GuardarPedidoComida(PedidoComidaEN pPedidoComidaEN)
        {
            string mensaje = "";
            if (pPedidoComidaEN != null)
            {
                if (_pedidocBL.GuardarPedidoComida(pPedidoComidaEN) > 0)
                {
                    mensaje = "¡Registro guardado!";
                }
                else
                {
                    mensaje = "No se guardo el registro";
                }
            }
            else
            {
                mensaje = "No dejar campos vacios";
            }
            return Json(new { Mensaje = mensaje, JsonRequestBehavior.AllowGet });

        }
    }
}