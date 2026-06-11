using QuizSolver_M.Views;
using System;
using System.Windows.Forms;

namespace QuizSolver_M
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware); 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SolverView());
        }
    }
};