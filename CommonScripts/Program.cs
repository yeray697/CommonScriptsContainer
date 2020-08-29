using CommonScripts.Presenter;
using CommonScripts.Repository;
using CommonScripts.Repository.Interfaces;
using CommonScripts.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommonScripts
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form mainForm = Injection();
            Application.Run(mainForm);
        }

        private static Form Injection()
        {
            //Poor Man's DI
            return InjectMainForm();
        }

        private static Form InjectMainForm()
        {
            ISettingsRepository repository = new SettingsRepository();
            MainForm view = new MainForm();

            var presenter = new MainPresenter(view, repository);

            return view;
        }
    }
}
