using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace MyShop
{
    public partial class Report : System.Web.UI.Page
    {
        string CS = ConfigurationManager.ConnectionStrings["myString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //data for table
               GetDate();

                //data for Column Chart
               using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spGetChartData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                Series series = Chart1.Series["Series1"];
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    series.Points.AddXY(dr["Item_Name"].ToString(), dr["Available_Quantity"]);
                }
            }

               //data for Pie Chart
               using(SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spGetChartData", con);
                cmd.CommandType= CommandType.StoredProcedure;
                Series series = Chart2.Series["Series1"];
                con.Open() ;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    series.Points.AddXY(dr["Item_Name"].ToString(), dr["Available_Quantity"]);
                }
            }
            }
        }


        private void GetDate()
        {
            using(SqlConnection con = new SqlConnection(CS)) {
                SqlCommand cmd = new SqlCommand("spGetChartData",con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                GridView1.DataSource = dr;
                GridView1.DataBind();
            }
        }
    }
}