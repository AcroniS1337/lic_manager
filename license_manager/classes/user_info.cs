using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace license_manager.classes
{
   public class user_info
    {
        public string login { get; set; }
        public string password { get; set; }
        public string name_pc { get; set; }


        public void save_data()
        {
            RegistryKey currentUserKey = Registry.CurrentUser;
            RegistryKey helloKey = currentUserKey.CreateSubKey("Lic_manager");
            helloKey.SetValue("login", this.login);
            helloKey.SetValue("password", this.password);
            helloKey.SetValue("pc_name", this.name_pc);
            helloKey.Close();
        }

        public void load_data()
        {
            RegistryKey currentUserKey = Registry.CurrentUser;
            RegistryKey helloKey = currentUserKey.OpenSubKey("Lic_manager");

            if (helloKey == null)
                return;

            string login = helloKey.GetValue("login").ToString();
            string password = helloKey.GetValue("password").ToString();

            if (login == "" || password == "")
                return;

            helloKey.Close();

            this.login = login;
            this.password = password;

        }
    }

}
