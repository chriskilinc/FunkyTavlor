using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for uploadimagejamwindow2.xaml
    /// </summary>
    public partial class uploadimagejamwindow2 : Window
    {

        SqlConnection sqlCon = new SqlConnection(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=ProjektArtstoneJammingDb;Integrated Security=True");

        public uploadimagejamwindow2()
        {
            InitializeComponent();

            sqlCon.Open();
            DataSet ds = new DataSet();

            SqlDataAdapter sqa = new SqlDataAdapter("select name from picture", sqlCon);
            sqa.Fill(ds);

            sqlCon.Close();
            foreach (DataRow dataRow in ds.Tables[0].Rows)
            {
                ListBoxItem lbItem = new ListBoxItem();
                lbItem.Content = dataRow[0].ToString();
                lbpics.Items.Add(lbItem);

            }
        }

        private void btnexit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lbpics_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem lb = (lbpics.SelectedItem as ListBoxItem);
            sqlCon.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter sqa = new SqlDataAdapter("Select pic from picture where name='" + lb.Content.ToString() + "'", sqlCon);
            sqa.Fill(ds);
            sqlCon.Close();


        }
    }
}
