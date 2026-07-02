using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hall_system
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Booking bookingForm = new Booking();
            bookingForm.FormClosed += (s, args) => this.Show();
            bookingForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Staff staffForm = new Staff();
            staffForm.FormClosed += (s, args) => this.Show();
            staffForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customer customerForm = new Customer();
            customerForm.FormClosed += (s, args) => this.Show();
            customerForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewBooking viewBookForm = new ViewBooking();
            viewBookForm.FormClosed += (s, args) => this.Show();
            viewBookForm.Show();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            login loginForm = new login();
            loginForm.Show();
            this.Hide();
        }
    }
}
