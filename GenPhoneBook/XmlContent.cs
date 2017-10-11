using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using GenPhoneBook.Model;

namespace GenPhoneBook
{
    class XmlContent
    {
        string Path;

        public XmlContent(string Path)
        {
            this.Path = Path;
        }

        public void XmlCreate(string Title)
        {
            XDocument xDoc = new XDocument();
            XElement CiscoIPPhoneDirectory = new XElement("CiscoIPPhoneDirectory");
            XElement TitleBook = new XElement("Title", Title);
            XElement DirectoryEntry = new XElement("DirectoryEntry");
            XElement NameDE = new XElement("Name", "Офис");
            XElement TelephoneDE = new XElement("Telephone", "2191490");
            DirectoryEntry.Add(NameDE);
            DirectoryEntry.Add(TelephoneDE);
            CiscoIPPhoneDirectory.Add(TitleBook);
            CiscoIPPhoneDirectory.Add(DirectoryEntry);
            xDoc.Add(CiscoIPPhoneDirectory);
            xDoc.Save(this.Path);
        }

        public IEnumerable<PhoneBookModel> XmlOpen()
        {
            XDocument xDoc = XDocument.Load(Path);
            var items = from xe in xDoc.Element("CiscoIPPhoneDirectory").Elements("DirectoryEntry")
                        select new PhoneBookModel
                        {
                            Name = xe.Element("Name").Value,
                            Phone = xe.Element("Telephone").Value
                        };
            return items;
        }

        public void XmlAddItems(string Name, string Phone)
        {
            XDocument xDox = XDocument.Load(Path);
            XElement root = xDox.Element("CiscoIPPhoneDirectory");
            root.Add(new XElement("DirectoryEntry",
                new XElement("Name", Name),
                new XElement("Telephone", Phone)));
            xDox.Save(Path);
        }

        public void XmlRemoveItems(string Finder)
        {
            XDocument xDoc = XDocument.Load(Path);
            XElement root = xDoc.Element("CiscoIPPhoneDirectory");

            foreach (XElement xe in root.Elements("DirectoryEntry").ToList())
            {
                if(xe.Element("Name").Value == Finder)
                {
                    xe.Remove();
                }
            }
            xDoc.Save(Path);
        }

        public void XmlUpdateItems(string Name, string Phone)
        {
            XDocument xDoc = XDocument.Load(Path);
            XElement root = xDoc.Element("CiscoIPPhoneDirectory");

            foreach (XElement xe in root.Elements("DirectoryEntry").ToList())
            {
                if (xe.Element("Name").Value == Name)
                {
                    xe.Element("Name").Value = Name;
                    xe.Element("Telephone").Value = Phone;
                }
            }
            xDoc.Save(Path);
        }
    }
}
