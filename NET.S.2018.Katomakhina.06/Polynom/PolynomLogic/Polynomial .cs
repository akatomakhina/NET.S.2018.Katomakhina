
namespace PolynomLogic
{
    using System;
    using System.Text;
    using System.Globalization;
    using System.Configuration;

    public class Polynomial : IEquatable<Polynomial>, ICloneable
    {
        private static double epsilon;
        private readonly double[] coefficients;

        #region Constructors

        static Polynomial()
        {
            epsilon = double.Parse(ConfigurationManager.AppSettings["epsilon"], CultureInfo.InvariantCulture);
        }

        public Polynomial(params double[] array)
        {
            if (array == null || array.Length == 0)
            {
                throw new ArgumentNullException(nameof(array));
            }

        }

        #endregion

        #region Indexer

        public double this[int i]
        {
            get
            {
                if (i < 0 || i > Degree)
                {
                    throw new ArgumentOutOfRangeException(nameof(i));
                }

                return coefficients[i];
            }
        }

        #endregion

        #region Properties

        public bool IsReadOnly
        {
            get { return true; }
        }

        public int Degree
        {
            get { return coefficients.Length - 1; }
        }

        private static double Epsilon {
            get {
                 return epsilon;
            }
        }

    #endregion

        #region OverrideMethods

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            for (int i = Degree; i >= 0; i--)
            {
                if (Math.Abs(this[i] - 0.0) < Epsilon) continue;
                builder.Append(i != 0 ? $"{this[i]}x^{i}+" : $"{this[i]}x^{i}");
            }

            return builder.ToString();
        }

        public override int GetHashCode()
        {
            return coefficients.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Polynomial)) return false;
            return Equals((Polynomial)obj);
        }

        #endregion

        #region Operators
        public static bool operator == (Polynomial lhs, Polynomial rhs)
        {
            if (ReferenceEquals(lhs, rhs))
            {
                return true;
            }

            if (ReferenceEquals(lhs, null))
            {
                return false;
            }

            return lhs.Equals(rhs);
        }

        public static bool operator != (Polynomial lhs, Polynomial rhs) => !(lhs == rhs);

        #endregion

        #region BasicOperations

        #endregion

        #region InterfaceMethods

        public bool Equals(Polynomial other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (Degree != other.Degree) return false;

            for (int i = 0; i < Degree; i++)
            {
                if (!(Math.Abs(this[i] - other[i]) < Epsilon)) return false;
            }

            return true;
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        #endregion

        public Polynomial Clone()
        {
            return new Polynomial(coefficients);
        }
    }
}
