using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler
{
    class Class1 : Interface1
    {
        private double _myProperty;

        public double MyProperty {
            get { return _myProperty * 1.23; }
            set { _myProperty = value; }

        }
        public int Zmienna { get; set; }

        public void Metoda()
        {
            try { }
            catch
            {
                throw;
            }
        }
    }
}
