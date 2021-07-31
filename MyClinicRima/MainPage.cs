using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyClinicRima
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            dateTimePicker3.Value = DateTime.Now.AddDays(30);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=localhost;Initial Catalog=MyClinic;Integrated Security=True";
            
            SqlConnection conn = new SqlConnection(connectionString);

            string sqlCommandString = "INSERT INTO PatientInfo VALUES(@Name, @Email, @Height, @Weight, @PhoneNum, @PaymentTotal, @DateOfBirth, @DateOfConsultant, @NextConsultant)";

            SqlCommand sqlCommand = new SqlCommand(sqlCommandString, conn);
            if (txtPhoneNum.Text == "")
            {
                MessageBox.Show("Phone Number is needed");
            }
            else
            {
                try
                {

                    sqlCommand.Parameters.Add("@Name", SqlDbType.VarChar);

                    sqlCommand.Parameters["@Name"].Value = txtName.Text;

                    sqlCommand.Parameters.Add("@Email", SqlDbType.VarChar);

                    sqlCommand.Parameters["@Email"].Value = txtEmail.Text;

                    sqlCommand.Parameters.Add("@Height", SqlDbType.VarChar);

                    sqlCommand.Parameters["@Height"].Value = txtHeight.Text;

                    sqlCommand.Parameters.Add("@Weight", SqlDbType.VarChar);

                    sqlCommand.Parameters["@Weight"].Value = txtWeight.Text;

                    sqlCommand.Parameters.Add("@PhoneNum", SqlDbType.VarChar);

                    sqlCommand.Parameters["@PhoneNum"].Value = txtPhoneNum.Text;

                    sqlCommand.Parameters.Add("@PaymentTotal", SqlDbType.VarChar);

                    sqlCommand.Parameters["@PaymentTotal"].Value = txtPrice.Text;

                    sqlCommand.Parameters.Add("@DateOfBirth", SqlDbType.DateTime);

                    sqlCommand.Parameters["@DateOfBirth"].Value = dateTimePicker1.Value.ToString("DD-MM-YYYY");

                    sqlCommand.Parameters["@DateOfBirth"].Value = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");

                    sqlCommand.Parameters.Add("@DateOfConsultant", SqlDbType.DateTime);

                    sqlCommand.Parameters["@DateOfConsultant"].Value = dateTimePicker2.Value.ToString("DD-MM-YYYY");

                    sqlCommand.Parameters["@DateOfConsultant"].Value = dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss");

                    sqlCommand.Parameters.Add("@NextConsultant", SqlDbType.DateTime);

                    sqlCommand.Parameters["@NextConsultant"].Value = dateTimePicker3.Value.ToString("DD-MM-YYYY");

                    sqlCommand.Parameters["@NextConsultant"].Value = dateTimePicker3.Value.ToString("yyyy-MM-dd HH:mm:ss");

                    conn.Open();

                    sqlCommand.ExecuteNonQuery();

                    MessageBox.Show(txtName.Text + " was registered successfully.");


                }
                catch (Exception Error)
                {

                    MessageBox.Show("Ops Somthing Went Wrong " + Error);

                    //Console.WriteLine(Error);
                }

                finally
                {
                    conn.Close();
                }
            }
        }

        private void SearchOldPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
            Search search = new Search();
            search.Show();
        }
    }
}
