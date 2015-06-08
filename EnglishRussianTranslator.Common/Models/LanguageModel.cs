using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EnglishRussianTranslator.Common.Models
{
    [DataContract]
    public class LanguageModel
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string LanguageName { get; set; }

    }
}
