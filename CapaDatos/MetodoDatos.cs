using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos{
    internal class MetodoDatos{
        //Método que nos regresa una tabla de información realizada con una consulta
        //sp hace referencia a procedimiento almacenado 
        public static DataSet ExecuteDataSet(String sp, params object[] parametros) { 
            DataSet ds = new DataSet();
            //Obetner la cadena de conexión
            string cadenaConexión = Configuracion.cadenaConeccion;

            //Crear la cadena de conexión
            SqlConnection conn = new SqlConnection(cadenaConexión);

            //Manejo de errores
            try{
                //Verificar la conexión no esté abierta
                if (conn.State == ConnectionState.Open){
                    conn.Close();
                }
                else{
                    //Crear el sql command
                    SqlCommand cmd = new SqlCommand(sp, conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = sp;

                    //Se valida que los parámetros estén completos
                    if (parametros != null && parametros.Length%2 !=0){
                        throw new ApplicationException("Los parámetros deben venir en pares");
                    }
                    else{
                        //Asignar los parámetros al command
                        for (int i = 0; i< parametros.Length; i = i + 2 ){
                            cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i+1]);
                        }

                        //Se abre la conexión
                        conn.Open();
                        //Se ejecuta el comando
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        //Se llena el dataSet
                        adapter.Fill(ds);

                        //Se cierra la conexión
                        conn.Close();
                    }
                }

                return ds;

            }
            catch (Exception ex) {
                return null;
            }
            finally{
                if(conn.State == ConnectionState.Open) conn.Close();
            }
            
        }

        //Método que sirve para ejecutar consultas que regresan un valor, por ejemplo el insert
        public static int ExecuteNonQuery(String sp, params object[] parametros){
            int exitoso = 0;

            //Obtener la cadena de conexión
            string cadenaConexion = Configuracion.cadenaConeccion;

            //Crean cadena de conexión:
            SqlConnection conn = new SqlConnection(cadenaConexion);

            //Manejo de errores
            try
            {
                //Verificar la conexión no esté abierta
                if (conn.State == ConnectionState.Open){
                    conn.Close();
                }

                //Crear el sql command
                SqlCommand cmd = new SqlCommand(sp, conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sp;

                //Se valida que los parámetros estén completos
                if (parametros != null && parametros.Length % 2 != 0)
                {
                    throw new ApplicationException("Los parámetros deben venir en pares");
                }
                else
                {
                    //Asignar los parámetros al command
                    for (int i = 0; i < parametros.Length; i = i + 2)
                    {
                        cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1]);
                    }

                    //Se abre la conexión
                    conn.Open();
                    //Se ejecuta el comando
                    cmd.ExecuteNonQuery();
                    exitoso = 1;


                    //Se cierra la conexión
                    conn.Close();
                }
                return exitoso;

            }
            catch (Exception ex)
            {
                Console.WriteLine(exitoso.ToString());
                return exitoso;
            }
            finally {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
                           
        }

    }
}
