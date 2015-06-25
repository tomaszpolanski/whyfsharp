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

        #region V2
        public static Option<CustomerId> CreateV2(string id)
        {
            return Option<string>.OfObject(id)
                                 .Where(str => str.Length == 22)
                                 .Select(str => new CustomerId(str));
        }
        #endregion


        public override string ToString()
        {
            return _id;
        }

    }
}
