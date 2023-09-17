using NUnit.Framework;
using _4sem_course_project;
using System.Collections.Generic;
using System.IO;

namespace Tests
{
    class XmlModuleSerializerTest
    {
        [Test]
        public void SerializeToStringTest() 
        {
            #region Init
            string expectedXml =
"<modules>\r\n" +
"  <module name=\"Module 1\" description=\"Description 1\">\r\n" +
"    <cards>\r\n" +
"      <card>\r\n" +
"        <term>term1</term>\r\n" +
"        <definition>def1</definition>\r\n" +
"      </card>\r\n" +
"      <card>\r\n" +
"        <term>term2</term>\r\n" +
"        <definition>def2</definition>\r\n" +
"      </card>\r\n" +
"      <card>\r\n" +
"        <term>term3</term>\r\n" +
"        <definition>def3</definition>\r\n" +
"      </card>\r\n" +
"    </cards>\r\n" +
"  </module>\r\n" +
"  <module name=\"Module 2\" description=\"Description 2\">\r\n" +
"    <cards>\r\n" +
"      <card>\r\n" +
"        <term>term1</term>\r\n" +
"        <definition>def1</definition>\r\n" +
"      </card>\r\n" +
"      <card>\r\n" +
"        <term>term2</term>\r\n" +
"        <definition>def2</definition>\r\n" +
"      </card>\r\n" +
"    </cards>\r\n" +
"  </module>\r\n" +
"</modules>";
            #endregion

            var module1 = new Module("Module 1", "Description 1");
            module1.AddCard("term1", "def1");
            module1.AddCard("term2", "def2");
            module1.AddCard("term3", "def3");
            var module2 = new Module("Module 2", "Description 2");
            module2.AddCard("term1", "def1");
            module2.AddCard("term2", "def2");

            var modules = new ModuleList();
            modules.Modules = new List<Module>() { module1, module2 };
            

            var serializer = new XmlModuleSerializer();
            var actualXml = serializer.SerializeToString(modules);
            Assert.AreEqual(expectedXml, actualXml);
        }

        [Test]
        public void SerializeToFileTest()
        {
            #region Init
            string expectedXml = 
"<modules>\r\n" +
"  <module name=\"Module 1\" description=\"Description 1\">\r\n" +
"    <cards>\r\n" +
"      <card>\r\n" +
"        <term>term1</term>\r\n" +
"        <definition>def1</definition>\r\n" +
"      </card>\r\n" +
"      <card>\r\n" +
"        <term>term2</term>\r\n" +
"        <definition>def2</definition>\r\n" +
"      </card>\r\n" +
"      <card>\r\n" +
"        <term>term3</term>\r\n" +
"        <definition>def3</definition>\r\n" +
"      </card>\r\n" +
"    </cards>\r\n" +
"  </module>\r\n" +
"  <module name=\"Module 2\" description=\"Description 2\">\r\n" +
"    <cards>\r\n" +
"      <card>\r\n" +
"        <term>term1</term>\r\n" +
"        <definition>def1</definition>\r\n" +
"      </card>\r\n" +
"      <card>\r\n" +
"        <term>term2</term>\r\n" +
"        <definition>def2</definition>\r\n" +
"      </card>\r\n" +
"    </cards>\r\n" +
"  </module>\r\n" +
"</modules>";
            #endregion

            var module1 = new Module("Module 1", "Description 1");
            module1.AddCard("term1", "def1");
            module1.AddCard("term2", "def2");
            module1.AddCard("term3", "def3");
            var module2 = new Module("Module 2", "Description 2");
            module2.AddCard("term1", "def1");
            module2.AddCard("term2", "def2");

            var modules = new ModuleList();
            modules.Modules = new List<Module>() { module1, module2 };

            var filePath = "SerializationTest.xml";

            var serializer = new XmlModuleSerializer();
            serializer.SerializeToFile(modules, filePath); // Запись во временный файл

            string actualXml;
            using (var reader = new StreamReader(filePath))
            {
                actualXml = reader.ReadToEnd();
            }

            // Удаление временного файла
            File.Delete(filePath);

            Assert.AreEqual(expectedXml.ToCharArray(), actualXml.ToCharArray());
        }

