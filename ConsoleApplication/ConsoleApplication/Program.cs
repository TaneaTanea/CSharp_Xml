using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("XML");
            //CreateXmlFile();
            ReadXML();
        }
        public static void CreateXmlFile()
        {
            var listUsers = new List<User>()
            {
                new User { Name = "John Rambo", Age = 25, Company= "Holiwood"},
                new User { Name = "John Smith", Age = 35, Company= "LuterCorp"},
                new User { Name = "Jenifer lopez", Age = 22, Company= "Muzic"},
            };
            XmlSerializer serialiser = new XmlSerializer(typeof(List<User>));
            TextWriter Filestream = new StreamWriter(@"D:\User.xml");
            serialiser.Serialize(Filestream, listUsers);
            Filestream.Close();

        }
        public static void ReadXML()
        {
            var xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode;
            int i = 0;
            string str = null;
            FileStream fs = new FileStream(@"D:\User.xml", FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName("User");
            for (i = 0; i <= xmlnode.Count - 1; i++)
            {
                xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                str = xmlnode[i].ChildNodes.Item(0).InnerText.Trim() + " " + xmlnode[i].ChildNodes.Item(1).InnerText.Trim() + " " + xmlnode[i].ChildNodes.Item(2).InnerText.Trim();
                Console.WriteLine(str);
            }
            fs.Close();
            Console.WriteLine("\n End of file");
            Console.ReadKey();
        }
        public static void RegexSamlpe()
        {

            Regex regex = new Regex(@"\d+");
            Match match = regex.Match("Dot 25 Step");
            if (match.Succes)
            {
                Console.WriteLine(match.Value);
            }
        }
    }

}
