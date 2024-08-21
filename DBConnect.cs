using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom5QLHocVienTTTH
{
    class DBConnect
    {
        public static string chuoiketnoi = @"Data Source=MINHQUOC\SA;Initial Catalog=QLHVTTTH;User Id=sa;Password=290703";

        public SqlConnection conn = new SqlConnection();

        public DBConnect()
        {
            conn = new SqlConnection(chuoiketnoi);
        }

        public void Open()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public void Close()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        public int getNonQuery(string sqlquery)
        {
            Open();
            SqlCommand cmd = new SqlCommand(sqlquery, conn);

            int kq = cmd.ExecuteNonQuery();
            Close();
            return kq;
        }

        public DataTable getDataTable (string sqlquery)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sqlquery, conn);

            da.Fill(ds);

            return ds.Tables[0];
        }
        public int getScalar (string sqlquery)
        {
            Open();
            SqlCommand cmd = new SqlCommand(sqlquery, conn);

            int kq = (int) cmd.ExecuteScalar();
            Close();
            return kq;
        }
        public void OpenConnection()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }
        public SqlConnection Connection
        {
            get { return conn; }
        }


        //public DataSet getDataSet(string sqlquery)
        //{
        //    DataSet ds = new DataSet();
        //    SqlDataAdapter da = new SqlDataAdapter(sqlquery, con);

        //    da.Fill(ds);
        //    return ds;
        //}


        internal DataTable ExecuteNonQuery(string query, SqlParameter sqlParameter)
        {
            throw new NotImplementedException();
        }
        public DataTable ExecuteQueryWithParameters(string query, params SqlParameter[] parameters)
        {
            DataTable dataTable = new DataTable();

            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddRange(parameters);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    dataTable.Load(reader);
                }
            }

            return dataTable;
        }

    }
}
