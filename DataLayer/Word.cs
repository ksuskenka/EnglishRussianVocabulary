namespace EnglishRussianTranslator.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Word")]
    public partial class Word
    {
        public Word()
        {
            Translations = new HashSet<Translation>();
            Translations1 = new HashSet<Translation>();
        }

        public long ID { get; set; }

        [Required]
        public string WordValue { get; set; }

        public int LanguageID { get; set; }

        public virtual Language Language { get; set; }

        public virtual ICollection<Translation> Translations { get; set; }

        public virtual ICollection<Translation> Translations1 { get; set; }
    }
}
