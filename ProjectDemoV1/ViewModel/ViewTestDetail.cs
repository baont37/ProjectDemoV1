using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectDemoV1.ViewModel
{
    public class ViewTestDetail
    {
        public int TestDetailId { get; set; }
        public DateTime CreateDate { get; set; }

        public int AccountId { get; set; }
        //[ForeignKey("AccountId")]


        public int SubjectId { get; set; }
        //[ForeignKey("SubjectId")]


    }
}