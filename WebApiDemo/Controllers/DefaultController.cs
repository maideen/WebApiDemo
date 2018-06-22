using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            IEnumerable<Articles> articles = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(string.Format(@"{0}://{1}{2}/api/",Request.Url.Scheme, Request.Url.Host, (Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port)));
                //client.BaseAddress = new Uri("http://localhost:49443/api/");
                var responseTask = client.GetAsync("articles");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<Articles>>();
                    readTask.Wait();

                    articles = readTask.Result;
                }
                else //web api sent error response 
                {
                    articles = Enumerable.Empty<Articles>();

                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }

            return View(articles);
        }
    }
}