using System;
using System.Collections.Generic;
using System.Linq;
using EnglishRussianTranslator.Common;
using EnglishRussianTranslator.DataLayer;
using EnglishRussianTranslator.Common.Models;

namespace EnglishRussianTranslator.Server
{
   public class Service:IService
    {
       public List<WordModel> GetWords(int languageId, string word)
       {
           List<WordModel> list = new List<WordModel>();
           DataBaseProvider db =new DataBaseProvider();
           list = db.GetWords(languageId, word)
               .Select(w=> new WordModel{ID = w.ID,TranslationWord = w.WordValue}).ToList();
           return list;}

       public List<LanguageModel> GetAllLanguages()
       {
           DataBaseProvider db = new DataBaseProvider();
           List<LanguageModel> languageList = db.GetLanguages()
               .Select(i => new LanguageModel{ID = i.ID, LanguageName = i.LanguageName }).ToList();
           return languageList;
       }
       public TranslationModel GetModel(int languageId, WordModel word)
       {
           DataBaseProvider db = new DataBaseProvider();
           TranslationModel returnedModel = db.GeTranslationModel(word.ID);

           return returnedModel;
       }

       public void DeleteWord(long wordId)
       {
           DataBaseProvider db = new DataBaseProvider();
           db.DeleteWord(wordId);
       }

       public void EditWord(int languageId, TranslationModel translationModel)
       {
           DataBaseProvider db = new DataBaseProvider();
           db.EditWord(languageId, translationModel);
       }

       public void AddWord(int languageId, TranslationModel translationModel)
       {
           DataBaseProvider db = new DataBaseProvider();
           db.AddWord(languageId, translationModel);
       }
    }
}
