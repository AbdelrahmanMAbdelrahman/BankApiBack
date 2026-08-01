using BankApi.Contracts.Currency;
using BankApi.Models;
using Mapster;

namespace BankApi.Mapping
{
    public class CurrencyMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CurrencyReq, Currency>()
                .Map(des => des.Name, src => src.name)
                .Map(des => des.Code, src => src.code)
                .Map(des => des.Status, src => src.status)
                .Map(des => des.DefaultCurrency, src => src.defaultCurrency)
                .Map(des => des.BaseCurrency, src => src.baseCurrency);

            config.NewConfig<Currency, CurrencyRes>()
                .Map(des => des.id, src => src.ID)
                .Map(des => des.name, src => src.Name)
                .Map(des => des.code, src => src.Code)
                .Map(des => des.status, src => src.Status)
                .Map(des => des.defaultCurrency, src => src.DefaultCurrency)
                .Map(des => des.baseCurrency, src => src.BaseCurrency);
        }
    }
}
