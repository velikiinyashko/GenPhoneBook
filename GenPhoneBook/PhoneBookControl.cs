using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;
using System.Windows;

namespace GenPhoneBook
{
    public class PhoneBookControl
    {
        public string FilePath { get; set; }

        private void OpenButtonClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.FileName = "Файл книги(*.xml)";
            openFile.CheckFileExists = true;
            if(openFile.ShowDialog() == true)
            {
                FilePath = openFile.FileName;
            }
        }

        private void CreateButtonClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Файл книги(*.xml)";
            saveFile.CheckFileExists = true;
            if(saveFile.ShowDialog() == true)
            {
                FilePath = saveFile.FileName;
            }
        }
    }
}
