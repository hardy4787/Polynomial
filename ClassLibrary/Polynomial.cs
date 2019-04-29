using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynom
{
    public class Polynomial
    {
        private readonly int _degree;
        private readonly double[] _matrix;
        public Polynomial(double[] matrix)
        {
            this._matrix = matrix;
            _degree = matrix.Length;
        }
        public Polynomial(int degree)
        {
            if (degree < 0)
                throw new PolynomialException("The degree of the polynomial can not be negative");
            this._degree = degree;
            _matrix = new double[this._degree];
        }
        
        public void ChangeCoefficients(int Degree, int ValueCoef)
        {
            this[Degree] = ValueCoef; 
        }

        private delegate double PlusOrMinusDel(double LeftCoeff, double RightCoeff);
        private static Polynomial PlusOrMinusCoefficients(Polynomial a, Polynomial b, PlusOrMinusDel Opperations)
        {
            if ((object)a == null || (object)b == null)
                throw new ArgumentNullException("The object is null. Initialize the polynomial");
            double[] newMatrix = new double[Math.Max(a._degree, b._degree)];
            Array.Copy(GetWiderPolynomial(a, b)._matrix, newMatrix, GetWiderPolynomial(a, b)._matrix.Length);
            Polynomial newPolynomial = new Polynomial(newMatrix);
            for (int i = 0; i < Math.Min(a._degree, b._degree); i++)
                newPolynomial[i] = Opperations(a[i], b[i]);
            return newPolynomial;
        }

        public static Polynomial operator -(Polynomial left, Polynomial right)
        {
            return PlusOrMinusCoefficients(left, right, (x, y) => x - y);
        }
        public static Polynomial operator +(Polynomial left, Polynomial right)
        {
            return PlusOrMinusCoefficients(left, right, (x, y) => x + y);
        }
        public static Polynomial GetWiderPolynomial(Polynomial a, Polynomial b)
        {
            return a._degree > b._degree ? a : b;
        }
        
        public static Polynomial operator *(Polynomial a, Polynomial b)
        {
            if ((object)a == null || (object)b == null)
                throw new ArgumentNullException("The object is null. Initialize the polynomial");
            double[] newMatrix = new double[a._degree + b._degree];
            Polynomial c = new Polynomial(newMatrix);
            for (int i = 0; i < a._degree; i++)
                for (int j = 0; j < a._degree; j++)
                    c[i+j] += a[i] * b[j];
            return c;
        }

        public override string ToString()
        {
            string OutValue = "";
            for (int i = 0; i < this._degree; i++)
                if (this[i] != 0)
                {
                    if (i == 0)
                    {
                        OutValue += this[i].ToString();
                    }
                    else
                    {
                        if (this[i] == 1)
                            OutValue += "+" + "x";
                        else if (this[i] == -1)
                            OutValue += "-x";
                        else if (this[i] > 0)
                            OutValue += "+" + this[i].ToString() + "x";
                        else
                            OutValue += this[i].ToString() + "x";
                        if (i != 1) OutValue += "^" + i;
                    }
                }
            return OutValue;
        }

        public double this[int elementDegree]
        {
            get {
                if (elementDegree < 0 || elementDegree > this._degree)
                    throw new PolynomialException("Out of range polynomial");
                return _matrix[elementDegree]; }
            set { _matrix[elementDegree] = value; }
        }
    }
}
