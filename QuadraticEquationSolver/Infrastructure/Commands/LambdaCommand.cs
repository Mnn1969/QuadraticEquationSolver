using QuadraticEquationSolver.Infrastructure.Commands.Base;

namespace QuadraticEquationSolver.Infrastructure.Commands
{
    class LambdaCommand : Command
    {
        private readonly Action<object?>? _OnExecute;
        private readonly Func<object?, bool>? _CanExecute;

        public LambdaCommand(Action<object?>? OnExecute, Func<object?, bool>? CanExecute = null)
        {
            _OnExecute = OnExecute;
            _CanExecute = CanExecute;
        }

        protected override bool CanExecute(object? parameter) => _CanExecute?.Invoke(parameter) ?? true;
        
        protected override void Execute(object? parameter) => _OnExecute!(parameter);
       
    }
}
