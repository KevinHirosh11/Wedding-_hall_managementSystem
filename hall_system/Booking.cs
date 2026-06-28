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
        private void Booking_Load(object sender, EventArgs e)
        {
            GetCustID();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {

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
        private void CustIDcb_SelectedIndexChanged(object sender, EventArgs e)
        {
            fetchcusName();
        }
    }
}
