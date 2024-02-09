using BlazorAppModeloKlinMilk.EF;
using BlazorAppModeloKlinMilk.Models;
using System.Net;

namespace BlazorAppModeloKlinMilk.Data
{
    public class Acesso
    {
        //private IAcessoService _acessoService;
        //public Acesso(IAcessoService acessoService)
        //{
        //    _acessoService = acessoService;
        //}

        public void PostEnviarParaServidor(AcessoEntityModel acessoEntityModel)
        {
            try
            {
                string IPLocal = string.Empty;
                string hostName = Dns.GetHostName();
                IPAddress[] ipv4Addresses = Dns.GetHostAddresses(hostName);

                foreach (IPAddress ip in ipv4Addresses)
                {
                    if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        IPLocal = ip.ToString();
                    }
                }

                string? strChave = string.Empty;
                string? dirDestino = @"C:\inetpub\wwwroot\devaiinaction\Files\Destiny\";

                using (Context dbContext = new Context())
                {
                    int dias = 0;
                    int diasParaTexto = dbContext.Acessos.Where(y => y.Id == 1).Select(x => x.Dias).First();
                    string diasOuDia = "";
                    if (diasParaTexto > 1)
                        diasOuDia = "Dias";
                    else
                        diasOuDia = "Dia";


                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
