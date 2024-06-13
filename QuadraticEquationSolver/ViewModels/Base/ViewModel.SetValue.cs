using System.Runtime.CompilerServices;

namespace QuadraticEquationSolver.ViewModels.Base
{
    partial class ViewModel
    {
        public readonly struct SetValueResult<T>
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

            public SetValueResult<T> Then(Action<T> action)
            {
                if (_Result)
                    action(_NewValue);
                return this;
            }

            public SetValueResult<T> UpdateProperty(string PropertyName)
            {
                if (_Result)
                    _Model.OnPropertyChanged(PropertyName);
                return this;
            }

            public SetValueResult<T> ThenIf(Func<T, bool> ValueChecker, Action<T> action)
            {
                if (_Result && ValueChecker(_NewValue))
                    action(_NewValue);
                return this;
            }

            public SetValueResult<T> ThenIf(Func<T, T, bool> ValueChecker, Action<T> action)
            {
                if (_Result && ValueChecker(_OldValue, _NewValue))
                    action(_NewValue);
                return this;
            }

        }

        protected SetValueResult<T> SetValue<T>(ref T field, T value, [CallerMemberName] string PropertyName = null!)
        {
            if (Equals(field, value))
                return new(false, field, value, Model: this);

            var old_value = field;
            field = value;
            OnPropertyChanged(PropertyName);

            return new(true, old_value, value, this);
        }

    }
    
}
