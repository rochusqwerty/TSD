using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        ObservableCollection<Book> books = new ObservableCollection<Book>();
        public MainWindow()
        {
            InitializeComponent();
            //listBoxBooksList.ItemsSource = MyBookCollection.GetMyCollection();
            //ObservableCollection<Book> books = new ObservableCollection<Book>();
            foreach (var book in MyBookCollection.GetMyCollection())
            {
                books.Add(book);
            }
            this.DataContext = books;
        }


        private void ListBoxBooksList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var lbi = ((sender as ListBox).SelectedItem as Book);
            if (lbi != null)
            {
                //lId.Content = lbi.Id;
                //lTitle.Text = lbi.Title;
                //lAuthor.Content = lbi.Author;
                //lYear.Content = lbi.Year;
                if (lbi.IsRead == true)
                {
                    //chbRead.IsChecked = true;
                }
                else
                {
                    //chbRead.IsChecked = false;
                }

            }
        }

        private void Click_Add(object sender, RoutedEventArgs e)
        {
            books.Add(new Book(books.Max(d => d.Id) + 1));
        }

        private void Click_Del(object sender, RoutedEventArgs e)
        {
            if (listBoxBooksList.SelectedIndex != null)
            {
                if (MessageBox.Show("Do you want to delete this book?",
                        "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    books.RemoveAt(listBoxBooksList.SelectedIndex);
                }
                else
                {
                    // Do nothing
                }
            }
        }
    }
    
}
