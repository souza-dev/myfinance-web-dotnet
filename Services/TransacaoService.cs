using AutoMapper;
using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Infrastructure;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Services
{
    public class TransacaoService : ITransacaoService
    {
        private readonly MyFinanceDbContext _myFinanceDbContext;
        private readonly IMapper _mapper;
        private readonly IPlanoContaService _planoContaService;


        public TransacaoService(MyFinanceDbContext myFinanceDbContext, IMapper mapper, IPlanoContaService planoContaService)
        {
            _myFinanceDbContext = myFinanceDbContext;
            _mapper = mapper;
            _planoContaService = planoContaService;
        }

        public void Excluir(int id)
        {
            var item = _myFinanceDbContext.Transacao.Where(x => x.Id == id).First();
            _myFinanceDbContext.Transacao.Attach(item);
            _myFinanceDbContext.Transacao.Remove(item);
            _myFinanceDbContext.SaveChanges();
        }

        public IEnumerable<TransacaoModel> ListarTransacoes()
        {
            var listaTransacao = _myFinanceDbContext.Transacao.ToList();
            var lista = _mapper.Map<IEnumerable<TransacaoModel>>(listaTransacao);
            return lista;
        }

        public TransacaoModel RetornarRegistro(int id)
        {
            var item = _myFinanceDbContext.Transacao.Where(x => x.Id == id).First();
            var lista = _mapper.Map<TransacaoModel>(item);
            return lista;
        }

        public void Salvar(TransacaoModel model)
        {
            var tipoTransacao = _planoContaService.RetornarRegistro(model.PlanoContaId).Tipo;
            var instancia = new Transacao()
            {
                Id = model.Id,
                Historico = model.Historico,
                Data = model.Data,
                Valor = model.Valor,
                PlanoContaId = model.PlanoContaId,
                Tipo = tipoTransacao
            };

            if (instancia.Id == null)
            {
                _myFinanceDbContext.Transacao.Add(instancia);

            }
            else
            {
                _myFinanceDbContext.Transacao.Attach(instancia);
                _myFinanceDbContext.Transacao.Entry(instancia).State = EntityState.Modified;
            }


            _myFinanceDbContext.SaveChanges();
        }
    }
}