using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Inventory
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

     

   

            SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dell\Desktop\Mall\bin\AttTable.mdf;Integrated Security=True;Connect Timeout=30");
        private void cataddbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (catname.Text == "" || description.Text == "" || ID.Text == "")
                {
                    MessageBox.Show("Can't Add !\t\n Missing Info");
                }
                else
                {
                    Con.Open();
                    String query = "insert into CatTable (CatName, Description,ID) values ('" + catname.Text + "','" + description.Text + "','" + ID.Text+ "')";
                    SqlCommand command = new SqlCommand(query, Con);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Category Added Successfully");
                    Con.Close();
                    ID.Text = "";
                    catname.Text = "";
                    description.Text = "";
                    fetchCat();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Con.Close();
            }
        }
        private void fetchCat()
        {
            Con.Open();
            string query = "select * from CatTable";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var data = new DataSet();
            sda.Fill(data);
            catList.DataSource = data.Tables[0];
            Con.Close();
        }

        private void FetchCat()
        {
            Con.Open();
            String query = "select CatName from CatTable";
            SqlCommand command = new SqlCommand(query, Con);
            SqlDataReader read;
            read = command.ExecuteReader();
            DataTable data = new DataTable();
            data.Columns.Add("CatName", typeof(string));
            data.Load(read);
            category.ValueMember = "catName";
            category.DataSource = data;
            Con.Close();
        }
        private void fetchData1()
        {
            Con.Open();
            string query = "select * from AttTable";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var data = new DataSet();
            sda.Fill(data);
            attList.DataSource = data.Tables[0];
            Con.Close();
        }

        private void Category_Load(object sender, EventArgs e)
        {
            fetchCat();
            FetchCat();
            fetchData();
            fetchData1();
        }

       
        private void catdelbtn_Click(object sender, EventArgs e)
        {
            try
            {
                
                    Con.Open();
                    String query = "delete from CatTable where ID=" + ID.Text + "";
                    SqlCommand command = new SqlCommand(query, Con);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Category Deleted Successfully");
                    Con.Close();
                    ID.Text = "";
                    catname.Text = "";
                    description.Text = "";
                    fetchCat();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Con.Close();
            }
        }

        private void cateditbtn_Click(object sender, EventArgs e)
        {
            try
            {
               
                    Con.Open();
                    String query = "update CatTable set CatName='" + catname.Text + "', Description='" + description.Text + "', ID='" + ID.Text + "'where ID=" + ID.Text + ";";
                    SqlCommand command = new SqlCommand(query, Con);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Category Edited Successfully");
                    Con.Close();
                     ID.Text = "";
                    catname.Text = "";
                    description.Text = "";
                    fetchCat();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Con.Close();
            }
        }


        private void label5_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void Category_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

      

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void catname_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void prodList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            prodid.Text = prodList.SelectedRows[0].Cells[0].Value.ToString();
            prodname.Text = prodList.SelectedRows[0].Cells[1].Value.ToString();
            quantity.Text = prodList.SelectedRows[0].Cells[2].Value.ToString();
            Serial.Text = prodList.SelectedRows[0].Cells[3].Value.ToString();
            category.Text = prodList.SelectedRows[0].Cells[4].Value.ToString();

        }

        private void prodaddbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (prodname.Text == "" || quantity.Text == "" || Serial.Text == "" || category.Text == "")
                {
                    MessageBox.Show("Can't Add !\t\n Missing Info");
                } 
                else
                {
                    Con.Open();
                    String query = "insert into ProdTable (ProdName, Quantity, Serial, Category) values ('" + prodname.Text + "'," + quantity.Text + "," + Serial.Text + ",'" + category.Text + "')";
                    SqlCommand command = new SqlCommand(query, Con);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Product Added Successfully");
                    Con.Close();
                   
                    prodname.Text = "";
                    quantity.Text = "";
                    Serial.Text = "";

                    fetchData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Con.Close();
            }
        }
        private void fetchData()
        {
            Con.Open();
            string query = "select * from ProdTable";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var data = new DataSet();
            sda.Fill(data);
            prodList.DataSource = data.Tables[0];
            Con.Close();
        }

        private void prodeditbtn_Click(object sender, EventArgs e)
        {
            try
            {
               
                    Con.Open();
                    String query = "update ProdTable set ProdName='" + prodname.Text + "', Quantity=" + quantity.Text + ", Serial=" + Serial.Text + ", Category='" + category.Text + "'where Serial=" + Serial.Text + ";";
                    SqlCommand command = new SqlCommand(query, Con);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Product Edited Successfully");
                    Con.Close();
                 
                    prodname.Text = "";
                    quantity.Text = "";
                    Serial.Text = "";

                    fetchData();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Con.Close();
            }
        }

        private void proddelbtn_Click(object sender, EventArgs e)
        {
            try
            {
               
                    Con.Open();
                    String query = "delete from ProdTable where Serial=" + Serial.Text + "";
                    SqlCommand command = new SqlCommand(query, Con);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Product Deleted Successfully");
                    Con.Close();
                   
                    prodname.Text = "";
                    quantity.Text = "";
                    Serial.Text = "";

                    fetchData();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Con.Close();
            }
        }

        private void part_TextChanged(object sender, EventArgs e)
        {

        }

        private void category_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void catid_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void quantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void prodname_TextChanged(object sender, EventArgs e)
        {

        }

        private void prodid_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void description_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void dob_TextChanged(object sender, EventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

       private void attaddbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (attname.Text == "" || dob.Text == "" || number.Text == "" || password.Text == "")
                {
                    MessageBox.Show("Can't Add !\t\n Missing Info");
                }
                else
                {
                    Con.Open();
                    String query = "insert into AttTable (AttName, Age, Number, Password) values ('" + attname.Text + "'," + dob.Text + "," + number.Text + ",'" + password.Text + "')";
                    SqlCommand command = new SqlCommand(query, Con);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Attendant Added Successfully");
                    Con.Close();
                  
                    attname.Text = "";
                    dob.Text = "";
                    number.Text = "";
                    password.Text = "";
                    fetchData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Con.Close();
            }
        }

        private void atteditbtn_Click(object sender, EventArgs e)
        {
            try
            {
              
                    Con.Open();
                    String query = "update AttTable set AttName='" + attname.Text + "', Age=" + dob.Text + ", Number=" + number.Text + ", Password='" + password.Text + "'where Number=" + number.Text + ";";
                    SqlCommand command = new SqlCommand(query, Con);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Attendant Edited Successfully");
                    Con.Close();
                   
                    attname.Text = "";
                    dob.Text = "";
                    number.Text = "";
                    password.Text = "";
                    fetchData();
             }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Con.Close();
            }
        }

        private void attdelbtn_Click(object sender, EventArgs e)
        {
            try
            {
              
                    Con.Open();
                    String query = "delete from AttTable where Number=" + number.Text + "";
                    SqlCommand command = new SqlCommand(query, Con);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Attendant Deleted Successfully");
                    Con.Close();
                   
                    attname.Text = "";
                    dob.Text = "";
                    number.Text = "";
                    password.Text = "";
                    fetchData();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Con.Close();
            }
        }

        private void catList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
       
        private void button4_Click(object sender, EventArgs e)
        {
            LOGIN lg = new LOGIN();
            lg.Show();
            this.Hide();

        }

        private void ID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
