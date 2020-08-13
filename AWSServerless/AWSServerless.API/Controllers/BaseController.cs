using AWSServerless.API.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace AWSServerless.API.Controllers
{
    public abstract class BaseController : Controller
    {
        // TODO:  This really should be in domain but doing this quick
        public enum StatusType
        {
            /// <summary>
            /// Complete failure of request.
            /// </summary>
            Fail = 0,

            /// <summary>
            /// Request was sent but saving to the database or other logic was not successful.
            /// </summary>
            PartialSuccess = 1,

            /// <summary>
            /// Success
            /// </summary>
            Success = 2
        }

        #region Public Methods

        [ApiExplorerSettings(IgnoreApi = true)]
        public virtual IActionResult GenerateResponse(
            StatusType statusType = StatusType.Fail,
            object value = null,
            string message = "",
            int count = 0
        )
        {
            var genericResponse = new GenericResponse
            {
                Count = count,
                Message = message,
                Status = statusType,
                Value = value
            };

            switch (statusType)
            {
                case StatusType.PartialSuccess:
                case StatusType.Success:
                    return Ok(genericResponse);

                default:
                    return BadRequest(genericResponse);
            }
        }

        #endregion Public Methods
    }
}