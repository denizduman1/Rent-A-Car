using Shared.Utilities.Results.Abstract;
using Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        public string Message { get; }
        public ResultStatus ResultStatus { get; }
        public Exception Exception { get; }

        public Result(ResultStatus resultStatus)
        {
            ResultStatus = resultStatus;
        }
        public Result(ResultStatus resultStatus, string message) : this(resultStatus)
        {
            Message = message;
        }
        public Result(ResultStatus resultStatus, Exception exception) : this(resultStatus)
        {
            Exception = exception;
        }

        public Result(ResultStatus resultStatus, Exception exception, string message) : this(resultStatus, message)
        {
            Exception = exception;
        }
    }
}
