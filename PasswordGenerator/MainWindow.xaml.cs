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

namespace PasswordGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        private void Length_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            
            if (!string.IsNullOrEmpty(textBox.Text) && textBox.Text[0] == '0')
            {
                textBox.Text = ""; 
            }
        }

        private void Length_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            
            if (!char.IsDigit(e.Text, 0))
            {
                e.Handled = true; 
            }
        }

        private void Generate_button_Click(object sender, RoutedEventArgs e)
        {
            string TbLength = Length.Text;
            bool? CLetters = Letters.IsChecked; //1
            bool? CNumbers = Numbers.IsChecked; //2
            bool? CSigns = Signs.IsChecked; //3
            List<int> types = new List<int> { 0 };
            List<string> SpecialSigns = new List<string> { "{","}","!","?","@","/","\\" };
            string password = "";
            if (int.TryParse(TbLength, out int lngth))
            {
                if (CLetters == true)
                {
                    types.Add(1);
                }

                if (CNumbers == true)
                {
                    types.Add(2);
                }

                if (CSigns == true)
                {
                    types.Add(3);
                }

                for (int i = 0; i != lngth; i++)
                {
                    Random random = new Random();
                    int nexttype = GetRandomElement(types);
                    if (nexttype == 0)
                    {
                        int randomNumber = random.Next(97, 123); // Генерация случайного числа от 97 ('a') до 122 ('z')
                        char randomChar = (char)randomNumber; // Преобразование числа обратно в символ
                        password += randomChar;
                    }
                    if (nexttype == 1)
                    {
                        int randomNumber = random.Next(65, 91); // Генерация случайного числа от 97 ('a') до 122 ('z')
                        char randomChar = (char)randomNumber; // Преобразование числа обратно в символ
                        password += randomChar;
                    }
                    if (nexttype == 2)
                    {
                        int randomNumber = random.Next(48, 58); // Генерация случайного числа от 97 ('a') до 122 ('z')
                        char randomChar = (char)randomNumber; // Преобразование числа обратно в символ
                        password += randomChar;
                    }
                    if (nexttype == 3)
                    {
                        string randomChar = GetRandomElement(SpecialSigns); // Преобразование числа обратно в символ
                        password += randomChar;
                    }

                }
                DonePassword donepasswrd = new DonePassword(password);
                donepasswrd.Show();
            }
            else
            {
                MessageBox.Show("Length is not a number");
            }
        }

        static T GetRandomElement<T>(List<T> list)
        {
            Random random = new Random();
            int index = random.Next(0, list.Count);
            return list[index];
        }
    }
}
