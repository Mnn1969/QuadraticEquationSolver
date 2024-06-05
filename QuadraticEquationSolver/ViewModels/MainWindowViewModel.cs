using QuadraticEquationSolver.ViewModels.Base;

namespace QuadraticEquationSolver.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        #region Title : string - Заголовок окна

        /// <summary>Заголовок окна</summary>
        private string _Title = "Поиск корней квадратного уравнения";

        /// <summary>Заголовок окна</summary>
        public string Title
        {
            get => _Title;
            set
            {
                if (Set(ref _Title, value))
                    OnPropertyChanged(nameof(TitleLength));
            }
        }

        public int TitleLength => Title.Length;

        #endregion
    }
}
