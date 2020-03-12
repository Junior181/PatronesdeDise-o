using AdapterPattern.Adaptee;
using AdapterPattern.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AdapterPattern.Adapter
{
    public class LogAdapter : HelperLog, IClienteLog
    {

        public string GuardarErrorLog(string error, string codigoError)
        {
            GuardarError(new Exception(error));

            // Se obtiene el mensaje amigable de error basado en su c�digo
            var root = XElement.Load("Mensajes.xml");

            return (from c in root.Elements("Mensaje")
                    where (string)c.Attribute("codigo") == codigoError
                    select c.Value).First();
        }
    }
}