//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjetEDF
{
    using System;
    using System.Collections.Generic;
    
    public partial class client
    {
        public int identifiant { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public int ancienReleve { get; set; }
        public int dernierReleve { get; set; }
        public int idcontroleur { get; set; }
    
        public virtual controleur controleur { get; set; }
    }
}
