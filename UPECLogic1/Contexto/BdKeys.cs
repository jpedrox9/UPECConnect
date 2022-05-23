using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPECLogic.Contexto
{
    internal static class BdKeys
    {
        public static void SetKeys(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model.Artigos>().Property(x => x.Codigo).HasMaxLength(15);
            modelBuilder.Entity<Model.Artigos>().Property(x => x.Abreviatura).HasMaxLength(15);
            modelBuilder.Entity<Model.Artigos>().Property(x => x.Nome).HasMaxLength(80);
            modelBuilder.Entity<Model.Artigos>().Property(x => x.Fornecedor).HasMaxLength(15);
            modelBuilder.Entity<Model.Artigos>().Property(x => x.CTBGrupoVendas).HasMaxLength(5);
            modelBuilder.Entity<Model.Artigos>().Property(x => x.CTBGrupoCompras).HasMaxLength(5);
            modelBuilder.Entity<Model.Artigos>().Property(x => x.ArtigoSubstituto).HasMaxLength(15);
            modelBuilder.Entity<Model.Artigos>().Property(x => x.ArtigoAssociado).HasMaxLength(15);
            modelBuilder.Entity<Model.Artigos>().Property(x => x.Observacoes).HasMaxLength(35);
            modelBuilder.Entity<Model.Artigos>().Property(x => x.Familia).HasMaxLength(6);
            modelBuilder.Entity<Model.Artigos>().Property(x => x.SubFamilia).HasMaxLength(6);
            modelBuilder.Entity<Model.Artigos>().Property(x => x.CodigoPautal).HasMaxLength(10);
            modelBuilder.Entity<Model.Artigos>().Property(x => x.Grupo).HasMaxLength(6);
            modelBuilder.Entity<Model.Artigos>().Property(x => x.UnidadeBase).HasMaxLength(3);
            modelBuilder.Entity<Model.Artigos>().Property(x => x.UnidadeEmbalagem).HasMaxLength(3);
            modelBuilder.Entity<Model.Artigos>().Property(x => x.UnidadeTransporte).HasMaxLength(3);
            modelBuilder.Entity<Model.Artigos>().Property(x => x.UnidadeCompra).HasMaxLength(3);
            modelBuilder.Entity<Model.Artigos>().Property(x => x.UnidadeVenda).HasMaxLength(3);
            modelBuilder.Entity<Model.Artigos>().Property(x => x.CTBGrupoMovInterno).HasMaxLength(5);
            modelBuilder.Entity<Model.Artigos>().Property(x => x.Formula).HasMaxLength(3);
            modelBuilder.Entity<Model.Artigos>().Property(x => x.MedidaHorizontal).HasMaxLength(10);
            modelBuilder.Entity<Model.Artigos>().Property(x => x.MedidaVertical).HasMaxLength(10);
            modelBuilder.Entity<Model.Artigos>().Property(x => x.ArtigoReferenciaMedida).HasMaxLength(15);
            modelBuilder.Entity<Model.Artigos>().Property(x => x.TipoMedidaHorizontal).HasMaxLength(10);
            modelBuilder.Entity<Model.Artigos>().Property(x => x.TipoMedidaVertical).HasMaxLength(10);
            modelBuilder.Entity<Model.Artigos>().Property(x => x.DescricaoRTF).HasMaxLength(4000);
            modelBuilder.Entity<Model.Artigos>().Property(x => x.AutorizacaoVenda).HasMaxLength(20);
            modelBuilder.Entity<Model.Artigos>().Property(x => x.CategoriaNumeroSerie).HasMaxLength(10);
            modelBuilder.Entity<Model.Artigos>().Property(x => x.CategoriaLotes).HasMaxLength(10);

            //modelBuilder.Entity<UPID.Logic.Sage100c.Model.AjudaCompra>().HasKey(x => new { x.Artigo, x.Fornecedor });
            //modelBuilder.Entity<UPID.Logic.Sage100c.Model.ArtigoPorArmazem>().HasKey(x => new { x.Artigo, x.Armazem });
            //modelBuilder.Entity<UPID.Logic.Sage100c.Model.ArtigosLotes>().HasKey(x => new { x.Artigo, x.CodigoLote, x.VossoLote, x.Armazem });
            //modelBuilder.Entity<UPID.Logic.Sage100c.Model.ArtigosOperacoes>().HasKey(x => new { x.Artigo, x.Operacao, x.Sequencia });
            //modelBuilder.Entity<UPID.Logic.Sage100c.Model.ArtigosPorIdioma>().HasKey(x => new { x.Artigo, x.Idioma });
            //modelBuilder.Entity<UPID.Logic.Sage100c.Model.Balcoes>().HasKey(x => new { x.Banco, x.CodigoPostal });
            //modelBuilder.Entity<UPID.Logic.Sage100c.Model.CodigoBarras>().HasKey(x => new { x.Codigo, x.Artigo, x.Imprime });
            //modelBuilder.Entity<UPID.Logic.Sage100c.Model.ConfiguracaoSeriePorSectorTipoDocumento>().HasKey(x => new { x.Sector, x.TipoDocumento });
            //modelBuilder.Entity<UPID.Logic.Sage100c.Model.Contas>().HasKey(x => new { x.Banco, x.Balcao, x.NumeroConta });
            //modelBuilder.Entity<UPID.Logic.Sage100c.Model.DocContaCorrenteCab>().HasKey(x => new { x.TipoDocumento, x.NumeroDocumento, x.Serie, x.Ano });
            //modelBuilder.Entity<UPID.Logic.Sage100c.Model.DocContaCorrenteLin>().HasKey(x => new { x.TipoDocumento, x.NumeroDoc, x.Serie, x.NumeroLinha, x.Ano });
            //modelBuilder.Entity<UPID.Logic.Sage100c.Model.DocumentoCab>().HasKey(x => new { x.TipoDocumento, x.NumeroDoc, x.Serie, x.Ano });
            //modelBuilder.Entity<UPID.Logic.Sage100c.Model.DocumentoCabTerceiro>().HasKey(x => new { x.TipoDocumento, x.NumeroDocumento, x.Serie, x.Ano });
            //modelBuilder.Entity<UPID.Logic.Sage100c.Model.DocumentoLinhas>().HasKey(x => new { x.TipoDocumento, x.NumeroDocumento, x.NumeroLinha, x.Serie, x.Ano });
            //modelBuilder.Entity<UPID.Logic.Sage100c.Model.DocumentosCab_Armazem>().HasKey(x => new { x.TipoDocumento, x.NumeroDoc, x.Serie, x.Ano });
            //modelBuilder.Entity<UPID.Logic.Sage100c.Model.DocumentosCab_Clientes>().HasKey(x => new { x.TipoDocumento, x.NumeroDoc, x.Serie, x.Ano });
            //modelBuilder.Entity<UPID.Logic.Sage100c.Model.DocumentosCab_Fornecedor>().HasKey(x => new { x.TipoDocumento, x.NumeroDoc, x.Serie, x.Ano });
            //modelBuilder.Entity<UPID.Logic.Sage100c.Model.DocumentosCab_Sector>().HasKey(x => new { x.TipoDocumento, x.NumeroDoc, x.Serie, x.Ano });
            //modelBuilder.Entity<UPID.Logic.Sage100c.Model.Documentos_CamposLivres>().HasKey(x => new { x.TipoDocumento, x.NumeroDocumento, x.Serie, x.Ano });
            //modelBuilder.Entity<UPID.Logic.Sage100c.Model.Familia>().HasKey(x => new { x.Codigo, x.Grupo });
            //modelBuilder.Entity<UPID.Logic.Sage100c.Model.LinhaPrecosArtigo>().HasKey(x => new { x.Artigo, x.Moeda, x.LinhaPreco });
            //modelBuilder.Entity<UPID.Logic.Sage100c.Model.MedidaTamanhoCor>().HasKey(x => new { x.Tipo, x.Medida });
            //modelBuilder.Entity<UPID.Logic.Sage100c.Model.MoradasAlternativas_Cliente>().HasKey(x => new { x.Terceiro, x.CodigoMorada });
            //modelBuilder.Entity<UPID.Logic.Sage100c.Model.MoradasAlternativas_fornecedor>().HasKey(x => new { x.Terceiro, x.CodigoMorada });
            //modelBuilder.Entity<UPID.Logic.Sage100c.Model.MovimentoLotes>().HasKey(x => new { x.TipoDocumento, x.NumeroDocumento, x.Serie, x.Ano, x.CodigoLote, x.NumeroLinha, x.VossoLote });
            //modelBuilder.Entity<UPID.Logic.Sage100c.Model.MovimentosContabilisticos>().HasKey(x => new { x.TipoDocumento, x.NumeroDocumento, x.Serie, x.Ano, x.NumeroLinha });
            //modelBuilder.Entity<UPID.Logic.Sage100c.Model.MovimentosNumSerie>().HasKey(x => new { x.TipoDocumento, x.NumeroDocumento, x.Serie, x.Ano, x.NumeroLinha, x.NumSerie });
            //modelBuilder.Entity<UPID.Logic.Sage100c.Model.OperacoesFactores>().HasKey(x => new { x.Artigo, x.Operacao, x.ArtigoComposto, x.Sequencia });
            //modelBuilder.Entity<UPID.Logic.Sage100c.Model.Serie>().HasKey(x => new { x.TipoDocumento, x.CodigoSerie });
            //modelBuilder.Entity<UPID.Logic.Sage100c.Model.SubFamilia>().HasKey(x => new { x.Codigo, x.Familia, x.Grupo });
        }
    }
}
