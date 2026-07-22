using BankApi.Contracts.Party;
using BankApi.Models;
using Mapster;

namespace BankApi.Mapping
{
    public class PartyMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<PartyReq, Party>()
                 .Map(des => des.Active, src => src.active)
                 .Map(des => des.InternalCode, src => src.internalCode)
                 .Map(des => des.Name, src => src.name)
                 .Map(des => des.NativeName, src => src.nativeName)
                 .Map(des => des.InternalCode, src => src.internalCode)
                 .Map(des => des.PartyGroupName, src => src.partyGroupName)
                 .Map(des => des.PartyCode, src => src.partyCode);

            config.NewConfig<Party, PartyRes>()
                 .Map(des => des.active, src => src.Active)
                 .Map(des => des.internalCode, src => src.InternalCode)
                 .Map(des => des.name, src => src.Name)
                 .Map(des => des.nativeName, src => src.NativeName)
                 .Map(des => des.internalCode, src => src.InternalCode)
                 .Map(des => des.partyGroupName, src => src.PartyGroupName)
                 .Map(des => des.partyCode, src => src.PartyCode);
        }
    }
}
