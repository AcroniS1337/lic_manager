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
    public partial class general_form : MaterialForm
    {
        public static general_form instance;
        public general_form()
        {
            InitializeComponent();

            var material_skin = MaterialSkinManager.Instance;
            material_skin.AddFormToManage(this);
            material_skin.Theme = MaterialSkinManager.Themes.DARK;

            instance = this;
            user_load();
        }
        public void user_load()
        {
            listView1.Items.Clear();
            bool found_file = false;

            FileInfo fileInf = new FileInfo("user_product.ini");
            if (fileInf.Exists)
            {
                found_file = true;
            }

            if (found_file)
            {
                string sraw;
                StreamReader sr = new StreamReader("user_product.ini");
                while ((sraw = sr.ReadLine()) != null)
                {
                    string splite = sraw.Split(',')[0];
                    string splite2 = sraw.Split(',')[1];
                    string splite3 = sraw.Split(',')[2];
                    string splite4 = sraw.Split(',')[3];
                    string splite5 = sraw.Split(',')[4];
                    string splite6 = sraw.Split(',')[5];
                    string splite7 = sraw.Split(',')[6];
                    string splite8 = sraw.Split(',')[7];
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.SubItems[0].Text = splite;
                    listViewItem.SubItems.Add(splite2);
                    listViewItem.SubItems.Add(splite3);
                    listViewItem.SubItems.Add(splite4);
                    listViewItem.SubItems.Add(splite5);
                    listViewItem.SubItems.Add(splite6);
                    listViewItem.SubItems.Add(splite7);
                    listViewItem.SubItems.Add(DateTime.Now > Convert.ToDateTime(splite6) ? "Истекла" : splite8);
                   
                        listView1.Items.Add(listViewItem);
                    
                    if (!comboBox1.Items.Cast<string>().Contains(listViewItem.SubItems[0].Text))
                    {
                        comboBox1.Items.Add(listViewItem.SubItems[0].Text);
                    }
                }
                sr.Close();
            }
        }
        public static void add_user(ListViewItem users)
        {
            general_form.instance.listView1.Items.Add(users);
        }
        public static void edit_user(int index, string product, string name, string mail, string hwid, string edition, DateTime time_end, string version, string enable)
        {
            if (general_form.instance.listView1.Items[index].Selected)
            {
                general_form.instance.listView1.FocusedItem.SubItems[0].Text = product;
                general_form.instance.listView1.FocusedItem.SubItems[1].Text = name;
                general_form.instance.listView1.FocusedItem.SubItems[2].Text = mail;
                general_form.instance.listView1.FocusedItem.SubItems[3].Text = hwid;
                general_form.instance.listView1.FocusedItem.SubItems[4].Text = edition;
                general_form.instance.listView1.FocusedItem.SubItems[5].Text = time_end.ToString();
                general_form.instance.listView1.FocusedItem.SubItems[6].Text = version;
                general_form.instance.listView1.FocusedItem.SubItems[7].Text = enable;

            }

            Program.general.save_file(general_form.instance.listView1, "user_product.ini");
        }
        private void materialRaisedButton1_Click(object sender, EventArgs e) // add product
        {
            add_product add_show = new add_product();
            add_show.ShowDialog();
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e) // add user product
        {
            add_user_product user_product = new add_user_product();

            user_product.ShowDialog();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = listView1.Items.Count - 1; i >= 0; i--)
            {
                if (listView1.Items[i].Selected)
                {
                    Program.log_info.log_user_product(listView1.FocusedItem.SubItems[1].Text, listView1.FocusedItem.SubItems[0].Text, DateTime.Now,"Удалил");
                    listView1.Items[i].Remove();
                }
            }           
            Program.general.save_file(listView1, "user_product.ini");
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edit_user_product user_edit = new edit_user_product();

            for (int i = listView1.Items.Count - 1; i >= 0; i--)
            {
                if (listView1.Items[i].Selected)
                {

                    user_edit.materialSingleLineTextField1.Text = this.listView1.FocusedItem.SubItems[0].Text; // name product
                    user_edit.materialSingleLineTextField2.Text = this.listView1.FocusedItem.SubItems[1].Text; //  name user
                    user_edit.materialSingleLineTextField3.Text = this.listView1.FocusedItem.SubItems[2].Text; //  mail
                    user_edit.materialSingleLineTextField4.Text = this.listView1.FocusedItem.SubItems[3].Text; //  hwid
                    user_edit.materialSingleLineTextField7.Text = this.listView1.FocusedItem.SubItems[4].Text; //  edition
                    user_edit.dateTimePicker1.Text = this.listView1.FocusedItem.SubItems[5].Text; // time end
                    user_edit.materialSingleLineTextField5.Text = this.listView1.FocusedItem.SubItems[6].Text; //  version
                    user_edit.materialSingleLineTextField6.Text = this.listView1.FocusedItem.SubItems[7].Text; //  enable
                    Program.product_info.id = i;
                }
            }
            user_edit.ShowDialog();

        }

        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {
            log_show log_open = new log_show();
            log_open.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            user_load();
            if (textBox1.Text != "")
                {
                    for (int i = listView1.Items.Count - 1; i >= 0; i--)
                    {
                    var item = listView1.Items[i];
                        if (item.SubItems[0].Text.IndexOf(textBox1.Text, StringComparison.OrdinalIgnoreCase) >= 0
                        || item.SubItems[1].Text.IndexOf(textBox1.Text, StringComparison.OrdinalIgnoreCase) >= 0
                         || item.SubItems[2].Text.IndexOf(textBox1.Text, StringComparison.OrdinalIgnoreCase) >= 0
                          || item.SubItems[3].Text.IndexOf(textBox1.Text, StringComparison.OrdinalIgnoreCase) >= 0
                     || item.SubItems[4].Text.IndexOf(textBox1.Text, StringComparison.OrdinalIgnoreCase) >= 0
                 || item.SubItems[5].Text.IndexOf(textBox1.Text, StringComparison.OrdinalIgnoreCase) >= 0
                 || item.SubItems[6].Text.IndexOf(textBox1.Text, StringComparison.OrdinalIgnoreCase) >= 0
                 || item.SubItems[7].Text.IndexOf(textBox1.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                    {                       
                    }
                        else
                        {
                        listView1.Items.Remove(item);
                    }
                    }
                    if (listView1.SelectedItems.Count == 1)
                    {
                        listView1.Focus();
                    }
            }
           if(textBox1.Text == "")
            {
                user_load();
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            user_load();
            if (comboBox1.Text != "" || comboBox1.Text != "None")
            {
                for (int i = listView1.Items.Count - 1; i >= 0; i--)
                {
                    var item = listView1.Items[i];
                    if (item.Text.IndexOf(comboBox1.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                    {

                    }
                    else
                    {
                        listView1.Items.Remove(item);
                    }
                }
                if (listView1.SelectedItems.Count == 1)
                {
                    listView1.Focus();
                }
            }
            if (comboBox1.Text == "" || comboBox1.Text == "None")
            {
                user_load();
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            listView1.FullRowSelect = true;
        }
    }
}
