using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDTO
{
    [DataContract]
    public class Response<T>
    {
        public Response()
        {
        }

        public Response(T Result)
        {
            this.Result = Result;
        }

        private string responseMessage;

        [DataMember]
        public string ResponseMessage
        {
            get { return responseMessage; }
            set { responseMessage = value; }
        }

        private int responseCode;

        [DataMember]
        public int ResponseCode
        {
            get { return responseCode; }
            set { responseCode = value; }
        }

        private T result;

        [DataMember]
        public T Result
        {
            get { return result; }
            set { result = value; }
        }

        private string status;

        [DataMember]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
