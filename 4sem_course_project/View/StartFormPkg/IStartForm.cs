using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _4sem_course_project.Controller.StartFormControllerPkg.Impl;

namespace _4sem_course_project.View.StartFormPkg
{
    public interface IStartForm
    {
        StartFormConroller SetController(StartFormConroller controller);
        bool UpdateGraphics();
        DataTable ModulesTable { get; set; }
    }
}
