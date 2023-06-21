using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace Exams
{

    internal class ReadXMLFile
    {
        private string _path;
        private string _newpath;
        private static int id = 0;
        public ReadXMLFile(string xlmFile_path, string newxmlFile_path)
        {
            _path = xlmFile_path;
            _newpath = newxmlFile_path;
        }

        public void removeMultipleElement()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(_path);

            XmlNodeList? clientsNodes = xmlDoc.SelectNodes("//Client");
            XmlElement? root = xmlDoc.DocumentElement;
            XmlNode generatedID = xmlDoc.CreateNode(XmlNodeType.Text, "GeneratedID", "//Clients/Client");
            foreach (XmlNode? clientNode in clientsNodes!)
            {

                if (clientNode!.SelectSingleNode("DiasoftID") != null)
                {                                      
                    
                    //clientNode.SelectSingleNode("GeneratedID")
                    string fio = clientNode.SelectSingleNode("FIO")!.InnerText.Trim();
                    string regNumber = clientNode.SelectSingleNode("RegNumber")!.InnerText.Trim();
                    string diasoftID = clientNode.SelectSingleNode("DiasoftID")!.InnerText.Trim();
                    string registrator = clientNode.SelectSingleNode("Registrator")!.InnerText.Trim();
                    clientNode.AppendChild(generatedID);
                    bool isFioValid = string.IsNullOrEmpty(fio);
                    bool isRegNumberValid = string.IsNullOrEmpty(regNumber);
                    bool isDiasoftValid = string.IsNullOrEmpty(diasoftID);
                    bool isRegistratorValid = string.IsNullOrEmpty(registrator);
                    if (!isFioValid || !isRegNumberValid || !isDiasoftValid || !isRegistratorValid)
                    {
                        xmlDoc.DocumentElement!.RemoveChild(clientNode);
                    }
                }                
                xmlDoc.Save(_newpath);
            }

            static string GeneratedID()
            {
                string newid = Convert.ToString(id++);
                id++;
                return newid;
            }
        }
    }
}
