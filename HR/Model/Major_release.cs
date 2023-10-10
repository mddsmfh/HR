using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Major_release
    {
        public int mre_id { get; set; }
        public int first_kind_id { get; set; }
        public string first_kind_name { get; set; }
        public int second_kind_id { get; set; }
        public string second_kind_name { get; set; }
        public int third_kind_id { get; set; }
        public string third_kind_name { get; set; }
        public int major_kind_id { get; set; }
        public string major_kind_name { get; set; }
        public int major_id { get; set; }
        public string major_name { get; set; }
        public int human_amount { get; set; }
        public string engage_type { get; set; }
        public DateTime deadline { get; set; }
        public string register { get; set; }
        public string changer { get; set; }
        public DateTime regist_time { get; set; }
        public DateTime change_time { get; set; }
        public string major_describe { get; set; }
        public string engage_required { get; set; }
    }
}
