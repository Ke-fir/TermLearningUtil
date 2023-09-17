using _4sem_course_project.Controller;
using _4sem_course_project.Controller.ModePkg;

namespace _4sem_course_project.View.ModuleFormPkg
{
    /// <summary>
    /// Interface that contracts behavior of ModuleForms.
    /// </summary>
    public interface IModuleForm
    {
        /// <summary>
        /// Sets the controller for MVC realization.
        /// </summary>
        /// <param name="controller"></param>
        /// <returns> Controller object if done. </returns>
        ModuleFormController SetController(ModuleFormController controller);

        string ModuleName { get; set; }
        int CurrentCardNumber { get; set; }
        int TotalCardsNumber { get; set; }
        string CardText { get; set; }
        bool IsCardFlipped { get; }
        bool IsCardEditing { get; }
        IMode Mode { get; set; }
    }
}
