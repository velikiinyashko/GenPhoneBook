using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Xml;
using System.IO;

namespace GenPhoneBook
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public string FilePath { get; set; }
        XmlDocument Xml = new XmlDocument();
        XmlTextReader reader = null;

        private void OpenButtonClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Файл книги(*.xml)|*.xml";
            openFile.CheckFileExists = true;
            if (openFile.ShowDialog() == true)
            {
                FilePath = openFile.FileName;
                Path.Text = openFile.FileName;
            }
            try
            {
                Xml.Load(FilePath);
                XmlElement xRoot = Xml.DocumentElement;
                foreach(XmlNode xNode in xRoot)
                {
                    if(xNode.Attributes.Count > 0)
                    {

                    }
                }
            }catch(Exception ex)
            {

            }

        }

        private void CreateButtonClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Файл книги(*.xml)|*.xml";
            saveFile.CheckFileExists = true;
            if (saveFile.ShowDialog() == true)
            {
                FilePath = saveFile.FileName;

            }
        }
    }

    class XmlSer
    {
        public void Write()
        {

        }
    }
}
