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
    public class PedidoBController : Controller
    {

        PedidoBebidaBL _pedidobBL = new PedidoBebidaBL();
        // GET: PedidoB
        public ActionResult Index()
        {
            return View();
        }
        //Devuelve la vista Guardar Pedido Bebida
        [HttpGet]
        public ActionResult GuardarPedidoBebida()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GuardarPedidoBebida(PedidoBebidaEN pPedidoBebidaEN)
        {
            string mensaje = "";
            if (pPedidoBebidaEN != null)
            {
                if (_pedidobBL.GuardarPedidoBebida(pPedidoBebidaEN) > 0)
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