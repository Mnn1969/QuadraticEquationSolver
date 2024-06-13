using QuadraticEquationSolver.ViewModels.Base;

namespace QuadraticEquationSolver.ViewModels
{
    internal class ChildWindowViewModel : ViewModel
    {
        private readonly MainWindowViewModel _BaseModel = null!;

        #region StringValue : string - Строковое значение

        /// <summary>Строковое значение</summary>
        private string? _StringValue;

        /// <summary>Строковое значение</summary>
        public string StringValue
        {
            get => _StringValue!;
            set => SetValue(ref _StringValue, value)
                .UpdateProperty(nameof(StringValueLength))
                .Then(v => _BaseModel.StringValue = v);
        }

        #endregion

        public int StringValueLength => _StringValue?.Length ?? -1;

        public string? BaseModelValue
        {
            get;
            set;
        }

        public void UpdateBaseModelValue(string? value)
        {
            if (Equals(value, BaseModelValue)) return;
            BaseModelValue = value;
            OnPropertyChanged(nameof(BaseModelValue));
        }

        public ChildWindowViewModel() { }

        public ChildWindowViewModel(MainWindowViewModel BaseModel) => _BaseModel = BaseModel;
       
    }
}
