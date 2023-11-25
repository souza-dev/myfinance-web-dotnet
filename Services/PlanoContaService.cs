using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Infrastructure;

namespace myfinance_web_netcore.Services
{
    public class PlanoContaService : IPlanoContaService
    {
        private readonly MyFinanceDbContext _myFinanceDbContext;
        public PlanoContaService(MyFinanceDbContext myFinanceDbContext)
        {
            _myFinanceDbContext = myFinanceDbContext;
        }

        public IEnumerable<PlanoConta> ListarPlanoContas()
        {
            return _myFinanceDbContext.PlanoConta.ToList();
        }
    }
}