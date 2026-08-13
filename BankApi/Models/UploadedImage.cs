namespace BankApi.Models
{
    public class UploadedImage
    {
        public Guid ID { get; set; }
        public string FileName { get; set; } = default!;
        public string Extension { get; set; } = default!;
        public string ContentType { get; set; } = default!;
        public long FileSize { get; set; } = default!;
        public string StoredFileName { get; set; } = default!;
        //public string ImagePath { get; set; }=default!;
        public Employee Employee { get; set; } = default!;
        

    }
}
