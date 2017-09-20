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

        private string FilePath;

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
                XmlContent content = new XmlContent(FilePath);
                GridView.ItemsSource = content.XmlOpen();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void CreateButtonClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Файл книги(*.xml)|*.xml";
            saveFile.FileName = "Phone";
            saveFile.DefaultExt = ".xml";

            if (saveFile.ShowDialog() == true)
            {
                FilePath = saveFile.FileName;
                try
                {
                    XmlContent content = new XmlContent(FilePath);
                    content.XmlCreate(saveFile.SafeFileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void SelectDataGridRow(object sender, MouseButtonEventArgs e)
        {
            try
            {
                PhoneBookModel SelectItem = GridView.SelectedItem as PhoneBookModel;
                NameText.Text = SelectItem.Name;
                PhoneText.Text = SelectItem.Telephone;
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void AddItemButtomClick(object sender, RoutedEventArgs e)
        {
            try
            {
                XmlContent content = new XmlContent(FilePath);
                content.XmlAddItems(NameText.Text, PhoneText.Text);
                GridView.ItemsSource = content.XmlOpen();
                NameText.Text = null;
                PhoneText.Text = null;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpadeItemsButtomClick(object sender, RoutedEventArgs e)
        {
            try
            {
                XmlContent content = new XmlContent(FilePath);
                content.XmlUpdateItems(NameText.Text, PhoneText.Text);
                GridView.ItemsSource = content.XmlOpen();
                NameText.Text = null;
                PhoneText.Text = null;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RemoveItemsButtomClick(object sender, RoutedEventArgs e)
        {
            try
            {
                XmlContent content = new XmlContent(FilePath);
                content.XmlRemoveItems(NameText.Text);
                GridView.ItemsSource = content.XmlOpen();
                NameText.Text = null;
                PhoneText.Text = null;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
