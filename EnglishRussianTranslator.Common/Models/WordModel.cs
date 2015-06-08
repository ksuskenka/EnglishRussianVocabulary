using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EnglishRussianTranslator.Common.Models
{
    /// <summary>
    /// intermediate model for keeping word
    /// </summary>
    [DataContract]
    public class WordModel
    {
        [DataMember]
        public long ID { get; set; }

        [DataMember]
        public string TranslationWord { get; set; }
    }
}
