using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BankApi.Utils
{
    public class PaginatedList<T>
    {
        public int PageNumber { get; set; }
        public List<T> Items {  get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
        public int TotalPages { get; set; }

        public PaginatedList(List<T>items, int pageNumber, int totalCount,int pageSize)
        {
            PageNumber = pageNumber;
            Items = items;
            TotalPages =(int) Math.Ceiling((totalCount /(double) pageSize));
            HasPreviousPage = PageNumber > 1;
            HasNextPage = PageNumber < TotalPages;
        }
        public static async Task<PaginatedList<T>> Create(IQueryable<T>items,int pageSize=10,int pageNumber=1)
        {
         List<T> data=await items.Skip((pageNumber-1)*pageSize)
                .Take(pageSize)
                .ToListAsync();
            int count = await items.CountAsync();
            return new PaginatedList<T>(data, pageNumber, count,pageSize);
        }
    }
}
