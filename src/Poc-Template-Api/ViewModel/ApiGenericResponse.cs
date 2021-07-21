using System.Net;

namespace Poc_Template_Api.ViewModel
{
    public class ApiGenericResponse
    {
        public string ProcessTime { get; set; }
        public string Message { get; set; }
        public HttpStatusCode Status { get; set; }
        public object Value { get; set; }
    }
}
