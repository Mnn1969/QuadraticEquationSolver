﻿using System.Configuration;
using System.Data;
using System.Windows;

namespace QuadraticEquationSolver
{    
    public partial class App
    {
        public static Window? ActiveWindow => Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive);

        public static Window? FocusedWindow => Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsFocused);

        public static Window? CerrentWindow => FocusedWindow ?? ActiveWindow;
    }

}
