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
using System.Windows.Shapes;
using FirstPractice1.LibraryDatabaseDataSetTableAdapters;

namespace FirstPractice1
{
    public partial class WindowAddB : Window
    {
        BooksTableAdapter books = new BooksTableAdapter();
        AuthorsTableAdapter authorsTable = new AuthorsTableAdapter();
        public WindowAddB()
        {
            InitializeComponent();
            Author.ItemsSource = authorsTable.GetData();
            Author.DisplayMemberPath = "AuthorName";
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            books.InsertQuery(Tittle.Text, Genre.Text, Convert.ToInt32(PublicationYear.Text), AvailabilityOfBook.Text == "0" ? false:true, (int)(Author.SelectedItem as DataRowView)[0]);
            Books.ItemsSource = books.GetData();
        }
    }
}
