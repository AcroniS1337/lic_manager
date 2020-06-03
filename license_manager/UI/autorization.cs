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
    public partial class autorization : MaterialForm
    {
        public static autorization instance;
        public autorization()
        {
            InitializeComponent();

            var material_skin = MaterialSkinManager.Instance;
            material_skin.AddFormToManage(this);
            material_skin.Theme = MaterialSkinManager.Themes.DARK;
            Program.login_data.load_data();
            materialSingleLineTextField1.Text = Program.login_data.login;
            materialSingleLineTextField2.Text = Program.login_data.password;
            instance = this;
        }

        public static void add_info(string login,string password)
        {
            autorization.instance.materialSingleLineTextField1.Text = login;
            autorization.instance.materialSingleLineTextField2.Text = password;
        }
        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            registration reg = new registration();
            reg.ShowDialog();
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            general_form main_form = new general_form();
            Program.log_info.log_registration(materialSingleLineTextField1.Text, DateTime.Now,"Авторизовался");
            main_form.Show();
            this.Hide();
        }
    }
}
