using MetodoKlinCriarMinimalAPI.EF;
using MetodoKlinCriarMinimalAPI.Entities;
using System.Net;
using System.Text;

namespace MetodoKlinCriarMinimalAPI
{
    internal class Program
    {
        //bool comandoVozSN = false;
        static void Main(string[] args)
        {
            //Não será usado no primeiro momento
            //ReconhecimentoDeVoz();
            
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
            using (var dbContext = new Context())
            {
                var acesso = dbContext.Acessos.Where(x => x.IP == IPLocal).FirstOrDefault();
                if (acesso == null)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append("Olá, seja muito bem vindo, sou Amy, secretária virtual do Projeto Fast Deve de Klenio Leite e estou aqui para ajudar-lhe ");
                    stringBuilder.Append("em seu processo de evolução técnica, como também para oferecer-lhe esse recurso inovador que chamamos de fest deve. ");
                    stringBuilder.Append("Não se preocupe, essa mensagem ser-lhe-a apresentada uma única vez e todas as demais poderão ser inibidas no início deste processo. ");
                    stringBuilder.Append("Salientamos que o Projeto Fest Deve está em sua primeira versão, e as tecnologias envolvidas são: DDD, DOMAIN DRIVEN DESIGN, SOLID, e API Web do ASP NET Core. ");
                    stringBuilder.Append("Com o projeto fest dev é assim. Você informa alguns parâmetros necessários e em segundos a inteligência artificial faz tudo por você.");
                    stringBuilder.Append(Environment.NewLine);
                    Console.WriteLine(stringBuilder.ToString());
                    Util.Falar(stringBuilder.ToString());
                }

                bool repetePergunta = true;
                bool blnDesabilitaVozSN = true;
                while (repetePergunta)
                {
                    Console.WriteLine(@"Deseja desativar a orientação por voz? S (Sim) ou N (Não)?");
                    Util.Falar("Deseja desativar a orientação por voz? Digite S para Sim e N para Não");
                    string? comandoVozSN = Console.ReadLine();
                    blnDesabilitaVozSN = comandoVozSN == "S" ? true : false;

                    if (comandoVozSN != null && comandoVozSN.Trim() != "S" && comandoVozSN.Trim() != "N")
                    {
                        bool blnContinuar = true;
                        while (blnContinuar)
                        {
                            Console.WriteLine("Favor digitar apenas S ou N.");
                            if (!blnDesabilitaVozSN)
                                Util.Falar("Favor digitar apenas S ou N");

                            Console.WriteLine("Deseja continuar Sim ou Não.");
                            if (!blnDesabilitaVozSN)
                                Util.Falar("Deseja continuar Sim ou Não");
                            string? seguir = Console.ReadLine().ToUpper();

                            if (seguir == "N")
                                return;
                            else if (seguir == "S")
                                blnContinuar = false;
                        }
                    }
                    else if (comandoVozSN.Trim() == "S" || comandoVozSN.Trim() == "N")
                    {
                        repetePergunta = false;
                    }
                }

                Console.WriteLine(@"Informe a string de conexão para acesso ao banco de dados.");
                if (!blnDesabilitaVozSN)
                    Util.Falar("Informe a string de conexão para acesso ao banco de dados");
                string? strConnectionString = Console.ReadLine();

                Console.WriteLine(@"Informe o caminho de destino da solução da API. Ex.: C:\Users\gabri\source\repos\ ");
                if (!blnDesabilitaVozSN)
                    Util.Falar("Informe o caminho para seu projeto da minimal API; como por exemplo na pasta repos, conforme estrutura da sua máquina e sugerido logo acima ");
                string? dirDestino = Console.ReadLine();

                if (dirDestino == null || dirDestino == string.Empty)
                {
                    if (!blnDesabilitaVozSN)
                        Util.Falar("O caminho de destino de seu projeto não foi informado, tente informar na próxima tentativa.");
                    
                    return;
                }
                
                int dias = 0;
                int diasParaTexto = dbContext.Acessos.Where(y => y.Id == 1).Select(x => x.Dias).First();
                string diasOuDia = "";
                if (diasParaTexto > 1)
                    diasOuDia = "Dias";
                else
                    diasOuDia = "Dia";
                Console.WriteLine(@"Digite sua chave de acesso temporária com limite de uso de " + diasParaTexto + " " + diasOuDia +", ou tecle Enter para o seu primeiro acesso pelo mesmo período.");
                if (!blnDesabilitaVozSN)
                    Util.Falar("Digite sua chave de acesso temporária com limite de uso de " + diasParaTexto + diasOuDia + " " + ", ou tecle Enter para o seu primeiro acesso pelo mesmo período.");
                strChave = Console.ReadLine();
                string? logon = string.Empty;

                acesso = dbContext.Acessos.Where(x => x.Chave == strChave).FirstOrDefault();
                if (acesso != null)
                {
                    logon = acesso.Logon;

                    dias = acesso != null ? acesso.DataExpiracao.Day - DateTime.Now.Day : 0;

                    if (dias > 0)
                    {
                        if (!acesso.Autorizado)
                        {
                            Console.WriteLine(@"Solicite seu acesso ao Administrador do Portal AIKlin pelo Whatsapp: (11) 91399-3756.");
                            if (!blnDesabilitaVozSN)
                                Util.Falar(logon + "Solicite seu acesso ao administrador do fest dev pelo What zap: (11) 91399-3756.");
                            Console.ReadLine();
                            return;
                        }

                        var tabelas = dbContext.Tabelas.ToList();
                        if (tabelas.Count > 0)
                        {
                            Console.WriteLine("Você tem as seguintes tabelas criação de APIS:");
                            if (!blnDesabilitaVozSN)
                                Util.Falar("Você tem as seguintes tabelas no banco de dados para criação de CRUD numa API:");
                            foreach (var tabel in tabelas)
                            {
                                Console.WriteLine(tabel.Nome);
                                if (!blnDesabilitaVozSN)
                                    Util.Falar(tabel.Nome);

                                Thread.Sleep(100);
                            }
                        }

                        repetePergunta = true;
                        var gerar = string.Empty;
                        while (repetePergunta)
                        {
                            Console.WriteLine("Deseja gerar o CRUD DE API para todas? S (Sim) ou N (Não)?");
                            if (!blnDesabilitaVozSN)
                                Util.Falar("Deseja gerar o CRUD DE API para todas? digite S para sim ou N para não");
                            gerar = Console.ReadLine().ToUpper();

                            if (gerar.Trim() != "S" && gerar.Trim() != "N")
                            {
                                bool blnContinuar = true;
                                while (blnContinuar)
                                {
                                    Console.WriteLine("Favor digitar apenas S ou N.");
                                    if (!blnDesabilitaVozSN)
                                        Util.Falar("Favor digitar apenas S ou N");

                                    Console.WriteLine("Deseja continuar Sim ou Não.");
                                    if (!blnDesabilitaVozSN)
                                        Util.Falar("Deseja continuar Sim ou Não");
                                    var seguir = Console.ReadLine().ToUpper();

                                    if (seguir == "N")
                                        return;
                                    else if (seguir == "S")
                                        blnContinuar = false;
                                }
                            } 
                            else if (gerar.Trim() == "S" || gerar.Trim() == "N")
                            {
                                repetePergunta = false;
                            }
                        }

                        if (gerar == "S")
                        {
                            foreach (var tabel in tabelas)
                            {
                                CriarProjetosAPI("Sln" + tabel.Nome, blnDesabilitaVozSN, dirDestino, out string nvDiretorio);
                                CriarMinimalAPI(nvDiretorio + "\\", tabel.Nome, "Sln" + tabel.Nome, dirDestino + "\\" + "Sln" + tabel.Nome + "\\", strConnectionString);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Informe o nome da sua solution: ");
                            if (!blnDesabilitaVozSN)
                                Util.Falar("Informe o nome da Solution do seu projeto");
                            string? slnNome = Console.ReadLine();

                            Console.WriteLine("Digite a Rota (ex.: fornecedor, cliente, estoque, etc.");
                            if (!blnDesabilitaVozSN)
                                Util.Falar("Digite a rota manualmente identificação em seus end points de sua API.");
                            string? strRota = Console.ReadLine();

                            CriarProjetosAPI("Sln" + slnNome, blnDesabilitaVozSN, dirDestino, out string nvDiretorio);
                            CriarMinimalAPI(nvDiretorio + "\\", slnNome, "Sln" + slnNome, dirDestino + "\\" + "Sln" + slnNome + "\\", strConnectionString);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Acesso Expirado.");
                        if (!blnDesabilitaVozSN)
                            Util.Falar(logon + "Acesso expirado. Solicite um novo acesso ao administrador do fest dev pelo What zap: (11) 91399-3756.");
                    }
                }
                else
                {
                    int idIPAutorizado = 0;
                    acesso = dbContext.Acessos.Where(x => x.IP == IPLocal).FirstOrDefault();
                    if(acesso != null)
                    {
                        idIPAutorizado = acesso.Id;
                        if (!acesso.Autorizado)
                        {
                            Console.WriteLine(@"Solicite seu acesso ao Administrador do AIKlin pelo Whatsapp: (11) 91399-3756.");
                            if (!blnDesabilitaVozSN)
                                Util.Falar("Solicite seu acesso ao administrador do fest dev pelo What zap: (11) 91399-3756.");
                            Console.ReadLine();
                            return;
                        }
                    }

                    if (idIPAutorizado > 0)
                        acesso = dbContext.Acessos.Where(x => x.Id == idIPAutorizado).FirstOrDefault();
                    else
                        acesso = dbContext.Acessos.Where(x => x.Id == 1).FirstOrDefault();
                    
                    dias = acesso != null ? acesso.DataExpiracao.Subtract(DateTime.Now).Days : 0;
                    if (dias > 0)
                    {
                        if (!acesso.Autorizado)
                        {
                            Console.WriteLine(@"O acesso gratuito por " + diasParaTexto + " " + diasOuDia + " dias está temporariamente desativado.");
                            if (!blnDesabilitaVozSN)
                                Util.Falar("O acesso gratuito por " + diasParaTexto + " " + diasOuDia + " dias está temporariamente desativado.");
                            Console.ReadLine();
                            return;
                        }

                        if (idIPAutorizado == 0 )
                        {
                            logon = string.Empty;
                            string email = string.Empty;
                            string corrigir = "S";
                            while (corrigir == "S")
                            {
                                repetePergunta = true;
                                while (repetePergunta)
                                {
                                    Console.WriteLine(@"Informe um nome que o identifique (Nome e Sobrenome, por exemplo):");
                                    if (!blnDesabilitaVozSN)
                                        Util.Falar("Informe seu primeiro e último nome para que possamos cadastrá-lo em nossa base de dados.");
                                    logon = Console.ReadLine();

                                    if (!blnDesabilitaVozSN)
                                        Util.Falar("Seja muito bem vindo " + logon + ". Ao Projeto Fest Dev de Klenio Leite.");

                                    Console.WriteLine(@"Informe um E-mail válido:");
                                    if (!blnDesabilitaVozSN)
                                        Util.Falar("Informe um e-mail válido, por favor.");
                                    email = Console.ReadLine();

                                    Console.WriteLine(@"Deseja corrigir alguma informação acima? Informe S (Sim) ou N (Não):");
                                    if (!blnDesabilitaVozSN)
                                        Util.Falar("Deseja corrigir alguma informação acima? Sim ou Não?. Digite S para Sim e N para Não.");
                                    corrigir = Console.ReadLine();

                                    if (corrigir.Trim() != "S" && corrigir.Trim() != "N")
                                    {
                                        bool blnContinuar = true;
                                        while (blnContinuar)
                                        {
                                            Console.WriteLine("Favor digitar apenas S ou N.");
                                            if (!blnDesabilitaVozSN)
                                                Util.Falar("Favor digitar apenas S ou N");

                                            Console.WriteLine("Deseja continuar Sim ou Não.");
                                            if (!blnDesabilitaVozSN)
                                                Util.Falar("Deseja continuar Sim ou Não");
                                            string? seguir = Console.ReadLine().ToUpper();

                                            if (seguir == "N")
                                                return;
                                            else if (seguir == "S")
                                                blnContinuar = false;
                                        }
                                    }
                                    else if (corrigir.Trim() == "S" || corrigir.Trim() == "N")
                                    {
                                        repetePergunta = false;
                                    }
                                }
                            }

                            string _chave = Guid.NewGuid().ToString();
                            Int16 expiraUsuario = dbContext.Params.Select(x => x.ExpiraUsuario).First();
                            
                            Acesso _acesso = new Acesso() { Chave = _chave, IP = IPLocal, Logon = logon, Email = email, Autorizado = true, DataExpiracao = DateTime.Now.AddDays(expiraUsuario), Dias = expiraUsuario };

                            dbContext.Acessos.Add(_acesso);
                            dbContext.SaveChanges();

                            Console.WriteLine(@"Guarde sua chave em lugar seguro, para os próximos acessos: " + _chave);
                            if (!blnDesabilitaVozSN)
                                Util.Falar("Bem vindo ao Projeto Fest Dev de Klenio Leite. Guarde sua chave de acesso em local seguro e não a compartilhe com ninguém.");
                            Console.ReadLine();
                        }

                        //Console.WriteLine(@"Digite o Path API. Ex.: C:\Users\gabri\source\repos\SlnERP\ERP.API\");

                        //if (!blnDesabilitaVozSN)
                        //    Util.Falar("Digite o caminho de seu projeto API web do ASP.NET Core");
                        //string strPath = Console.ReadLine();

                        var tabelas = dbContext.Tabelas.ToList();
                        if (tabelas.Count > 0)
                        {
                            Console.WriteLine("Você tem as seguintes tabelas para criação de CRUD em APIS:");
                            if (!blnDesabilitaVozSN)
                                Util.Falar("Você tem as seguintes tabelas no banco de dados para criação de CRUD em APIs:");
                            foreach (var tabel in tabelas)
                            {
                                Console.WriteLine(tabel.Nome);
                                if (!blnDesabilitaVozSN)
                                    Util.Falar(tabel.Nome);

                                Thread.Sleep(100);
                            }
                        }

                        repetePergunta = true;
                        while (repetePergunta)
                        {
                            Console.WriteLine("Deseja gerar o CRUD DE API para todas? S (Sim) ou N (Não)?");
                            if (!blnDesabilitaVozSN)
                                Util.Falar("Deseja gerar o CRUD DE API para todas? digite S para sim ou N para não");
                            var gerar = Console.ReadLine();

                            if (gerar.Trim() != "S" && gerar.Trim() != "N")
                            {
                                bool blnContinuar = true;
                                while (blnContinuar)
                                {
                                    Console.WriteLine("Favor digitar apenas S ou N.");
                                    if (!blnDesabilitaVozSN)
                                        Util.Falar("Favor digitar apenas S ou N");

                                    Console.WriteLine("Deseja continuar Sim ou Não.");
                                    if (!blnDesabilitaVozSN)
                                        Util.Falar("Deseja continuar Sim ou Não");
                                    var seguir = Console.ReadLine().ToUpper();

                                    if (seguir == "N")
                                        return;
                                    else if (seguir == "S")
                                        blnContinuar = false;
                                }
                            }
                            else if (gerar.Trim() == "S" || gerar.Trim() == "N")
                            {
                                repetePergunta = false;
                            }

                            if (gerar == "S")
                            {
                                foreach (var tabel in tabelas)
                                {
                                    CriarProjetosAPI("Sln" + tabel.Nome, blnDesabilitaVozSN, dirDestino, out string nvDiretorio);
                                    CriarMinimalAPI(nvDiretorio + "\\", tabel.Nome, "Sln" + tabel.Nome, null, strConnectionString);
                                }
                            }
                            else
                            {
                                if (gerar == "N")
                                {
                                    Console.WriteLine("Informe o nome da sua solution: ");
                                    if (!blnDesabilitaVozSN)
                                        Util.Falar("Informe o nome da Solution do seu projeto");
                                    string slnNome = Console.ReadLine();

                                    Console.WriteLine("Digite a Rota (ex.: fornecedor, cliente, estoque, etc.");
                                    if (!blnDesabilitaVozSN)
                                        Util.Falar("Digite a rota manualmente identificação em seus end points de sua API.");
                                    string strRota = Console.ReadLine();

                                    CriarProjetosAPI("Sln" + slnNome, blnDesabilitaVozSN, dirDestino, out string nvDiretorio);
                                    CriarMinimalAPI(nvDiretorio + "\\", slnNome, "Sln" + slnNome, null, strConnectionString);
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine(@"Acesso negado ao Fast Dev. Adquira uma licença pelo Whatsapp: (11) 91399-3756.");
                        if (!blnDesabilitaVozSN)
                            Util.Falar("Digite a rota para identificação em seus end points.");
                        return;
                    }
                }
            }

            static void CriarProjetosAPI(string slnNome, bool blnDesabilitaVozSN, string dirDestino, out string nvDiretorio)
            {
                //Definir diretório no servidor quando o sistema for publicado em mvc
                string dirOrigemAPI = @"C:\Users\gabri\source\repos\MetodoKlinMilk\Templates\MinimalAPI\SlnTemplate\";

                if (!Directory.Exists(dirDestino + slnNome))
                    Directory.CreateDirectory(dirDestino + slnNome);

                Util.DirectoryCopy(dirOrigemAPI, dirDestino + "\\" + slnNome, true);

                string diretorioAntigo = dirDestino + slnNome + "\\Template.API";
                string novoNomeDiretorio = dirDestino + slnNome + "\\" + slnNome.Replace("sln", "").Replace("Sln", "") + ".API";
                nvDiretorio = novoNomeDiretorio;
                // Renomeia o diretório
                Directory.Move(diretorioAntigo, Path.Combine(Path.GetDirectoryName(diretorioAntigo), novoNomeDiretorio));

                string caminhoArquivoAntigo = dirDestino + slnNome + "\\" + "SlnTemplate.sln";
                string novoNomeArquivo = slnNome + ".sln";

                // Renomeia o arquivo
                File.Move(caminhoArquivoAntigo, Path.Combine(Path.GetDirectoryName(caminhoArquivoAntigo), novoNomeArquivo));

                string diretorioProjetoAPI = novoNomeDiretorio;

                // Verificar se o diretório existe
                if (Directory.Exists(diretorioProjetoAPI))
                {
                    // Listar arquivos no diretório
                    string[] arquivos = Directory.GetFiles(diretorioProjetoAPI);

                    // Renomear cada arquivo com um novo nome
                    foreach (string arquivo in arquivos)
                    {
                        // Extrair nome do arquivo e extensão
                        string nomeArquivo = Path.GetFileNameWithoutExtension(arquivo);
                        string extensao = Path.GetExtension(arquivo);
                        string novoNome = string.Empty;
                        // Novo nome desejado (neste exemplo, adicionando um sufixo "_renomeado")
                        if (nomeArquivo.Contains("Template"))
                        {
                            novoNome = nomeArquivo.Replace("Template", slnNome.Replace("sln", "").Replace("Sln", "")) + extensao;

                            // Caminho completo do arquivo com o novo nome
                            string novoCaminho = Path.Combine(diretorioProjetoAPI, novoNome);

                            // Renomear o arquivo
                            File.Move(arquivo, novoCaminho);

                            Console.WriteLine($"Arquivo renomeado: {novoCaminho}");
                        }
                    }

                    Console.WriteLine("Todos os arquivos foram renomeados!");
                }

                Console.WriteLine("Arquivo copiado com sucesso!");

            }

            static void CriarMinimalAPI(string path, string rota, string nomeSolucao, string? pathSolution, string? strConnectionString)
            {
                string[] buscaNameSpace = path.Split('\\');
                string nameSpaceEncontrado = buscaNameSpace[buscaNameSpace.Length - 2].ToString()
                    .Replace(@"\", "");

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                if (!Directory.Exists(path + "\\Data"))
                    Directory.CreateDirectory(path + "\\Data");

                if (!Directory.Exists(path + "\\Models"))
                    Directory.CreateDirectory(path + "\\Models");

                //Alterando o conteúdo do arquivo .sln
                string caminhoArquivoSln = string.Empty;
                // Caminho do arquivo
                if (pathSolution == null)
                    caminhoArquivoSln = Path.Combine(path.Replace(Util.FormatarTexto(rota) +".API\\", ""), nomeSolucao + ".sln");
                else
                   caminhoArquivoSln = Path.Combine(pathSolution, nomeSolucao + ".sln");

                //Alterando o conteúdo do arquivo nomeArquivo.sln
                var conteudo = "";
                using (StreamReader writer = File.OpenText(caminhoArquivoSln))
                {
                    conteudo = writer.ReadToEnd();

                    conteudo = conteudo.Replace("Template", nomeSolucao.Replace("sln","").Replace("Sln", ""));
                }

                File.WriteAllText(caminhoArquivoSln, conteudo);

                // Caminho do arquivo
                string caminhoArquivoData = Path.Combine(path + "\\Data\\", "APIContext" + ".cs");
                conteudo = "";
                using (StreamReader writer = File.OpenText(caminhoArquivoData))
                {
                    conteudo = writer.ReadToEnd();

                    conteudo = conteudo.Replace("$mapinamespace$", nameSpaceEncontrado.Replace("sln", "").Replace("Sln", ""))
                        .Replace("$FolderData$", "Data")
                        .Replace("$FolderModels$", "Models")
                        .Replace("Template", nomeSolucao.Replace("sln", ""))
                        .Replace("$DbConnectionName$", strConnectionString)
                        .Replace("$Entity$", Util.FormatarTexto(rota) + "Entity")
                        .Replace("$PluralEntity$", Util.FormatarTexto(rota) + "s");
                }

                File.WriteAllText(caminhoArquivoData, conteudo);

                // Caminho do arquivo
                string caminhoArquivoModels = Path.Combine(path + "\\Models\\", "Entity" + ".cs");
                conteudo = "";
                using (StreamReader writer = File.OpenText(caminhoArquivoModels))
                {
                    conteudo = writer.ReadToEnd();

                    StringBuilder stringBuilder = new StringBuilder();
                    using (Context context = new Context())
                    {
                        var colunasTabela = Util.MeuRetornoDAOProcedureColunasTabelas().Where(x => x.Tabela == Util.FormatarTexto(rota)).AsEnumerable();
                        
                        if (colunasTabela != null && colunasTabela.ToList().Count > 0)
                        {
                            foreach(var colunas in colunasTabela)
                            { 
                                stringBuilder.Append("public " + Util.AdaptaTipoSQLParaCSharp(colunas.Tipo) + " " + colunas.Coluna + " { get; set; }");
                                stringBuilder.Append(Environment.NewLine);                               
                            }
                        }
                    }

                    conteudo = conteudo.Replace("Template", nomeSolucao.Replace("sln", "").Replace("Sln", ""))
                        .Replace("$Properties$", stringBuilder.ToString())
                        .Replace("$Entity$", Util.FormatarTexto(rota) + "Entity")
                        .Replace("$mapinamespace$", nameSpaceEncontrado.Replace("sln", "").Replace("Sln", "") + ".Models") ;
                }

                File.WriteAllText(caminhoArquivoModels, conteudo);

                // Renomeia o arquivo
                File.Move(caminhoArquivoModels, Path.Combine(Path.GetDirectoryName(caminhoArquivoModels), Util.FormatarTexto(rota ) + "Entity.cs"));

                // Caminho do arquivo
                string caminhoArquivo = Path.Combine(path, "Program.cs");

                //Alterando o conteúdo do arquivo Program.cs
                conteudo = "";
                using (StreamWriter writer = File.CreateText(caminhoArquivo))
                {
                    using (var dbContext = new Context())
                    {
                        var snippetAPI = dbContext.Snippets.Where(x => x.Nome == "SnippetMinimalAPI").FirstOrDefault();

                        if (snippetAPI != null)
                            conteudo = snippetAPI.Conteudo;
                    }

                    StringBuilder sb = new StringBuilder();
                    string linha = "";
                    string textoGeral = "";
                    for (int i = 0; i <= conteudo.Length-1; i++)
                    {
                        if (conteudo[i].ToString() != "\\")
                            linha += conteudo[i];
                        else
                        {
                            if (conteudo[i+1].ToString() == "n")
                            {
                                textoGeral += linha.Replace("$mapinamespace$", nameSpaceEncontrado.Replace("sln", "").Replace("Sln", ""))
                                                   .Replace("$FolderData$", "Data")
                                                   .Replace("$FolderModels$", "Models")
                                                   .Replace("$VariableType$", rota)
                                                   .Replace("$VariableRoot$", rota.ToLower())
                                                   .Replace("$YourDbContextName$", "APIContext")
                                                   .Replace("$DbConnectionName$", strConnectionString)
                                                   .Replace("$PluralizeType$", Util.Pluralizar(Util.FormatarTexto(rota)))
                                                   .Replace("$Type$", Util.FormatarTexto(rota) + "Entity")
                                                   .Replace("$Tag$", Util.FormatarTexto(rota)) + Environment.NewLine;
                                linha = "";
                                i++;
                            }
                        }
                    }
                    
                    conteudo = textoGeral;

                    writer.Write(conteudo);
                }

                Console.WriteLine("Projeto Gerado. Abra a solução e execute.");
                Util.Falar("Projeto Gerado. Abra a solução e execute.");
            }
        }
    }
}
