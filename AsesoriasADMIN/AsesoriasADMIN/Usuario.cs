using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsesoriasADMIN
{
    class Usuario
    {
    private int claveU;
    private String contra, tel, correo, nombre;
    private Int16 idCali;

    public Usuario(int claveU, string contra, string tel, string correo, string nombre)
    {
      this.claveU = claveU;
      this.contra = contra;
      this.tel = tel;
      this.correo = correo;
      this.nombre = nombre;
    }

    public Usuario(int claveU)
    {
      this.claveU = claveU;
    }

    public Usuario()
    {
    }

    public static List<Usuario> busca(String nombre)
    {
      Usuario u;
      List<Usuario> resp = new List<Usuario>();
      SqlConnection con = Conexion.conectarAsesorias();
      SqlCommand cmd;
      SqlDataReader drd;
      String query = String.Format("select * from usuario where nombre like '%{0}%'", nombre);
      cmd = new SqlCommand(query, con);
      drd = cmd.ExecuteReader();
      while (drd.Read())
      {
        u = new Usuario();
        u.claveU = drd.GetInt32(0);
        u.tel = drd.GetString(1);
        u.correo = drd.GetString(2);
        u.nombre = drd.GetString(3);
        u.contra = drd.GetString(4);
        try
        {
          u.idCali = drd.GetInt16(5);
        }catch(Exception e)
        {
          u.idCali = 0;
        }
        resp.Add(u);
      }
      con.Close();
      drd.Close();
      return resp;
      
    }

    public static int baja(Usuario u)
    {
      return 0;
    }

    public static String alta(Usuario u)
    {
      return "aqui deberia dar de alta";
    }


  }
}
