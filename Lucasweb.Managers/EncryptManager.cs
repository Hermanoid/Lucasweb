using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lucasweb.Contracts;
using Lucasweb.Utilities;

namespace Lucasweb.Managers
{
    class EncryptManager : IEncryptManager
    {

        public string GenericEncrypt(string Message)
        {
            return ClassFactory.CreateClass<IEncryptEngine>().GenericEncrypt(Message);
        }

        public string GenericDecrypt(string EncryptedMessage)
        {
            return ClassFactory.CreateClass<IEncryptEngine>().GenericDecrypt(EncryptedMessage);
        }

        public string PinEncrypt(string Message, int Pin)
        {
            return ClassFactory.CreateClass<IEncryptEngine>().PinEncrypt(Message, Pin);
        }

        public string PinDecrypt(string EncryptedMessage, int Pin)
        {
            return ClassFactory.CreateClass<IEncryptEngine>().PinDecrypt(EncryptedMessage, Pin);
        }

        public string PasswordEncrypt(string message, string password)
        {
            return ClassFactory.CreateClass<IEncryptEngine>().PinEncrypt(message, ClassFactory.CreateClass<ICharacterUtils>().addAsciiValsOf(password));
        }

        public string PasswordDecrypt(string message, string password)
        {
            return ClassFactory.CreateClass<IEncryptEngine>().PinDecrypt(message, ClassFactory.CreateClass<ICharacterUtils>().addAsciiValsOf(password));
        }
    }
}