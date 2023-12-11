using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class WebService : System.Web.Services.WebService {

    public WebService () {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hola a todos";
    }
   /*   [WebMethod]
    public int suma(int a, int b) {
        return a + b;
    }
    * */
  
      [WebMethod]
      public DataSet tbAlumno()
      {
          SqlConnection con = new SqlConnection();
          SqlDataAdapter ada = new SqlDataAdapter();
          DataSet ds = new DataSet();
          con.ConnectionString = @"server=EMERSON\SQLEXPRESS;user=inf324;pwd=123456;database=academico";
          ada.SelectCommand = new SqlCommand();
          ada.SelectCommand.Connection = con;
          ada.SelectCommand.CommandText = "select * from alumno";
          ada.SelectCommand.CommandType = CommandType.Text;
          ada.Fill(ds, "alumno");
          return ds;
      }
      [WebMethod]
          public void ActualizarAlumno(string ci, string nuevoNombre, string nuevoPaterno, string nuevoDepto, int nuevoPromedio)
          {
              using (SqlConnection con = new SqlConnection(@"server=EMERSON\SQLEXPRESS;user=inf324;pwd=123456;database=academico"))
              {
                  con.Open();

                  using (SqlCommand cmd = new SqlCommand()) {
                      cmd.Connection = con;
                      cmd.CommandText = "UPDATE alumno SET nombre = @nuevoNombre, paterno = @nuevoPaterno, depto = @nuevoDepto, promedio = @nuevoPromedio WHERE ci = @ci";
                      cmd.CommandType = CommandType.Text;
                      // Parámetros
                      cmd.Parameters.AddWithValue("@ci", ci);
                      cmd.Parameters.AddWithValue("@nuevoNombre", nuevoNombre);
                      cmd.Parameters.AddWithValue("@nuevoPaterno", nuevoPaterno);
                      cmd.Parameters.AddWithValue("@nuevoDepto", nuevoDepto);
                      cmd.Parameters.AddWithValue("@nuevoPromedio", nuevoPromedio);
                      cmd.ExecuteNonQuery();
                  }
              }
          }
      [WebMethod]
      public void EliminarAlumno(string ci)
      {
          using (SqlConnection con = new SqlConnection(@"server=EMERSON\SQLEXPRESS;user=inf324;pwd=123456;database=academico"))
          {
              con.Open();
              using (SqlCommand cmd = new SqlCommand())
              {
                  cmd.Connection = con;
                  cmd.CommandText = "DELETE FROM alumno WHERE ci = @ci";
                  cmd.CommandType = CommandType.Text;

                  // Parámetros
                  cmd.Parameters.AddWithValue("@ci", ci);

                  cmd.ExecuteNonQuery();
              }
          }
      }
      [WebMethod]
      public void AgregarAlumno(string ci,string nuevoNombre, string nuevoPaterno, string nuevoDepto, int nuevoPromedio)
      {
          using (SqlConnection con = new SqlConnection(@"server=EMERSON\SQLEXPRESS;user=inf324;pwd=123456;database=academico"))
          {
              con.Open();

              using (SqlCommand cmd = new SqlCommand())
              {
                  cmd.Connection = con;
                  cmd.CommandText = "INSERT INTO alumno (ci,nombre, paterno, depto, promedio) VALUES (@nuevoci,@nuevoNombre, @nuevoPaterno, @nuevoDepto, @nuevoPromedio)";
                  cmd.CommandType = CommandType.Text;

                  // Parámetros
                  cmd.Parameters.AddWithValue("@nuevoci", ci);
                  cmd.Parameters.AddWithValue("@nuevoNombre", nuevoNombre);
                  cmd.Parameters.AddWithValue("@nuevoPaterno", nuevoPaterno);
                  cmd.Parameters.AddWithValue("@nuevoDepto", nuevoDepto);
                  cmd.Parameters.AddWithValue("@nuevoPromedio", nuevoPromedio);

                  cmd.ExecuteNonQuery();
              }
          }
      }
}
