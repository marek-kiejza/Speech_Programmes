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
using System.Threading;
using System.IO;
using System.Speech.Synthesis;

namespace WpfApplication11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] preposition;
        public MainWindow()
        {
            InitializeComponent();
            List<string> myList = new List<string>();

            preposition = myList.ToArray();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string[] menu = { "Learning To Write","Learning to Read"};
            comboBox.ItemsSource = menu;
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string select = comboBox.SelectedItem as string;

            if (select.Equals("Learning To Write")) 
            {
                //Create new window object
                LearningToWrite w = new LearningToWrite(preposition);

                //Set the owner of this new object
                w.Owner = this;

                //Display the new window
                w.ShowDialog();
            }
        }
    }
}
