using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrainingSheet.Core.Error
{
    public class MessageError
    {
        public MessageError(string errorCode, string message)
        {
            ErrorCode = errorCode;
            Message = message;
        }

        public string ErrorCode { get; set; }
        public string Message { get; set; }
    }

}
