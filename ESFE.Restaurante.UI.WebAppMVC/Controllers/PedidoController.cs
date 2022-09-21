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
    public class PedidoController : Controller
    {
        PedidoBL _pedidoBL = new PedidoBL();
        // GET: Pedido
        public ActionResult Index()
        {
            return View();
        }
        //Devuelve la vista Guardar Pedido
        [HttpGet]
        public ActionResult GuardarPedido()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GuardarPedido(PedidoEN pPedidoEN)
        {
            string mensaje = "";
            if (pPedidoEN != null)
            {
                if (_pedidoBL.GuardarPedido(pPedidoEN) > 0)
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