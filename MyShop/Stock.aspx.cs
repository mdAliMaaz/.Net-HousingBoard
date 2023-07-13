using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyShop
{
    public partial class Stock : System.Web.UI.Page
    {
        string CS = ConfigurationManager.ConnectionStrings["myString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              GetData();
            }
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
         
            using(SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    string Name = Convert.ToString(nameTb.Text);
                    int Quantity = Convert.ToInt32(QuantityTb.Text);
                    decimal RatePerItem = Convert.ToDecimal(RateTb.Text);

                    if (nameTb.Text!=null && QuantityTb.Text!=null && RateTb.Text!= null)
                    {
                        SqlCommand cmd = new SqlCommand("spCreateStock", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Name", Name);
                        cmd.Parameters.AddWithValue("@Quantity", Quantity);
                        cmd.Parameters.AddWithValue("@RatePerItem", RatePerItem);
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            GetData();
                            clear();
                            msg.Visible = true;
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data Inserted Successfully')", true);
                          
                        }
                        else
                        {
                            msg.Text = "Invalid Data!";
                        }
                    }
                 
                }
                catch (Exception)
                {
                    msg.Visible = true;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid Data!')", true);
                }
              
            }
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void GetData()
        {
            using(SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spGetStockData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    DataSet ds = new DataSet();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(ds);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                catch(Exception ex) {
                    Response.Write(ex);

                 }
            }
        }

        private void clear()
        {
            msg.Visible =false;
            nameTb.Text = "";
            QuantityTb.Text = "";
            RateTb.Text = "";
        }
    }
}