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
using FirstPractice2;

namespace FirstPractice1
{
    public partial class Page2 : Page
    {
        private LibraryDatabaseEntities library1 = new LibraryDatabaseEntities();
        public Page2()
        {
            InitializeComponent();
            biba.ItemsSource = library1.Books.ToList();
            Author.ItemsSource = library1.Authors.ToList();
            Author.DisplayMemberPath = "AuthorName";
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (biba.SelectedItem != null)
            {
                var selected = biba.SelectedItem as Books;

                NewTittle.Text = selected.BookTittle;
                NewGenre.Text = selected.GenreOfbOOK;
                selected.PublicationYear = Convert.ToInt32(NewPublishingYear.Text);
                selected.AvailabilityOfBook = NewAvailability.Text == "0" ? false : true;
                selected.Author_ID = (Author.SelectedItem as Authors).ID_Author;

                library1.SaveChanges();
                biba.ItemsSource = library1.Books.ToList();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (biba.SelectedItem != null)
            {
                library1.Books.Remove(biba.SelectedItem as Books);

                library1.SaveChanges();
                biba.ItemsSource = library1.Authors.ToList();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            WindowAddB win = new WindowAddB();
            win.Show();
            biba.ItemsSource = library1.Authors.ToList();
        }
    }
}
