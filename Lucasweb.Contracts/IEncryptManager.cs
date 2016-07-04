using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucasweb.Contracts
{
    public interface IEncryptManager
    {
        string GenericEncrypt(string Message);

        string GenericDecrypt(string Message);

        string PinEncrypt(string Message, int Pin);

        string PinDecrypt(string EncryptedMessage, int Pin);
        string PasswordEncrypt(string message, string password);
        string PasswordDecrypt( string message, string password);
    }
}
