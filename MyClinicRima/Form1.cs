using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyClinicRima
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Usertxt.Text = "RimaElCharif";
        }

        private void Loginbtn_Click(object sender, EventArgs e)
        {
           if (Usertxt.Text == "RimaElCharif" && passtxt.Text == "123")
            {
                this.Visible = false;
                MainPage main = new MainPage();
                main.Show();
            }
            else
                MessageBox.Show("Wrong PassWord or Username!");
        }
        //This Program author is abed.sharif
    }
}
