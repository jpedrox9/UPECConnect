using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPID.Extensoes.File;
using UPECLogic.Model;
using UPECLogic.Repositorio;
using System.IO;
using System.Net.Http;
using RestSharp;
using UPWebPrestaShop.Models;
using UPWebPrestaShop;
using System.Data.SqlClient;

namespace UPWebPrestashop.Services
{
    public class ImagensService : Base
    {
        private readonly string _site;
        private readonly URLParameters _key;
        public ImagensService(string Site, string Key) : base(Site, Key)
        {
            _site = Site;
            _key = new URLParameters()
            {
                Propriedade = "ws_key",
                Valor = Key
            };
        }

        private string URL = "images/products";

        public void AtualizarImagens(ConfigApp config, string connectionString)
        {
            DirectoryInfo pasta = new DirectoryInfo(config.Images_Path);
            FileInfo[] imagens = pasta.GetFiles();
            var artigosService = new ArtigosService(_site, _key.Valor);
            var artigos = artigosService.ListaArtigos();
            var imagensRepositorio = new ImagensRepositorio(connectionString, UPECLogic.Classes.Aplicacao.eTipoBD.SQL);
            List<Imagens> imgs = imagensRepositorio.LerImagens();

            //verificar se existem imagens por adicionar
            foreach (var artigo in artigos)
            {
                foreach (var imagem in imagens)
                {
                    if (imagem.Name.StartsWith(artigo.reference) && artigo.reference != "")
                    {
                        var imgsSite = ListaImagens(artigo.id);
                        if (imgsSite.Count != 0)
                        {
                            int check = 0;
                            foreach (var img in imgs)
                            {
                                if (img.Nome == imagem.Name) check = 1;
                            }
                            if (check != 1)
                            {
                                byte[] file = File.ReadAllBytes(imagem.FullName);
                                var sres = InserirImagem(artigo.id, file, imagem.Name);
                                string id = ListaImagens(artigo.id)[imgsSite.Count()];
                                imagensRepositorio.InserirImagem(imagem, artigo.reference, id);
                                CreateLog(config.Logs_Path, artigo, id, sres, "inserir");
                            }
                        }
                        else
                        {
                            byte[] file = File.ReadAllBytes(imagem.FullName);
                            var sres = InserirImagem(artigo.id, file, imagem.Name);
                            string id = ListaImagens(artigo.id)[imgsSite.Count()];
                            imagensRepositorio.InserirImagem(imagem, artigo.reference, id);
                            CreateLog(config.Logs_Path, artigo, id, sres, "inserir");
                        }
                    }
                }
            }

            //eliminar imagens que não existam
            imgs = imagensRepositorio.LerImagens();
            foreach (var img in imgs)
            {
                int check = 0;
                foreach (var imagem in imagens)
                {
                    if (imagem.Name == img.Nome) check = 1;
                }
                if (check != 1)
                {
                    var artigo = new Product();
                    foreach (var art in artigos)
                    {
                        if (art.reference == img.Artigo) artigo = art;
                    }
                    var sres = ApagarImagem(artigo.id, img.Codigo);
                    imagensRepositorio.ApagarImagem(img);
                    CreateLog(config.Logs_Path, artigo, img.Codigo, sres, "apagar");
                }
            }

            //atualizar imagens que foram alteradas
            imgs = imagensRepositorio.LerImagens();
            foreach (var img in imgs)
            {
                foreach (var imagem in imagens)
                {
                    DateTime data = imagem.LastWriteTime;
                    var interval = new TimeSpan(0, 0, 1);
                    data = new DateTime((long)Math.Round(data.Ticks / (double)interval.Ticks) * interval.Ticks);
                    int comparacao = DateTime.Compare(data, img.Data_Mod);
                    if (imagem.Name == img.Nome && comparacao != 0 /*&& File.ReadAllBytes(imagem.FullName).Length <*/ )
                    {
                        string id = "";
                        foreach (var artigo in artigos)
                        {
                            if (artigo.reference == img.Artigo) id = artigo.id;
                        }
                        var imgsSite = ListaImagens(id);
                        ApagarImagem(id, img.Codigo);
                        byte[] file = File.ReadAllBytes(imagem.FullName);
                        InserirImagem(id, file, imagem.Name);

                        string artigoRef = img.Artigo;
                        imagensRepositorio.ApagarImagem(img);
                        string imagemId = ListaImagens(id)[imgsSite.Count()];
                        imagensRepositorio.InserirImagem(imagem, artigoRef, imagemId);
                    }
                }
            }
        }

