using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPECLogic.Model
{
    [Table(UPID.Logic.Sage100c.BaseDados.Tabelas.Artigos)]
    public class Artigos : UPID.Logic.Sage100c.BaseDados.BDArtigos
    {
        //[Column("STATISMA", Order = 51, TypeName = "smallint")]
        //public short IsentoIntrastat { get; set; }

        //[Column("TMVER", Order = 12, TypeName = "nvarchar")]
        //[StringLength(10)]
        //public string TipoMedidaVertical { get; set; }

        //[Column("TMHOR", Order = 10, TypeName = "nvarchar")]
        //[StringLength(10)]
        //public string TipoMedidaHorizontal { get; set; }

        //[Column("CODREF", Order = 50, TypeName = "nvarchar")]
        //[StringLength(15)]
        //public string ArtigoReferenciaMedida { get; set; }

        //[Column("MEDVERT", Order = 13, TypeName = "nvarchar")]
        //[StringLength(10)]
        //public string MedidaVertical { get; set; }

        //[Column("MEDHOR", Order = 11, TypeName = "nvarchar")]
        //[StringLength(10)]
        //public string MedidaHorizontal { get; set; }

        //[Column("WEB", Order = 52, TypeName = "smallint")]
        //public short LigacaoExterna { get; set; }

        //[Column("TVALORIZ", Order = 49, TypeName = "smallint")]
        //public short TipoValorizacao { get; set; }

        //[Column("FORMULA", Order = 47, TypeName = "nvarchar")]
        //[StringLength(3)]
        //public string Formula { get; set; }

        //[Column("INACTIVO", Order = 46, TypeName = "smallint")]
        //public short Inativo { get; set; }

        //[Column("PCMPSIVA", Order = 45, TypeName = "decimal")]
        //public decimal PrecoCMPSemIVA { get; set; }

        //[Column("PCMPCIVA", Order = 44, TypeName = "decimal")]
        //public decimal PrecoCMPComIVA { get; set; }

        //[Column("PVPSIVA", Order = 43, TypeName = "decimal")]
        //public decimal PrecoSemIva { get; set; }

        //[Column("PVPCIVA", Order = 42, TypeName = "decimal")]
        //public decimal PrecoComIVA { get; set; }

        //[Column("TCOMPOSI", Order = 48, TypeName = "smallint")]
        //public short Tipocomposicao { get; set; }

        //[Column("CNMVINT", Order = 41, TypeName = "nvarchar")]
        //[StringLength(5)]
        //public string CTBGrupoMovInterno { get; set; }

        //[Column("PESOLIQ", Order = 53, TypeName = "decimal")]
        //public decimal PesoLiquido { get; set; }

        //[Column("TOTENCCL", Order = 55, TypeName = "decimal")]
        //public decimal EncomendasCliente { get; set; }

        //[Column("CATEGORIA_NUMSERIE", Order = 69, TypeName = "nvarchar")]
        //[StringLength(10)]
        //public string CategoriaNumeroSerie { get; set; }

        //[Column("CONTROLO_NUMSERIE", Order = 68, TypeName = "smallint")]
        //public short ControlaNumeroSerie { get; set; }

        //[Column("NUMERO_AUTORIZACAO", Order = 67, TypeName = "nvarchar")]
        //[StringLength(20)]
        //public string AutorizacaoVenda { get; set; }

        //[Column("TIPO_DESCRITOR", Order = 66, TypeName = "smallint")]
        //public short TipoDescritor { get; set; }

        //[Column("DBTS", Order = 65, TypeName = "timestamp")]
        //public byte[] DBTS { get; set; }

        //[Column("PVP3_COM_IVA", Order = 64, TypeName = "decimal")]
        //public decimal PVP3ComIVA { get; set; }

        //[Column("TOTENCFO", Order = 54, TypeName = "decimal")]
        //public decimal EncomendasFornecedor { get; set; }

        //[Column("PVP3_SEM_IVA", Order = 63, TypeName = "decimal")]
        //public decimal PVP3SemIVA { get; set; }

        //[Column("IVACOMPR", Order = 61, TypeName = "smallint")]
        //public short IvaCompra { get; set; }

        //[Column("STRESENC", Order = 60, TypeName = "decimal")]
        //public decimal StockReservado { get; set; }

        //[Column("MARGEM", Order = 59, TypeName = "decimal")]
        //public decimal Margem { get; set; }

        //[Column("PVALCIVA", Order = 58, TypeName = "decimal")]
        //public decimal PVP2ComIva { get; set; }

        //[Column("PVALSIVA", Order = 57, TypeName = "decimal")]
        //public decimal PVP2SemIva { get; set; }

        //[Column("DESCRRTF", Order = 56, TypeName = "nvarchar")]
        //[StringLength(4000)]
        //public string DescricaoRTF { get; set; }

        //[Column("DESCONTO_COMPRA", Order = 62, TypeName = "decimal")]
        //public decimal DescontoCompra { get; set; }

        //[Column("ULTPMP", Order = 40, TypeName = "float")]
        //public double UltimoPrecoMedio { get; set; }

        //[Column("PRSTND", Order = 39, TypeName = "decimal")]
        //public decimal PrecoStandard { get; set; }

        //[Column("QTDMINEN", Order = 38, TypeName = "decimal")]
        //public decimal QtdMinimaEncomenda { get; set; }

        //[Column("ARTASSOC", Order = 21, TypeName = "nvarchar")]
        //[StringLength(15)]
        //public string ArtigoAssociado { get; set; }

        //[Column("ARTSUBST", Order = 20, TypeName = "nvarchar")]
        //[StringLength(15)]
        //public string ArtigoSubstituto { get; set; }

        //[Column("STMAX", Order = 19, TypeName = "decimal")]
        //public decimal StockMaximo { get; set; }

        //[Column("CNCOMPRA", Order = 18, TypeName = "nvarchar")]
        //[StringLength(5)]
        //public string CTBGrupoCompras { get; set; }

        //[Column("CNVENDAS", Order = 17, TypeName = "nvarchar")]
        //[StringLength(5)]
        //public string CTBGrupoVendas { get; set; }

        //[Column("STMIN", Order = 16, TypeName = "decimal")]
        //public decimal StockMinimo { get; set; }

        //[Column("OBSERV", Order = 22, TypeName = "nvarchar")]
        //[StringLength(35)]
        //public string Observacoes { get; set; }

        //[Column("STDISP", Order = 6, TypeName = "decimal")]
        //public decimal StockDisponivel { get; set; }

        //[Column("VLREXIST", Order = 4, TypeName = "decimal")]
        //public decimal ValorExistencia { get; set; }

        //[Column("IVA", Order = 15, TypeName = "smallint")]
        //public short IvaVendas { get; set; }

        //[Column("NOME", Order = 3, TypeName = "nvarchar")]
        //[StringLength(80)]
        //public string Nome { get; set; }

        //[Column("ABREV", Order = 2, TypeName = "nvarchar")]
        //[StringLength(15)]
        //public string Abreviatura { get; set; }

        //[Column("NUMERO", Order = 1, TypeName = "int")]
        //public int Numero { get; set; }

        //[Column("CODIGO", Order = 0, TypeName = "nvarchar")]
        //[Key]
        //[StringLength(15)]
        //public string Codigo { get; set; }

        //[Column("FORNEC", Order = 5, TypeName = "nvarchar")]
        //[StringLength(15)]
        //public string Fornecedor { get; set; }

        //[Column("BLNOTAS", Order = 23, TypeName = "ntext")]
        //[StringLength(1073741823)]
        //public string ObservacoesBlocoNotas { get; set; }

        //[Column("FAMILIA", Order = 8, TypeName = "nvarchar")]
        //[StringLength(6)]
        //public string Familia { get; set; }

        //[Column("SUBFAMIL", Order = 9, TypeName = "nvarchar")]
        //[StringLength(6)]
        //public string SubFamilia { get; set; }

        //[Column("UNVND", Order = 37, TypeName = "nvarchar")]
        //[StringLength(3)]
        //public string UnidadeVenda { get; set; }

        //[Column("UNCMP", Order = 36, TypeName = "nvarchar")]
        //[StringLength(3)]
        //public string UnidadeCompra { get; set; }

        //[Column("FACTTRA", Order = 35, TypeName = "decimal")]
        //public decimal FactorTransporte { get; set; }

        //[Column("FACTEMB", Order = 34, TypeName = "decimal")]
        //public decimal FactorEmbalagem { get; set; }

        //[Column("UNTRANS", Order = 33, TypeName = "nvarchar")]
        //[StringLength(3)]
        //public string UnidadeTransporte { get; set; }

        //[Column("UNEMB", Order = 32, TypeName = "nvarchar")]
        //[StringLength(3)]
        //public string UnidadeEmbalagem { get; set; }

        //[Column("UNBASE", Order = 31, TypeName = "nvarchar")]
        //[StringLength(3)]
        //public string UnidadeBase { get; set; }

        //[Column("TPBEM", Order = 30, TypeName = "smallint")]
        //public short TipoBem { get; set; }

        //[Column("DTSAID", Order = 29, TypeName = "datetime")]
        //public DateTime? DataUltimaSaida { get; set; }

        //[Column("DTENTR", Order = 28, TypeName = "datetime")]
        //public DateTime? DataUltimaEntrada { get; set; }

        //[Column("VOLUME", Order = 27, TypeName = "decimal")]
        //public decimal Volume { get; set; }

        //[Column("PESO", Order = 26, TypeName = "decimal")]
        //public decimal PesoBruto { get; set; }

        //[Column("GRUPO", Order = 7, TypeName = "nvarchar")]
        //[StringLength(6)]
        //public string Grupo { get; set; }

        //[Column("CODPAUTA", Order = 25, TypeName = "nvarchar")]
        //[StringLength(10)]
        //public string CodigoPautal { get; set; }

        //[Column("CTRSTOCK", Order = 24, TypeName = "smallint")]
        //public short ControlaStock { get; set; }

        //[Column("CONTROLO_LOTES", Order = 70, TypeName = "smallint")]
        //public short ControlaLotes { get; set; }

        //[Column("CATEGORIA_LOTES", Order = 71, TypeName = "nvarchar")]
        //[StringLength(10)]
        //public string CategoriaLotes { get; set; }
    }
}
