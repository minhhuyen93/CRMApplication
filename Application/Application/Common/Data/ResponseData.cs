using Application.Common.Validation;
using System.Collections.Generic;
using System.Net;

namespace Application.Common.Data
{
    public class ResponseData
    {
        public object Data { get; set; }
        public IList<ValidationError> Errors { get; set; }
        public HttpStatusCode Status { get; set; }
        public ResponseData()
        {
            this.Errors = new List<ValidationError>();
            this.Status = HttpStatusCode.OK;
        }

        internal void SetStatus(HttpStatusCode status)
        {
            this.Status = status;
        }

        internal void SetErrors(IList<ValidationError> errors)
        {
            this.Status = HttpStatusCode.BadRequest;
            this.Errors = errors;
        }

        internal void SetData(object data)
        {
            this.Status = HttpStatusCode.OK;
            this.Data = data;
        }
    }
}