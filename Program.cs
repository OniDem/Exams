using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Xml;

namespace Exams
{
    class Exams
    {
        static int id = 0; 
        static ReadXMLFile readXMLFile = new ReadXMLFile("C:\\Users\\OniDem1\\source\\repos\\Exams\\Clients.xml", "C:\\Users\\OniDem1\\source\\repos\\Exams\\NewClients.xml");
        static void Main(String[] args)
        {
            readXMLFile.removeMultipleElement();
        }        
    }
}