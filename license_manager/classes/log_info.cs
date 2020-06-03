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
   public class log_info
    {

        public void read_file_log(ListView list, string file_name)
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
                    string splite3 = sraw.Split(',')[2];
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.SubItems[0].Text = splite;
                    listViewItem.SubItems.Add(splite2);
                    listViewItem.SubItems.Add(splite3);
                    list.Items.Add(listViewItem);
                }
                sr.Close();
            }
        }

        public void log_product(string name_product,DateTime time,string action)
        {
            log_show log_open = new log_show();

            ListViewItem listViewItem = new ListViewItem();

            listViewItem.SubItems[0].Text = Program.login_data.login;
            listViewItem.SubItems.Add($"{action} продукт {name_product}");
            listViewItem.SubItems.Add($"В {time}");
            log_show.add_log_delete(listViewItem);
            Program.general.save_file(log_show.instance.listView1, "log_users.ini");
        }
        public void log_user_product(string name_user,string name_product, DateTime time,string action)
        {
            log_show log_open = new log_show();

            ListViewItem listViewItem = new ListViewItem();

            listViewItem.SubItems[0].Text = Program.login_data.login;
            listViewItem.SubItems.Add($"{action} пользователя {name_user} продукта {name_product}");
            listViewItem.SubItems.Add($"В {time}");
            log_show.add_log_delete(listViewItem);
            Program.general.save_file(log_show.instance.listView1, "log_users.ini");
        }
        public void log_registration(string name_user, DateTime time,string action)
        {
            log_show log_open = new log_show();

            ListViewItem listViewItem = new ListViewItem();

            listViewItem.SubItems[0].Text = Program.login_data.login;
            listViewItem.SubItems.Add($"{action} пользователь с ником {name_user}");
            listViewItem.SubItems.Add($"В {time}");
            log_show.add_log_delete(listViewItem);
            Program.general.save_file(log_show.instance.listView1, "log_users.ini");
        }
    }
}
