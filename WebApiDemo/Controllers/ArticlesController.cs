using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    public class ArticlesController : ApiController
    {
        Articles[] articles = new Articles[]
        {
            new Articles{ ID=1, Title="Why smart people build better societies", Description="How intelligence sparks cooperation", Category="Capital", Image="1.png" }
            ,new Articles{ ID=2, Title="How Harry Portter became a rallying cry", Description="How JK Rowling's novels have influenced the March For Our Lives movement", Category="Culture", Image="2.png" }
            ,new Articles{ ID=3, Title="When art meets jewellery", Description="Dali and Picasso are among the surprising names featured in a Parix exhibition", Category="Designed", Image="3.png" }
        };

        public IEnumerable<Articles> GetAllArticles()
        {
            return articles;
        }

        public IHttpActionResult GetArticle(int id)
        {
            var article = articles.FirstOrDefault((p) => p.ID == id);
            if (article == null)
            {
                return NotFound();
            }
            return Ok(article);
        }
    }
}
