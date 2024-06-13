using QuadraticEquationSolver.Infrastructure.Attributes;
using QuadraticEquationSolver.Models;
using QuadraticEquationSolver.ViewModels.Base;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using QuadraticEquationSolver.Infrastructure.Commands;
using QuadraticEquationSolver.View.Windows;

namespace QuadraticEquationSolver.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private readonly QuadraticEquation _QuadraticEquation = new();
        #region Title : string - Заголовок окна

        /// <summary>Заголовок окна</summary>
        private string? _Title = "Поиск корней квадратного уравнения";

        /// <summary>Заголовок окна</summary>
        public string? Title
        {
            get => _Title;

            set => SetValue(ref _Title, value)
                //.Then(v => OnPropertyChanged(nameof(TitleLength)))
                .UpdateProperty(nameof(TitleLength))
                .Then(v => Debug.WriteLine("Установлен заголовок окна {0}", v))
                .ThenIf(v => !string.IsNullOrEmpty(v), 
                    v => Debug.WriteLine("Не пустое значение заголовка окна"))
            ;
        }

        [DependencyOn(nameof(Title))]
        public int TitleLength => Title!.Length;

        #endregion

        public string? UserName {  get => Get<string>(); set => Set(value); }

        private double _A;
        public double A
        {
            get => _A;
            //set
            //{
            //    if (!Set(ref _A, value, "Значение должно быть больше, либо равно нулю", a => a >= 0)) return;
            //    _QuadraticEquation.A = value;
            //    OnPropertyChanged(nameof(X1));
            //    OnPropertyChanged(nameof(X2));
            //}

            set => SetValue(ref _A, value)
                .ThenIf(
                    (old_value, new_value) => Math.Abs(old_value - new_value) > 0.001,
                    v =>
                    {
                        OnPropertyChanged(nameof(X1));
                        OnPropertyChanged(nameof(X2));
                    });
        }

        public double B 
        {
            get => _QuadraticEquation.B;
            set
            {
                if (Equals(_QuadraticEquation.B, value)) return;
                _QuadraticEquation.B = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(X1));
                OnPropertyChanged(nameof(X2));
            }
        }

        public double C
        {
            get => _QuadraticEquation.C;
            set
            {
                if (!Set(value, _QuadraticEquation.C, v => _QuadraticEquation.C = v)) return;

                OnPropertyChanged(nameof(X1));
                OnPropertyChanged(nameof(X2));
            }
        }

        public double X1 => _QuadraticEquation.X1;

        public double X2 => _QuadraticEquation.X2;

        private string? _StrValue;

        //private SetValueResult<string> _Value;

        public string? StrValue
        {
            get => _StrValue!;

            set
            {
                var set_result = SetValue(ref _Title, value);
                set_result.UpdateProperty(nameof(Title));
                
            }
        }

        private ChildWindow? _ChildWindow;
        protected ChildWindowViewModel? _ChildWindowViewModel;

        #region Command ShowChildWindowCommand - Показать дочернее окно

        /// <summaryПоказать дочернее окно</summary>
        private ICommand? _ShowChildWindowCommand;

        /// <summary>Показать дочернее окно</summary>
        public ICommand ShowChildWindowCommand => _ShowChildWindowCommand
            ??= new LambdaCommand(OnShowChildWindowCommandExecuted!, CanShowChildWindowCommandExecute!);

        /// <summary>Проверка возможности выполнения - Показать дочернее окно</summary>
        private bool CanShowChildWindowCommandExecute(object p) => _ChildWindowViewModel is null;

        /// <summary>Логика выполнения - Показать дочернее окно</summary>
        private void OnShowChildWindowCommandExecuted(object p)
        {
            var child_window_view_model = new ChildWindowViewModel(this);

            var child_window = new ChildWindow
            {
                DataContext = child_window_view_model,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Owner = Application.Current.MainWindow
            };

            child_window.Closed += (_, _) =>
            {
                _ChildWindowViewModel = null;
                _ChildWindow = null;
            };

            _ChildWindow = child_window;
            _ChildWindowViewModel = child_window_view_model;

            child_window.Show();
        }

        #endregion

        #region StringValue : string - Строковое значение

        /// <summary>Строковое значение</summary>
        private string? _StringValue;

        /// <summary>Строковое значение</summary>
        public string? StringValue
        {
            get => _StringValue;
            set => SetValue(ref _StringValue, value)
                .Then(v => _ChildWindowViewModel?.UpdateBaseModelValue(v));
        }

        #endregion
    }
}
