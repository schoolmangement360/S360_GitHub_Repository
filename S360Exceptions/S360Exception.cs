using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace S360Exceptions
{
    [Serializable]
    public class S360Exception : Exception
    {
        public S360Exception()
            : base() { S360Logging.S360Log.Instance.Error("Exception Occured"); }

        public S360Exception(string message)
            : base(message) { S360Logging.S360Log.Instance.Error(message); }

        public S360Exception(string format, params object[] args)
            : base(string.Format(format, args)) { S360Logging.S360Log.Instance.Error(format, args); }

        public S360Exception(string message, Exception innerException)
            : base(message, innerException) { S360Logging.S360Log.Instance.Error(innerException, message); }

        public S360Exception(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { S360Logging.S360Log.Instance.Error(innerException, innerException.Message, args); }

        protected S360Exception(SerializationInfo info, StreamingContext context)
            : base(info, context) { S360Logging.S360Log.Instance.Error(info.ToString(), context); }

        //////////// Sample For Throwing Excetions /////////
        ////throw new S360Exception()
        ////throw new S360Exception(message)
        ////throw new S360Exception("Exception with parameter value '{0}'", param)
        ////throw new S360Exception(message, innerException)
        ////throw new S360Exception("Exception with parameter value '{0}'", innerException, param)
    }
}
