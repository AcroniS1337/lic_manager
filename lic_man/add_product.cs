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
    public partial class add_product : Form
    {
        public add_product()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // add
        {
            if (this.textBox1.Text != "" && this.textBox2.Text != "")
            {
                Program.product_info.name_product = this.textBox1.Text;
                Program.product_info.version = Convert.ToInt32(this.textBox2.Text);


                ListViewItem listViewItem = new ListViewItem(new string[] { this.textBox1.Text, this.textBox2.Text, Convert.ToString(Program.product_info.license_count = 0) });

                listView1.Items.Add(listViewItem);
            }



        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = listView1.Items.Count - 1; i >= 0; i--)
            {
                if (listView1.Items[i].Selected)
                {
                    listView1.Items[i].Remove();
                }
            }
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {


            for (int i = listView1.Items.Count - 1; i >= 0; i--)
            {
                if (listView1.Items[i].Selected)
                {
                    MessageBox.Show(i.ToString(),"edit");

                    this.textBox4.Text = this.listView1.FocusedItem.SubItems[0].Text;
                    this.textBox3.Text = this.listView1.FocusedItem.SubItems[1].Text;
                    Program.product_info.id = i;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) //save
        {

            for (int i = listView1.Items.Count - 1; i >= 0; i--)
            {
                if (listView1.Items[i].Selected)
                {
                    MessageBox.Show(i.ToString(), "edit_save");

                    this.listView1.FocusedItem.SubItems[0].Text = this.textBox4.Text;
                    this.listView1.FocusedItem.SubItems[1].Text = this.textBox3.Text;
                    Program.product_info.id = i;
                }
            }

        }
    }
}
