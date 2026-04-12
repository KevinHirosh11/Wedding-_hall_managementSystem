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

namespace hall_system
{
    public partial class Staff : Form
    {
        public Staff()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Wedding-_hall_managementSystem\hall_system\WeddingHallDB.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            string query = "select * from SatffTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            StaffDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void StyleDataGridView()
        {
            StaffDGV.BackgroundColor = Color.White;
            StaffDGV.BorderStyle = BorderStyle.None;
            StaffDGV.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            StaffDGV.EnableHeadersVisualStyles = false;
            StaffDGV.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            StaffDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.DeepPink;
            StaffDGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            StaffDGV.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            StaffDGV.ColumnHeadersHeight = 35;

            StaffDGV.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            StaffDGV.DefaultCellStyle.BackColor = Color.White;
            StaffDGV.DefaultCellStyle.ForeColor = Color.Black;
            StaffDGV.DefaultCellStyle.SelectionBackColor = Color.ForestGreen;
            StaffDGV.DefaultCellStyle.SelectionForeColor = Color.White;

            StaffDGV.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSteelBlue;

            StaffDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            StaffDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            StaffDGV.RowHeadersVisible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (StaffName.Text == "" || StaffPhone.Text == "" || StaffGender.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into SatffTbl (StaffName, StaffPhone, StaffGender, StaffPassword) values (@Name, @Phone, @Gender, @Password)";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.Parameters.AddWithValue("@Name", StaffName.Text);
                    cmd.Parameters.AddWithValue("@Phone", StaffPhone.Text);
                    cmd.Parameters.AddWithValue("@Gender", StaffGender.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Password", StaffPassTb.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Staff Successfully Added");
                    Con.Close();
                    populate();
                    //clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Staff_Load(object sender, EventArgs e)
        {
            try 
            {
                Con.Open();

                try {
                    new SqlCommand("EXEC sp_rename 'SatffTbl', 'StaffTbl'", Con).ExecuteNonQuery();
                } catch {}

                try {
                    new SqlCommand("ALTER TABLE StaffTbl ALTER COLUMN StaffName VARCHAR(50) NOT NULL", Con).ExecuteNonQuery();
                } catch {}

                Con.Close();
            }
            catch {
                if (Con.State == ConnectionState.Open) Con.Close();
            }

            populate();
            StyleDataGridView();
        }
    }
}
