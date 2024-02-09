using System.Data;
using Azure.Storage.Blobs;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using MetodoKlinMilk.Domain.Entities;
using System.Data.SqlClient;
using System.IO;
using System.IO.Compression;

namespace AppRazorDevAIInAction.CrossCutting
{

    public static class Util
    {
        public static class CheckBoxItem
        {
            public static int Id { get; set; }
            public static string Label { get; set; }
            public static bool IsChecked { get; set; }
        }

        public enum PlanType
        {
            Mensal = 1,
            Bimestral = 2,
            Trimestral = 3,
            Semestral = 4,
            Anual = 5,
            Business = 6
        }

        public static byte[] GetZipFileBytes(string pasta)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (ZipArchive archive = new ZipArchive(ms, ZipArchiveMode.Create, true))
                {
                    // Adiciona todos os arquivos da pasta ao arquivo ZIP
                    var arquivos = Directory.GetFiles(pasta);
                    foreach (var arquivo in arquivos)
                    {
                        var entrada = archive.CreateEntry(Path.GetFileName(arquivo));
                        using (var stream = entrada.Open())
                        using (var fileStream = File.OpenRead(arquivo))
                        {
                            fileStream.CopyTo(stream);
                        }
                    }
                }
                return ms.ToArray();
            }
        }

        public static string AdaptaTipoSQLParaCSharp(string tipoSQL)
        {
            string retornoCSharp = string.Empty;
            switch (tipoSQL)
            {
                case "bit":
                    retornoCSharp = "bool";
                    break;
                case "varchar":
                    retornoCSharp = "string?";
                    break;
                case "nvarchar":
                    retornoCSharp = "string?";
                    break;
                case "char":
                    retornoCSharp = "string?";
                    break;
                case "nchar":
                    retornoCSharp = "string?";
                    break;
                case "int":
                    retornoCSharp = "int";
                    break;
                case "smallint":
                    retornoCSharp = "short";
                    break;
                case "bigint":
                    retornoCSharp = "long";
                    break;
                case "tinyint":
                    retornoCSharp = "byte";
                    break;
                case "decimal":
                    retornoCSharp = "decimal";
                    break;
                case "float":
                    retornoCSharp = "float";
                    break;
                case "real":
                    retornoCSharp = "float";
                    break;
                case "double precision":
                    retornoCSharp = "double";
                    break;
                case "money":
                    retornoCSharp = "double";
                    break;
                case "smallmoney":
                    retornoCSharp = "decimal";
                    break;
                case "datetime":
                    retornoCSharp = "DateTime";
                    break;
                case "smalldatetime":
                    retornoCSharp = "DateTime";
                    break;
                case "time":
                    retornoCSharp = "TimeSpan";
                    break;
                case "timestamp":
                    retornoCSharp = "byte[]";
                    break;
                case "boolean":
                    retornoCSharp = "bool";
                    break;
                case "uniqueidentifier":
                    retornoCSharp = "Guid";
                    break;
            }
            return retornoCSharp;
        }

        static async Task DownloadBlobToFileAsync(
                BlobClient blobClient,
                string localFilePath)
        {
            await blobClient.DownloadToAsync(localFilePath);
        }
        static async Task DownloadBlobToStreamAsync(
            BlobClient blobClient,
            string localFilePath)
        {
            FileStream fileStream = File.OpenWrite(localFilePath);

            await blobClient.DownloadToAsync(fileStream);

            fileStream.Close();
        }

        static async Task ProcessarBlob(BlobClient blobClient)
        {
            // Faça algo com o BlobClient aqui
            await Task.Delay(1000); // Exemplo de operação assíncrona simulada
            Console.WriteLine($"Blob processado: {blobClient.Uri}");
        }
        //Estudar mais esse método, pois está com erro para fazer download direto do azure...
        //Estudar o BlobClient
        static async Task BaixarPastaCompleta(ShareDirectoryClient directoryClient, string caminhoLocalDestino)
        {
            string diretorioLocal = Path.Combine(caminhoLocalDestino, directoryClient.Name);
            Directory.CreateDirectory(diretorioLocal);

            string connectionString = "fastdevklinmilk.file.core.windows.net/dirfastdevklinmilk";
            string nomeContainer = "nome-do-container";
            string nomeBlob = "nome-do-blob";

            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(nomeContainer);
            BlobClient blobClient = containerClient.GetBlobClient(nomeBlob);

            if (await containerClient.ExistsAsync())
            {
                blobClient = containerClient.GetBlobClient(nomeBlob);

                await ProcessarBlob(blobClient);
                Console.WriteLine("Blob processado com sucesso!");
            }
            else
            {
                Console.WriteLine("O container não existe.");
            }

            await foreach (ShareFileItem fileItem in directoryClient.GetFilesAndDirectoriesAsync())
            {
                if (!fileItem.IsDirectory)
                {
                    ShareFileClient fileClient = directoryClient.GetFileClient(fileItem.Name);
                    string caminhoArquivoLocal = Path.Combine(diretorioLocal, fileItem.Name);

                    FileStream fileStream = File.OpenWrite(caminhoArquivoLocal);

                    await blobClient.DownloadToAsync(fileStream);

                    fileStream.Close();
                }
                else
                {
                    await BaixarPastaCompleta(directoryClient.GetSubdirectoryClient(fileItem.Name), diretorioLocal);
                }
            }
        }
        public static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException("A pasta de origem não existe ou não pode ser encontrada: " + sourceDirName);
            }

            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, true);
            }

            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }
        public static void Falar(string mensagem)
        {
            // Cria um objeto SpeechSynthesizer
            SpeechSynthesizer synth = new SpeechSynthesizer();

            // Fala o texto fornecido pelo usuário
            synth.Speak(mensagem);

            // Libera os recursos do SpeechSynthesizer
            synth.Dispose();
        }
        //Está dando problema de Acesso Negado (pode ser o Firewall do windows bloqueando o recurso)
        //Preciso Pesquisar; não usar no momento...!
        static void ReconhecimentoDeVoz()
        {
            // Cria um objeto SpeechRecognitionEngine
            SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();

            // Define a cultura para reconhecimento de voz (opcional)
            recognizer.SetInputToDefaultAudioDevice(); // Usa o dispositivo de áudio padrão

            // Define uma gramática simples para reconhecer comandos
            Choices comandos = new Choices("Olá", "Como você está", "Sim", "Não", "Continue", "Continuar", "Encerrar");
            GrammarBuilder gb = new GrammarBuilder(comandos);
            Grammar grammar = new Grammar(gb);

            // Carrega a gramática no reconhecedor
            recognizer.LoadGrammarAsync(grammar);

            // Manipuladores de eventos para o reconhecimento de voz
            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Recognizer_SpeechRecognized);
            recognizer.RecognizeAsync(RecognizeMode.Multiple);

            Console.WriteLine("Fale algum dos comandos: 'Olá', 'Como você está', 'Encerrar'");
            Console.ReadLine();

            // Encerra o reconhecedor quando pressionar Enter
            recognizer.Dispose();
        }
        static void Recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result != null && e.Result.Confidence > 0.7) // Verifica a confiança da transcrição
            {
                Console.WriteLine("Você disse: " + e.Result.Text);
                if (e.Result.Text == "Encerrar")
                {
                    Environment.Exit(0);
                }
            }
        }
        public static string Pluralizar(string palavra)
        {
            if (!string.IsNullOrEmpty(palavra))
            {
                if (palavra.Substring(palavra.Length - 1, 1).Contains("a") ||
                    palavra.Substring(palavra.Length - 1, 1).Contains("e") ||
                    palavra.Substring(palavra.Length - 1, 1).Contains("o") ||
                    palavra.Substring(palavra.Length - 1, 1).Contains("m") ||
                    palavra.Substring(palavra.Length - 1, 1).Contains("n"))
                {
                    palavra = palavra + "s";
                }
                else { palavra = palavra + "es"; }
            }
            return palavra;
        }

        public static IEnumerable<string> ObterPastas(string path)
        {
            // Supondo que as pastas estão em um diretório específico
            string caminhoBase = path;

            // Obtém todas as pastas no diretório
            string[] pastas = Directory.GetDirectories(caminhoBase);

            return pastas.Select(Path.GetFileName);
        }

        public static IEnumerable<string> ObterProjetos(string path, string chave)
        {
            // Supondo que as pastas estão em um diretório específico
            string caminhoBase = path;

            // Obtém todas as pastas no diretório
            string[] pastas = Directory.GetDirectories(caminhoBase);
            string[] pastasUsua = new string[] { };

            var pastarUsuario = pastas.Select(Path.GetFileName);
            if (pastarUsuario.Count() > 0)
            {
                foreach (var pasta in pastas)
                {
                    if (pasta.Contains(chave))
                        pastasUsua = new string[] { pasta.ToString().Substring(pasta.IndexOf("Sln") + 3, pasta.Length - pasta.IndexOf("Sln") - 3) };
                }
            }

            return pastasUsua;
        }

        public static string? FormatarTexto(string? texto)
        {
            if (string.IsNullOrEmpty(texto))
            {
                return texto;
            }

            texto = texto.ToLower();
            texto = char.ToUpper(texto[0]) + texto.Substring(1);

            return texto;
        }

        public static IEnumerable<ColunasTabelasEntityModel> MeuRetornoDAOProcedureColunasTabelas()
        {
            List<ColunasTabelasEntityModel> listaColunas = new List<ColunasTabelasEntityModel>();
            string connectionString = "Server=tcp:svdklinmilkfastdev.database.windows.net,1433; Initial Catalog = DbKMilkFastDev; Persist Security Info = False; User ID = KlinMilkFastDev; Password = 022711@2024Gmc; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("ColunasTabelas", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var jsonArray = new JArray();
                        while (reader.Read())
                        {
                            var jsonObject = new JObject();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                jsonObject[reader.GetName(i)] = JToken.FromObject(reader[i]);
                            }
                            jsonArray.Add(jsonObject);
                        }
                        var strJson = jsonArray.ToString().Substring(jsonArray.ToString().IndexOf(":") + 3, jsonArray.ToString().Length - jsonArray.ToString().IndexOf(":") - 12).Replace("\\", "");
                        listaColunas = JsonConvert.DeserializeObject<List<ColunasTabelasEntityModel>>(strJson);
                    }
                }
            }
            return listaColunas;
        }
    }
}
