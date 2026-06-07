using QuizSolver.Views;
using QuizSolver.Presenters;

namespace QuizSolver
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            FileReaderView view = new FileReaderView();
            FileReaderPresenter presenter = new FileReaderPresenter(view);

            Application.Run(view);
        }
    }
}