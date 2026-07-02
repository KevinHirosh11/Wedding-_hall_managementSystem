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

namespace hall_system
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Wedding-_hall_managementSystem\hall_system\WeddingHallDB.mdf;Integrated Security=True;Connect Timeout=30");
        private void button4_Click(object sender, EventArgs e)
        {
            if (CusNameTb.Text == "" || CusAddressTb.Text == "" || CusPhoneTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into CustomerTbl values('" + CusNameTb.Text + "','" + CusAddressTb.Text + "','" + CusPhoneTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Successfully Added");
                    Con.Close();
                    populate();
                    clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void populate()
        {
            Con.Open();
            string query = "select * from CustomerTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            Con.Close() ;
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            populate();
            SetupDataGridViewStyle();
        }

        private void SetupDataGridViewStyle()
        {
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dataGridView1.RowTemplate.Height = 35;
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.MediumSeaGreen;

            dataGridView1.RowHeadersVisible = false;

            dataGridView1.BackgroundColor = SystemColors.Control;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Indigo;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
            dataGridView1.ColumnHeadersHeight = 40;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
        }
        int custKey = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CusNameTb.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            CusAddressTb.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            CusPhoneTb.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            if(CusPhoneTb.Text == "")
            {
                custKey = 0;
            }
            else
            {
                custKey = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
        private void clear()
        {
            CusPhoneTb.Text = "";
            CusAddressTb.Text = "";
            custKey = 0;
            CusNameTb.Text = "";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (custKey == 0)
            {
                MessageBox.Show("Select The Customer To Be Deleted");

            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "Delete from CustomerTbl where CusId=" + custKey + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Deleted Successfully ");
                    Con.Close();
                    populate();
                    clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CusNameTb.Text == "" || CusAddressTb.Text == "" || CusPhoneTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update CustomerTbl set CusNameTb='"+CusNameTb.Text+"',CusAddressTb='"+CusAddressTb.Text+"',CusPhoneTb='"+CusPhoneTb.Text+"' where CusID=" + custKey + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Successfully Updated");
                    Con.Close();
                    populate();
                    clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
