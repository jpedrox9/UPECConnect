using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPECLogic.Classes.Aplicacao;
using UPECLogic.Model;
using Repositorios.Base;
using UPECLogic.Interfaces;


namespace UPECLogic.Repositorio
{
    public class StockRepositorio : BaseRepository<Stock>, IStock, IDisposable
    {
        public StockRepositorio(string NameOrConectionString, eTipoBD TipoBD) : base(NameOrConectionString, TipoBD)
        {
        }

        public List<Stock> LerStock()
        {
            var dados = ContextBD.Stock.ToList();
            List<Stock> stock = new List<Stock>();
            foreach(var item1 in dados)
            {
                int check = 0;
                Stock st = new Stock();
                st.Artigo = item1.Artigo;
                foreach (var item2 in dados)
                {
                    if (item1.Artigo == item2.Artigo) st.Existencia += item2.Existencia;
                }
                foreach (var item in stock)
                {
                    if (st.Artigo == item.Artigo)
                    {    
                        check = 1;
                        break;
                    }
                }
                if (check != 1) stock.Add(st);
            }
            return stock;
        }
        public string LerArmazem(string codigo)
        {
            return ContextBD.Stock.Where(x => x.Artigo == codigo).Select(x => x.Armazem).FirstOrDefault();
        }
    }
}
