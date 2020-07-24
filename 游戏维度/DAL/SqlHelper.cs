using System.Data;
using System.Data.SqlClient;
using System.Web;
using Model;
using System;
using System.Configuration;

namespace DAL
{
    public class SqlHelper
    {
        /*public Sql()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }*/

        private static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
        //public static SqlConnection con = new SqlConnection("Data Source =.; Initial Catalog = QYDB; User Id = sa; Password = 123123");
        //public static DataTable Select(string column, string table, string where = "1=1", string bystr = "Inum", string DESC = "DESC")

        public static DataTable Select(string column, string table, string where = "1=1", string bystr = "Inum", string DESC = "DESC")
        {
          
            con.Open();  
            if (con.State != ConnectionState.Open)
                HttpContext.Current.Response.Write("<script type='text/javascript'>alert('对不起，无法连接！')</script>");
            try
            {
                SqlDataAdapter myda = new SqlDataAdapter("SELECT " + column + " FROM " + table + " where " + where + " ORDER BY " + bystr + " " + DESC, con);
                DataTable d = new DataTable();
                myda.Fill(d);
                return d;
            }
            finally
            {
                con.Close();
            }

        }
        public static void Update(string table, string column, string newstr, string where)
        {
            if (con.State == ConnectionState.Open)
            { con.Close(); }
            try
            {
                con.Open();
                if (con.State != ConnectionState.Open)
                    HttpContext.Current.Response.Write("<script type='text/javascript'>alert('对不起，暂时无法连接！')</script>");
                SqlDataAdapter myda = new SqlDataAdapter("UPDATE " + table + " SET " + column + "=" + newstr + " where " + where, con);
                DataTable d = new DataTable();
                myda.Fill(d);

            }
            finally { con.Close(); }
        }
        public static void Delete(string table, string column, string where)
        {
            try
            {
                con.Open();
                if (con.State != ConnectionState.Open)
                    HttpContext.Current.Response.Write("<script type='text/javascript'>alert('对不起，暂时无法连接！')</script>");
                SqlDataAdapter myda = new SqlDataAdapter("DELETE FROM" + table + " where " + where, con);
                DataTable d = new DataTable();
                myda.Fill(d);
            }
            finally { con.Close(); }
        }
        public static void Insert(string table, string column, string values)
        {
            try
            {
                con.Open();
                if (con.State != ConnectionState.Open)
                    HttpContext.Current.Response.Write("<script type='text/javascript'>alert('对不起，无法连接！')</script>");
                SqlDataAdapter myda = new SqlDataAdapter("INSERT INTO" + table + column + values, con);
                DataTable d = new DataTable();
                myda.Fill(d);
            }
            finally { con.Close(); }
        }
    }
}
