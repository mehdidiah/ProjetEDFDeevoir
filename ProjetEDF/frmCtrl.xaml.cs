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

namespace ProjetEDF
{
    /// <summary>
    /// Logique d'interaction pour frmCtrl.xaml
    /// </summary>
    public partial class frmCtrl : Window
    {

        edfEntities gst;
        public frmCtrl(edfEntities unGst)
        {
            InitializeComponent();
            gst = unGst;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            //controleur leControleur = gst.controleur.ToList().Find(ctrl => ctrl.login == txtLogin.Text && ctrl.mdp == txtMdp.Text);

            //var query = from ctrl in gst.controleur
            //            join cl in gst.client
            //            on ctrl.id equals cl.idcontroleur
            //            where ctrl.id = cl.idcontroleur
            //            select new Client1
            //            {
            //                IdClient = cl.identifiant,
            //                NomClient = cl.nom,
            //                PrenomClient = cl.prenom,
            //                AncienReleve = cl.ancienReleve,
            //                NouveauReleve = cl.dernierReleve,
            //                Total = cl.dernierReleve - cl.ancienReleve
            //            };

            //lstClients.ItemsSource = query.ToList();
        }

        private void lstClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnInsererNewReleve_Click(object sender, RoutedEventArgs e)
        {
            if(txtNewReleve.Text == "")
            {
                MessageBox.Show("Veuillez saisir un relevé", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                gst.client.ToList().Find(cl => cl.dernierReleve.ToString() == txtNewReleve.Text);
            }
        }
    }
}
