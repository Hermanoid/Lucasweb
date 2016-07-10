using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucasweb.Contracts
{
    public interface IEncryptEngine
    {
        string GenericEncrypt(string Message);

        string GenericDecrypt(string EncryptedMessage);

        string PinEncrypt(string Message, int Pin);

        string PinDecrypt(string Message, int Pin);

        string CreatePassword();
    }
}
