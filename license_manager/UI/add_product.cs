using MaterialSkin;
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
    public partial class add_product : MaterialForm
    {
        public add_product()
        {
            InitializeComponent();

            var material_skin = MaterialSkinManager.Instance;
            material_skin.AddFormToManage(this);
            material_skin.Theme = MaterialSkinManager.Themes.DARK;

            Program.general.read_file(listView1, "products.ini");

        }

        private void materialRaisedButton1_Click(object sender, EventArgs e) // add
        {
            if (this.materialSingleLineTextField1.Text != "" && this.materialSingleLineTextField2.Text != "")
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.SubItems[0].Text = this.materialSingleLineTextField1.Text;

                Program.product_info.version = Convert.ToDouble(this.materialSingleLineTextField2.Text);

                listViewItem.SubItems.Add(Convert.ToString(Program.product_info.version));

                listView1.Items.Add(listViewItem);

                Program.log_info.log_product(materialSingleLineTextField1.Text, DateTime.Now, "Добавил");
                Program.general.save_file(listView1, "products.ini");
            }
            else
                MessageBox.Show("Заполните поля");
        }

        private void materialSingleLineTextField2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) & (e.KeyChar != ',') & (e.KeyChar != (char)Keys.Back))  // lock
                e.Handled = true;
        }

        private void materialSingleLineTextField2_TextChanged(object sender, EventArgs e)
        {
            var size = materialSingleLineTextField2.Text.Length.ToString(CultureInfo.InvariantCulture);

            if (Convert.ToInt32(size) > 7)
            {
                MessageBox.Show("Максимальная длина 7 символов");
                return;
            }

        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)  // save edit
        {
            for (int i = listView1.Items.Count - 1; i >= 0; i--)
            {
                if (listView1.Items[i].Selected)
                {

                    this.listView1.FocusedItem.SubItems[0].Text = this.materialSingleLineTextField3.Text;
                    this.listView1.FocusedItem.SubItems[1].Text = this.materialSingleLineTextField4.Text;

                    Program.log_info.log_product(this.listView1.FocusedItem.SubItems[0].Text, DateTime.Now,"Сохранил");
                    Program.product_info.id = i;
                }
            }
            Program.general.save_file(listView1, "products.ini");
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = listView1.Items.Count - 1; i >= 0; i--)
            {
                if (listView1.Items[i].Selected)
                {
                    Program.log_info.log_product(this.listView1.FocusedItem.SubItems[0].Text.ToString(), DateTime.Now,"Удалил");
                    listView1.Items[i].Remove();
                }
            }

            Program.general.save_file(listView1, "products.ini");
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = listView1.Items.Count - 1; i >= 0; i--)
            {
                if (listView1.Items[i].Selected)
                {

                    this.materialSingleLineTextField3.Text = this.listView1.FocusedItem.SubItems[0].Text;
                    this.materialSingleLineTextField4.Text = this.listView1.FocusedItem.SubItems[1].Text;
                    Program.product_info.id = i;
                }
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            listView1.FullRowSelect = true;

        }

        private void materialSingleLineTextField4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) & (e.KeyChar != ',') & (e.KeyChar != (char)Keys.Back))  // lock
                e.Handled = true;
        }

        private void materialSingleLineTextField4_TextChanged(object sender, EventArgs e)
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
