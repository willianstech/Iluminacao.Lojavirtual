﻿using System.Web.Mvc;

namespace Iluminacao.LojaVirtual.Web.Areas.Administrativo
{
    public class AdministrativoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Administrativo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Administrativo_default",
                "Administrativo/{controller}/{action}/{id}",
                new { controller= "Produto", action = "Index", id = UrlParameter.Optional },
                new[] { "Iluminacao.LojaVirtual.Web.Areas.Administrativo.Controllers" }
            );
        }
    }
}