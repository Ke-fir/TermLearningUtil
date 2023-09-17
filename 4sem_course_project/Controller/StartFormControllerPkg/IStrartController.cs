using System.Data;

namespace _4sem_course_project.Controller.StartFormControllerPkg
{
    /// <summary>
    /// Contract of StartController behaviour.
    /// </summary>
    interface IStrartController
    {
        /// <summary>
        /// Adds module to module list and refreshes forms' table.
        /// </summary>
        /// <returns>
        /// True if everithing done.
        /// </returns>
        bool AddModule();

        /// <summary>
        /// Removes module from tables and module list.
        /// </summary>
        /// <returns>True if everithing done.</returns>
        bool RemoveModule();

        /// <summary>
        /// Edits module info in tables and module list.
        /// </summary>
        /// <returns>True if everithing done.</returns>
        bool EditModule();

        /// <summary>
        /// Updates properties in StartForm and calling UpdateGraphics().
        /// </summary>
        /// <returns>True if everithing done.</returns>
        bool UpdateFormInfo();

        /// <summary>
        /// Builds table from module list.
        /// </summary>
        /// <param name="modules"></param>
        /// <returns>Built table.</returns>
        DataTable BuildTable(ModuleList modules);

        /// <summary>
        /// Calls ModuleForm due to chosen module in table.
        /// </summary>
        /// <returns>True if everithing done.</returns>
        bool OpenChosenModule();

        /// <summary>
        /// Saves module list to xml due to file path.
        /// </summary>
        /// <returns>Writen module list.</returns>
        ModuleList SaveDataToXmlFile();

        /// <summary>
        /// Calls dialog form that asks user if the data sould be saved.
        /// </summary>
        /// <returns>True if everithing done.</returns>
        bool CheckAndClose();

        /// <summary>
        /// 
        /// </summary>
        ModuleList GetModuleList { get; }

        /// <summary>
        /// Returns StartForm object.
        /// </summary>
        StartForm GetForm { get; }
    }
}
