using Shared.Utilities.Results.Abstract;
using Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Utilities.Results.Concrete
{
    public class DataResult<T> : Result,IDataResult<T>
    {
        public T Data { get; }

        public DataResult(T data, ResultStatus resultStatus) : base(resultStatus)
        {
            Data = data;
        }

        public DataResult(T data, ResultStatus resultStatus, string message) : base(resultStatus, message)
        {
            Data = data;
        }

        public DataResult(T data, ResultStatus resultStatus, Exception exception) : base(resultStatus, exception)
        {
            Data = data;
        }

        public DataResult(T data, ResultStatus resultStatus, Exception exception, string message) : base(resultStatus, exception, message)
        {
            Data = data;
        }
    }
}
