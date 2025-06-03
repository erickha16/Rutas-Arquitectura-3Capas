using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class CamionesVo
    {
        private int _id;
        private String _Matricula;
        private String _TipoCamion;
        private int _Modelo;
        private String _Marca;
        private int _Capacidad;
        private double _Kilometraje;
        private bool _Disponibilidad;
        private String _UrlFoto;

        public int Id
        {
            get => _id; set => _id = value;
        }
        public string Matricula
        {
            get => _Matricula; set => _Matricula = value;
        }
        public string TipoCamion
        {
            get => _TipoCamion; set => _TipoCamion = value;
        }
        public int Modelo
        {
            get => _Modelo; set => _Modelo = value;
        }
        public string Marca
        {
            get => _Marca; set => _Marca = value;
        }
        public int Capacidad
        {
            get => _Capacidad; set => _Capacidad = value;
        }
        public double Kilometraje
        {
            get => _Kilometraje; set => _Kilometraje = value;
        }
        public bool Disponibilidad
        {
            get => _Disponibilidad; set => _Disponibilidad = value;
        }
        public string UrlFoto
        {
            get => _UrlFoto; set => _UrlFoto = value;
        }

        public CamionesVo()
        {
            _id = 0;
            _Matricula = "";
            _TipoCamion = "";
            _Modelo = 0;
            _Marca = "";
            _Capacidad = 0;
            _Kilometraje = 0;
            _Disponibilidad = false;
            _UrlFoto = "";

        }

        public CamionesVo(DataRow registro)
        {
            _id = int.Parse(registro["id"].ToString());
            _Matricula = registro["Matricula"].ToString();
            _TipoCamion = registro["TipoCamion"].ToString();
            _Modelo = int.Parse(registro["Modelo"].ToString());
            _Marca = registro["Marca"].ToString();
            _Capacidad = int.Parse(registro["Capacidad"].ToString());
            _Kilometraje = double.Parse(registro["Kilometraje"].ToString());
            _Disponibilidad = bool.Parse(registro["Disponibilidad"].ToString());
            _UrlFoto = registro["UrlFoto"].ToString();
        }

    }
}
