namespace WhyFSharp.CSharp
{
    class TwoDPointC
    {
        public readonly int X, Y;

        public TwoDPointC(int x, int y)  
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            TwoDPointC p = obj as TwoDPointC;
            if (p == null)
            {
                return false;
            }

            return (X == p.X) && (Y == p.Y);
        }

        public bool Equals(TwoDPointC p)
        {
            if (p == null)
            {
                return false;
            }

            return (X == p.X) && (Y == p.Y);
        }

        public override int GetHashCode()
        {
            return X ^ Y;
        }

        public static bool operator ==(TwoDPointC a, TwoDPointC b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }
            return a.X == b.X && a.Y == b.Y;
        }

        public static bool operator !=(TwoDPointC a, TwoDPointC b)
        {
            return !(a == b);
        }
    }
}
