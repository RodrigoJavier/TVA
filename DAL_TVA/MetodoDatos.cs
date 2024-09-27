using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_TVA
{
    internal class MetodoDatos
    {
        public static DataSet ExecuteDataSet(string sp, params object[] parametros)
        {
            DataSet ds = new DataSet();

            string cadenaConexion = Configuracion.cadena_con_;

            SqlConnection con = new SqlConnection(cadenaConexion);

            try
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
                else
                {
                    SqlCommand cmd = new SqlCommand(sp, con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = sp;

                    if (parametros != null && parametros.Length % 2 != 0)
                    {
                        throw new Exception("Los Parametros deden estar pares (Clave:Valor)");
                    }
                    else
                    {
                        for (int i = 0; i < parametros.Length; i = i + 2)
                        {
                            cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1]);
                            //Clave, valor,Clave, valor, Clave, valor]
                            //Matricula, 'abcd', 'Nombre', 'Joaquie', 'apellido', 'Marquez']
                            //[0,1,2,3,4,5]
                            //Exec sp_x @varl = 'valor'
                        }
                        //Abrir conexion a la base da datos
                        con.Open();
                        //Ejecutamos nuestro comando
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        //llenamos nuestro data set
                        adapter.Fill(ds);
                        //cerramos nuestra conexion
                        con.Close();
                    }
                }
                return ds;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        public static int ExecuteScalar(string sp, params object[] parametros)
        {
            int id = 0;

            string cadenaConexion = Configuracion.cadena_con_;

            SqlConnection con = new SqlConnection(cadenaConexion);

            try
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
                else
                {
                    SqlCommand cmd = new SqlCommand(sp, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = sp;

                    for (int i = 0; i < parametros.Length; i = 1 + 2)
                    {
                        cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1]);
                    }
                    con.Open();
                    id = int.Parse(cmd.ExecuteScalar().ToString());
                    con.Close();
                }
                return id;
            }
            catch
            {
                return id;
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        public static int ExecuteNonQuery(string sp, params object[] parametros)
        {
            int IdOrigenDestino = 0;
            string cadenaConexion = Configuracion.cadena_con_;
            SqlConnection con = new SqlConnection(cadenaConexion);

            try
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
                else
                {
                    SqlCommand cmd = new SqlCommand(sp, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = sp;

                    for (int i = 0; i < parametros.Length; i = i + 2)
                    {
                        cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1]);
                    }
                    con.Open();
                    cmd.ExecuteNonQuery();
                    IdOrigenDestino = 1;
                    con.Close();
                }
                return IdOrigenDestino;
            }
            catch
            {
                return IdOrigenDestino;
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }

        }


    }
}
