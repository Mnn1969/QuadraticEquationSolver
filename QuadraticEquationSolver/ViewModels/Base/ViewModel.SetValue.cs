using System.Runtime.CompilerServices;

namespace QuadraticEquationSolver.ViewModels.Base
{
    partial class ViewModel
    {
        private SetValueResult<T> SetValue<T>(ref T field, T value, [CallerMemberName] string PropertyName = null!)
        {
            if (Equals(field, value))
                return new(false, field, value, this);

            var old_value = field;
            field = value;
            OnPropertyChanged(PropertyName!);

            return new (true, old_value, value, this);
        }
    }

    internal class SetValueResult<T>
    {
        private readonly bool _Result;
        private readonly T _OldValue;
        private readonly T _NewValue;
        private readonly ViewModel _Model;

        public SetValueResult(bool Result, in T OldValue, in T NewValue, ViewModel Model)
        {
            _Result = Result;
            _OldValue = OldValue;
            _NewValue = NewValue;
            _Model = Model;
        }
        
    }
}
