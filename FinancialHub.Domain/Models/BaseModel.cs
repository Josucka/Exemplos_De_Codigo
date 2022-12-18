using System;

namespace FinancialHub.Domain.Models
{
    public abstract class BaseModel
    {
        public Guid? Id { get; set; }
    }
}
