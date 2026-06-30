using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace hall_system
{
    public partial class Booking : Form
    {
        public Booking()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Wedding-_hall_managementSystem\hall_system\WeddingHallDB.mdf;Integrated Security=True;Connect Timeout=30");
        private void GetCustID()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select CusID from CustomerTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CusID", typeof(string));
            dt.Load(rdr);
            CustIDcb.ValueMember = "CusID";
            CustIDcb.DataSource = dt;
            Con.Close();
        }
        private void label17_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SodaCheck_CheckStateChanged(object sender, EventArgs e)
        {
            if (SodaCheck.Checked == true)
            {
                SodaPri.Enabled = true;
                SodaQun.Enabled = true;
            }
            else
            {
                SodaPri.Enabled = false;
                SodaQun.Enabled = false;
                SodaPri.Text = "";
                SodaQun.Text = "";
            }
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                beerPri.Enabled = true;
                beerQty.Enabled = true;
            }
            else
            {
                beerPri.Enabled = false;
                beerQty.Enabled = false;
                beerPri.Text = "";
                beerQty.Text = "";
            }
        }

        private void Winechk_CheckStateChanged(object sender, EventArgs e)
        {
            if (Winechk.Checked == true)
            {
                WInepri.Enabled = true;
                WIneqty.Enabled = true;
            }
            else
            {
                WInepri.Enabled = false;
                WIneqty.Enabled = false;
                WInepri.Text = "";
                WIneqty.Text = "";
            }
        }

        private void Whiskychk_CheckStateChanged(object sender, EventArgs e)
        {
            if (Whiskychk.Checked == true)
            {
                Whiskypri.Enabled = true;
                Whiskyqty.Enabled = true;
            }
            else
            {
                Whiskypri.Enabled = false;
                Whiskyqty.Enabled = false;
                Whiskypri.Text = "";
                Whiskyqty.Text = "";
            }
        }

        private void juicechk_CheckStateChanged(object sender, EventArgs e)
        {
            if (juicechk.Checked == true)
            {
                juicepri.Enabled = true;
                juiceqty.Enabled = true;
            }
            else
            {
                juicepri.Enabled = false;
                juiceqty.Enabled = false;
                juicepri.Text = "";
                juiceqty.Text = "";
            }
        }

        private void chickenchk_CheckStateChanged(object sender, EventArgs e)
        {
            if (chickenchk.Checked == true)
            {
                chickenpri.Enabled = true;
                chickenqty.Enabled = true;
            }
            else
            {
                chickenpri.Enabled = false;
                chickenqty.Enabled = false;
                chickenpri.Text = "";
                chickenqty.Text = "";
            }
        }

        private void fishchk_CheckStateChanged(object sender, EventArgs e)
        {
            if (fishchk.Checked == true)
            {
                fishpri.Enabled = true;
                fishqty.Enabled = true;
            }
            else
            {
                fishpri.Enabled = false;
                fishqty.Enabled = false;
                fishpri.Text = "";
                fishqty.Text = "";
            }
        }

        private void sausagechk_CheckStateChanged(object sender, EventArgs e)
        {
            if (sausagechk.Checked == true)
            {
                sausagepri.Enabled = true;
                sausageqty.Enabled = true;
            }
            else
            {
                sausagepri.Enabled = false;
                sausageqty.Enabled = false;
                sausagepri.Text = "";
                sausageqty.Text = "";
            }
        }

        private void biryanichk_CheckStateChanged(object sender, EventArgs e)
        {
            if (biryanichk.Checked == true)
            {
                biryanipri.Enabled = true;
                biryaniqty.Enabled = true;
            }
            else
            {
                biryanipri.Enabled = false;
                biryaniqty.Enabled = false;
                biryanipri.Text = "";
                biryaniqty.Text = "";
            }
        }

        private void mottonchk_CheckStateChanged(object sender, EventArgs e)
        {
            if (mottonchk.Checked == true)
            {
                mottonpri.Enabled = true;
                mottonqty.Enabled = true;
            }
            else
            {
                mottonpri.Enabled = false;
                mottonqty.Enabled = false;
                mottonpri.Text = "";
                mottonqty.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int beer=0, soda=0, wine=0, whisky = 0, juice = 0;
            if (checkBox1.Checked == true && beerPri.Text == "" && beerQty.Text == "")
            {
                MessageBox.Show("Enter Beer Quantity");
            }
            else
            {
                beer = Convert.ToInt32(beerPri.Text) * Convert.ToInt32(beerQty.Text);
            }
            if (SodaCheck.Checked == true && SodaPri.Text == "" && SodaQun.Text == "")
            {
                MessageBox.Show("Enter Beer Quantity");
            }
            else
            {
                soda = Convert.ToInt32(SodaPri.Text) * Convert.ToInt32(SodaQun.Text);
            }
            if (Winechk.Checked == true && WInepri.Text == "" && WIneqty.Text == "")
            {
                MessageBox.Show("Enter Beer Quantity");
            }
            else
            {
                wine = Convert.ToInt32(WInepri.Text) * Convert.ToInt32(WIneqty.Text);
            }
            if (Whiskychk.Checked == true && Whiskypri.Text == "" && Whiskyqty.Text == "")
            {
                MessageBox.Show("Enter Beer Quantity");
            }
            else
            {
                whisky = Convert.ToInt32(Whiskypri.Text) * Convert.ToInt32(Whiskyqty.Text);
            }
            if (juicechk.Checked == true && juicepri.Text == "" && juiceqty.Text == "")
            {
                MessageBox.Show("Enter Beer Quantity");
            }
            else
            {
                juice = Convert.ToInt32(juicepri.Text) * Convert.ToInt32(juiceqty.Text);
            }
            int bevcost = wine + beer + juice + whisky + soda;
            BevCostLbl.Text = "" + bevcost;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int chicken = 0, Fish = 0, sausage = 0, Biryani = 0, motton = 0;
            if (chickenchk.Checked == true && chickenpri.Text == "" && chickenqty.Text == "")
            {
                MessageBox.Show("Enter Chicken Quantity");
            }
            else
            {
                chicken = Convert.ToInt32(chickenpri.Text) * Convert.ToInt32(chickenqty.Text);
            }
            if (fishchk.Checked == true && fishpri.Text == "" && fishqty.Text == "")
            {
                MessageBox.Show("Enter Fish Quantity");
            }
            else
            {
                Fish = Convert.ToInt32(fishpri.Text) * Convert.ToInt32(fishqty.Text);
            }
            if (sausagechk.Checked == true && sausagepri.Text == "" && sausageqty.Text == "")
            {
                MessageBox.Show("Enter Sausage Quantity");
            }
            else
            {
                sausage = Convert.ToInt32(sausagepri.Text) * Convert.ToInt32(sausageqty.Text);
            }
            if (biryanichk.Checked == true && biryanipri.Text == "" && biryaniqty.Text == "")
            {
                MessageBox.Show("Enter Biryani Quantity");
            }
            else
            {
                Biryani = Convert.ToInt32(biryanipri.Text) * Convert.ToInt32(biryaniqty.Text);
            }
            if (mottonchk.Checked == true && mottonpri.Text == "" && mottonqty.Text == "")
            {
                MessageBox.Show("Enter Motton Quantity");
            }
            else
            {
                motton = Convert.ToInt32(mottonpri.Text) * Convert.ToInt32(mottonqty.Text);
            }
            int dishcost = chicken + Fish + sausage + Biryani + motton;
            foodCos.Text = "" + dishcost;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        private void fetchcusName()
        {
            Con.Open();
            string mysql = "select * from CustomerTbl where CusID=" + CustIDcb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(mysql, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                CustName.Text = "" + dr["CusName"].ToString();
            }
            Con.Close();
        }

        private void CustIDcb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fetchcusName();
        }

        private void Booking_Load(object sender, EventArgs e)
        {
            GetCustID();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (CustIDcb.SelectedValue == null || CustIDcb.Text == "")
            {
                MessageBox.Show("Please select a Customer ID");
                return;
            }
            if (comboBox1.SelectedItem == null || comboBox1.Text == "")
            {
                MessageBox.Show("Please select Day or Night");
                return;
            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter number of persons");
                return;
            }

            try
            {
                Con.Open();
                string cusID = CustIDcb.SelectedValue.ToString();
                string dayNight = comboBox1.SelectedItem.ToString();
                string bookingDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string persons = textBox1.Text;
                string beverageCost = BevCostLbl.Text;
                string foodCost = foodCos.Text;
                string otherCharges = textBox23.Text == "" ? "0" : textBox23.Text;

                string query = "insert into BookingTbl values('" + cusID + "','" + dayNight + "','" + bookingDate + "','" + persons + "','" + beverageCost + "','" + foodCost + "','" + otherCharges + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Booking Successfully Added");
                Con.Close();
                ClearForm();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                Con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            CustIDcb.SelectedIndex = -1;
            CustName.Text = "";
            comboBox1.SelectedIndex = -1;
            textBox1.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            BevCostLbl.Text = "0";
            foodCos.Text = "0";
            textBox23.Text = "";
            textBox24.Text = "";
            textBox25.Text = "";

            // Reset all checkboxes
            SodaCheck.Checked = false;
            checkBox1.Checked = false;
            Winechk.Checked = false;
            Whiskychk.Checked = false;
            juicechk.Checked = false;
            chickenchk.Checked = false;
            fishchk.Checked = false;
            sausagechk.Checked = false;
            biryanichk.Checked = false;
            mottonchk.Checked = false;

            // Reset all textboxes
            SodaPri.Text = "";
            SodaQun.Text = "";
            beerPri.Text = "";
            beerQty.Text = "";
            WInepri.Text = "";
            WIneqty.Text = "";
            Whiskypri.Text = "";
            Whiskyqty.Text = "";
            juicepri.Text = "";
            juiceqty.Text = "";
            chickenpri.Text = "";
            chickenqty.Text = "";
            fishpri.Text = "";
            fishqty.Text = "";
            sausagepri.Text = "";
            sausageqty.Text = "";
            biryanipri.Text = "";
            biryaniqty.Text = "";
            mottonpri.Text = "";
            mottonqty.Text = "";
        }
    }
}
