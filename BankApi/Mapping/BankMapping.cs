using BankApi.Contracts.Bank;
using BankApi.Models;
using Mapster;

namespace BankApi.Mapping
{
    public class BankMapping:IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<BankReq, Bank>()
                .Map(des => des.CurrencyID, src => src.currencyID)
                .Map(des => des.Phone, src => src.phone)
                .Map(des => des.Fax, src => src.fax)
                .Map(des => des.EMail, src => src.eMail)
                .Map(des => des.Address, src => src.address)
                .Map(des => des.Abbreviation, src => src.abbreviation)
                .Map(des => des.LookupCode, src => src.lookupCode)
                .Map(des => des.SwiftCode, src => src.swiftCode)
                .Map(des => des.Active, src => src.active)
                .Map(des => des.Description, src => src.description);

        }
    }
}
