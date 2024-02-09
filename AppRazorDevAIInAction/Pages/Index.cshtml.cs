using AppRazorDevAIInAction.EF;
using AppRazorDevAIInAction.Models;
using AppRazorDevAIInAction.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;

namespace AppRazorDevAIInAction.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public string Logon { get; set; }
        [BindProperty]
        public string Email { get; set; }
        public string BlinkClass { get; set; } = "blinking-label";
        public string MensagemDeErro { get; set; } = "";
        
        public AcessoEntityModel appAcessoEntityModel { get; set; } = new AcessoEntityModel();
        public TipoPlano tipoPlano { get; set; } = new TipoPlano();

        string escolha = string.Empty;

        private string mensagemDeErro = "";
        private string? Chave { get; set; }
        private bool primVez { get; set; } = true;
        private bool devNovo { get; set; } = false;

        private string authorizationKey = "";
        private string msgChave = "";
        private int dias = 0;
        private string diasOuDia = "";
        private Int16 planoAtual = 0;

        string blinkClass = "blinking-label";

        // Restante das propriedades e métodos aqui

        public async Task<IActionResult> OnPostAsync()
        {
            Int16 expiraUsuario = 0;
            string IPLocal = string.Empty;
            string hostName = Dns.GetHostName();
            try
            {
                IPAddress[] ipv4Addresses = Dns.GetHostAddresses(hostName);
                foreach (IPAddress ip in ipv4Addresses)
                {
                    if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        IPLocal = ip.ToString();
                    }
                }
                if (tipoPlano.Id != 0 || planoAtual != 0)
                {
                    string? strChave = string.Empty;
                    using (Context dbContext = new Context())
                    {
                        string? logon = string.Empty;

                        var acesso = dbContext.Acessos.Where(x => x.IP == IPLocal).FirstOrDefault();
                        if (acesso != null)
                        {
                            acesso = dbContext.Acessos.Where(x => x.Email == appAcessoEntityModel.Email).FirstOrDefault();
                            if (acesso != null)
                            {
                                int diasExpirar = (acesso.DataExpiracao - DateTime.Now).Days;
                                if (diasExpirar > 0)
                                {
                                    if (acesso.Autorizado == true)
                                    {
                                        AuthorizationService.SetAuthorization(true);
                                        return RedirectToPage("/NavMenu");

                                        // expiraUsuario = 0;

                                        // if (tipoPlano.Id > 0)
                                        // {
                                        //     switch (tipoPlano.Id)
                                        //     {
                                        //         case 1:
                                        //             expiraUsuario = 30;
                                        //             break;
                                        //         case 2:
                                        //             expiraUsuario = 60;
                                        //             break;
                                        //         case 3:
                                        //             expiraUsuario = 90;
                                        //             break;
                                        //         case 4:
                                        //             expiraUsuario = 180;
                                        //             break;
                                        //         case 5:
                                        //             expiraUsuario = 365;
                                        //             break;
                                        //         case 6:
                                        //             expiraUsuario = 9999;
                                        //             break;
                                        //     }
                                        // }

                                        // if (tipoPlano.Id != 0 && tipoPlano.Id != planoAtual)
                                        // {
                                        //     acesso = new AcessoEntityModel() { Chave = acesso.Chave, IP = IPLocal, Logon = this.Logon, Email = this.Email, Autorizado = false, TipoPlano = tipoPlano.Id, DataExpiracao = DateTime.Now.AddDays(expiraUsuario), Dias = expiraUsuario };
                                        //     dbContext.Acessos.Update(acesso);
                                        //     dbContext.SaveChanges();
                                        // }
                                        // else
                                        // {
                                        //     AuthorizationService.SetAuthorization(true);
                                        //     NavigationManager.NavigateTo($"/NavMenu/");
                                        // }
                                    }
                                    else
                                    {
                                        int diasAcessoGenerico = dbContext.Acessos.Where(y => y.Id == 1).Select(x => x.Dias).First();
                                        diasExpirar = acesso != null ? (acesso.DataExpiracao - DateTime.Now).Days : 0;
                                        if (diasAcessoGenerico > 0 && diasExpirar > 0)
                                        {
                                            AuthorizationService.SetAuthorization(true);
                                            return RedirectToPage("/NavMenu");
                                        }
                                        else
                                            mensagemDeErro = "Solicite seu acesso mediante comprovação do pagamento, pelo link do Grupo no Whatsapp.";
                                    }
                                }
                                else
                                {
                                    mensagemDeErro = "Sua licença está expirada, solicite seu acesso ao Administrador do Portal DevAIInAction.net pelo Whatsapp: (11) 91399-3756.";
                                }
                            }
                            else
                            {
                                acesso = dbContext.Acessos.Where(y => y.Id == 1).FirstOrDefault();
                                if (acesso != null)
                                {
                                    int diasAcessoGenerico = dbContext.Acessos.Where(y => y.Id == 1).Select(x => x.Dias).First();
                                    int diasExpirar = acesso != null ? (acesso.DataExpiracao - DateTime.Now).Days : 0;
                                    if (diasAcessoGenerico > 0 && diasExpirar > 0)
                                    {
                                        Chave = Guid.NewGuid().ToString();

                                        expiraUsuario = 0;

                                        if (tipoPlano.Id > 0)
                                        {
                                            switch (tipoPlano.Id)
                                            {
                                                case 1:
                                                    expiraUsuario = 30;
                                                    break;
                                                case 2:
                                                    expiraUsuario = 60;
                                                    break;
                                                case 3:
                                                    expiraUsuario = 90;
                                                    break;
                                                case 4:
                                                    expiraUsuario = 180;
                                                    break;
                                                case 5:
                                                    expiraUsuario = 365;
                                                    break;
                                                case 6:
                                                    expiraUsuario = 9999;
                                                    break;
                                            }
                                        }

                                        acesso = new AcessoEntityModel() { Chave = this.Chave, IP = IPLocal, Logon = this.Logon, Email = this.Email, Autorizado = false, TipoPlano = tipoPlano.Id, DataExpiracao = DateTime.Now.AddDays(expiraUsuario), Dias = expiraUsuario };
                                        dbContext.Acessos.Add(acesso);
                                        dbContext.SaveChanges();

                                        devNovo = true;

                                        mensagemDeErro = "Solicite seu acesso mediante comprovação do pagamento, pelo link do Grupo no Whatsapp.";
                                    }
                                    else
                                    {
                                        Chave = Guid.NewGuid().ToString();

                                        expiraUsuario = 0;

                                        if (tipoPlano.Id > 0)
                                        {
                                            switch (tipoPlano.Id)
                                            {
                                                case 1:
                                                    expiraUsuario = 30;
                                                    break;
                                                case 2:
                                                    expiraUsuario = 60;
                                                    break;
                                                case 3:
                                                    expiraUsuario = 90;
                                                    break;
                                                case 4:
                                                    expiraUsuario = 180;
                                                    break;
                                                case 5:
                                                    expiraUsuario = 365;
                                                    break;
                                                case 6:
                                                    expiraUsuario = 9999;
                                                    break;
                                            }
                                        }

                                        acesso = new AcessoEntityModel() { Chave = this.Chave, IP = IPLocal, Logon = this.Logon, Email = this.Email, Autorizado = false, TipoPlano = tipoPlano.Id, DataExpiracao = DateTime.Now.AddDays(expiraUsuario), Dias = expiraUsuario };
                                        dbContext.Acessos.Add(acesso);
                                        dbContext.SaveChanges();

                                        devNovo = true;

                                        mensagemDeErro = "Solicite seu acesso mediante comprovação do pagamento, pelo link do Grupo no Whatsapp.";
                                    }
                                }
                            }
                        }
                        else
                        {
                            acesso = dbContext.Acessos.Where(y => y.Id == 1).FirstOrDefault();
                            if (acesso != null)
                            {
                                int diasAcessoGenerico = dbContext.Acessos.Where(y => y.Id == 1).Select(x => x.Dias).First();
                                DateTime dataExpiraGerenico = dbContext.Acessos.Where(y => y.Id == 1).Select(x => x.DataExpiracao).First();
                                int diasExpirar = dataExpiraGerenico.Day > 0 ? (dataExpiraGerenico - DateTime.Now).Days : 0;
                                if (diasAcessoGenerico > 0 && diasExpirar > 0)
                                {
                                    Chave = Guid.NewGuid().ToString();

                                    tipoPlano.Id = 1;

                                    if (tipoPlano.Id > 0)
                                    {
                                        switch (tipoPlano.Id)
                                        {
                                            case 1:
                                                expiraUsuario = 30;
                                                break;
                                            case 2:
                                                expiraUsuario = 60;
                                                break;
                                            case 3:
                                                expiraUsuario = 90;
                                                break;
                                            case 4:
                                                expiraUsuario = 180;
                                                break;
                                            case 5:
                                                expiraUsuario = 365;
                                                break;
                                            case 6:
                                                expiraUsuario = 9999;
                                                break;
                                        }
                                    }

                                    acesso = new AcessoEntityModel() { Chave = this.Chave, IP = IPLocal, Logon = this.Logon, Email = this.Email, Autorizado = false, TipoPlano = tipoPlano.Id, DataExpiracao = dataExpiraGerenico.AddDays(expiraUsuario), Dias = expiraUsuario };
                                    dbContext.Acessos.Add(acesso);
                                    dbContext.SaveChanges();

                                    devNovo = true;

                                    AuthorizationService.SetAuthorization(true);
                                    return RedirectToPage("/NavMenu");
                                }
                                else if (diasExpirar == 0)
                                {
                                    if (tipoPlano.Id == 0)
                                    {
                                        TempData["Mensagem"] = "Você deve clicar no botão [Concordo com a Doação Voluntária para Acesso Anual] e em seguida no botão [Login]";
                                        return RedirectToPage("/Index");
                                    }

                                    expiraUsuario = dbContext.Params.Select(x => x.ExpiraUsuario).FirstOrDefault();
                                    acesso = new AcessoEntityModel() { Chave = Guid.NewGuid().ToString(), IP = IPLocal, Logon = this.Logon, Email = this.Email, Autorizado = false, TipoPlano = tipoPlano.Id, DataExpiracao = dataExpiraGerenico.AddDays(expiraUsuario), Dias = expiraUsuario };
                                    dbContext.Acessos.Add(acesso);
                                    dbContext.SaveChanges();

                                    devNovo = true;

                                    TempData["Mensagem"] = "Solicite seu acesso em nosso grupo de whatsapp, mediante comprovação de pagamento.";
                                    return RedirectToPage("/Index");
                                }
                            }
                        }
                    }
                }
                else
                {
                    using (Context dbContext = new Context())
                    {
                        expiraUsuario = dbContext.Params.Select(x => x.ExpiraUsuario).FirstOrDefault();
                        if (Logon == null || Logon == "")
                        {
                            TempData["Mensagem"] = "Informe seu Logon.";
                            return RedirectToPage("/Index");
                        }

                        if (Email == null || Email == "")
                        {
                            TempData["Mensagem"] = "Informe seu E-mail.";
                            return RedirectToPage("/Index");
                        }

                        var acesso = dbContext.Acessos.Where(x => x.Email == appAcessoEntityModel.Email).FirstOrDefault();
                        if (acesso != null)
                        {
                            int diasAcessoGenerico = dbContext.Acessos.Where(y => y.Id == 1).Select(x => x.Dias).First();
                            int diasExpirar = acesso != null ? (acesso.DataExpiracao - DateTime.Now).Days : 0;
                            if (diasAcessoGenerico > 0 && diasExpirar > 0)
                            {
                                if (acesso.Autorizado == true)
                                {
                                    AuthorizationService.SetAuthorization(true);
                                    return RedirectToPage("/NavMenu");
                                }
                                else
                                {
                                    planoAtual = acesso.TipoPlano;
                                    mensagemDeErro = "Solicite autorização de seu primeiro acesso em nosso grupo de whatsapp, mediante comprovação de pagamento.";
                                }
                            }
                        }
                        else
                        {
                            int diasAcessoGenerico = dbContext.Acessos.Where(y => y.Id == 1).Select(x => x.Dias).First();
                            DateTime dataExpiraGerenico = dbContext.Acessos.Where(y => y.Id == 1).Select(x => x.DataExpiracao).First();
                            int diasExpirar = dataExpiraGerenico.Day > 0 ? (dataExpiraGerenico - DateTime.Now).Days : 0;
                            if (diasAcessoGenerico > 0 && diasExpirar > 0)
                            {
                                planoAtual = 1;
                                mensagemDeErro = "Bem vindo! Catrastre-se. Você deve confirmar sua acesão ao Projeto AmigoDev da DevAIInAction.net, porém você tem acesso gratuito até: " + dbContext.Acessos.Where(y => y.Id == 1).Select(x => x.DataExpiracao).First() + ". Caso não selecione, o plano padrão será o Anual: após ativação via Whatsapp.";
                            }
                            else if (diasExpirar == 0)
                            {
                                if (tipoPlano.Id == 0)
                                {
                                    mensagemDeErro = "Você deve clicar no botão [Concordo com a Doação Voluntária para Acesso Anual] e em seguida no botão [Login]";
                                    return Page();
                                }

                                expiraUsuario = dbContext.Params.Select(x => x.ExpiraUsuario).FirstOrDefault();
                                acesso = new AcessoEntityModel() { Chave = Guid.NewGuid().ToString(), IP = IPLocal, Logon = this.Logon, Email = this.Email, Autorizado = false, TipoPlano = tipoPlano.Id, DataExpiracao = dataExpiraGerenico.AddDays(expiraUsuario), Dias = expiraUsuario };
                                dbContext.Acessos.Add(acesso);
                                dbContext.SaveChanges();

                                devNovo = true;

                                TempData["Mensagem"] = "Solicite seu acesso em nosso grupo de whatsapp, mediante comprovação de pagamento.";
                                return RedirectToPage("/Index");
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return Page();
        }

        public void OnGet()
        {

        }
    }
}
