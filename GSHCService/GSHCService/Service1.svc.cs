using GSHCService.Codificacion;
using GSHCService.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GSHCService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        GSHCTec ser = new GSHCTec();
        Generador gen = new Generador();
        public string CambiarPin(string email, string pass)
        {
            try
            {
                if (email.Equals(null) && pass.Equals(null))
                {
                    return "Correo o contraseña Incorrecta";
                }
                else
                {
                    var acces = ser.Acceso.Where(a => a.strEmail == email && a.strPassword == pass).FirstOrDefault();
                    acces.strPin = gen.Generar(acces.Usuario.strNombre, acces.Usuario.strnApellidoPaterno, acces.Usuario.strnApellidoMaterno, acces.Usuario.strnTelefono);
                    ser.Entry(acces).State = EntityState.Modified;
                    ser.SaveChanges();
                    gen.SendEmail(acces.strPin, acces.strEmail);
                    return "Se realizÓ el cambio de PIN";
                }
            }
            catch (Exception _e)
            {
                return _e.Message;
            }
        }

        public string CrearCuenta(string Nombre, string apaterno, string amaterno, string telefono, string email, string pass)
        {
            if (Nombre.Equals(null)&& apaterno.Equals(null)&& amaterno.Equals(null) && telefono.Equals(null) && pass.Equals(null))
            {
                return "Tienen que tener datos los campos";
            }
            else
            {
                try
                {
                    Usuario us = new Usuario { strNombre = Nombre, strnApellidoPaterno = apaterno, strnApellidoMaterno = amaterno, strnTelefono = telefono };
                    ser.Usuario.Add(us);
                    ser.SaveChanges();
                    Acceso ac = new Acceso { UsuarioId = us.Id, strEmail = email, strPassword = pass, strPin = gen.Generar(Nombre, apaterno, amaterno, telefono) };
                    ser.Acceso.Add(ac);
                    ser.SaveChanges();
                    gen.SendEmail(ac.strPin, ac.strEmail);
                    return "Se registro el Usuario";
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
        }

        public UsuriosGSH GetUsuriosGSH(string email, string pass, string pin)
        {
            if (email.Equals(null) && pass.Equals(null))
            {
                return new UsuriosGSH { Error="Datos vacios"};
            }
            else
            {
                UsuriosGSH us = new UsuriosGSH();
                try
                {
                    var acce = ser.Acceso.Where(a => a.strEmail == email && a.strPassword == pass).FirstOrDefault();
                    us.Nombre = acce.Usuario.strNombre;
                    us.ApePaterno = acce.Usuario.strnApellidoPaterno;
                    us.ApeMaterno = acce.Usuario.strnApellidoMaterno;
                    us.Email = acce.strEmail;
                    us.password = acce.strPassword;
                    us.Telefono = acce.Usuario.strnTelefono;
                    return us;
                }
                catch (Exception e)
                {
                    us.Error = e.Message;
                    return us;
                }
                
                
            }
        }

        public mensaje Validacion(string email, string pass, string pin)
        {
            mensaje ms = new mensaje();
            if (email.Equals(null) && pass.Equals(null) && pin.Equals(null))
            {
                ms.Acceso = false;
                return ms;
            }
            else
            {
                try
                {
                    var ac = ser.Acceso.Where(a => a.strEmail == email && a.strPassword == pass && a.strPin == pin).FirstOrDefault();
                    if (ac.Equals(null))
                    {
                        ms.Acceso = false;
                        return ms;
                    }
                    else
                    {
                        ms.Acceso = true;
                        return ms;
                    }
                }
                catch (Exception e)
                {
                    ms.Acceso = false;
                    ms.Error = e.Message;
                    return ms;
                }
            }
        }
    }
}
