using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduler.BusinessLayer
{
    public class ValuePair
    {
        private string _name;
        private string _value;

        public ValuePair() { }

        public ValuePair(string strName, string strValue)
        {
            _name = strName;
            _value = strValue;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value.ToString(); }
        }

        public string Value
        {
            get { return _value; }
            set { _value = value.ToString(); }
        }
    }
}
