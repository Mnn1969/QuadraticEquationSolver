namespace QuadraticEquationSolver.Models
{
    /// <summary>Квадратное уравнение y(x) = a*x^2 + b*x + c</summary>
    /// <remarks>Корни уравнения y(x) = (x - x1) * (x - x2)</remarks>

    class QuadraticEquation
    {
        public double A {  get; set; }
        public double B { get; set; }
        public double C { get; set; }
    }
}
