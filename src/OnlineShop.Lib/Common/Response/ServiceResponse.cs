using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Lib.Common.Response
{
    public class ServiceResponse<T>
    {
        public ServiceResponse(T payload)
        {
            Payload = payload;
        }

        public ServiceResponse(ICollection<string> errors)
        {
            Errors = errors;
        }

        public T Payload { get; init; } = default;

        public ICollection<string> Errors { get; init; } = new List<string>();

        public bool IsSuccessfull => Errors.Count() == 0;
    }
}
