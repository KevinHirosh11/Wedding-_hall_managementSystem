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
         int Staffkey = 0;
                private void clear()
                {
                    StaffName.Text = "";
                    StaffPhone.Text = "";
                    Staffkey = 0;
                    StaffGender.SelectedIndex = -1;
                    StaffPassTb.Text = "";
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
                    if (Con.State == ConnectionState.Open)
                    {
                        Con.Close();
                    }
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
                    clear();
                }
                catch (Exception Ex)
                {
                    if (Con.State == ConnectionState.Open)
                    {
                        Con.Close();
                    }
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

        private void button3_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (StaffDGV.SelectedRows.Count > 0)
            {
                Staffkey = Convert.ToInt32(StaffDGV.SelectedRows[0].Cells[0].Value.ToString());
            }

            if (Staffkey == 0)
            {
                MessageBox.Show("Select The Staff Member To Be Deleted");

            }
            else
            {
                try
                {
                    if (Con.State == ConnectionState.Open)
                    {
                        Con.Close();
                    }
                    Con.Open();
                    string query = "Delete from SatffTbl where StaffId=" + Staffkey + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Staff Deleted Successfully ");
                    Con.Close();
                    populate();
                    clear();
                }
                catch (Exception Ex)
                {
                    if (Con.State == ConnectionState.Open)
                    {
                        Con.Close();
                    }
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void StaffDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            StaffName.Text = StaffDGV.SelectedRows[0].Cells[1].Value.ToString();
            StaffPhone.Text = StaffDGV.SelectedRows[0].Cells[2].Value.ToString();
            StaffGender.SelectedItem = StaffDGV.SelectedRows[0].Cells[3].Value.ToString();
            StaffPassTb.Text = StaffDGV.SelectedRows[0].Cells[4].Value.ToString();
            if (StaffPhone.Text == "")
            {
                Staffkey = 0;
            }
            else
            {
                Staffkey = Convert.ToInt32(StaffDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (StaffName.Text == "" || StaffPhone.Text == "" || StaffGender.SelectedItem == null || StaffPassTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    if (Con.State == ConnectionState.Open)
                    {
                        Con.Close();
                    }
                    Con.Open();
                    string query = "update SatffTbl set StaffName='" + StaffName.Text + "',StaffPhone='" + StaffPhone.Text + "',StaffGender='" + StaffGender.SelectedItem.ToString() + "',StaffPassword='" + StaffPassTb.Text + "' where StaffId=" + Staffkey + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Staff Successfully Updated");
                    Con.Close();
                    populate();
                    clear();
                }
                catch (Exception Ex)
                {
                    if (Con.State == ConnectionState.Open)
                    {
                        Con.Close();
                    }
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}

