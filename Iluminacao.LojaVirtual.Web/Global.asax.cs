﻿using Iluminacao.Lojavirtual.Dominio.Entidade;
using Iluminacao.LojaVirtual.Web.infraestrutura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Iluminacao.LojaVirtual.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //ModelBinders.Binders.Add(typeof(Carrinho), new CarrinhoModelBinder());

        }
    }
}
