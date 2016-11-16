using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace PRODUCTS_MANAGEMENT.DAL
{
    class DataAccessLayer
    {
        SqlConnection sqlconnection;
        //thie constructor initialize the connection object
        public DataAccessLayer()
        {
            sqlconnection = new SqlConnection (@"Server=.\SQLEXPRESS01; Database=PRODUCT_DB; Integrated security=true");

        }
      // method to open the connection 
      public void Open()
        {
            if (sqlconnection.State != ConnectionState.Open)
            {
                sqlconnection.Open();
            }
        }    
        //method to close to connection 
        
        public void Close()
        {
            if(sqlconnection.State == ConnectionState.Open)
            {
                sqlconnection.Close();

            }
                    }  
        //method to read data from database
        public DataTable SelectData(string stored_procedure, SqlParameter[] param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_procedure;
            sqlcmd.Connection = sqlconnection;
            if (param !=null)
            {
                for(int i=0;  i < param.Length; i++)
                {
                    sqlcmd.Parameters.Add(param[i]);

                }
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        //method to insert update and delete data from database
        public void ExecuteCommand(string stored_procedure, SqlParameter[] param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_procedure;
            sqlcmd.Connection = sqlconnection;

            if (param != null)
            {
                sqlcmd.Parameters.AddRange(param);

            }
            sqlcmd.ExecuteNonQuery();
        }
    }
}
