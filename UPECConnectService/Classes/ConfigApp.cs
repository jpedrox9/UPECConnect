namespace UPECConnectService
{
    public class ConfigApp
    {
        public Dados Dados { get; set; }
        public int TempoArranque { get; set; }
        public string Images_Path { get; set; }
        public string Logs_Path { get; set; }
        public string EmpresaId { get; set; }

        public static bool Compare(ConfigApp obj, ConfigApp another)
        {
            // If null or the same, return true
            if (ReferenceEquals(obj, another)) return true;

            // If one of them is null, return false
            if ((obj == null) || (another == null)) return false;

            return obj.Images_Path.Equals(another.Images_Path)
                   && obj.Logs_Path.Equals(another.Logs_Path)
                   && obj.TempoArranque == another.TempoArranque
                   && obj.Dados.DadosDoc.Serie == another.Dados.DadosDoc.Serie
                   && obj.Dados.DadosDoc.Setor.Equals(another.Dados.DadosDoc.Setor)
                   && obj.Dados.DadosDoc.TipoDoc.Equals(another.Dados.DadosDoc.TipoDoc)
                   && obj.Dados.DadosERP.BaseDados.Equals(another.Dados.DadosERP.BaseDados)
                   && obj.Dados.DadosERP.Password.Equals(another.Dados.DadosERP.Password)
                   && obj.Dados.DadosERP.Servidor.Equals(another.Dados.DadosERP.Servidor)
                   && obj.Dados.DadosERP.Utilizador.Equals(another.Dados.DadosERP.Utilizador)
                   && obj.Dados.DadosERP.WebService.Equals(another.Dados.DadosERP.WebService)
                   && obj.Dados.DadosSite.Token.Equals(another.Dados.DadosSite.Token)
                   && obj.Dados.DadosSite.URL.Equals(another.Dados.DadosSite.URL);
        }
    }

}
