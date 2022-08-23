using System;

namespace FinancialHub.Domain.Results.Erros
{
    public class NotFoundError : ServiceError
    {
        private const int code = 404;
        public NotFoundError(string message, Exception error = null) : base(code, message, error) { }
    }
}
