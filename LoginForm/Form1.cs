using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source =Database2.accdb");
        OleDbCommand cmd;
        OleDbDataReader rdr;
       
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtUsername.Text, "^[a-zA-Z ]"))
            {
                MessageBox.Show("This textbox accepts only alphabetical characters");
                txtUsername.Text.Remove(txtUsername.Text.Length - 1);
            }

            List<string> allvalues = this.Controls.OfType<TextBox>().Select(x => x.Text).ToList();

            System.IO.File.WriteAllText("C:\\Users\\Administrator\\Documents\\login.txt", String.Join(Environment.NewLine, allvalues));
            string[] alllines = System.IO.File.ReadAllLines("C:\\Users\\Administrator\\Documents\\login.txt");

            List<TextBox> allTextboxes = this.Controls.OfType<TextBox>().ToList();
            for (int i = 0; i < allTextboxes.Count; i++)
            {
                allTextboxes[i].Text = alllines[i];
            }
            
        }

        
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = txtUsername.Text;
            string password = txtPassword.Text;
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT *FROM Login WHERE Username='"+name+"'AND Password='"+password+"'";
            rdr = cmd.ExecuteReader();

            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("ID or Password should be filled.");
            }
            else if (txtUsername.Text == "admin" && txtPassword.Text == "admin" || txtUsername.Text == "user" && txtPassword.Text == "user")
            {
                Form2 form = new Form2();
                form.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Wrond ID or Password!");
            }

        }
      
    }
}
