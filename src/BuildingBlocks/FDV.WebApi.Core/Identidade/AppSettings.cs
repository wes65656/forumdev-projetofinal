namespace FDV.WebApi.Core.Identidade;

public class AppSettings
{
    public string Secret { get; set; }

    public int ExpiracaHoras { get; set; }

    public string Emissor { get; set; }

    public string ValidoEm { get; set; }
}