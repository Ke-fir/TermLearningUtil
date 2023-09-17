using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace _4sem_course_project
{
    /// <summary>
    /// The class responsible for wrapping modules.
    /// </summary>
    [Serializable]
    [XmlRoot (ElementName = "modules", Namespace = null)]
    public class ModuleList
    {
        private List<Module> _modules = new List<Module>();

        public ModuleList() { }

        public ModuleList(List<Module> modules)
        {
            Modules = modules;
        }

        
        /// <summary>
        /// Returns clone of modules. Sets list of unique modules.
        /// Throws AddingSameModulesException if there are the same modules.
        /// </summary>
        /// <exception cref="AddingSameModulesException"></exception>
        [XmlElement("module")]
        public List<Module> Modules
        {
            get
            {
                return _modules;
            }
            set
            {
                if (value.Distinct().Count() == value.Count)
                {
                    _modules = value;
                }
                else
                {
                    throw new Exception("AddingRecurringModuleException");
                }
            }
        }

        public override bool Equals(object obj)
        {
            var result = true;
            var moduleList = ((ModuleList)obj).Modules;
            for (int i = 0; i < _modules.Count; i++)
                result &= _modules[i].Equals(moduleList[i]);
            return result && (_modules.Count == moduleList.Count);
        }
    }
}
