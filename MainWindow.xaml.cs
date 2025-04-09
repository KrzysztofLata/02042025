using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    class item
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string pesel { get; set; }
        public string name2nd {get;set;}
        public string adres { get; set; }
        public string city { get; set; }
        public string date { get; set; }
        public string phone { get; set; }
        public string code { get; set; }
        public item(int i, string n, string s,string p, string n2,string a,string c,string d,string ph, string co) 
        {
            id = i;
            name = n;
            surname = s;
            pesel = p;
            name2nd = n2;
            adres = a;
            city = c;
            date = d;
            phone = ph;
            code = co;
        }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Dodaj(object sender, RoutedEventArgs e)
        {
            Window1 newWindow = new Window1();
            newWindow.ShowDialog();
            item x = new item(listView.Items.Count+1, newWindow.xname, newWindow.xsurname, newWindow.xpes, newWindow.xname2nd,newWindow.xadres,newWindow.xcity,newWindow.xdate,newWindow.xphone,newWindow.xcode);
            listView.Items.Add(x);
        }
    }
}