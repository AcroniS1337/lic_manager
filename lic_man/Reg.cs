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
    public partial class Reg : Form
    {
        user_Info login_data;
        public Reg()
        {
            InitializeComponent();
            login_data = new user_Info();

            textBox3.Text = System.Net.Dns.GetHostName();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show(textBox1.Text == "" && textBox2.Text == "" ? "Введите логин и пароль" : (textBox1.Text == "" ? "Введите логин" : "Введите пароль"));
                return;
            }


            login_data.login = this.textBox1.Text;
            login_data.password = this.textBox2.Text;
            login_data.name_pc = this.textBox3.Text;

            login_data.save_data();

            this.Close();
        }
    }
}
