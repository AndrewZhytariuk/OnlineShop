namespace OnlineShop.Lib
{
    public class PromiseResult<T>
    {
        public bool IsRejected { get; private set; }
        public bool IsCompleted { get; private set; }
        public string RejectionMessage { get; private set; }
        public Exception Exception { get; private set; }
        public T Result { get; private set; }

        public PromiseResult<TNew> AsPromiseResult<TNew>(Func<T, TNew> converter = null, bool withPartialResult = false)
        {
            TNew convertedResult = converter == null ?
                default(TNew) :
                Result != null ? converter(Result) : default(TNew);

            if (withPartialResult && IsRejected)
            {
                return new PromiseResult<TNew>()
                {
                    Result = convertedResult,
                    Exception = Exception,
                    IsRejected = true,
                    RejectionMessage = RejectionMessage
                };
            }

            if (!string.IsNullOrEmpty(RejectionMessage))
            {
                return PromiseResult<TNew>.Rejected(RejectionMessage);
            }
            else if (Exception != null)
            {
                return PromiseResult<TNew>.Failed(Exception);
            }

            return PromiseResult<TNew>.Done(convertedResult);
        }

        public static PromiseResult<T> Done(T result)
        {
            return new PromiseResult<T>()
            {
                Result = result,
                IsCompleted = true
            };
        }

        public static PromiseResult<T> Rejected(string reason)
        {
            return new PromiseResult<T>()
            {
                RejectionMessage = reason,
                IsRejected = true
            };
        }

        public static PromiseResult<T> Failed(Exception exception)
        {
            return new PromiseResult<T>()
            {
                Exception = exception,
                IsRejected = true
            };
        }

        public static PromiseResult<T> FailedWithPartialResult(T partialResult, Exception exception, string reason)
        {
            return new PromiseResult<T>()
            {
                Result = partialResult,
                Exception = exception,
                IsRejected = true,
                RejectionMessage = reason
            };
        }
    }
}
