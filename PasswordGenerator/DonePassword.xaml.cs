using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace PasswordGenerator
{
    /// <summary>
    /// Логика взаимодействия для DonePassword.xaml
    /// </summary>
    public partial class DonePassword : Window
    {
        
        public DonePassword(string password)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            pass.Text = password;
            if(password == null ) {
            Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(pass.Text);
            lb.Content= "Copied!";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"; 
            saveFileDialog.DefaultExt = "txt"; 
            saveFileDialog.Title = "Save password";
            bool? result = saveFileDialog.ShowDialog();
            if (result == true)
            {
                
                string filePath = saveFileDialog.FileName;
                File.WriteAllText(filePath, pass.Text );
                lb.Content = "Saved!";
            }
        }
    }
}
