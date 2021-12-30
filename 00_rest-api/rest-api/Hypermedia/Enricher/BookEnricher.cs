using Microsoft.AspNetCore.Mvc;
using rest_api.Data.VO;
using rest_api.Hypermedia.Constants;
using System.Text;
using System.Threading.Tasks;

namespace rest_api.Hypermedia.Enricher
{
    public class BookEnricher : ContentResponseEnricher<BookVO>
    {
        private readonly object _lock = new object();

        protected override Task EnrichModel(BookVO content, IUrlHelper urlHelper)
        {
            string path = "api/person";
            string version = "v1";
            string link = GetLink(content.Id, urlHelper, path, version);

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.GET,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet,
            });

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.POST,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPost,
            });

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.PUT,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPut,
            });

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.DELETE,
                Href = link,
                Rel = RelationType.self,
                Type = "int",
            });

            return null;
        }

        private string GetLink(long id, IUrlHelper urlHelper, string path, string version)
        {
            lock (_lock)
            {
                var url = new { controller = path, version = version, id = id };
                var link = urlHelper.Link("DefaultApi", url);

                return new StringBuilder(link).Replace("%2F", "/").ToString();
            };
        }
    }
}
