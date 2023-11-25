namespace myfinance_web_netcore.Domain
{
    public class PlanoConta
    {
        public int? Id { get; set; }
        public required string Descricao { get; set; }
        public required string Tipo { get; set; }
    }

}