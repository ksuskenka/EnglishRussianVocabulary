using System;
using System.Collections.Generic;
using System.Linq;
using EnglishRussianTranslator.Common.Models;


namespace EnglishRussianTranslator.DataLayer
{
    public class DataBaseProvider
    {
        #region getData operations
        public List<Word> GetWords(int langId, string searchWord)
        {
            List<Word> words = new List<Word>();
            using (var context = new EnglishRussianVocabulary())
            {
                if (string.IsNullOrEmpty(searchWord))
                {
                    words = context.Words.Where(w => w.LanguageID == langId).Take(20).ToList();
                }
                else
                {
                    words = context.Words.Where(w => w.LanguageID == langId && w.WordValue == searchWord).ToList();
                }

            }
            return words;
        }

        public List<Language> GetLanguages()
        {
            List<Language> languages = new List<Language>();
            using (var context = new EnglishRussianVocabulary())
            {
                languages = context.Languages.ToList();
            }
            return languages;
        }

        public TranslationModel GeTranslationModel(long wordId)
        {
            TranslationModel translationModel = new TranslationModel();
            if (wordId != 0)
            {
                using (var context = new EnglishRussianVocabulary())
                {
                    var word = context.Words.FirstOrDefault(w => w.ID == wordId);
                    if (word != null)
                    {
                        translationModel.MainWord = new WordModel { ID = word.ID, TranslationWord = word.WordValue };
                        translationModel.MainWord.TranslationWord = word.WordValue;

                        List<WordModel> wordTranslationList = new List<WordModel>();
                        switch (word.LanguageID)
                        {
                            case (int)LanguageEnum.English:
                                var rusList = context.Translations.Where(w => w.EnglishWordID == word.ID).ToList();
                                wordTranslationList.AddRange(rusList.
                                    Select(translation => context.Words.
                                        FirstOrDefault(w => w.ID == translation.RussianWordID)).
                                        Select(translationWord => new WordModel
                                {
                                    ID = translationWord.ID,
                                    TranslationWord = translationWord.WordValue
                                }));
                                translationModel.TranslationList = wordTranslationList;

                                break;
                            case (int)LanguageEnum.Russian:
                                var engList = context.Translations.Where(w => w.EnglishWordID == word.ID).ToList();
                                wordTranslationList.AddRange(engList.
                                   Select(translation => context.Words.
                                       FirstOrDefault(w => w.ID == translation.RussianWordID)).
                                       Select(translationWord => new WordModel
                               {
                                   ID = translationWord.ID,
                                   TranslationWord = translationWord.WordValue
                               }));
                                translationModel.TranslationList = wordTranslationList;
                                break;
                        }

                    }


                }
            }
            else
            {
                return null;
            }
            return translationModel;
        }
        #endregion

        #region manipulate words operations

