using FinancialHub.Domain.Results.Erros;

namespace FinancialHub.Domain.Results
{
    public class ServiceResult<T>
    {
        public bool HasError => Error != null;
        public ServiceError Error { get; protected set; }
        public T Data { get; protected set; }

        public ServiceResult(T data = default, ServiceError error = null)
        {
            Error = error;
            Data = data;
        } 

        public static implicit operator ServiceResult<T>(T result)
        {
            return new ServiceResult<T>(result);
        }

        public static implicit operator ServiceResult<T>(ServiceError error)
        {
            return new ServiceResult<T>(error: error);
        }
    }

    public class ServiceResult
    {
        public bool HasError => Error != null;
        public ServiceError Error { get; protected set; }

        public ServiceResult(ServiceError error = null)
        {
            Error = error;
        }

        public static implicit operator ServiceResult(ServiceError error)
        {
            return new ServiceResult(error: error);
        }
    }
}
