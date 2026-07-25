using System.Collections.ObjectModel;

namespace BankApi.Models
{
    public class Party
    {
 public Guid ID { get; set; }
        public string InternalCode { get; set; } = default!;
 public string PartyGroupName { get; set; } = default!;
        public bool Active { get; set; } = default!;
        public string NativeName { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string PartyCode { get; set; } = default!;
        public ICollection<Contract> Contracts { get; set; } = [];
    }
}
