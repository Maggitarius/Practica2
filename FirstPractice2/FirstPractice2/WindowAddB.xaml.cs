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
using System.Windows.Shapes;

namespace FirstPractice2
{
    public partial class WindowAddB : Window
    {
        private LibraryDatabaseEntities library = new LibraryDatabaseEntities();
        public WindowAddB()
        {   
            InitializeComponent();
            Books.ItemsSource = library.Books.ToList();
            Author.ItemsSource = library.Authors.ToList();
            Author.DisplayMemberPath = "AuthorName";
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            Books b = new Books();
            b.BookTittle = Tittle.Text;
            b.GenreOfbOOK = Genre.Text;
            b.PublicationYear = Convert.ToInt32(PublicationYear.Text);
            b.AvailabilityOfBook =  AvailabilityOfBook.Text == "0" ? false:true;
            b.Author_ID = (Author.SelectedItem as Authors).ID_Author;

            library.Books.Add(b);

            library.SaveChanges();
            Books.ItemsSource = library.Books.ToList();
        }
    }
}
