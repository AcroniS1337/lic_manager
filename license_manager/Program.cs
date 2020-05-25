using license_manager.classes;
using license_manager.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace license_manager
{
    static class Program
    {


        public static user_info login_data;
        public static general general;
        public static info_product product_info;
        public static log_info log_info;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            login_data = new user_info();
            general = new general();
            product_info = new info_product();
            log_info = new log_info();
            Application.Run(new autorization());
        }
    }
}
