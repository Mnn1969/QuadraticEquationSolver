using QuadraticEquationSolver.Infrastructure.Commands.Base;
using System.Windows;

namespace QuadraticEquationSolver.Infrastructure.Commands
{
    class CloseWindowCommand : Command
    {
        protected override bool CanExecute(object? parameter) => parameter is Window || App.ActiveWindow != null;
        
        protected override void Execute(object? parameter) => (parameter as Window ?? App.ActiveWindow)?.Close();
        
    }
}
