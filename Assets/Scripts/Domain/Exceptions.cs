using System;

namespace Domain
{
    public class OperationNotSupportedException : SystemException
    {
        public override string Message => "This ariphmetical operation is not implemented";
    }
}