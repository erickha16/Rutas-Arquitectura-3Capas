using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace CapaNegocio
{
    public class BllChoferes
    {
        //Listar Choferes
        public static List<ChoferesVo> GetListChoferes(bool? paramDisponibilidad)//bool? paramDisponibilidad Indica que puede o no llegarun valor (puede ser nulo)
        {
            try
            {
                //Declaramos la lista a retornar
                List<ChoferesVo> ListaChoferes = new List<ChoferesVo>();

                //Verificamos la dsponibilidad
                if (paramDisponibilidad == null)
                {
                    //Obtenemos los choferes de la bd
                   ListaChoferes = DalChoferes.GetListChoferes(null);
                }
                else
                {
                    //Obtenemos los choferes según el paramDisponibilidad
                    ListaChoferes = DalChoferes.GetListChoferes(paramDisponibilidad);
                }

                return ListaChoferes;

            }
            catch { throw; }

        }


        //Insertar Chofer
        public static void InsChofer(string paramLicencia, string paramTelefono, DateTime paramFechaNacimiento, string paramNombre, string paramApPaterno,
            string paramApMaterno, string paramUrlFoto)
        {
            try
            {
                DalChoferes.InsChofer(paramLicencia, paramTelefono, paramFechaNacimiento, paramNombre, paramApPaterno, paramApMaterno, paramUrlFoto);

            }
            catch { throw; }

        }
        //Actualizar Chofer
        public static string UpdChofer(int paramIdChofer, string paramLicencia, string paramTelefono, DateTime? paramFechaNacimiento, string paramNombre, string paramApPaterno,
            string paramApMaterno, string paramUrlFoto, bool? paramDisponibilidad)
        {
            try
            {
                //Verificar disponibilidad del chofer
                ChoferesVo Chofer = DalChoferes.GetChoferById(paramIdChofer);

                if (Chofer.Disponibilidad)
                {
                    DalChoferes.UpdChofer(paramIdChofer, paramLicencia, paramTelefono, paramFechaNacimiento, paramNombre, paramApPaterno, paramApMaterno, paramUrlFoto, paramDisponibilidad);
                    return "1";
                }
                else
                {
                    return "0";
                }
            }
            catch { throw; }
        }

        //Eliminar Chofer
        public static string DelChofer(int paramIdChofer)
        {
            try
            {
                //Verificar disponibilidad del chofer
                ChoferesVo Chofer = DalChoferes.GetChoferById(paramIdChofer);

                if (Chofer.Disponibilidad)
                {
                    DalChoferes.DelChofer(paramIdChofer);
                    return "1";
                }
                else
                {
                    return "0";
                }
            }
            catch { throw; }
        }


        //Obtener Chofer por ID

        public static ChoferesVo GetChoferById(int paramIdChofer)
        {
            return DalChoferes.GetChoferById(paramIdChofer); 
            
        }
    }
}
