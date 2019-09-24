using System;
using System.Windows.Forms;

namespace WinFormsMVP
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var repository = new Model.CustomerXmlRepository(Application.StartupPath);
            var view = new View.CustomerForm();

            // Poor Man's Dependency Injection/Pure Dependency Injection, Main() is the Composition Root.
            // See https://github.com/mrts/winforms-mvp/issues/2.
            var presenter = new Presenter.CustomerPresenter(view, repository);

            Application.Run(view);
        }
    }
}
