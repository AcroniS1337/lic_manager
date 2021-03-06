﻿using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace license_manager.UI
{
    public partial class edit_user_product : MaterialForm
    {
        public edit_user_product()
        {
            InitializeComponent();

            var material_skin = MaterialSkinManager.Instance;
            material_skin.AddFormToManage(this);
            material_skin.Theme = MaterialSkinManager.Themes.DARK;

        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            general_form.edit_user(Program.product_info.id, materialSingleLineTextField1.Text, materialSingleLineTextField2.Text, materialSingleLineTextField3.Text, materialSingleLineTextField4.Text, materialSingleLineTextField7.Text,dateTimePicker1.Value, materialSingleLineTextField5.Text, materialSingleLineTextField6.Text);
            Program.log_info.log_user_product(materialSingleLineTextField2.Text, materialSingleLineTextField1.Text, DateTime.Now,"Изменил");
            Program.general.save_file(general_form.instance.listView1, "user_product.ini");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value > DateTime.Now)
                materialSingleLineTextField6.Text = "Да";
            else
                materialSingleLineTextField6.Text = "Нет";
        }

        private void materialSingleLineTextField5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) & (e.KeyChar != ',') & (e.KeyChar != (char)Keys.Back))  // lock
                e.Handled = true;
        }

        private void materialSingleLineTextField5_TextChanged(object sender, EventArgs e)
        {
            var size = materialSingleLineTextField2.Text.Length.ToString(CultureInfo.InvariantCulture);

            if (Convert.ToInt32(size) > 7)
            {
                MessageBox.Show("Максимальная длина 7 символов");
                return;
            }
        }
    }
}
