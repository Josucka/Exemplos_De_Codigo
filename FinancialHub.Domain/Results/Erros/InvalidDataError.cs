using System;

namespace FinancialHub.Domain.Results.Erros
{
    public class InvalidDataError : ServiceError
    {
        private const int code = 400;

        public InvalidDataError(int code, string message, Exception error = null) : base(code, message, error)
        {
        }
    }
}