        public async Task<List<string>> ListaImagensAsync(string id)
        {
            List<URLParameters> Parametros = new List<URLParameters>();
            Parametros.Add(_key);

            using (HttpResponseMessage RestResponse = await ClienteHTTP.GetAsync(GetURL(URL, id, Parametros)))
            {
                ImagensResponse sResult = await RestResponse.GetContent<ImagensResponse>();
                List<string> result = new List<string>();
                if(sResult != null)
                {
                    int i = 0;
                    foreach(var item in sResult.Imagens)
                    {
                        if(i != 0) result.Add(item.id);
                        i++;
                    }
                }
                return result;
            }

        }
        public List<string> ListaImagens(string id)
        {
            var st = Task.Run(async () =>
            {
                return await ListaImagensAsync(id);
            });
            st.Wait();
            return st.Result;
        }


        public async Task<Resultado> InserirImagemAsync(string id, byte[] Dados, string nome)
        {
            if(Dados.Length > 1962855)
            {
                Resultado res = new Resultado();
                res.Sucesso = false;
                res.Mensagem = "Imagem não suportada";
                return res;
            }

            List<URLParameters> Parametros = new List<URLParameters>();
            Parametros.Add(_key);

            var client = new RestClient(GetURL(""));

            var request = new RestRequest(GetURL(URL, id, Parametros), Method.POST);
            request.AddFileBytes("image", Dados, nome);

            IRestResponse response = await client.ExecuteAsync(request);
            Resultado sResultado = new Resultado();
            if (response.ResponseStatus == ResponseStatus.Completed) sResultado.Sucesso = true;
            else
            {
                sResultado.Sucesso = false;
                sResultado.Mensagem = response.ErrorMessage;
            }

            return sResultado;
        }
        public Resultado InserirImagem(string id, byte[] Dados, string nome)
        {
            var st = Task.Run(async () =>
            {
                return await InserirImagemAsync(id, Dados, nome);
            });
            st.Wait();
            return st.Result;
        }

        public async Task<Resultado> ApagarImagemAsync(string id, string imagemId)
        {
            List<URLParameters> Parametros = new List<URLParameters>();
            Parametros.Add(_key);

            id += "/" + imagemId;

            Resultado sResultado = new Resultado();

            using (HttpResponseMessage RestResponse = await ClienteHTTP.DeleteAsync(GetURL(URL, id, Parametros)))
            {
                try
                {
                    ArtigosResponse sResult = await RestResponse.GetContent<ArtigosResponse>();
                    sResultado.Sucesso = true;
                }
                catch (Exception ex)
                {
                    sResultado.Mensagem = ex.Message;
                    sResultado.Sucesso = false;
                }
            }
            return sResultado;
        }

        public Resultado ApagarImagem(string id, string imagemId)
        {
            var st = Task.Run(async () =>
            {
                return await ApagarImagemAsync(id, imagemId);
            });
            st.Wait();
            return st.Result;
        }
        public void CreateLog(string localizacao, Product artigo, string id, Resultado res, string acao)
        {
            DirectoryInfo pasta = new DirectoryInfo(localizacao);
            FileInfo[] logs = pasta.GetFiles();
            string nome = (logs.Count() + 1).ToString();

            string descricao = "Id = " + id + " : ";
            if (acao == "inserir") descricao += "Inserido - ";
            else if (acao == "apagar") descricao += "Apagado - ";
            descricao += "Sucesso";
            if (res.Sucesso == false) descricao = "Erro! " + res.Mensagem;
            var log = new Logs()
            {
                Sincronizado = "Imagem",
                Codigo_BD = artigo.reference,
                Codigo_Site = artigo.id,
                Data = DateTime.Now,
                Descricao = descricao
            };

            string texto = Newtonsoft.Json.JsonConvert.SerializeObject(log, Newtonsoft.Json.Formatting.Indented);

            using (FileStream fs = File.Create(localizacao + @"\" + nome + ".json"))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(texto);
                fs.Write(info, 0, info.Length);
            }
        }
    }
}
