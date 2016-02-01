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

namespace ProjectArtStone
{
    /// <summary>
    /// Interaction logic for page3.xaml
    /// </summary>
    public partial class page3 : Window
    {
        public page3()
        {
            InitializeComponent();
            ArtworkDb.Artlist = ArtworkDb.GetArts();
            foreach (var item in ArtworkDb.Artlist)
            {
                listBox.Items.Add(item.Titel + " | rum: " + item.Rum);
            }   
        }

        private void btntillbaka_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Main m3 = new Main();
            m3.Show();
        }
    }
}
