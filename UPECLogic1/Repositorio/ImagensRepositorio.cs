using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPECLogic.Classes.Aplicacao;
using UPECLogic.Model;
using Repositorios.Base;
using UPECLogic.Interfaces;
using System.IO;

namespace UPECLogic.Repositorio
{
    public class ImagensRepositorio : BaseRepository<Imagens>, IImagens, IDisposable
    {
        public ImagensRepositorio(string NameOrConectionString, eTipoBD TipoBD) : base(NameOrConectionString, TipoBD)
        {
        }

        public List<Imagens> LerImagens()
        {
            return ContextBD.Imagens.ToList();
        }

        public void InserirImagem(FileInfo imagem, string artigo, string id)
        {
            DateTime data = imagem.LastWriteTime;
            var interval = new TimeSpan(0, 0, 1);
            data = new DateTime((long)Math.Round(data.Ticks / (double)interval.Ticks) * interval.Ticks);
            var img = new Imagens
            { 
                Nome = imagem.Name,
                Artigo = artigo,
                Codigo = id,
                Data_Mod = data
            };
            ContextBD.Imagens.Add(img);
            ContextBD.SaveChanges();
        }

        public void ApagarImagem(Imagens img)
        {
            ContextBD.Imagens.Remove(img);
            ContextBD.SaveChanges();
        }
    }
}
