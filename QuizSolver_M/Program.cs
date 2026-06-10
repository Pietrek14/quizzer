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
            
            Application.Run(new SolverView());
        }
    }
};