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
        private string _matricula;
        private string _tipoCamion;
        private int _modelo;
        private string _marca;
        private int _capacidad;
        private double _kilometraje;
        private bool _disponibilidad;
        private string _urlFoto;

        public int Id
        {
            get => _id; set => _id = value;
        }
        public string Matricula
        {
            get => _matricula; set => _matricula = value;
        }
        public string TipoCamion
        {
            get => _tipoCamion; set => _tipoCamion = value;
        }
        public int Modelo
        {
            get => _modelo; set => _modelo = value;
        }
        public string Marca
        {
            get => _marca; set => _marca = value;
        }
        public int Capacidad
        {
            get => _capacidad; set => _capacidad = value;
        }
        public double Kilometraje
        {
            get => _kilometraje; set => _kilometraje = value;
        }
        public bool Disponibilidad
        {
            get => _disponibilidad; set => _disponibilidad = value;
        }
        public string UrlFoto
        {
            get => _urlFoto; set => _urlFoto = value;
        }

        public CamionesVo()
        {
            _id = 0;
            _matricula = "";
            _tipoCamion = "";
            _modelo = 0;
            _marca = "";
            _capacidad = 0;
            _kilometraje = 0;
            _disponibilidad = false;
            _urlFoto = "";

        }

        public CamionesVo(DataRow registro)
        {
            _id = int.Parse(registro["id"].ToString());
            _matricula = registro["Matricula"].ToString();
            _tipoCamion = registro["TipoCamion"].ToString();
            _modelo = int.Parse(registro["Modelo"].ToString());
            _marca = registro["Marca"].ToString();
            _capacidad = int.Parse(registro["Capacidad"].ToString());
            _kilometraje = double.Parse(registro["Kilometraje"].ToString());
            _disponibilidad = bool.Parse(registro["Disponibilidad"].ToString());
            _urlFoto = registro["UrlFoto"].ToString();
        }

    }
}
