using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PhoneSendEmail8._1.Resources;
using Microsoft.Phone.Tasks;

namespace PhoneSendEmail8._1
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        /// <summary>
        /// Lors du clique sur le bouton rechercher un contacte
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EmailAddressChooserTask emailSearch = new EmailAddressChooserTask();
            emailSearch.Completed += emailSearch_Completed;
            emailSearch.Show();
        }

        /// <summary>
        /// Lors de la fin de l'événement de la recherche d'un contact
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void emailSearch_Completed(object sender, EmailResult e)
        {
            //teste une erreur
            if (e.Error != null)
            {
                System.Diagnostics.Debug.WriteLine(e.Error.Message);
            }
            else
            {
                //récupération du contact
                var contactEmail = e.Email;
                var contactName = e.DisplayName;
                this.txtEmail.Text = contactEmail;
                this.txtName.Text = contactName;
            }
        }

        /// <summary>
        /// Envoi un mail a la personne 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sendMail_Click(object sender, RoutedEventArgs e)
        {
            EmailComposeTask emailCompose = new EmailComposeTask();
            emailCompose.Body = "Mon corps de mail a envoyé.";
            emailCompose.To = this.txtEmail.Text;//récupération de l'adresse via le champ TextBlock
            emailCompose.Subject = "Email de test";
            emailCompose.Show();
        }
    }
}