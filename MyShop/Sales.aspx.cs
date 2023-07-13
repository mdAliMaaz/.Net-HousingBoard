using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyShop
{
    public partial class Sales : System.Web.UI.Page
    {
        string CS = ConfigurationManager.ConnectionStrings["myString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            dateTb.Text = DateTime.Now.ToString();
            if (!IsPostBack)
            {
                GetItem();
                GetSales();
                clear();
                itemDdl.SelectedIndex = 0;
            saveBtn.Visible = false;
            }
        }
       
        protected void saveBtn_Click(object sender, EventArgs e)
        {
            CheckValidation();
            try
            { 
                DateTime date = Convert.ToDateTime(dateTb.Text);
                int id = Convert.ToInt32(itemDdl.SelectedValue);
                int Qty = Convert.ToInt32(PqtyTb.Text);
                decimal Total = Convert.ToDecimal(TotalTb.Text);

                if (date != null && id >0 && Qty>0 && Total >0)
                {
                    using (SqlConnection con = new SqlConnection(CS)){
                        SqlCommand cmd = new SqlCommand("insert into Sales_tbl values(@TRN_Date,@Id,@P_Qty,@Total_Amount)",con);
                        cmd.Parameters.AddWithValue("@TRN_Date", date);
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@P_Qty", Qty);
                        cmd.Parameters.AddWithValue("@Total_Amount", Total);
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        if(i > 0)
                        {
                            itemDdl.SelectedIndex = 0;
                            GetSales();
                            clear();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data Inserted Successfully')", true);
                            UpdateStock(Qty, id);
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid data')", true);
                        }

                    }
                }
            }
            catch(Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid data')", true);
            }
        }
      
        protected void CkeckId_Click(object sender, EventArgs e)
        {
            CheckValidation();
        }

        protected void clearBtn_Click(object sender, EventArgs e)
        {
            clear();
        }
        protected void itemDdl_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckValidation();  
        }

        private void GetSales()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("spGetSalesData", con);
                    cmd.CommandType=CommandType.StoredProcedure;
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }

        private void GetItem()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("select Name,Id from  Stock_tbl", con);
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    itemDdl.DataSource = ds;
                    itemDdl.DataTextField = "Name";
                    itemDdl.DataValueField = "Id";
                    itemDdl.DataBind();
                    itemDdl.Items.Insert(0, "--Select Item--");

                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }

        }

        private void clear()
        {
            PqtyTb.Text = "";
            TotalTb.Text = "";
            RateLb.Text = "0.0";
            QtyAvlLb.Text = "0.00";
            TotalTb.Text = "0";
            itemDdl.SelectedIndex = 0;
            saveBtn.Visible = false;
            msg.Text = "";
        }

        private void CheckValidation()
        {
            try
            {
                if (itemDdl.SelectedIndex > 0)
                {
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        SqlCommand cmd = new SqlCommand("Select Quantity, RatePerItem from Stock_tbl Where Id = @id", con);
                        cmd.Parameters.AddWithValue("@id", itemDdl.SelectedValue);
                        con.Open();
                        SqlDataReader reader;
                        reader = cmd.ExecuteReader(); 

                        if (reader.Read())
                        {
                            RateLb.Text = reader["RatePerItem"].ToString();

                            if (Convert.ToInt32(reader["Quantity"]) == 0)
                            {
                                QtyAvlLb.Text = "--Out Of Stock--";
                            }
                            else
                            {
                            QtyAvlLb.Text = reader["Quantity"].ToString();
                            }


                            int avlQty = Convert.ToInt32(reader["Quantity"]);
                            int qty = Convert.ToInt32(PqtyTb.Text);
                            int r = Convert.ToInt32(reader["RatePerItem"]);

                            if (qty <= avlQty)
                            {
                                int result = qty * r;
                                TotalTb.Text = result.ToString();
                                saveBtn.Visible = true;
                                msg.Text = null;
                            }
                            else if(avlQty == 0)
                            {
                                TotalTb.Text = "---";
                            }
                            else
                            {
                                saveBtn.Visible = false;
                                TotalTb.Text = "Quantity must be less that or equal to" + " " + avlQty;
                            }

                        }
                      
                    }
                }
              
            }
            catch (System.FormatException )
            {
                return;
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('hello')", true);
            }
        }

        private void UpdateStock(int p_Qty,int id)
        {
            try
            {
                using(SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateStock", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Quantity",p_Qty);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                Response.Write(ex.ToString());  
            }
        }
    }
}