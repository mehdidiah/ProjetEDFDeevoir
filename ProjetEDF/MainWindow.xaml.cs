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

namespace ProjetEDF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        edfEntities gst;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gst = new edfEntities();

        }


        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {


            controleur leControleur = gst.controleur.ToList().Find(ctrl => ctrl.login == txtLogin.Text && ctrl.mdp == txtMdp.Text);

            if(leControleur == null)
            {
                txtErreurLogin.Text = "erreur de saisie";
            }
            else if(leControleur.statut == "admin")
            {
                frmAdmin frmA = new frmAdmin(gst);
                frmA.Show();
            }
            else
            {
                frmCtrl frmC = new frmCtrl(gst);
                frmC.Show();
            }
        }
    }
}
