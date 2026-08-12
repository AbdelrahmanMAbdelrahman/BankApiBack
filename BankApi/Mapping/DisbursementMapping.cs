using BankApi.Contracts.Disbursement;
using BankApi.Models;
using Mapster;

namespace BankApi.Mapping
{
    public class DisbursementMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<DisbursementReq, Disbursement>()
                 .Map(des => des.Amount, src => src.amount)
                 .Map(des => des.DisbursementDate, src => src.disbursementDate)
                 .Map(des => des.DisbursementMethod, src => src.disbursementMethod)
                 .Map(des => des.Comments, src => src.comments)
                 .Map(des => des.ContractID, src => src.contractID)
                 .Map(des => des.FacilityID, src => src.facilityID);

            config.NewConfig<Disbursement, DisbursementRes>()
                 .Map(des => des.id, src => src.ID)
                 .Map(des => des.amount, src => src.Amount)
                 .Map(des => des.disbursementDate, src => src.DisbursementDate)
                 .Map(des => des.disbursementMethod, src => src.DisbursementMethod)
                 .Map(des => des.comments, src => src.Comments)
                 .Map(des => des.contract, src => src.Contract.ContractNumber)
                 .Map(des => des.facility, src => src.Facility.AccountNumber)
                 .Map(des => des.contractID, src => src.ContractID)
                 .Map(des => des.facilityID, src => src.FacilityID);
        }
    }
}
