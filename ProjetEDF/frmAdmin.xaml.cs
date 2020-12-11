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
    /// Logique d'interaction pour frmAdmin.xaml
    /// </summary>
    public partial class frmAdmin : Window
    {

        edfEntities gst;
        public frmAdmin(edfEntities unGst)
        {
            InitializeComponent();
            gst = unGst;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lstControleurs.ItemsSource = gst.controleur.ToList();
        }

        private void lstControleurs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //int numClient = (lstControleurs.SelectedItem as client).idcontroleur;
            
            if(lstControleurs.SelectedItem != null)
            {
                //int numClient = (lstControleurs.SelectedItem as client).idcontroleur;

                //lstClients.ItemsSource = gst.client.ToList().FindAll(ctrl => ctrl.idcontroleur == (lstControleurs.SelectedItem as controleur).id);
                int idControleur = (lstControleurs.SelectedItem as controleur).id;
                var query = from ctrl in gst.controleur
                            join cl in gst.client
                            on ctrl.id equals cl.idcontroleur
                            where cl.idcontroleur == idControleur
                            select new Client1
                            {
                                IdClient = cl.identifiant,
                                NomClient = cl.nom,
                                PrenomClient = cl.prenom,
                                AncienReleve = cl.ancienReleve,
                                NouveauReleve = cl.dernierReleve,
                                Total = cl.dernierReleve - cl.ancienReleve
                            };

                lstClients.ItemsSource = query.ToList();
            }
        }

        private void lstClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnInsererControleur_Click(object sender, RoutedEventArgs e)
        {
            if(txtNomControleur.Text == "")
            {
                MessageBox.Show("Veuillez entrer le nom du contrôleur", "Nom du contrôleur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if(txtPrenomControleur.Text == "")
            {
                MessageBox.Show("Veuillez entrer le prénom du contrôleur", "Prénom du contrôleur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {

                controleur ctrl = new controleur()
                {
                    //id = gst.controleur.Find().id.
                    id = (gst.controleur.ToList().Max(c=>c.id))+1,
                    nom = txtNomControleur.Text,
                    prenom = txtPrenomControleur.Text,
                    login = txtPrenomControleur.Text.Substring(0, 1).ToLower() + txtNomControleur.Text.Substring(0, 1).ToLower(),
                    mdp = txtPrenomControleur.Text.Substring(0, 1).ToLower() + txtNomControleur.Text.Substring(0, 1).ToLower() + 123,
                    statut = "ctrl"

                };

                gst.controleur.Add(ctrl);
                gst.SaveChanges();

                lstControleurs.ItemsSource = null;
                lstControleurs.ItemsSource = gst.controleur.ToList();
            }
        }

        private void btnInsererClient_Click(object sender, RoutedEventArgs e)
        {
            if(lstControleurs.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un controleur", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else if(txtNomClient.Text == "")
            {
                MessageBox.Show("Veuillez entrer le nom du client", "Nom du client", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (txtPrenomClient.Text == "")
            {
                MessageBox.Show("Veuillez entrer le prénom du client", "Prénom du client", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else
            {
                //int idControleur = (lstControleurs.SelectedItem as controleur).id;
                //var query = from ctrl in gst.controleur
                //            join cli in gst.client
                //            on ctrl.id equals cli.idcontroleur
                //            where cli.idcontroleur == idControleur
                //            select new Client1 
                //            {
                //                IdClient = (gst.client.ToList().Max(cli => cli.identifiant)) + 1,
                //                NomClient = txtNomClient.Text,
                //                PrenomClient = txtPrenomClient.Text,
                //                AncienReleve = 0,
                //                NouveauReleve = 0,
                //                Total = cli.dernierReleve - cli.ancienReleve
                //            };
                int numControleur = (lstControleurs.SelectedItem as controleur).id;
                var query = from ctrl in gst.controleur
                            join cli in gst.client
                            on ctrl.id equals cli.idcontroleur
                            where cli.idcontroleur == numControleur
                            select new Client1
                            {
                                IdClient = (gst.client.ToList().Max(cli => cli.identifiant)) + 1,
                                NomClient = txtNomClient.Text,
                                PrenomClient = txtPrenomClient.Text,
                                AncienReleve = 0,
                                NouveauReleve = 0,
                                Total = cli.dernierReleve - cli.ancienReleve
                            };

                gst.SaveChanges();
                lstClients.ItemsSource = null;
                lstClients.ItemsSource = query.ToList();


                //gst.client.Add(c1);
            }
        }

    }
}
