using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TdeA.Automata
{
    public class MainViewModel
    { 
        private List<Country> _Values;

        public List<Country> Values
        {
            get { return _Values; }
            set { _Values = value; }
        }
        public MainViewModel()
        {
            this.Values = new List<Country>();
            this.Values.Add(new Country { Name = "America" });
            this.Values.Add(new Country { Name = "Africa" });
            this.Values.Add(new Country { Name = "India" });
        }
    }
    public class Country
    {
        public string Name { get; set; }
    }
}
