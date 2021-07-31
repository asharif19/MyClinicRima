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
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
            button2.Enabled = false;
            dateTimePicker3.Value = DateTime.Now.AddDays(30);
        }

        private void Search_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'finalData.PatientInfo' table. You can move, or remove it, as needed.
            this.patientInfoTableAdapter1.Fill(this.finalData.PatientInfo);

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=localhost;Initial Catalog=MyClinic;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);
            if (textBox5.Text == "")
            {
                MessageBox.Show("Phone Number is needed");
            }
            else
            {
                string Phone = txtSearch.Text;
                string name = textBox1.Text;
                string Email = textBox2.Text;
                string Height = textBox3.Text;
                string weight = textBox4.Text;
                string PhoneNum = textBox5.Text;
                string payment = textBox6.Text;
                string next = dateTimePicker3.Value.ToString("yyyy-MM-dd HH:mm:ss");

                SqlCommand sqlCommand
                    = new SqlCommand("UPDATE PatientInfo SET Name ='"
                        + name + "', Email ='" + Email
                        + "', Height ='" + Height + "', Weight ='" + weight + "', PhoneNum ='" + PhoneNum + "',NextConsultant ='"
                        + next + "',PaymentTotal ='" + payment + "' WHERE PhoneNum = '" + Phone + "'", conn);
                try
                {
                    conn.Open();
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show(name + " was updated successfully.");
                }
                catch (Exception err)
                {
                    MessageBox.Show("Error updating database. " + err);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string connectionString2 = "Data Source=localhost;Initial Catalog=MyClinic;Integrated Security=True";
            // string connectionString2 = @"Data Source=DESKTOP-P5B22V5\FIRSTSERVER;Initial Catalog=MyClinic;Integrated Security=True";

            SqlConnection conn = new SqlConnection(connectionString2);

            string id = txtSearch.Text;
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM PatientInfo WHERE PhoneNum = '"
                  + id + "'", conn);

            SqlCommand sqlCommand2 = new SqlCommand("SELECT * FROM PatientInfo ", conn);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand2);
            try
            {
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception exx)
            {
                MessageBox.Show("Error Occured with searching for " + txtSearch.Text + " " + exx);
                //Console.WriteLine(ex);
            }

            try
            {
                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    textBox1.Text = reader[0].ToString();
                    textBox2.Text = reader[1].ToString();
                    textBox3.Text = reader[2].ToString();
                    textBox4.Text = reader[3].ToString();
                    textBox5.Text = reader[4].ToString();
                    textBox6.Text = reader[5].ToString();

                    //label7.Text = reader[7].ToString();
                    label19.Text = reader[8].ToString();
                    //dateTimePicker3.Text = reader[9].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured with searching for " + txtSearch.Text + " " + ex);
                //Console.WriteLine(ex);
            }

            finally
            {
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            //string connectionString3 = "Data Source=localhost;Initial Catalog=MyClinic;Integrated Security=True";
            //SqlConnection conn3 = new SqlConnection(connectionString3);
            //if (txtSearch.Text == "")
            //{
            //    MessageBox.Show("Phone Number is needed");
            //}
            //else
            //{
            //    string PhoneNum = txtSearch.Text;

            //    SqlCommand sqlCommand
            //        = new SqlCommand("DELETE FROM PatientInfo WHERE PhoneNum = PhoneNum ", conn3);
            //    try
            //    {
            //        conn3.Open();
            //        sqlCommand.ExecuteNonQuery();
            //        MessageBox.Show(PhoneNum + " was deleted successfully.");
            //    }
            //    catch (Exception err)
            //    {
            //        MessageBox.Show("Error updating database. " + err);
            //    }
            //    finally
            //    {
            //        conn3.Close();
            //    }
            //}
        }
    }//this code was written by abed.sharif.
}

