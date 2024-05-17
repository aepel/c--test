using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qualyt.Domain.Models.Mails
{
    public class Tag
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public Tag(string Key, string Value)
        {
            this.Key = Key;
            this.Value = Value;
        }

        public override bool Equals(object otherTag)
        {
            if (otherTag == null)
                return false;

            Tag t = otherTag as Tag;
            if ((System.Object)t == null)
                return false;


            if (this.Key == t.Key)
                return true;

            return false;
        }

        public string ReemplazarTag(string Texto)
        {
            return Texto.Replace(Key, Value);
        }
    }
}
