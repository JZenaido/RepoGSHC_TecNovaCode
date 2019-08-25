using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GSHCService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        mensaje Validacion(string email, string pass, string pin);

        [OperationContract]
        string CrearCuenta(string Nombre,string apaterno,string amaterno,string telefono, string email,string pass);

        [OperationContract]
        string CambiarPin(string email, string pass);
        [OperationContract]
        UsuriosGSH GetUsuriosGSH(string email, string pass, string pin);

        // TODO: agregue aquí sus operaciones de servicio
    }

    [DataContract]
    public class mensaje
    {
        [DataMember]
        public string Error { get; set; }
        [DataMember]
        public bool Acceso { get; set; }
    }
    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    [DataContract]
    public class UsuriosGSH: mensaje
    {
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string ApePaterno { get; set; }
        [DataMember]
        public string ApeMaterno { get; set; }
        [DataMember]
        public string Telefono { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string password { get; set; }
        [DataMember]
        public string PIN { get; set; }
    }
}
