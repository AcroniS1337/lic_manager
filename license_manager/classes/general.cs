using license_manager.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace license_manager.classes
{
    public class general
    {
        public string name_pc_set = System.Net.Dns.GetHostName();

        public void read_file(ListView list, string file_name)
        {

            bool found_file = false;

            FileInfo fileInf = new FileInfo(file_name);
            if (fileInf.Exists)
            {
                found_file = true;
            }

            if (found_file)
            {
                string sraw;
                StreamReader sr = new StreamReader(file_name);
                while ((sraw = sr.ReadLine()) != null)
                {
                    string splite = sraw.Split(',')[0];
                    string splite2 = sraw.Split(',')[1];
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.SubItems[0].Text = splite;
                    listViewItem.SubItems.Add(splite2);
                    list.Items.Add(listViewItem);
                }
                sr.Close();
            }
        }

        public  void save_file(ListView list, string file_name)
        {
            StreamWriter sw = new StreamWriter(file_name);
            foreach (ListViewItem item in list.Items)
            {
                for (int i = 0; i < item.SubItems.Count; i++)
                {
                    sw.Write(item.SubItems[i].Text);
                    if (i != item.SubItems.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.WriteLine();
            }
            sw.Close();
        }

        public void read_file_product(ComboBox combo, string file_name, string pname, ComboBox versionc = null)
        {
            string sraw;
            if (File.Exists(file_name))
            {
                StreamReader sr = new StreamReader(file_name);
                while ((sraw = sr.ReadLine()) != null)
                {
                    string product = sraw == null ? "Продукт пустой или не найден" : sraw.Split(',')[0];
                    string version = pname == null ? "Версия неизвестна" : new add_product().listView1.FindItemWithText(add_user_product.instance.comboBox1.Text == null ? "" : add_user_product.instance.comboBox1.Text).SubItems[1].Text;
                    if (!combo.Items.Cast<string>().Contains(product))
                    {
                        combo.Items.Add(product);
                    }
                    object[] items = versionc.Items.OfType<String>().Distinct().ToArray();
                    versionc.Items.Clear();
                    versionc.Items.Add(version);
                }
                sr.Close();
            }
        }
    }
}
