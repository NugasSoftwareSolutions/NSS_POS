using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlreySolutions.Class
{
    public class clsAccountStatement
    {
        public string TransDate { get; set; }
        public string Description { get; set; }
        public double Debit { get; set; }
        public double Credit { get; set; }
        public double Balance { get; set; }
        public Receipt ORInfo {get;set;}
        public override string ToString()
        {
            return string.Format("\t{0}\t{1}\t{2}\t{3}\t{4}",TransDate,Description,Debit,Credit,Balance);
        }

    }

}
