using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace CapaDatos
{
    public class DalChoferes {
        //Listar Choferes
        public static List<ChoferesVo> GetListChoferes(bool? paramDisponibilidad)//bool? paramDisponibilidad Indica que puede o no llegarun valor (puede ser nulo)
        {
            try
            {
                //Declaramos un DataSet 
                DataSet dsChoferes;

                //Verificamos la dsponibilidad
                if (paramDisponibilidad == null)
                {
                    //Obtenemos los choferes de la bd
                    dsChoferes = MetodoDatos.ExecuteDataSet("Choferes_Listar");
                }
                else
                {
                    //Obtenemos los choferes según el paramDisponibilidad
                    dsChoferes = MetodoDatos.ExecuteDataSet("Choferes_listar", "@Disponibilidad");
                }

                //Declaramos la lista a retornas
                List<ChoferesVo> ListaChoferes = new List<ChoferesVo>();

                //Recorremos el DataSet(matriz) para llenar la lista:
                foreach(DataRow dr in dsChoferes.Tables[0].Rows)
                {
                    ListaChoferes.Add(new ChoferesVo(dr));
                }

                return ListaChoferes;

            }
            catch (Exception ex) {
                //Re lanza la excepción tal cual la cacha
                throw;
            }
                
        
        }

        //Insertar Chofer
        public static void InsChofer(string paramLicencia, string paramTelefono, string paramNombre, string paramApPaterno, 
            string paramApMaterno, string paramUrlFoto, DateTime paramFechaNacimiento)
        {
            try
            {
                MetodoDatos.ExecuteNonQuery("Choferes_Insertar",
                    "@Nombre", paramNombre,
                    "@ApPaterno", paramApPaterno,
                    "@ApMaterno", paramApMaterno,
                    "@Telefono", paramTelefono,
                    "@FechaNacimiento", paramFechaNacimiento,
                    "@Licencia", paramLicencia,
                    "@UrlFoto", paramUrlFoto);

            }catch {  throw; }

        }
    }
}
