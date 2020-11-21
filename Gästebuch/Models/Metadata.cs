namespace Gästebuch.Models
    {
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="Metadata" />.
    /// </summary>
    public class Metadata
        {
        /// <summary>
        /// Defines the Nachname.
        /// </summary>
        [StringLength(20)]
        [Display(Name = "Nachname")]
        public string Nachname;

        /// <summary>
        /// Defines the Vorname.
        /// </summary>
        [StringLength(20)]
        [Display(Name = "Vorname")]
        public string Vorname;

        /// <summary>
        /// Defines the Bewertung.
        /// </summary>
        [Range(0, 5)]
        [Display(Name = "Bewertung")]
        public String Bewertung;

        /// <summary>
        /// Defines the Verbesserungsvorschläge.
        /// </summary>
        [StringLength(255)]
        [Display(Name = "Vorschlag")]
        public string Verbesserungsvorschläge;

        /// <summary>
        /// Defines the Zeitpunkt.
        /// </summary>
        [Display(Name = "Zeitpunkt")]
        public Nullable<System.DateTime> Zeitpunkt;
        }
    }