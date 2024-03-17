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
using FirstPractice1.LibraryDatabaseDataSetTableAdapters;

namespace FirstPractice1
{

    public partial class Page2 : Page
    {
        BooksTableAdapter books = new BooksTableAdapter();
        AuthorsTableAdapter authorsTable = new AuthorsTableAdapter();
        public Page2()
        {
            InitializeComponent();
            Books.ItemsSource = books.GetData();
            Author.ItemsSource = authorsTable.GetData();
            Author.DisplayMemberPath = "AuthorName";
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            WindowAddB win = new WindowAddB();
            win.Show();
            Books.ItemsSource = books.GetData();
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            object id = (Books.SelectedItem as DataRowView).Row[0];
            books.UpdateQueryBooks(NewTittle.Text, NewGenre.Text, Convert.ToInt32(NewPublishingYear.Text), NewAvailability.Text == "0" ? false : true, (int)(Author.SelectedItem as DataRowView)[0], Convert.ToInt32(id));
            Books.ItemsSource = books.GetData();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            object id = (Books.SelectedItem as DataRowView).Row[0];
            books.DeleteQueryBooks(Convert.ToInt32(id));
            Books.ItemsSource = books.GetData();
        }
    }
}
