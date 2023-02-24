using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProstyBank
{
    class Loan
    {
        private decimal kredens;
        public decimal Kredens
        {
            get { return kredens; }
            set { kredens = value; }
        }
        public Loan(decimal loan)
        {
            this.Kredens = loan;
        }

    }
}