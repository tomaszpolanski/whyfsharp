using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhyFSharp.CSharp
{
    public abstract class Option<T>
    {
        public abstract bool HasValue { get; }
        public abstract T Get();
    }

    public class Some<T> : Option<T>
    {
        private readonly T _value;

        public Some(T value)
        {
            _value = value;
        }

        public override T Get()
        {
            return _value;
        }

        public override bool HasValue
        {
            get { return true; }
        }
    }

    public class None<T> : Option<T>
    {
        public override T Get()
        {
            throw new NotImplementedException();
        }

        public override bool HasValue
        {
            get { return false; }
        }
    }
}
