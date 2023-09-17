using System.Windows.Forms;
using _4sem_course_project.View;

namespace _4sem_course_project.Controller.ModuleFormControllerPkg
{
    /// <summary>
    /// Conract of ModuleController behaviour.
    /// </summary>
    public interface IModuleController
    {
        /// <summary>
        /// Updates properties in form and calls graphic updating method.
        /// </summary>
        /// <returns>True if everithing done.</returns>
        bool UpdateFormInfo();

        /// <summary>
        /// Loads and draws next card from module if possible. 
        /// </summary>
        /// <returns>Loaded card.</returns>
        Card NextCard();

        /// <summary>
        /// Loads and draws previous card from module if possible. 
        /// </summary>
        /// <returns>Loaded card.</returns>
        Card PrevCard();

        bool DisableButton(Button button);
        bool EnableButton(Button button);
        int CheckCounter();
        bool FlipCard();
        ModuleForm ShowForm();
        Module GetModule { get; }
        ModuleForm GetForm { get; }
    }
}
