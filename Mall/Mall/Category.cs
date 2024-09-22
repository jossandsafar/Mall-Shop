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

namespace Inventory
{
    public partial class Category : Form
    {
        public Category()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            Reports att = new Reports();
            att.Show();
            await Task.Delay(500);
            this.Hide();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Products pd = new Products();
            pd.Show();
            await Task.Delay(500);
            this.Hide();
        }

            SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dell\Desktop\Mall\bin\AttTable.mdf;Integrated Security=True;Connect Timeout=30");
        
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
        private void Category_Load(object sender, EventArgs e)
        {
            fetchCat();
        }

        private void catList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            catid.Text = catList.SelectedRows[0].Cells[0].Value.ToString();
            catname.Text = catList.SelectedRows[0].Cells[1].Value.ToString();
            description.Text = catList.SelectedRows[0].Cells[2].Value.ToString();

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

        private void button4_Click(object sender, EventArgs e)
        {
            LOGIN lg = new LOGIN();
            lg.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            LOGIN ct = new LOGIN();
            ct.Show();

            this.Hide();
        }
    }
}
