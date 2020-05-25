using license_manager.classes;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace license_manager.UI
{
    public partial class add_user_product : MaterialForm
    {
        public static add_user_product instance;
        public add_user_product()
        {
            InitializeComponent();
            instance = this;
            var material_skin = MaterialSkinManager.Instance;
            material_skin.AddFormToManage(this);
            material_skin.Theme = MaterialSkinManager.Themes.DARK;

            this.materialSingleLineTextField3.Text = Program.general.name_pc_set;

            if (File.Exists("products.ini"))
            {
                Program.general.read_file_product(this.comboBox1, "products.ini", "", comboBox2);
            }
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e) // add user product
        {
            if (this.materialSingleLineTextField1.Text != "" && this.materialSingleLineTextField2.Text != "" && this.materialSingleLineTextField3.Text != "" && this.materialSingleLineTextField4.Text != "" && comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1)
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.SubItems[0].Text = comboBox1.Text;
                listViewItem.SubItems.Add(materialSingleLineTextField1.Text);
                listViewItem.SubItems.Add(materialSingleLineTextField2.Text);
                listViewItem.SubItems.Add(materialSingleLineTextField3.Text);
                listViewItem.SubItems.Add(materialSingleLineTextField4.Text);
                listViewItem.SubItems.Add(dateTimePicker1.Value.ToString());
                listViewItem.SubItems.Add(comboBox2.Text);
                listViewItem.SubItems.Add(dateTimePicker1.Value > DateTime.Now ? "Да" : "Нет");
                general_form.add_user(listViewItem);
                Program.log_info.log_add_add_user_product(materialSingleLineTextField1.Text, comboBox1.Text, DateTime.Now);
               Program.general.save_file(general_form.instance.listView1, "user_product.ini");
            }
        }

        private void comboBox2_MouseEnter(object sender, EventArgs e)
        {
            Program.general.read_file_product(this.comboBox1, "products.ini", comboBox1.Text != null ? comboBox1.Text : "", comboBox2);
        }
    }
}
