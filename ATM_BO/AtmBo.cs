using System;
using System.Collections.Generic;
using System.Text;


namespace ATM_BO
{
    public class AtmBoCust
    {
        public int cid { get; set; }
        public string Name { get; set; }    //login name
        public int Pin { get; set; }
        public int Cash { get; set; }
        public string type { get; set; }
        public string status { get; set; }  //status of account

    }

    public class AtmBoAd
    {
        public int id { get; set; }
        public string AdminName { get; set; }
        public int Pin { get; set; }
    }


}
