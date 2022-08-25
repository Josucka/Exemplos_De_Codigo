using FinancialHub.Domain.Responses.Success;
using FinancialHub.Domain.Results;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FinancialHub.WebApplic.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult CreateResponse<T>(ServiceResult<T> result)
        {
            return this.StatusCode(result.Error.Code, result.Data);
        }

        protected IActionResult SuccessListResponse<T>(ServiceResult<ICollection<T>> result)
        {
            return this.Ok(new ListResponse<T>(result.Data));
        }

        protected IActionResult SuccessSaveResponse<T>(ServiceResult<T> result)
        {
            return this.Ok(new SaveResponse<T>(result.Data));
        }
    }
}

        //https://github.com/Chingling152/my-financial-hub/tree/main/api/src/FinancialHub