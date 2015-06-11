using System;

namespace WhyFSharp.CSharp
{
    public abstract class Option<T>
    {
        public abstract bool HasValue { get; }
        public abstract T Get();

        #region V2
        public abstract Option<OUT> Select<OUT>(Func<T, OUT> selector);
        public abstract Option<T> Where(Func<T, bool> predicate);

        public static Option<T> OfObject(T obj)
        {
            return obj != null ? (Option<T>) new Some<T>(obj) : new None<T>();
        }
        #endregion
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

        #region V2

        public override Option<OUT> Select<OUT>(Func<T, OUT> selector)
        {
            return new Some<OUT>(selector.Invoke(_value));
        }

        public override Option<T> Where(Func<T, bool> predicate)
        {
            return predicate.Invoke(_value) ? this : (Option<T>)new None<T>();
        }

        #endregion
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

        #region V2
        public override Option<OUT> Select<OUT>(Func<T, OUT> selector)
        {
            return new None<OUT>();
        }

        public override Option<T> Where(Func<T, bool> predicate)
        {
            return this;
        }
        #endregion
    }
}
