using System;
using System.Collections.Generic;
using System.Text;

namespace ShopMenager.Helpers
{
    public class KeyValueItem
    {
        public int Key { get; set; }
        public string Value { get; set; }
        public override string ToString() => Value;
    }
}
