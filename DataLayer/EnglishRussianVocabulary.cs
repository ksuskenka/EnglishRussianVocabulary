using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EnglishRussianTranslator.DataLayer
{
    public class EnglishRussianVocabulary:DbContext
    {
        public EnglishRussianVocabulary()
            : base("name=EnglishRussianVocabulary")
        {
        }

        public DbSet<Language> Languages { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<Translation> Translations { get; set; }
        public DbSet<TranslationView> TranslationViews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>()
                .HasMany(e => e.Words)
                .WithRequired(e => e.Language)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Word>()
                .HasMany(e => e.Translations)
                .WithRequired(e => e.Word)
                .HasForeignKey(e => e.EnglishWordID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Word>()
                .HasMany(e => e.Translations1)
                .WithRequired(e => e.Word1)
                .HasForeignKey(e => e.RussianWordID)
                .WillCascadeOnDelete(false);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
