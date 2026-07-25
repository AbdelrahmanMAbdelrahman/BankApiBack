using BankApi.Contracts.Contract;
using BankApi.Models;
using Mapster;

namespace BankApi.Mapping
{
    public class ContractMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ContractReq, Contract>()
                .Map(des => des.PartyID, src => src.partyID)
                .Map(des => des.LeasingType, src => src.leasingType)
                .Map(des => des.ContractNumber, src => src.contractNumber)
                .Map(des => des.ContractType, src => src.contractType)
                .Map(des => des.EndDate, src => src.endDate)
                .Map(des => des.ISLetter, src => src.iSLetter)
                .Map(des => des.StartDate, src => src.startDate);

            config.NewConfig<Contract, ContractRes>()
                .Map(des => des.partyID, src => src.PartyID)
                .Map(des => des.leasingType, src => src.LeasingType)
                .Map(des => des.contractNumber, src => src.ContractNumber)
                .Map(des => des.contractType, src => src.ContractType)
                .Map(des => des.endDate, src => src.EndDate)
                .Map(des => des.iSLetter, src => src.ISLetter)
                .Map(des => des.startDate, src => src.StartDate);

                
                
        }
    }
}
