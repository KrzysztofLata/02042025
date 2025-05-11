using Microsoft.Win32;
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
using System.Collections.ObjectModel;
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
        public string name2nd { get; set; }
        public string adres { get; set; }
        public string city { get; set; }
        public string date { get; set; }
        public string phone { get; set; }
        public string code { get; set; }
        public item()
        {

        }
        public item(int i, string n, string s, string p, string n2, string a, string c, string d, string ph, string co)
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
                if (int.TryParse(dddd, out _) == false && d[i] != '.')
                {
                    return false;
                }
            }
            int l1 = d.IndexOf('.');
            int l2 = d.LastIndexOf('.');
            int dzien = (int.Parse(d.Substring(0, 2)));
            int miesiac = (int.Parse(d.Substring(l1 + 1, 2)));
            int rok = (int.Parse(d.Substring(l2 + 1)));
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
                int pesD = int.Parse(pes.Substring(4, 2));
                if (pesD != dzien)
                {
                    return false;
                }
                string rk = rok.ToString();
                if (rk.Substring(2) != pes.Substring(0, 2))
                {
                    return false;
                }
                string w = pes.Substring(2, 1);
                Console.WriteLine(rk[1]);
                if (miesiac < 10)
                {
                    if ((w == "8" && rk[1] == '8') || (w == "0" && rk[1] == '9') || (w == "4" && rk[1] == '1') || (w == "2" && rk[1] == '0'))
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
        char fplec(string name)
        {
            char[] y = name.ToCharArray();
            int x = y.Length - 1;
            if (y[x] == 'a')
            {
                return 'K';
            }
            return 'M';
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
                tablica[i] = int.Parse(p.Substring(i, 1));
                tablica[i] *= waga[i];
                if (tablica[i] > 9)
                {
                    tablica[i] = tablica[i] % 10;
                }

            }
            int sum = tablica.Sum();
            sum %= 10;
            sum = 10 - sum;
            if (sum == 10)
            {
                sum = 0;
            }
            if (sum != Int32.Parse(p[10].ToString()))
            {
                return false;
            }
            if (int.Parse(p.Substring(9, 1)) % 2 == 0 && (m == 'M'))
            {
                return false;
            }
            if (int.Parse(p.Substring(9, 1)) % 2 == 0 && (m == 'K'))
            {
                return false;
            }
            if (fdata(d, p) == false)
            {
                return false;
            }
            return true;
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
            if (x == -1 && num.Length == 9)
            {
                num = "+48" + num;
            }

            return num;
        }
        private void Dodaj(object sender, RoutedEventArgs e)
        {
            Window1 newWindow = new Window1();
            newWindow.ShowDialog();
            if (fpesel(newWindow.xpes, newWindow.xdate, fplec(newWindow.xname)) == true)
            {
                newWindow.xsurname = fnazwisko(newWindow.xsurname);
                newWindow.xname = fnazwisko(newWindow.xname);
                if (newWindow.xname2nd.Length > 0) newWindow.xname2nd = fnazwisko(newWindow.xname2nd);
                newWindow.xcity = fnazwisko(newWindow.xcity);
                newWindow.xadres = fnazwisko(newWindow.xadres);
                newWindow.xphone = fphone(newWindow.xphone);
                item x = new item(listView.Items.Count + 1, newWindow.xname, newWindow.xsurname, newWindow.xpes, newWindow.xname2nd, newWindow.xadres, newWindow.xcity, newWindow.xdate, newWindow.xphone, newWindow.xcode);
                listView.Items.Add(x);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            while (listView.SelectedItems.Count > 0)
            {
                listView.Items.Remove(listView.SelectedItems[0]);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Pliki CSV z separatorem (,) |*.csv|Pliki CSV z separatorem (;) |*.csv";
            saveFileDialog.Title = "Zapisz jako plik CSV";
            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                string delimiter = ";";
                if (saveFileDialog.FilterIndex == 1)
                {
                    delimiter = ",";
                }
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (item item in listView.Items)
                    {
                        var row = $"{item.id}{delimiter}{item.name}{delimiter}{item.name2nd}{delimiter}"+
                            $"{item.surname}{delimiter}{item.date}{delimiter}{item.pesel}{delimiter}"+
                            $"{item.code}{delimiter}{item.city}{delimiter}{item.adres}{delimiter}{item.phone}";
                        writer.WriteLine(row);
                    }
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            ///funkcja menu „open”:
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Pliki CSV z separatorem (,) |*.csv|Pliki CSV z separatorem (;) |*.csv";
            openFileDialog.Title = "Otwórz plik CSV";
            if (openFileDialog.ShowDialog() == true)
            {
                listView.Items.Clear();
                string filePath = openFileDialog.FileName;
                int selectedFilterIndex = openFileDialog.FilterIndex;
                string delimiter = ";";
                if (selectedFilterIndex == 1)
                {
                    delimiter = ",";
                }
                Encoding encoding = Encoding.UTF8;
                if (File.Exists(filePath))
                {
                    var lines = File.ReadAllLines(filePath, encoding);
                    foreach (var line in lines)
                    {
                        string[] columns = line.Split(delimiter);
                        if (columns != null)
                        {
                            item uczen = new item();
                            uczen.pesel = columns.ElementAtOrDefault(5);
                            uczen.name = columns.ElementAtOrDefault(1);
                            uczen.name2nd = columns.ElementAtOrDefault(2);
                            uczen.surname = columns.ElementAtOrDefault(3);
                            uczen.date = columns.ElementAtOrDefault(4);
                            uczen.code = columns.ElementAtOrDefault(6);
                            uczen.city = columns.ElementAtOrDefault(7);
                            uczen.adres = columns.ElementAtOrDefault(8);
                            uczen.phone = columns.ElementAtOrDefault(9);
                            int id = Int32.Parse(columns.ElementAtOrDefault(0));
                            uczen.id =id;
                            listView.Items.Add(uczen);

                        }
                    }
                }
            }
        }

    }
}