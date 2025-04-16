using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
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

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public string xpes;
        public string xname;
        public string xsurname;
        public string xname2nd;
        public string xadres;
        public string xdate;
        public string xphone;
        public string xcity ;
        public string xcode ;
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (pesel.Text != "" && name.Text != "" && surname.Text != "" && adres.Text != "" && date_of_birth.Text != "" && post.Text != "" && city.Text != "")
            {
                xpes = pesel.Text;
                xname = name.Text;
                xsurname = surname.Text;
                xname2nd = name2nd.Text;
                xadres = adres.Text;
                xdate = date_of_birth.Text;
                xphone = phone.Text;
                xcode = post.Text;
                xcity = city.Text;
                Hide();
            }
            else
            {
                
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("Czy chcesz zamknąć?","Zamknąć okno", MessageBoxButton.YesNo);
            if (res==MessageBoxResult.Yes)
            {
                Hide();
            }
        }
    }
}
