using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static AWSServerless.API.Controllers.BaseController;

namespace AWSServerless.API.ResponseModels
{
    public class GenericResponse
    {
        #region Public Properties

        public int Count { get; set; } = 0;
        public string Message { get; set; }
        public StatusType Status { get; set; } = StatusType.Fail;
        public object Value { get; set; }

        #endregion Public Properties

    }
}
