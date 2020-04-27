using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace lic_man
{
    public class general : info_product
    {


        public string name_pc_set = System.Net.Dns.GetHostName();

        public void save_product(string file)
        {

            info_product name = new info_product() { };
            File.AppendAllText(file, JsonConvert.SerializeObject(name));

        }


        public void load_product(string file)
        {
            using (FileStream fstream = File.OpenRead(file))
            {
 
                byte[] array = new byte[fstream.Length];
               
                fstream.Read(array, 0, array.Length);
           
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                MessageBox.Show(textFromFile);

                info_product account = JsonConvert.DeserializeObject<info_product>(textFromFile);

                MessageBox.Show(account.count_lic.ToString());
            }


        }
    }
  
}
