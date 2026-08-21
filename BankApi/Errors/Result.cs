namespace BankApi.Errors
{
    public record Result
    {
        public bool IsSuccess { get; set; }
        public bool IsError => !IsSuccess;
        public Error error { get; set; } = default!;
        public Result(bool isSuccess,Error err)
        {
            if ((isSuccess && err != Error.None) || (!isSuccess && err == Error.None))
            {
                throw new InvalidOperationException();
            }
            IsSuccess = isSuccess;
            error = err;
        }
        public static Result Success() => new Result(true,Error.None);
        public static Result Failure(Error err) => new Result(false,err);
        public static Result<T> Success<T>(T val) => new Result<T>(true,Error.None,val);
        public static Result<T> Failure<T>(Error err) => new Result<T>(false,err,default!);
    }


    public record Result<T> : Result
    {
        T _val;
        public Result(bool isSuccess, Error err,T value) :base(isSuccess,err)
        {
         _val = value;    
        }
        public T Value =>IsSuccess? _val:throw new InvalidOperationException();
    }
    
 
}
