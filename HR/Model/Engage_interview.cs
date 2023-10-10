using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Engage_interview
    {
        public int ein_id { get; set; }
        public string human_name { get; set; }
        public string interview_amount { get; set; }
        public string human_major_kind_id { get; set; }
        public string human_major_kind_name { get; set; }
        public string human_major_id { get; set; }
        public string human_major_name { get; set; }
        public string image_degree { get; set; }
        public string native_language_degree { get; set; }
        public string foreign_language_degree { get; set; }
        public string response_speed_degree { get; set; }
        public string EQ_degree { get; set; }
        public string IQ_degree { get; set; }
        public string multi_quality_degree { get; set; }
        public string register { get; set; }
        public string checker { get; set; }
        public DateTime registe_time { get; set; }
        public DateTime check_time { get; set; }
        public string resume_id { get; set; }
        public string result { get; set; }
        public string interview_comment { get; set; }
        public string check_comment { get; set; }
        public string interview_status { get; set; }
        public string check_status { get; set; }
    }
}
