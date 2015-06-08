namespace EnglishRussianTranslator.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Language")]
    public partial class Language
    {
        public Language()
        {
            Words = new HashSet<Word>();
        }

        public int ID { get; set; }

        [Required]
        public string LanguageName { get; set; }

        public virtual ICollection<Word> Words { get; set; }
    }
}
