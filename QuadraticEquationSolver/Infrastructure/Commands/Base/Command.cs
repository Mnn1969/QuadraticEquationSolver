﻿using System.Windows.Input;

namespace QuadraticEquationSolver.Infrastructure.Commands.Base
{
    abstract class Command : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested += value;
        }

        bool ICommand.CanExecute(object? parameter) => CanExecute(parameter);        

        void ICommand.Execute(object? parameter)
        {
            if (CanExecute(parameter)) 
                Execute(parameter);
        }

        protected virtual bool CanExecute(object? parameter) => true;

        protected abstract void Execute(object? parameter);
    }
}
