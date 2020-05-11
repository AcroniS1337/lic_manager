using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lic_man
{
    public partial class Form1 : Form
    {
        user_Info login_data;
        main_form main_Form;
        public Form1()
        {
            InitializeComponent();

            login_data = new user_Info();
            login_data.load_data();           
            textBox1.Text = login_data.login;
            textBox2.Text = login_data.password;

            main_Form = new main_form();



        }

        private void button2_Click(object sender, EventArgs e) // reg
        {
            Reg reg_reg = new Reg();
            reg_reg.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e) // auto
        {
            if (this.textBox1.Text == "" || this.textBox2.Text == "")
            {
                MessageBox.Show("Логин или пароль не заполнен");
                return;
            }

            main_Form.Show();
            this.Hide();
        }
    }
}
