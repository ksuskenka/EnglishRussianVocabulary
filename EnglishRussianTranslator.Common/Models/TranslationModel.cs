using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EnglishRussianTranslator.Common.Models
{
    /// <summary>
    /// intermediate model for keeping translation of word
    /// </summary>
    [DataContract]
    public class TranslationModel
    {
        [DataMember]
        public WordModel MainWord { get; set; }

        [DataMember]
        public List<WordModel> TranslationList { get; set; }
    }
}
