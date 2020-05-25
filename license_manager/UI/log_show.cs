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
    public partial class log_show : MaterialForm
    {
        public static log_show instance;
        public log_show()
        {
            InitializeComponent();


            var material_skin = MaterialSkinManager.Instance;
            material_skin.AddFormToManage(this);
            material_skin.Theme = MaterialSkinManager.Themes.DARK;

            instance = this;

            Program.log_info.read_file_log(listView1, "log_users.ini");
        }

        public static void add_log_delete(ListViewItem log)
        {
            log_show.instance.listView1.Items.Add(log);
        }
    }
}
