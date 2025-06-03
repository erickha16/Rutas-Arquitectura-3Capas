using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace CapaNegocio
{
    public class BllCamiones
    {
        public static string InsCamion(string Matricula, string TipoCamion, int Modelo, string Marca, int Capacidad, double Kilometraje, string URLFoto)
        {
            // No se puede repetir la matricula
            try
            {
                List<CamionesVo> LstCamiones = DalCamiones.GetLstCamiones(null);

                bool Existe = false;

                foreach (CamionesVo item in LstCamiones.Take(1))
                {
                    if (item.Matricula == Matricula)
                    {
                        Existe = true;
                    }
                }

                if (Existe)
                {
                    return "La matrícula del camión ya fue utilizada con anterioridad";
                }
                else
                {
                    DalCamiones.InsCamion(Matricula, TipoCamion, Modelo, Marca, Capacidad, Kilometraje, URLFoto);
                    return "Camión agregado";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        } // del INSERT

        public static string UpdCamion(int IdCamion, string Matricula, string TipoCamion, int? Modelo, string Marca, int Capacidad, double Kilometraje, bool Disponibilidad, string UrlFoto)
        {
            try
            {
                List<CamionesVo> LstCamiones = DalCamiones.GetLstCamiones(null);
                bool Existe = false;

                foreach (CamionesVo item in LstCamiones)
                {
                    if ((item.Id != IdCamion) && (item.Matricula == Matricula))
                    {
                        Existe = true;
                    }
                }

                if (Existe)
                {
                    return "La matrícula del camión ya fue utilizada con anterioridad";
                }
                else
                {
                    DalCamiones.UpdCamion(IdCamion, Matricula, TipoCamion, Modelo, Marca, Capacidad, Kilometraje, Disponibilidad, UrlFoto);
                    return "Camión actualizado correctamente";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }  // Del Update

        public static string DelCamion(int IdCamion)
        {
            // Borrar solo si el camion esta disponible
            try
            {
                CamionesVo CamionVO = DalCamiones.GetCamionById(IdCamion);

                if (CamionVO.Disponibilidad)
                {
                    DalCamiones.DelCamion(IdCamion);
                    return "Camión eliminado";
                }
                else
                {
                    return "El camión se encuentra en una ruta o no está disponible";
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        } // del DELETE

        public static CamionesVo GetCamionById(int IdCamion)
        {
            try
            {
                return DalCamiones.GetCamionById(IdCamion);
            }
            catch (Exception)
            {
                return new CamionesVo();
            }
        } // del GetCamionById

        public static List<CamionesVo> GetLstCamiones(bool? Disponibilidad)
        {
            List<CamionesVo> LstCamiones = new List<CamionesVo>();
            try
            {
                System.Diagnostics.Debug.WriteLine("voy a llamar a DALCamiones.GetLstCamiones");
                return DalCamiones.GetLstCamiones(Disponibilidad);
            }
            catch (Exception)
            {
                return LstCamiones;
            }
        }

    }
}
