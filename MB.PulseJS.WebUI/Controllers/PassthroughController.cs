namespace MB.PulseJS.WebUI.Controllers
{
  using System;
  using System.Net;
  using System.Net.Http;
  using System.Text;
  using System.Web.Http;

  public class PassthroughController : ApiController
  {
    // http://localhost:64149/api/passthrough?url=http://www.radionz.co.nz/rss/national.xml
    // http://localhost:64149/api/passthrough?url=http://rss.nzherald.co.nz/rss/xml/uttm.xml
    // http://localhost:64149/api/passthrough?url=http://www.stuff.co.nz/rss/

    public HttpResponseMessage GetContent(string url)
    {
      using (var client = new WebClient())
      {
        client.Proxy = WebRequest.GetSystemWebProxy();
        client.Proxy.Credentials = CredentialCache.DefaultNetworkCredentials;

        var data = client.DownloadString(new Uri(url));
        var mediaType = client.ResponseHeaders["Content-Type"].Split(';')[0];

        var msg = new HttpResponseMessage
                    {
                      Content = new StringContent(data, Encoding.UTF8, mediaType),
                      StatusCode = HttpStatusCode.OK,
                    };

        return msg;
      }
    }
  }
}
