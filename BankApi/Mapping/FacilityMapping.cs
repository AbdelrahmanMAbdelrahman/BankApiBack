using BankApi.Contracts.Facility;
using BankApi.Models;
using Mapster;

namespace BankApi.Mapping
{
    public class FacilityMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<FacilityReq, Facility>()
                .Map(des => des.CurrencyID, src => src.currencyID)
                .Map(des => des.PartyID, src => src.partyID)
                .Map(des => des.AccountNumber, src => src.accountNumber)
                .Map(des => des.FacilityType, src => src.facilityType);
            config.NewConfig<Facility, FacilityRes>()
                .Map(des => des.id, src => src.ID)
                .Map(des => des.currencyID, src => src.CurrencyID)
                .Map(des => des.partyID, src => src.PartyID)
                .Map(des => des.accountNumber, src => src.AccountNumber)
                .Map(des => des.facilityType, src => src.FacilityType);
        }
    }
}
