using System.Data;
using _4sem_course_project.View.AdditionalFormPkg;

namespace _4sem_course_project.Controller.StartFormControllerPkg.Impl
{
    public class StartFormConroller : IStrartController
    {
        private readonly string _filePath; 

        private ModuleList _moduleList = new ModuleList();
        public ModuleList GetModuleList => _moduleList;


        private StartForm _form;
        public StartForm GetForm => _form;

        public StartFormConroller(string fileWithSerializedModulesPath, StartForm form)
        {
            _filePath = fileWithSerializedModulesPath;
            _form = form;
            _moduleList = GetModules();
            _form.SetController(this) ;
            UpdateFormInfo();
            //_form.ModulesTable = BuildTable(_moduleList);
        }

        private ModuleList GetModules()
        {
            var moduleList = new XmlModuleSerializer().DeserializeFromFile(_filePath);
            return moduleList;
        }

        public bool AddModule()
        {
            string name = _form.ModulesTable.Rows[_form.RowPointer].ItemArray[0].ToString();
            string description = _form.ModulesTable.Rows[_form.RowPointer].ItemArray[1].ToString();

            _moduleList.Modules.Add(new Module(name, description));

            UpdateFormInfo();
            return true;
        }

        public DataTable BuildTable(ModuleList modules)
        {
            var table = new DataTable();
            table.Columns.AddRange(
                new DataColumn[]
                {
                    new DataColumn("Name", typeof(string)),
                    new DataColumn("Description", typeof(string))
                });
            foreach (var module in modules.Modules)
            {
                table.Rows.Add(module.Name, module.Description);
            }
            return table;
        }

        public bool EditModule()
        {
            var editingModule = _moduleList.Modules[_form.RowPointer];

            string name = _form.ModulesTable.Rows[_form.RowPointer].ItemArray[0].ToString(); 
            string description = _form.ModulesTable.Rows[_form.RowPointer].ItemArray[1].ToString();

            editingModule.Name = name;
            editingModule.Description = description;

            UpdateFormInfo();
            return true;
        }


        public bool RemoveModule()
        {
            _moduleList.Modules.RemoveAt(_form.RowPointer);
            UpdateFormInfo();
            return true;
        }

        public bool UpdateFormInfo()
        {
            _form.ModulesTable = BuildTable(_moduleList);
            _form.UpdateGraphics();
            return true;
        }

        /// <summary>
        /// Checks which method should be called and does it.
        /// Drops row added flag when adding new module.
        /// </summary>
        /// <returns>True if everithing done.</returns>
        public bool AddOrEditModule()
        {
            if (_form.IsRowAdded) //проверяет, что метод вызван в случае добавления новой строки
            {
                AddModule();
                _form.IsRowAdded = false;
            }
            else //в случае изменения имеющейся строки
            {
                EditModule();
            }
            return true;
        }

        public bool OpenChosenModule()
        {
            if (!_form.IsGridViewEditing)
            {
                if (_moduleList == null || _moduleList.Modules.Count == 0) // if no modules find, we can't open module
                {
                    return false;
                }
                var module = _moduleList.Modules[_form.RowPointer];
                var additionalController = new ModuleFormController(module, new View.ModuleForm());
                additionalController.ShowForm();
            }
            return !_form.IsGridViewEditing; // if grid view is edditing, we can't choose module, and reverse situation
        }

        public ModuleList SaveDataToXmlFile()
        {
            new XmlModuleSerializer().SerializeToFile(_moduleList, _filePath);
            return _moduleList;
        }

        public bool CheckAndClose()
        {
            var dialogForm = new CheckSaveForm();
            dialogForm.ShowDialog();
            if (dialogForm.IsAnswerYes)
            {
                SaveDataToXmlFile();
                dialogForm.Close();
                return true;
            }
            return false;
        }
    }
}
