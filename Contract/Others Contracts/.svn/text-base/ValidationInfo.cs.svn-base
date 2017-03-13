using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contract
{
    [Serializable ]
    public class ValidationInfo
    {
        private ErrorTypeEnum _idErrorType;
        public ErrorTypeEnum IdErrorType
        {
            get
            {
                return _idErrorType;
            }
            set {
                _idErrorType = value;
            }
        }

        private String _Message
        {
            get {
                if (_Message == null)
                    _Message = String.Empty;
                return _Message;
            }
            set {
                _Message = value; 
            }
        }
        public ValidationInfo(String Message, ErrorTypeEnum IdErrorType)
        {
            _Message = Message;
            _idErrorType = IdErrorType;
        }
    }
    public class ValidationsInfo
    {
        List<ValidationInfo> validations;

        public List<ValidationInfo> Validations
        {
            get
            {
                if (validations == null)
                    validations = new List<ValidationInfo>();
                return validations;
            }
            set { validations = value; }
        }
        public void Validate(bool value, string Message)
        {
            Validate(value, Message, ErrorTypeEnum.User);
        }
        public void Validate(bool value, string message, ErrorTypeEnum exceptionType)
        { 
            if ( !value ) 
                Validations.Add ( new ValidationInfo(message, exceptionType));
        }
        public bool HadError()
        {
            return (Validations.Count > 0);
        }
    }
}
