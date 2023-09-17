using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace _4sem_course_project
{
    /// <summary>
    /// The class responsible for serializing user modules to XML file.
    /// </summary>
    public class XmlModuleSerializer
    {

        public XmlModuleSerializer() { }

        /// <summary>
        /// Serialize list of modules to xml string and writes it to the file due to its path.
        /// </summary>
        /// <param name="modules"></param>
        /// <param name="filePath"></param>
        /// <returns>True if successfully done. Otherwise false</returns>
        /// <exception cref="WritingModulesToFileException"></exception>
        public bool SerializeToFile(ModuleList modules, string filePath)
        {
            try
            {
                var xml = this.SerializeToString(modules);

                using (var writer = new StreamWriter(filePath))
                {
                    writer.Write(xml);
                }

                    // Все прошло успешно
                    return true;
            }
            catch (Exception ex)
            {
                // Обработка ошибок
                Console.WriteLine("WritingModulesToFileException: " + ex.Message);
                return false;

            }
        }

        /// <summary>
        /// Serialize list of modules to XML string.
        /// </summary>
        /// <param name="modules"></param>
        /// <returns>
        /// XML string of modules.
        /// </returns>
        public string SerializeToString(ModuleList modules)
        {
            string xml;

            // Создаем объект XmlSerializer для сериализации
            var serializer = new XmlSerializer(modules.GetType());

            // Создаем настройки XmlWriter для удаления строчки версии xml и читаемого переноса строчек
            var settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = true,
                Indent = true
            };

            // Создаем новый экземпляр XmlSerializerNamespaces и добавляем в него пространства имен, установив их в пустые строки, чтобы удалить xlmns из рута
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            // Создаем StringBuilder для записи XML
            var sb = new StringBuilder();

            // Создаем XmlWriter для записи в StringBuilder с использованием настроек
            using (var writer = XmlWriter.Create(sb, settings))
            {
                // Сериализуем объект modules в XmlWriter
                serializer.Serialize(writer, modules, ns);
            }

            // Получаем строку XML из StringBuilder
            xml = sb.ToString();

            return xml;
        }

        /// <summary>
        /// Converts XML string to list of modules.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>
        /// List of modules.
        /// </returns>
        public ModuleList DeserializeFromString(string xml)
        {
            if (xml == null || xml == "")
            {
                return new ModuleList();
            }
            // Создаем сериалайзер
            XmlSerializer serializer = new XmlSerializer(typeof(ModuleList));

            using (var reader = new StringReader(xml))
            {
                // Возвращаем результат десериализации xml строки, засунутой в StringReader
                return (ModuleList)serializer.Deserialize(reader);
            }
        }

        /// <summary>
        /// Deserialize xml file due to its path to list of modules.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>
        /// Deserialized ModuleList object.
        /// </returns>
        public ModuleList DeserializeFromFile(string filePath)
        {
            string xml;
            if (!File.Exists(filePath))
            {
                using (File.Create(filePath)) { }// используем временные ресурсы, чтобы закрыть поток
            }
            using (var reader = new StreamReader(filePath))
            {
                xml = reader.ReadToEnd();
            }
            return DeserializeFromString(xml);
        }
    }    
}
