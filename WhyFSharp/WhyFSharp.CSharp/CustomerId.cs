using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhyFSharp.CSharp
{
    public class CustomerId
    {
        private readonly string _id;

        private CustomerId(string id)
        {
            _id = id;
        }

        public static Option<CustomerId> Create(string id)
        {
            return !string.IsNullOrEmpty(id) && id.Length == 22
                    ? (Option<CustomerId>) new Some<CustomerId>(new CustomerId(id))
                    : new None<CustomerId>();
        }


        public override string ToString()
        {
            return _id;
        }

    }
}
