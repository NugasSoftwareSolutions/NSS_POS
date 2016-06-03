using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
namespace AlreySolutions.Class
{
    public class Profile
    {
        private string _Company;

        public string Company
        {
            get { return _Company; }
            set { _Company = value; }
        }
        private string _Address;

        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        private string _ContactNum;

        public string ContactNum
        {
            get { return _ContactNum; }
            set { _ContactNum = value; }
        }
        private string _TIN;

        public string TIN
        {
            get { return _TIN; }
            set { _TIN = value; }
        }

        private bool _EnablePreview;

        public bool EnablePreview
        {
            get { return _EnablePreview; }
            set { _EnablePreview = value; }
        }


        private bool _EnableAutoPrint;

        public bool EnableAutoPrint
        {
            get { return _EnableAutoPrint; }
            set { _EnableAutoPrint = value; }
        }

        private bool _PrintReceipt;
        public bool PrintReceipt
        {
            get { return _PrintReceipt; }
            set { _PrintReceipt = value; }
        }


        public Profile()
        {
            _Company = "Kawayanan Food Hauz";
            _Address = "Leopoldo, Jalandoni Street, Pob. 5 Midsayap, Cotabato";
            _ContactNum = "09178285095";
            _TIN = "12345-6789-0";
            _EnablePreview = true;
            _EnableAutoPrint = true;
            _PrintReceipt = true;
        }

        public void ReadXML()
        {
            FileStream fs = new FileStream("CompanyProfile.xml", FileMode.OpenOrCreate);
            try
            {
                XmlTextReader xmlread = new XmlTextReader(fs);

                while (xmlread.IsStartElement("CompanyName") == false) xmlread.Read();
                Company = xmlread.ReadElementString("CompanyName");
                Address = xmlread.ReadElementString("Address");
                ContactNum = xmlread.ReadElementString("ContactNum");
                TIN = xmlread.ReadElementString("TIN");
                EnablePreview = (xmlread.ReadElementString("EnablePreview")=="True"?true:false);
                EnableAutoPrint = (xmlread.ReadElementString("EnableAutoPrint") == "True" ? true : false);
                PrintReceipt = (xmlread.ReadElementString("PrintReceipt") == "True" ? true : false);

                xmlread.Close();
            }
            catch { }
            finally
            {
                fs.Close();
            }
        }

        public void SaveXML()
        {
            FileStream fs = new FileStream("CompanyProfile.xml", FileMode.Create);
            try
            {
                XmlTextWriter xmlwrite = new XmlTextWriter(fs, Encoding.ASCII);
                xmlwrite.WriteStartDocument();
                xmlwrite.WriteStartElement("Kawayanan");
                xmlwrite.WriteStartElement("Settings");
                xmlwrite.WriteStartElement("CompanyName");
                xmlwrite.WriteValue(Company);
                xmlwrite.WriteEndElement();
                xmlwrite.WriteStartElement("Address");
                xmlwrite.WriteValue(Address);
                xmlwrite.WriteEndElement();
                xmlwrite.WriteStartElement("ContactNum");
                xmlwrite.WriteValue(ContactNum);
                xmlwrite.WriteEndElement();
                xmlwrite.WriteStartElement("TIN");
                xmlwrite.WriteValue(TIN);
                xmlwrite.WriteEndElement();
                xmlwrite.WriteStartElement("EnablePreview");
                xmlwrite.WriteValue(EnablePreview.ToString());
                xmlwrite.WriteEndElement();
                xmlwrite.WriteStartElement("EnableAutoPrint");
                xmlwrite.WriteValue(EnableAutoPrint.ToString());
                xmlwrite.WriteEndElement();
                xmlwrite.WriteStartElement("PrintReceipt");
                xmlwrite.WriteValue(PrintReceipt.ToString());
                xmlwrite.WriteEndElement();
                xmlwrite.WriteEndDocument();
                xmlwrite.Close();
            }
            catch { }
            finally
            {
                fs.Close();
            }        
        }
    }
}
