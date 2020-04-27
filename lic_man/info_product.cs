using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lic_man
{
    [Serializable]
    public class info_product
    {

        public string name_product { get; set; }
        public int id { get; set; }

        public bool status = false;
        public int count_lic { get; set; }
        public int buy_key_count { get; set; }
    }
}
