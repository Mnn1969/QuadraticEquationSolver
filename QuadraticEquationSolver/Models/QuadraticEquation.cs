namespace QuadraticEquationSolver.Models
{
    /// <summary>Квадратное уравнение y(x) = a*x^2 + b*x + c</summary>
    /// <remarks>Корни уравнения y(x) = (x - x1) * (x - x2)</remarks>

    class QuadraticEquation
    {
        public double A {  get; set; }
        public double B { get; set; }
        public double C { get; set; }

        /// <summary>Дискриминант</summary>
        public double D => B * B - 4 * A * C;

        public int RootCount => D switch
        {
            > 0 => 2,
            0 => 1,
            _ => 0
        };

        public double X1 => RootCount == 0 ? double.NaN : (-B + Math.Sqrt(D)) / (2 * A);

        public double X2 => RootCount == 0 ? double.NaN : (-B - Math.Sqrt(D)) / (2 * A);


    }
}
