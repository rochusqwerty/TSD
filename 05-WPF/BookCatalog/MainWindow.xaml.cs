using System;
using System.Collections.Generic;
using System.Data;
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

namespace BookCatalog
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            listBoxBooksList.ItemsSource = MyBookCollection.GetMyCollection();
        }


        private void ListBoxBooksList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var lbi = ((sender as ListBox).SelectedItem as Book);
            if (lbi != null)
            {
                lId.Content = lbi.Id;
                lTitle.Content = lbi.Title;
                lAuthor.Content = lbi.Author;
                lYear.Content = lbi.Year;
                if (lbi.IsRead == true)
                {
                    chbRead.IsChecked = true;
                }
                else
                {
                    chbRead.IsChecked = false;
                }

            }
        }
    }
}
