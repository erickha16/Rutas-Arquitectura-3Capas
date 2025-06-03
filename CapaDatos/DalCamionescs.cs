using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace CapaDatos
{
    public class DalCamiones
    {
        public static List<CamionesVo> GetLstCamiones(bool? Disponibilidad)
        {
            string Query = "Camiones_Listar";

            DataSet dsCamiones = new DataSet();

            try
            {
                if (Disponibilidad == null)
                {
                    //Obtenemos todos los Choferes de la BD
                    dsCamiones = MetodoDatos.ExecuteDataSet(Query);
                }
                else
                {
                    //Obtenemos los choferes según paramDisponibilidad
                    dsCamiones = MetodoDatos.
                        ExecuteDataSet(Query, "@Disponibilidad", Disponibilidad);
                }
                if (dsCamiones.Tables[0].Rows.Count > 0)
                {
                    List<CamionesVo> LstCamiones = new List<CamionesVo>();

                    foreach (DataRow dr in dsCamiones.Tables[0].Rows)
                    {
                        LstCamiones.Add(new CamionesVo(dr));
                    }
                    return LstCamiones;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        } // del GetLstCamiones
        public static void InsCamion(string Matricula, string TipoCamion, int Modelo, string Marca, int Capacidad, double Kilometraje, string UrlFoto)
        {

            try
            {

                int intResult;

                intResult = MetodoDatos.ExecuteNonQuery("Camiones_Insertar", "@Matricula", Matricula, "@TipoCamion", TipoCamion, "@Modelo", Modelo, "@Marca", Marca, "@Capacidad", Capacidad, "@Kilometraje", Kilometraje, "@UrlFoto", UrlFoto);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
        }// del Insert

        public static void UpdCamion(int IdCamion, string Matricula, string TipoCamion,
             int? Modelo, string Marca, int? Capacidad, double? Kilometraje, bool? Disponibilidad, string UrlFoto)
        {
            try
            {

                int intResult;

                intResult = MetodoDatos.ExecuteNonQuery("Camiones_Actualizar", "@Id", IdCamion, "@Matricula", Matricula, "@TipoCamion", TipoCamion, "@Modelo", Modelo, "@Marca", Marca, "@Capacidad", Capacidad, "@Kilometraje", Kilometraje, "@Disponibilidad", Disponibilidad, "@UrlFoto", UrlFoto);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
        }// del Update

        public static void DelCamion(int IdCamion)
        {
            try
            {

                MetodoDatos.ExecuteNonQuery("Camiones_Eliminar", "@id", IdCamion);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }// del DelCamion

        public static CamionesVo GetCamionById(int IdCamion)
        {
            try
            {
                DataSet dsCamion = MetodoDatos.ExecuteDataSet("Camiones_GetByID", "@id", IdCamion);
                if (dsCamion.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = dsCamion.Tables[0].Rows[0];
                    CamionesVo Camion = new CamionesVo(dr);
                    return Camion;
                }
                else
                {
                    CamionesVo Camion = new CamionesVo();
                    return Camion;
                }
            }
            catch (Exception)
            {
                throw;
            }
        } //

    }
}
