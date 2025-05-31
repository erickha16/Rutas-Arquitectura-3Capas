using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class ChoferesVo
    {
        //---------- Atributos --------------------------
        //Convenvión de atributos _minusculas
        private int _id;
        private string _nombre;
        private string _apPaterno;
        private string _apMaterno;
        private string _telefono;
        private DateTime _fechaNacimiento;
        private string _licencia;
        private string _urlFoto;
        private bool _disponibilidad;


        //------------------------------------------Propiedades ------------------------------------------
        //------------------------------------- Setters y Getters () ------------------------------------------
        //Id
        public int Id { get => _id; set => _id = value; }

        //Nombre
        public string Nombre { get => _nombre; set => _nombre = value; }

        //Apellido Paterno
        public string ApPaterno { get => _apPaterno; set => _apPaterno = value; }
        //Apellido Materno
        public string ApMaterno { get => _apMaterno; set => _apMaterno = value; }
        //Teléfono
        public string Telefono { get => _telefono; set => _telefono = value; }
        //Fecha Nacimiento

        public DateTime FechaNacimiento { get => _fechaNacimiento; set => _fechaNacimiento = value; }
        //Licencia
        public string Licencia { get => _licencia; set => _licencia = value; }
        // Url Foto
        public string UrlFoto { get => _urlFoto; set => _urlFoto = value; }
        //Disponibilidad
        public bool Disponibilidad { get => _disponibilidad; set => _disponibilidad = value; }

        //---------------------------------- Constructor ------------------------------------------------
        public ChoferesVo(DataRow dr){
            Id = int.Parse(dr["id"].ToString());
            //Hacemos referencia a lo setters
            Nombre = dr["Nombre"].ToString();
            ApPaterno = dr["ApPaterno"].ToString();
            ApMaterno = dr["ApMaterno"].ToString();
            Telefono = dr["Telefono"].ToString();
            FechaNacimiento = DateTime.Parse(dr["FechaNacimiento"].ToString());
            Licencia = dr["Licencia"].ToString();
            UrlFoto = dr["UrlFoto"].ToString();
            Disponibilidad = bool.Parse(dr["Disponibilidad"].ToString());
        }

        public ChoferesVo() {
            Id = 0;
            Nombre = String.Empty;
            ApPaterno = String.Empty;
            ApMaterno = String.Empty;
            Telefono = String.Empty;
            FechaNacimiento = DateTime.MinValue;
            Licencia = String.Empty;
            UrlFoto = String.Empty;
            Disponibilidad = false;
        }
    }
}
