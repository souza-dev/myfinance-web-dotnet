namespace myfinance_web_netcore.Models
{
    public class PlanoContaModel
    {
        public int? Id { get; set; }
        public required string Descricao { get; set; }
        public required string Tipo { get; set; }
    }

}