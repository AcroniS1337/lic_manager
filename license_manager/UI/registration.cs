using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace license_manager.UI
{
    public partial class registration : MaterialForm
    {
        public registration()
        {
            InitializeComponent();

            var material_skin = MaterialSkinManager.Instance;
            material_skin.AddFormToManage(this);
            material_skin.Theme = MaterialSkinManager.Themes.DARK;
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            if (materialSingleLineTextField1.Text == "" || materialSingleLineTextField2.Text == "")
            {
                MessageBox.Show(materialSingleLineTextField1.Text == "" && materialSingleLineTextField2.Text == "" ? "Введите логин и пароль" : (materialSingleLineTextField1.Text == "" ? "Введите логин" : "Введите пароль"));
                return;
            }


            Program.login_data.login = this.materialSingleLineTextField1.Text;
            Program.login_data.password = this.materialSingleLineTextField2.Text;
            Program.login_data.name_pc = "1337";

            Program.login_data.save_data();
            autorization.add_info(this.materialSingleLineTextField1.Text, this.materialSingleLineTextField2.Text);
            Program.log_info.log_add_registration(this.materialSingleLineTextField1.Text, DateTime.Now);
            this.Close();
        }
    }
}
