using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Services
{
    public interface IPlanoContaService
    {
        IEnumerable<PlanoConta> ListarPlanoContas();
    }
}