        public void DeleteWord(long wordId)
        {
            using (var context = new EnglishRussianVocabulary())
            {
                var word = context.Words.FirstOrDefault(w => w.ID == wordId);
                if (word != null)
                {
                    if (word.LanguageID == (int)LanguageEnum.English)
                    {
                        var translationToDelete = context.Translations.Where(t => t.EnglishWordID == wordId);
                        foreach (var translation in translationToDelete)
                        {
                            context.Translations.Remove(translation);
                        }
                        context.Words.Remove(word);
                        context.SaveChanges();
                    }
                    else
                    {
                        var translationToDelete = context.Translations.Where(t => t.RussianWordID == wordId);
                        foreach (var translation in translationToDelete)
                        {
                            context.Translations.Remove(translation);
                        }
                        context.Words.Remove(word);
                        context.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("Данное слово не найдено в словаре");
                }
            }
        }

        public void AddWord(int langId, TranslationModel model)
        {
            using (var context = new EnglishRussianVocabulary())
            {
                if (context.Words.Any(w => w.WordValue == model.MainWord.TranslationWord))
                {
                    throw new Exception("Данное слово уже имеется в словаре");
                }
                else
                {
                    Word newWord = new Word { LanguageID = langId, WordValue = model.MainWord.TranslationWord };
                    context.Words.Add(newWord);
                    context.SaveChanges();
                    foreach (var wordModel in model.TranslationList)
                    {
                        if (!context.Words.Any(w => w.WordValue == wordModel.TranslationWord))
                        {
                            int langnewId = context.Languages.FirstOrDefault(l => l.ID != langId).ID;
                            Word newTranslationWord = new Word { LanguageID = langnewId, WordValue = wordModel.TranslationWord };
                            context.Words.Add(newTranslationWord);
                            context.SaveChanges();
                            if (langId == (int)LanguageEnum.English)
                            {
                                Translation transNew = new Translation { EnglishWordID = newWord.ID, RussianWordID = newTranslationWord.ID };
                                context.Translations.Add(transNew);
                            }
                            else
                            {
                                Translation transNew = new Translation { RussianWordID = newWord.ID, EnglishWordID = newTranslationWord.ID };
                                context.Translations.Add(transNew);
                            }
                        }
                        else
                        {
                            var wordExist = context.Words.FirstOrDefault(w => w.WordValue == wordModel.TranslationWord);
                            if (langId == (int)LanguageEnum.English)
                            {
                                Translation transNew = new Translation { EnglishWordID = newWord.ID, RussianWordID = wordExist.ID };
                                context.Translations.Add(transNew);
                            }
                            else
                            {
                                Translation transNew = new Translation { RussianWordID = newWord.ID, EnglishWordID = wordExist.ID };
                                context.Translations.Add(transNew);
                            }
                        }
                        context.SaveChanges();
                    }
                }
            }

        }

        public void EditWord(int langId, TranslationModel model)
        {
            using (var context = new EnglishRussianVocabulary())
            {
                Word wordForUpdate = context.Words.FirstOrDefault(w => w.ID == model.MainWord.ID);
                
                if (wordForUpdate != null)
                {
                    if (wordForUpdate.WordValue != model.MainWord.TranslationWord)
                    {
                        wordForUpdate.WordValue = model.MainWord.TranslationWord;
                    }
                    switch (langId)
                    {
                        case (int)LanguageEnum.Russian:
                            var translationListFromBd =
                                context.Translations.Where(t => t.RussianWordID == wordForUpdate.ID).ToList();

                            #region addNewTranslations
                            foreach (var wordModel in model.TranslationList)
                            {
                                if (wordModel.ID != 0)
                                {
                                    var translstionWord = context.Words.FirstOrDefault(w => w.ID == wordModel.ID);
                                    if (translstionWord != null)
                                    {
                                        if (translstionWord.WordValue != wordModel.TranslationWord)
                                        {
                                            translstionWord.WordValue = wordModel.TranslationWord;
                                            context.SaveChanges();
                                        }

                                        bool isExistTranslation =
                                            translationListFromBd.Any(t => t.RussianWordID == wordForUpdate.ID
                                                                          && t.EnglishWordID == translstionWord.ID);
                                        if (!isExistTranslation)
                                        {
                                            Translation tr = new Translation
                                            {
                                                RussianWordID = wordForUpdate.ID,
                                                EnglishWordID = translstionWord.ID
                                            };
                                            context.Translations.Add(tr);
                                            context.SaveChanges();
                                        }
                                    }
                                }
                                else
                                {
                                    var translstionWord = context.Words.FirstOrDefault(w => w.WordValue == wordModel.TranslationWord);
                                    if (translstionWord==null)
                                    {
                                        Word newTrWord = new Word
                                        {
                                            WordValue = wordModel.TranslationWord,
                                            LanguageID = (int)LanguageEnum.English
                                        };
                                        context.Words.Add(newTrWord);
                                        context.SaveChanges();
                                        Translation tr = new Translation
                                        {
                                            RussianWordID = wordForUpdate.ID,
                                            EnglishWordID = newTrWord.ID
                                        };
                                        context.Translations.Add(tr);
                                        context.SaveChanges();
                                    }
                                    else
                                    {
                                        Translation tr = new Translation
                                        {
                                            RussianWordID = wordForUpdate.ID,
                                            EnglishWordID = translstionWord.ID
                                        };
                                        context.Translations.Add(tr);
                                        context.SaveChanges();
                                    }
                                   

                                }
                            }
                            break;
                        case (int)LanguageEnum.English:
                            var translationListFromBd2 =
                                context.Translations.Where(t => t.EnglishWordID == wordForUpdate.ID).ToList();

                            
                            foreach (var wordModel in model.TranslationList)
                            {
                                if (wordModel.ID != 0)
                                {
                                    var translstionWord = context.Words.FirstOrDefault(w => w.ID == wordModel.ID);
                                    if (translstionWord != null)
                                    {
                                        if (translstionWord.WordValue != wordModel.TranslationWord)
                                        {
                                            translstionWord.WordValue = wordModel.TranslationWord;
                                            context.SaveChanges();
                                        }

                                        bool isExistTranslation =
                                            translationListFromBd2.Any(t => t.RussianWordID == translstionWord.ID
                                                                          && t.EnglishWordID == wordForUpdate.ID );
                                        if (!isExistTranslation)
                                        {
                                            Translation tr = new Translation
                                            {
                                                RussianWordID =translstionWord.ID ,
                                                EnglishWordID = wordForUpdate.ID
                                            };
                                            context.Translations.Add(tr);
                                            context.SaveChanges();
                                        }
                                    }
                                }
                                else
                                {
                                     var translstionWord = context.Words.FirstOrDefault(w => w.WordValue == wordModel.TranslationWord);
                                    if (translstionWord == null)
                                    {
                                        Word newTrWord = new Word
                                        {
                                            WordValue = wordModel.TranslationWord,
                                            LanguageID = (int) LanguageEnum.Russian
                                        };
                                        context.Words.Add(newTrWord);
                                        context.SaveChanges();
                                        Translation tr = new Translation
                                        {
                                            RussianWordID = newTrWord.ID,
                                            EnglishWordID = wordForUpdate.ID
                                        };
                                        context.Translations.Add(tr);
                                        context.SaveChanges();
                                    }
                                    else
                                    {
                                        Translation tr = new Translation
                                        {
                                            RussianWordID = translstionWord.ID,
                                            EnglishWordID = wordForUpdate.ID
                                        };
                                        context.Translations.Add(tr);
                                        context.SaveChanges();
                                    }
                                }
                            }
                            break;
                            #endregion
                    }
                    #region DeleteNotNecessary
                    var translationListFromBdTodelete = GeTranslationModel(model.MainWord.ID).TranslationList;
                    foreach (var wordModel in translationListFromBdTodelete)
                    {
                        if (model.TranslationList.All(tr => tr.TranslationWord != wordModel.TranslationWord))
                        {
                            switch (langId)
                            {
                                case (int)LanguageEnum.Russian:
                                    var translationToDelete =
                                        context.Translations.FirstOrDefault(
                                            tr => tr.RussianWordID == model.MainWord.ID
                                                  && tr.EnglishWordID == wordModel.ID);
                                    context.Translations.Remove(translationToDelete);
                                    break;
                                case (int)LanguageEnum.English:
                                    var translationToDelete2 =
                                        context.Translations.FirstOrDefault(
                                            tr => tr.EnglishWordID == model.MainWord.ID
                                                  && tr.RussianWordID == wordModel.ID);
                                    context.Translations.Remove(translationToDelete2);
                                    break;
                            }

                        }
                        context.SaveChanges();
                    }
                    #endregion

                }
            }
        }
        #endregion
    }
}
