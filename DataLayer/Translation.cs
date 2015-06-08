namespace EnglishRussianTranslator.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Translation")]
    public partial class Translation
    {
        public long ID { get; set; }

        public long EnglishWordID { get; set; }

        public long RussianWordID { get; set; }

        public virtual Word Word { get; set; }

        public virtual Word Word1 { get; set; }
    }
}
