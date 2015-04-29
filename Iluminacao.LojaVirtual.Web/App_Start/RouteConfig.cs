using System.Web.Mvc;
using System.Web.Routing;

namespace Iluminacao.LojaVirtual.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //1- Inicio - lista todas as categorias

            routes.MapRoute(null,
                "",
                new
                {
                    controller = "Vitrine"
                    ,
                    action = "ListaProdutos"
                    ,
                    categoria = (string) null,
                    pagina = 1
                });

            //2- Paginas

            routes.MapRoute(null,
                "Pagina{pagina}",
                new { controller = "Vitrine",
                     action = "ListaProdutos",
                     categoria = (string) null},
                     new { pagina = @"\d+"});
                

            //3 - Categoria

            routes.MapRoute(null, "{categoria}", new
            {
                controller = "Vitrine",
                action = "ListaProdutos",
                pagina = 1
            });       
    

            //4
            routes.MapRoute(null,
               "{categoria}Pagina{pagina}",
               new
               {
                   controller = "Vitrine",
                   action = "ListaProdutos"
               },
                   new { pagina = @"\d+" });

            routes.MapRoute("ObterImagem", "Vitrine/ObterImagem/{produtoId}", new {controller = "Vitrine", action="ObterImagem", produtoId = UrlParameter.Optional});
            

            routes.MapRoute(null, "{controller}/{action}");


            
        }
    }
}
