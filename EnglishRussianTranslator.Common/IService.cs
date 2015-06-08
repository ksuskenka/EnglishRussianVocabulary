using System.Collections.Generic;
using System.ServiceModel;
using EnglishRussianTranslator.Common.Models;

namespace EnglishRussianTranslator.Common
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        List<WordModel> GetWords(int languageId, string word);

        [OperationContract]
        List<LanguageModel> GetAllLanguages();

        [OperationContract]
        void AddWord(int languageId, TranslationModel translationVm);

        [OperationContract]
        void EditWord(int languageId, TranslationModel translationVm);

        [OperationContract]
        void DeleteWord(long wordId);

        [OperationContract]
        TranslationModel GetModel(int languageId, WordModel word);

    }
}
