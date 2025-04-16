using System.IO;
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
        bool fdata(string d, string pes = "0")
        {
            if (d.Length > 10)
            {
                return false;
            }
            for (int i = 0; i < d.Length; i++)
            {
                char ddd = d[i];
                string dddd = ddd.ToString();
                if (int.TryParse(dddd, out _) == false && d[i] != '-' && d[i] != '/')
                {
                    return false;
                }
            }
            int l1 = d.IndexOf('-');
            int l2 = d.LastIndexOf('-');
            if (l1 == -1)
            {
                l1 = d.IndexOf('/');
            }
            if (l2 == -1)
            {
                l2 = d.LastIndexOf('/');
            }
            int rok = (int.Parse(d.Substring(0, l1)));
            int miesiac = (int.Parse(d.Substring(l1 + 1, l2)));
            int dzien = (int.Parse(d.Substring(l2 + 1)));
            if (rok < 1800 || rok > 2299)
            {
                return false;
            }
            if (dzien < 1 || dzien > 31)
            {
                return false;
            }
            if (miesiac > 12 || miesiac < 1)
            {
                return false;
            }
            if (pes != "0")
            {
                pes = pes.Substring(0, 6);
                int pesD = int.Parse(pes.Substring(0, 2));
                if (pesD != dzien)
                {
                    return false;
                }
                string rk = rok.ToString();
                if (rk.Substring(2) != pes.Substring(4))
                {
                    return false;
                }
                string w = pes.Substring(2, 3);
                if (miesiac < 10)
                {
                    if ((w == "8" && rk[2] == '8') || (w == "0" && rk[2] == '9') || (w == "4" && rk[2] == '1') || (w == "6" && rk[2] == '2'))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }

            return true;
        }
        bool fpesel(string p, string d, char m)
        {
            if (p.Length > 11)
            {
                return false;
            }
            int[] tablica = new int[10];
            int[] waga = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
            for (int i = 0; i < 10; i++)
            {
                tablica[i] = int.Parse(p.Substring(i, i + 1));
                tablica[i] *= waga[i];
            }
            int sum = tablica.Sum();
            sum %= 10;
            sum = 10 - sum;
            sum %= 10;
            if (sum != p[10])
            {
                return false;
            }
            if (int.Parse(p.Substring(9, 10)) % 2 == 0 && (m == 'M'))
            {
                return false;
            }
            if (int.Parse(p.Substring(9, 10)) % 2 == 1 && (m == 'K'))
            {
                return false;
            }
            if (fdata(d, p) == false)
            {
                return false;
            }
            return true;
        }
        public char fplec(string name)
        {
            int x = name.Length - 1;
            char [] y = name.ToCharArray();
            if (y[x]=='a')
            {
                return 'K';
            }
                return 'M';
        }
        string fnazwisko(string n)
        {
            n = n.Trim();
            char xzz = n[0];
            string xzzz = xzz.ToString();
            xzzz = xzzz.ToUpper();
            xzzz = xzz.ToString();
            xzzz = xzzz.ToUpper();
            n = xzzz + n.Substring(1);
            int xxx = n.IndexOf('-');
            if (xxx != -1)
            {
                xzz = n[xxx + 1];
                xzzz = xzz.ToString();
                xzzz = xzzz.ToUpper();
                n = n.Substring(0, xxx + 1) + xzzz + n.Substring(xxx + 2);
            }
            
            return n;
        }
        string fphone(string num)
        {
            int x = num.IndexOf("+");
            if(x==-1)
            {
                num = "+48" + num;
            }

            return num;
        }
        private void Dodaj(object sender, RoutedEventArgs e)
        {
            Window1 newWindow = new Window1();
            newWindow.ShowDialog();
            //if (fpesel(newWindow.xpes, newWindow.date_of_birth.ToString(),fplec(newWindow.xname)) == true)
            {
                newWindow.xsurname = fnazwisko(newWindow.xsurname);
                newWindow.xname = fnazwisko(newWindow.xname);
                newWindow.xname2nd = fnazwisko(newWindow.xname2nd);
                newWindow.xcity = fnazwisko(newWindow.xcity);
                newWindow.xadres = fnazwisko(newWindow.xadres);
                newWindow.xphone = fphone(newWindow.xphone);
                item x = new item(listView.Items.Count + 1, newWindow.xname, newWindow.xsurname, newWindow.xpes, newWindow.xname2nd, newWindow.xadres, newWindow.xcity, newWindow.xdate, newWindow.xphone, newWindow.xcode);
                listView.Items.Add(x);
            }
                
        }
    }
}