using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using _4sem_course_project.View;
using _4sem_course_project.Controller.StartFormControllerPkg.Impl;

namespace _4sem_course_project
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var filePath = "Modules.xml"; // файл лежит в
                                          // ...\team-1006\4sem_course_project\4sem_course_project\bin\Debug\net5.0-windows

            var controller = new StartFormConroller(filePath, new StartForm());
            Application.Run(controller.GetForm);
        }
    }
}
