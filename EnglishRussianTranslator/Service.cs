﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EnglishRussianTranslator.Common.Models
{
    using System.Runtime.Serialization;


    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "WordModel", Namespace = "http://schemas.datacontract.org/2004/07/EnglishRussianTranslator.Common.Models")]
    public partial class WordModel : object, System.Runtime.Serialization.IExtensibleDataObject
    {

        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        private long IDField;

        private string TranslationWordField;

        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public long ID
        {
            get
            {
                return this.IDField;
            }
            set
            {
                this.IDField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TranslationWord
        {
            get
            {
                return this.TranslationWordField;
            }
            set
            {
                this.TranslationWordField = value;
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "LanguageModel", Namespace = "http://schemas.datacontract.org/2004/07/EnglishRussianTranslator.Common.Models")]
    public partial class LanguageModel : object, System.Runtime.Serialization.IExtensibleDataObject
    {

        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        private int IDField;

        private string LanguageNameField;

        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ID
        {
            get
            {
                return this.IDField;
            }
            set
            {
                this.IDField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LanguageName
        {
            get
            {
                return this.LanguageNameField;
            }
            set
            {
                this.LanguageNameField = value;
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "TranslationModel", Namespace = "http://schemas.datacontract.org/2004/07/EnglishRussianTranslator.Common.Models")]
    public partial class TranslationModel : object, System.Runtime.Serialization.IExtensibleDataObject
    {

        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        private EnglishRussianTranslator.Common.Models.WordModel MainWordField;

        private EnglishRussianTranslator.Common.Models.WordModel[] TranslationListField;

        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public EnglishRussianTranslator.Common.Models.WordModel MainWord
        {
            get
            {
                return this.MainWordField;
            }
            set
            {
                this.MainWordField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public EnglishRussianTranslator.Common.Models.WordModel[] TranslationList
        {
            get
            {
                return this.TranslationListField;
            }
            set
            {
                this.TranslationListField = value;
            }
        }
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName = "IService")]
public interface IService
{

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IService/GetWords", ReplyAction = "http://tempuri.org/IService/GetWordsResponse")]
    EnglishRussianTranslator.Common.Models.WordModel[] GetWords(int languageId, string word);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IService/GetWords", ReplyAction = "http://tempuri.org/IService/GetWordsResponse")]
    System.Threading.Tasks.Task<EnglishRussianTranslator.Common.Models.WordModel[]> GetWordsAsync(int languageId, string word);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IService/GetAllLanguages", ReplyAction = "http://tempuri.org/IService/GetAllLanguagesResponse")]
    EnglishRussianTranslator.Common.Models.LanguageModel[] GetAllLanguages();

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IService/GetAllLanguages", ReplyAction = "http://tempuri.org/IService/GetAllLanguagesResponse")]
    System.Threading.Tasks.Task<EnglishRussianTranslator.Common.Models.LanguageModel[]> GetAllLanguagesAsync();

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IService/AddWord", ReplyAction = "http://tempuri.org/IService/AddWordResponse")]
    void AddWord(int languageId, EnglishRussianTranslator.Common.Models.TranslationModel translationVm);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IService/AddWord", ReplyAction = "http://tempuri.org/IService/AddWordResponse")]
    System.Threading.Tasks.Task AddWordAsync(int languageId, EnglishRussianTranslator.Common.Models.TranslationModel translationVm);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IService/EditWord", ReplyAction = "http://tempuri.org/IService/EditWordResponse")]
    void EditWord(int languageId, EnglishRussianTranslator.Common.Models.TranslationModel translationVm);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IService/EditWord", ReplyAction = "http://tempuri.org/IService/EditWordResponse")]
    System.Threading.Tasks.Task EditWordAsync(int languageId, EnglishRussianTranslator.Common.Models.TranslationModel translationVm);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IService/DeleteWord", ReplyAction = "http://tempuri.org/IService/DeleteWordResponse")]
    void DeleteWord(long wordId);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IService/DeleteWord", ReplyAction = "http://tempuri.org/IService/DeleteWordResponse")]
    System.Threading.Tasks.Task DeleteWordAsync(long wordId);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IService/GetModel", ReplyAction = "http://tempuri.org/IService/GetModelResponse")]
    EnglishRussianTranslator.Common.Models.TranslationModel GetModel(int languageId, EnglishRussianTranslator.Common.Models.WordModel word);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IService/GetModel", ReplyAction = "http://tempuri.org/IService/GetModelResponse")]
    System.Threading.Tasks.Task<EnglishRussianTranslator.Common.Models.TranslationModel> GetModelAsync(int languageId, EnglishRussianTranslator.Common.Models.WordModel word);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IServiceChannel : IService, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class ServiceClient : System.ServiceModel.ClientBase<IService>, IService
{

    public ServiceClient()
    {
    }

    public ServiceClient(string endpointConfigurationName) :
        base(endpointConfigurationName)
    {
    }

    public ServiceClient(string endpointConfigurationName, string remoteAddress) :
        base(endpointConfigurationName, remoteAddress)
    {
    }

    public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
        base(endpointConfigurationName, remoteAddress)
    {
    }

    public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
        base(binding, remoteAddress)
    {
    }

    public EnglishRussianTranslator.Common.Models.WordModel[] GetWords(int languageId, string word)
    {
        return base.Channel.GetWords(languageId, word);
    }

    public System.Threading.Tasks.Task<EnglishRussianTranslator.Common.Models.WordModel[]> GetWordsAsync(int languageId, string word)
    {
        return base.Channel.GetWordsAsync(languageId, word);
    }

    public EnglishRussianTranslator.Common.Models.LanguageModel[] GetAllLanguages()
    {
        return base.Channel.GetAllLanguages();
    }

    public System.Threading.Tasks.Task<EnglishRussianTranslator.Common.Models.LanguageModel[]> GetAllLanguagesAsync()
    {
        return base.Channel.GetAllLanguagesAsync();
    }

    public void AddWord(int languageId, EnglishRussianTranslator.Common.Models.TranslationModel translationVm)
    {
        base.Channel.AddWord(languageId, translationVm);
    }

    public System.Threading.Tasks.Task AddWordAsync(int languageId, EnglishRussianTranslator.Common.Models.TranslationModel translationVm)
    {
        return base.Channel.AddWordAsync(languageId, translationVm);
    }

    public void EditWord(int languageId, EnglishRussianTranslator.Common.Models.TranslationModel translationVm)
    {
        base.Channel.EditWord(languageId, translationVm);
    }

    public System.Threading.Tasks.Task EditWordAsync(int languageId, EnglishRussianTranslator.Common.Models.TranslationModel translationVm)
    {
        return base.Channel.EditWordAsync(languageId, translationVm);
    }

    public void DeleteWord(long wordId)
    {
        base.Channel.DeleteWord(wordId);
    }

    public System.Threading.Tasks.Task DeleteWordAsync(long wordId)
    {
        return base.Channel.DeleteWordAsync(wordId);
    }

    public EnglishRussianTranslator.Common.Models.TranslationModel GetModel(int languageId, EnglishRussianTranslator.Common.Models.WordModel word)
    {
        return base.Channel.GetModel(languageId, word);
    }

    public System.Threading.Tasks.Task<EnglishRussianTranslator.Common.Models.TranslationModel> GetModelAsync(int languageId, EnglishRussianTranslator.Common.Models.WordModel word)
    {
        return base.Channel.GetModelAsync(languageId, word);
    }
}