        [Test]
        public void DeserializeFromStringTest()
        {
            #region Init
            string xml = 
"<modules>\r\n" +
"  <module name=\"Module 1\" description=\"Description 1\">\r\n" +
"    <cards>\r\n" +
"      <card>\r\n" +
"        <term>term1</term>\r\n" +
"        <definition>def1</definition>\r\n" +
"      </card>\r\n" +
"      <card>\r\n" +
"        <term>term2</term>\r\n" +
"        <definition>def2</definition>\r\n" +
"      </card>\r\n" +
"      <card>\r\n" +
"        <term>term3</term>\r\n" +
"        <definition>def3</definition>\r\n" +
"      </card>\r\n" +
"    </cards>\r\n" +
"  </module>\r\n" +
"  <module name=\"Module 2\" description=\"Description 2\">\r\n" +
"    <cards>\r\n" +
"      <card>\r\n" +
"        <term>term1</term>\r\n" +
"        <definition>def1</definition>\r\n" +
"      </card>\r\n" +
"      <card>\r\n" +
"        <term>term2</term>\r\n" +
"        <definition>def2</definition>\r\n" +
"      </card>\r\n" +
"    </cards>\r\n" +
"  </module>\r\n" +
"</modules>";

            var module1 = new Module("Module 1", "Description 1");
            module1.AddCard("term1", "def1");
            module1.AddCard("term2", "def2");
            module1.AddCard("term3", "def3");
            var module2 = new Module("Module 2", "Description 2");
            module2.AddCard("term1", "def1");
            module2.AddCard("term2", "def2");

            var expectedModules = new ModuleList();
            expectedModules.Modules = new List<Module>() { module1, module2 };
            #endregion

            var serializer = new XmlModuleSerializer();
            var actualModules = serializer.DeserializeFromString(xml);

            Assert.AreEqual(expectedModules, actualModules);
        }

        [Test]
        public void DeserializeFromFileTest()
        {
            #region Init
            string xml =
"<modules>\r\n" +
"  <module name=\"Module 1\" description=\"Description 1\">\r\n" +
"    <cards>\r\n" +
"      <card>\r\n" +
"        <term>term1</term>\r\n" +
"        <definition>def1</definition>\r\n" +
"      </card>\r\n" +
"      <card>\r\n" +
"        <term>term2</term>\r\n" +
"        <definition>def2</definition>\r\n" +
"      </card>\r\n" +
"      <card>\r\n" +
"        <term>term3</term>\r\n" +
"        <definition>def3</definition>\r\n" +
"      </card>\r\n" +
"    </cards>\r\n" +
"  </module>\r\n" +
"  <module name=\"Module 2\" description=\"Description 2\">\r\n" +
"    <cards>\r\n" +
"      <card>\r\n" +
"        <term>term1</term>\r\n" +
"        <definition>def1</definition>\r\n" +
"      </card>\r\n" +
"      <card>\r\n" +
"        <term>term2</term>\r\n" +
"        <definition>def2</definition>\r\n" +
"      </card>\r\n" +
"    </cards>\r\n" +
"  </module>\r\n" +
"</modules>";

            var module1 = new Module("Module 1", "Description 1");
            module1.AddCard("term1", "def1");
            module1.AddCard("term2", "def2");
            module1.AddCard("term3", "def3");
            var module2 = new Module("Module 2", "Description 2");
            module2.AddCard("term1", "def1");
            module2.AddCard("term2", "def2");

            var expectedModules = new ModuleList();
            expectedModules.Modules = new List<Module>() { module1, module2 };
            #endregion

            var filePath = "DeserializationTest.xml";

            // Запись xml во временный файл
            using (var writer = new StreamWriter(filePath))
            {
                writer.Write(xml);
            }

            var serializer = new XmlModuleSerializer();
            var actualModules = serializer.DeserializeFromFile(filePath);

            // Удаление временного файла
            File.Delete(filePath);

            Assert.AreEqual(expectedModules, actualModules);
        }
    }
}
