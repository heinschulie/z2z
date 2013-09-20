using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zephry;

namespace Z2Z
{
    public class UserImplementation
    {    
        #region Client Methods

        /// <summary>
        ///   Gets the <see cref="Client"/> by Key.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns>Client as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetClient(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetClient");
            }
            Client vClient = new Client();
            vClient = XmlUtils.Deserialize<Client>(aXmlArgument);
            ClientBusiness.Load(aUserKey, vClient);
            return XmlUtils.Serialize<Client>(vClient, true);
        }

        /// <summary>
        ///   The <c>GetClientCollection</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="ClientCollection"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="ClientBusiness"/> with the newly deserialized <see cref="ClientCollection"/> object.
        ///   Finally, it returns the collection object as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="ClientCollection"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetClientCollection(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetClientCollection");
            }
            ClientCollection vClientCollection = new ClientCollection();
            vClientCollection = XmlUtils.Deserialize<ClientCollection>(aXmlArgument);
            ClientBusiness.Load(aUserKey, vClientCollection);
            return XmlUtils.Serialize<ClientCollection>(vClientCollection, true);
        }

        /// <summary>
        ///   The <c>AddClient</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="Client"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="ClientBusiness"/> with the newly deserialized <see cref="Client"/> object.
        ///   Finally, it returns the inserted object (now with an assigned Client Key) as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="Client"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string AddClient(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of AddClient");
            }
            Client vClient = new Client();
            vClient = XmlUtils.Deserialize<Client>(aXmlArgument);
            ClientBusiness.Insert(aUserKey, vClient);
            return XmlUtils.Serialize<Client>(vClient, true);
        }

        /// <summary>
        ///   The <c>EditClient</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="Client"/> object.
        ///   It invokes the <c>Update</c> method of <see cref="ClientBusiness"/> with the newly deserialized <see cref="Client"/> object.
        ///   Finally, it returns the updated object unchanged as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="Client"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string EditClient(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of EditClient");
            }
            Client vClient = new Client();
            vClient = XmlUtils.Deserialize<Client>(aXmlArgument);
            ClientBusiness.Update(aUserKey, vClient);
            return XmlUtils.Serialize<Client>(vClient, true);
        }

        /// <summary>
        ///   The <c>DeleteClient</c> implementation method deserializes an incoming XML Argument as a new <see cref="Client"/> object.
        ///   It invokes the <c>Delete</c> method of <see cref="ClientBusiness"/> with the newly deserialized <see cref="Client"/> object.
        ///   Finally, it returns the Deleted object unchanged as a serialized <c>string</c> of XML.
        /// </summary>
        /// <param name="aXmlArgument">A XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="Client"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string DeleteClient(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of DeleteClient");
            }
            Client vClient = new Client();
            vClient = XmlUtils.Deserialize<Client>(aXmlArgument);
            ClientBusiness.Delete(aUserKey, vClient);
            return XmlUtils.Serialize<Client>(vClient, true);
        }
        #endregion

        //#region ClientProxy Methods

        ///// <summary>
        /////   The <c>GetClientProxyCollection</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="ClientProxyCollection"/> object.
        /////   It invokes the <c>Insert</c> method of <see cref="ClientBusiness"/> with the newly deserialized <see cref="ClientProxyCollection"/> object.
        /////   Finally, it returns the collection object as a serialized <see cref="string"/> of XML.
        ///// </summary>
        ///// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        ///// <returns><see cref="ClientProxyCollection"/> as XML <see cref="string"/>.</returns>
        ///// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        //public static string GetClientProxyCollection(UserKey aUserKey, string aXmlArgument)
        //{
        //    if (aXmlArgument == null)
        //    {
        //        throw new ArgumentNullException("aXmlArgument of GetClientProxyCollection");
        //    }
        //    ClientProxyCollection vClientProxyCollection = new ClientProxyCollection();
        //    vClientProxyCollection = XmlUtils.Deserialize<ClientProxyCollection>(aXmlArgument);
        //    ClientProxyBusiness.Load(aUserKey, vClientProxyCollection);
        //    return XmlUtils.Serialize<ClientProxyCollection>(vClientProxyCollection, true);
        //}

        //#endregion

        #region Contributor Methods

        /// <summary>
        ///   Gets the <see cref="Contributor"/> by Key.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns>Contributor as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetContributor(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetContributor");
            }
            Contributor vContributor = new Contributor();
            vContributor = XmlUtils.Deserialize<Contributor>(aXmlArgument);
            ContributorBusiness.Load(aUserKey, vContributor);
            return XmlUtils.Serialize<Contributor>(vContributor, true);
        }

        /// <summary>
        ///   The <c>GetContributorCollection</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="ContributorCollection"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="ContributorBusiness"/> with the newly deserialized <see cref="ContributorCollection"/> object.
        ///   Finally, it returns the collection object as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="ContributorCollection"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetContributorCollection(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetContributorCollection");
            }
            ContributorCollection vContributorCollection = new ContributorCollection();
            vContributorCollection = XmlUtils.Deserialize<ContributorCollection>(aXmlArgument);
            ContributorBusiness.Load(aUserKey, vContributorCollection);
            return XmlUtils.Serialize<ContributorCollection>(vContributorCollection, true);
        }

        /// <summary>
        ///   The <c>AddContributor</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="Contributor"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="ContributorBusiness"/> with the newly deserialized <see cref="Contributor"/> object.
        ///   Finally, it returns the inserted object (now with an assigned Contributor Key) as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="Contributor"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string AddContributor(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of AddContributor");
            }
            Contributor vContributor = new Contributor();
            vContributor = XmlUtils.Deserialize<Contributor>(aXmlArgument);
            ContributorBusiness.Insert(aUserKey, vContributor);
            return XmlUtils.Serialize<Contributor>(vContributor, true);
        }

        /// <summary>
        ///   The <c>EditContributor</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="Contributor"/> object.
        ///   It invokes the <c>Update</c> method of <see cref="ContributorBusiness"/> with the newly deserialized <see cref="Contributor"/> object.
        ///   Finally, it returns the updated object unchanged as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="Contributor"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string EditContributor(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of EditContributor");
            }
            Contributor vContributor = new Contributor();
            vContributor = XmlUtils.Deserialize<Contributor>(aXmlArgument);
            ContributorBusiness.Update(aUserKey, vContributor);
            return XmlUtils.Serialize<Contributor>(vContributor, true);
        }

        /// <summary>
        ///   The <c>DeleteContributor</c> implementation method deserializes an incoming XML Argument as a new <see cref="Contributor"/> object.
        ///   It invokes the <c>Delete</c> method of <see cref="ContributorBusiness"/> with the newly deserialized <see cref="Contributor"/> object.
        ///   Finally, it returns the Deleted object unchanged as a serialized <c>string</c> of XML.
        /// </summary>
        /// <param name="aXmlArgument">A XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="Contributor"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string DeleteContributor(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of DeleteContributor");
            }
            Contributor vContributor = new Contributor();
            vContributor = XmlUtils.Deserialize<Contributor>(aXmlArgument);
            ContributorBusiness.Delete(aUserKey, vContributor);
            return XmlUtils.Serialize<Contributor>(vContributor, true);
        }

        #endregion

        #region ContributorLanguage Methods

        /// <summary>
        ///   Gets the <see cref="ContributorLanguage"/> by Key.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns>ContributorLanguage as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetContributorLanguage(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetContributorLanguage");
            }
            ContributorLanguage vContributorLanguage = new ContributorLanguage();
            vContributorLanguage = XmlUtils.Deserialize<ContributorLanguage>(aXmlArgument);
            ContributorLanguageBusiness.Load(aUserKey, vContributorLanguage);
            return XmlUtils.Serialize<ContributorLanguage>(vContributorLanguage, true);
        }

        /// <summary>
        ///   The <c>GetContributorLanguageCollection</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="ContributorLanguageCollection"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="ContributorLanguageBusiness"/> with the newly deserialized <see cref="ContributorLanguageCollection"/> object.
        ///   Finally, it returns the collection object as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="ContributorLanguageCollection"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetContributorLanguageCollection(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetContributorLanguageCollection");
            }
            ContributorLanguageCollection vContributorLanguageCollection = new ContributorLanguageCollection();
            vContributorLanguageCollection = XmlUtils.Deserialize<ContributorLanguageCollection>(aXmlArgument);
            ContributorLanguageBusiness.Load(aUserKey, vContributorLanguageCollection);
            return XmlUtils.Serialize<ContributorLanguageCollection>(vContributorLanguageCollection, true);
        }

        /// <summary>
        ///   The <c>AddContributorLanguage</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="ContributorLanguage"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="ContributorLanguageBusiness"/> with the newly deserialized <see cref="ContributorLanguage"/> object.
        ///   Finally, it returns the inserted object (now with an assigned ContributorLanguage Key) as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="ContributorLanguage"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string AddContributorLanguage(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of AddContributorLanguage");
            }
            ContributorLanguage vContributorLanguage = new ContributorLanguage();
            vContributorLanguage = XmlUtils.Deserialize<ContributorLanguage>(aXmlArgument);
            ContributorLanguageBusiness.Insert(aUserKey, vContributorLanguage);
            return XmlUtils.Serialize<ContributorLanguage>(vContributorLanguage, true);
        }

        /// <summary>
        ///   The <c>EditContributorLanguage</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="ContributorLanguage"/> object.
        ///   It invokes the <c>Update</c> method of <see cref="ContributorLanguageBusiness"/> with the newly deserialized <see cref="ContributorLanguage"/> object.
        ///   Finally, it returns the updated object unchanged as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="ContributorLanguage"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string EditContributorLanguage(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of EditContributorLanguage");
            }
            ContributorLanguage vContributorLanguage = new ContributorLanguage();
            vContributorLanguage = XmlUtils.Deserialize<ContributorLanguage>(aXmlArgument);
            ContributorLanguageBusiness.Update(aUserKey, vContributorLanguage);
            return XmlUtils.Serialize<ContributorLanguage>(vContributorLanguage, true);
        }

        /// <summary>
        ///   The <c>DeleteContributorLanguage</c> implementation method deserializes an incoming XML Argument as a new <see cref="ContributorLanguage"/> object.
        ///   It invokes the <c>Delete</c> method of <see cref="ContributorLanguageBusiness"/> with the newly deserialized <see cref="ContributorLanguage"/> object.
        ///   Finally, it returns the Deleted object unchanged as a serialized <c>string</c> of XML.
        /// </summary>
        /// <param name="aXmlArgument">A XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="ContributorLanguage"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string DeleteContributorLanguage(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of DeleteContributorLanguage");
            }
            ContributorLanguage vContributorLanguage = new ContributorLanguage();
            vContributorLanguage = XmlUtils.Deserialize<ContributorLanguage>(aXmlArgument);
            ContributorLanguageBusiness.Delete(aUserKey, vContributorLanguage);
            return XmlUtils.Serialize<ContributorLanguage>(vContributorLanguage, true);
        }

        #endregion

        #region Document Methods

        /// <summary>
        ///   Gets the <see cref="Document"/> by Key.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns>Document as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetDocument(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetDocument");
            }
            Document vDocument = new Document();
            vDocument = XmlUtils.Deserialize<Document>(aXmlArgument);
            DocumentBusiness.Load(aUserKey, vDocument);
            return XmlUtils.Serialize<Document>(vDocument, true);
        }

        /// <summary>
        ///   The <c>GetDocumentCollection</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="DocumentCollection"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="DocumentBusiness"/> with the newly deserialized <see cref="DocumentCollection"/> object.
        ///   Finally, it returns the collection object as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="DocumentCollection"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetDocumentCollection(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetDocumentCollection");
            }
            DocumentCollection vDocumentCollection = new DocumentCollection();
            vDocumentCollection = XmlUtils.Deserialize<DocumentCollection>(aXmlArgument);
            DocumentBusiness.Load(aUserKey, vDocumentCollection);
            return XmlUtils.Serialize<DocumentCollection>(vDocumentCollection, true);
        }

        /// <summary>
        ///   The <c>AddDocument</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="Document"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="DocumentBusiness"/> with the newly deserialized <see cref="Document"/> object.
        ///   Finally, it returns the inserted object (now with an assigned Document Key) as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="Document"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string AddDocument(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of AddDocument");
            }
            Document vDocument = new Document();
            vDocument = XmlUtils.Deserialize<Document>(aXmlArgument);
            DocumentBusiness.Insert(aUserKey, vDocument);
            return XmlUtils.Serialize<Document>(vDocument, true);
        }

        /// <summary>
        ///   The <c>EditDocument</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="Document"/> object.
        ///   It invokes the <c>Update</c> method of <see cref="DocumentBusiness"/> with the newly deserialized <see cref="Document"/> object.
        ///   Finally, it returns the updated object unchanged as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="Document"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string EditDocument(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of EditDocument");
            }
            Document vDocument = new Document();
            vDocument = XmlUtils.Deserialize<Document>(aXmlArgument);
            DocumentBusiness.Update(aUserKey, vDocument);
            return XmlUtils.Serialize<Document>(vDocument, true);
        }

        /// <summary>
        ///   The <c>DeleteDocument</c> implementation method deserializes an incoming XML Argument as a new <see cref="Document"/> object.
        ///   It invokes the <c>Delete</c> method of <see cref="DocumentBusiness"/> with the newly deserialized <see cref="Document"/> object.
        ///   Finally, it returns the Deleted object unchanged as a serialized <c>string</c> of XML.
        /// </summary>
        /// <param name="aXmlArgument">A XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="Document"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string DeleteDocument(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of DeleteDocument");
            }
            Document vDocument = new Document();
            vDocument = XmlUtils.Deserialize<Document>(aXmlArgument);
            DocumentBusiness.Delete(aUserKey, vDocument);
            return XmlUtils.Serialize<Document>(vDocument, true);
        }

        #endregion

        #region Function Methods

        /// <summary>
        ///   Gets the <see cref="Function"/> by Key.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns>Function as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetFunction(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetFunction");
            }
            Function vFunction = new Function();
            vFunction = XmlUtils.Deserialize<Function>(aXmlArgument);
            FunctionBusiness.Load(aUserKey, vFunction);
            return XmlUtils.Serialize<Function>(vFunction, true);
        }

        /// <summary>
        ///   The <c>GetFunctionCollection</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="FunctionCollection"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="FunctionBusiness"/> with the newly deserialized <see cref="FunctionCollection"/> object.
        ///   Finally, it returns the collection object as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="FunctionCollection"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetFunctionCollection(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetFunctionCollection");
            }
            FunctionCollection vFunctionCollection = new FunctionCollection();
            vFunctionCollection = XmlUtils.Deserialize<FunctionCollection>(aXmlArgument);
            FunctionBusiness.Load(aUserKey, vFunctionCollection);
            return XmlUtils.Serialize<FunctionCollection>(vFunctionCollection, true);
        }

        /// <summary>
        ///   The <c>AddFunction</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="Function"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="FunctionBusiness"/> with the newly deserialized <see cref="Function"/> object.
        ///   Finally, it returns the inserted object (now with an assigned Function Key) as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="Function"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string AddFunction(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of AddFunction");
            }
            Function vFunction = new Function();
            vFunction = XmlUtils.Deserialize<Function>(aXmlArgument);
            FunctionBusiness.Insert(aUserKey, vFunction);
            return XmlUtils.Serialize<Function>(vFunction, true);
        }

        /// <summary>
        ///   The <c>EditFunction</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="Function"/> object.
        ///   It invokes the <c>Update</c> method of <see cref="FunctionBusiness"/> with the newly deserialized <see cref="Function"/> object.
        ///   Finally, it returns the updated object unchanged as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="Function"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string EditFunction(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of EditFunction");
            }
            Function vFunction = new Function();
            vFunction = XmlUtils.Deserialize<Function>(aXmlArgument);
            FunctionBusiness.Update(aUserKey, vFunction);
            return XmlUtils.Serialize<Function>(vFunction, true);
        }

        /// <summary>
        ///   The <c>DeleteFunction</c> implementation method deserializes an incoming XML Argument as a new <see cref="Function"/> object.
        ///   It invokes the <c>Delete</c> method of <see cref="FunctionBusiness"/> with the newly deserialized <see cref="Function"/> object.
        ///   Finally, it returns the Deleted object unchanged as a serialized <c>string</c> of XML.
        /// </summary>
        /// <param name="aXmlArgument">A XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="Function"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string DeleteFunction(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of DeleteFunction");
            }
            Function vFunction = new Function();
            vFunction = XmlUtils.Deserialize<Function>(aXmlArgument);
            FunctionBusiness.Delete(aUserKey, vFunction);
            return XmlUtils.Serialize<Function>(vFunction, true);
        }

        #endregion

        #region JobType Methods

        /// <summary>
        ///   Gets the <see cref="JobType"/> by Key.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns>JobType as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetJobType(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetJobType");
            }
            JobType vJobType = new JobType();
            vJobType = XmlUtils.Deserialize<JobType>(aXmlArgument);
            JobTypeBusiness.Load(aUserKey, vJobType);
            return XmlUtils.Serialize<JobType>(vJobType, true);
        }

        /// <summary>
        ///   The <c>GetJobTypeCollection</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="JobTypeCollection"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="JobTypeBusiness"/> with the newly deserialized <see cref="JobTypeCollection"/> object.
        ///   Finally, it returns the collection object as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="JobTypeCollection"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetJobTypeCollection(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetJobTypeCollection");
            }
            JobTypeCollection vJobTypeCollection = new JobTypeCollection();
            vJobTypeCollection = XmlUtils.Deserialize<JobTypeCollection>(aXmlArgument);
            JobTypeBusiness.Load(aUserKey, vJobTypeCollection);
            return XmlUtils.Serialize<JobTypeCollection>(vJobTypeCollection, true);
        }

        /// <summary>
        ///   The <c>AddJobType</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="JobType"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="JobTypeBusiness"/> with the newly deserialized <see cref="JobType"/> object.
        ///   Finally, it returns the inserted object (now with an assigned JobType Key) as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="JobType"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string AddJobType(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of AddJobType");
            }
            JobType vJobType = new JobType();
            vJobType = XmlUtils.Deserialize<JobType>(aXmlArgument);
            JobTypeBusiness.Insert(aUserKey, vJobType);
            return XmlUtils.Serialize<JobType>(vJobType, true);
        }

        /// <summary>
        ///   The <c>EditJobType</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="JobType"/> object.
        ///   It invokes the <c>Update</c> method of <see cref="JobTypeBusiness"/> with the newly deserialized <see cref="JobType"/> object.
        ///   Finally, it returns the updated object unchanged as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="JobType"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string EditJobType(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of EditJobType");
            }
            JobType vJobType = new JobType();
            vJobType = XmlUtils.Deserialize<JobType>(aXmlArgument);
            JobTypeBusiness.Update(aUserKey, vJobType);
            return XmlUtils.Serialize<JobType>(vJobType, true);
        }

        /// <summary>
        ///   The <c>DeleteJobType</c> implementation method deserializes an incoming XML Argument as a new <see cref="JobType"/> object.
        ///   It invokes the <c>Delete</c> method of <see cref="JobTypeBusiness"/> with the newly deserialized <see cref="JobType"/> object.
        ///   Finally, it returns the Deleted object unchanged as a serialized <c>string</c> of XML.
        /// </summary>
        /// <param name="aXmlArgument">A XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="JobType"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string DeleteJobType(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of DeleteJobType");
            }
            JobType vJobType = new JobType();
            vJobType = XmlUtils.Deserialize<JobType>(aXmlArgument);
            JobTypeBusiness.Delete(aUserKey, vJobType);
            return XmlUtils.Serialize<JobType>(vJobType, true);
        }

        #endregion

        #region Job Methods

        /// <summary>
        ///   Gets the <see cref="Job"/> by Key.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns>Job as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetJob(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetJob");
            }
            Job vJob = new Job();
            vJob = XmlUtils.Deserialize<Job>(aXmlArgument);
            JobBusiness.Load(aUserKey, vJob);
            return XmlUtils.Serialize<Job>(vJob, true);
        }

        /// <summary>
        ///   The <c>GetJobCollection</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="JobCollection"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="JobBusiness"/> with the newly deserialized <see cref="JobCollection"/> object.
        ///   Finally, it returns the collection object as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="JobCollection"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetJobCollection(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetJobCollection");
            }
            JobCollection vJobCollection = new JobCollection();
            vJobCollection = XmlUtils.Deserialize<JobCollection>(aXmlArgument);
            JobBusiness.Load(aUserKey, vJobCollection);
            return XmlUtils.Serialize<JobCollection>(vJobCollection, true);
        }

        /// <summary>
        ///   The <c>AddJob</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="Job"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="JobBusiness"/> with the newly deserialized <see cref="Job"/> object.
        ///   Finally, it returns the inserted object (now with an assigned Job Key) as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="Job"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string AddJob(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of AddJob");
            }
            Job vJob = new Job();
            vJob = XmlUtils.Deserialize<Job>(aXmlArgument);
            JobBusiness.Insert(aUserKey, vJob);
            return XmlUtils.Serialize<Job>(vJob, true);
        }

        /// <summary>
        ///   The <c>EditJob</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="Job"/> object.
        ///   It invokes the <c>Update</c> method of <see cref="JobBusiness"/> with the newly deserialized <see cref="Job"/> object.
        ///   Finally, it returns the updated object unchanged as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="Job"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string EditJob(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of EditJob");
            }
            Job vJob = new Job();
            vJob = XmlUtils.Deserialize<Job>(aXmlArgument);
            JobBusiness.Update(aUserKey, vJob);
            return XmlUtils.Serialize<Job>(vJob, true);
        }

        /// <summary>
        ///   The <c>DeleteJob</c> implementation method deserializes an incoming XML Argument as a new <see cref="Job"/> object.
        ///   It invokes the <c>Delete</c> method of <see cref="JobBusiness"/> with the newly deserialized <see cref="Job"/> object.
        ///   Finally, it returns the Deleted object unchanged as a serialized <c>string</c> of XML.
        /// </summary>
        /// <param name="aXmlArgument">A XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="Job"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string DeleteJob(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of DeleteJob");
            }
            Job vJob = new Job();
            vJob = XmlUtils.Deserialize<Job>(aXmlArgument);
            JobBusiness.Delete(aUserKey, vJob);
            return XmlUtils.Serialize<Job>(vJob, true);
        }

        #endregion

        //#region ProviderSuburb Methods

        ///// <summary>
        /////   Gets the <see cref="ProviderSuburb"/> by Key.
        ///// </summary>
        ///// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        ///// <returns>ProviderSuburb as XML <see cref="string"/>.</returns>
        ///// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        //public static string GetProviderSuburb(UserKey aUserKey, string aXmlArgument)
        //{
        //    if (aXmlArgument == null)
        //    {
        //        throw new ArgumentNullException("aXmlArgument of GetProviderSuburb");
        //    }
        //    ProviderSuburb vProviderSuburb = new ProviderSuburb();
        //    vProviderSuburb = XmlUtils.Deserialize<ProviderSuburb>(aXmlArgument);
        //    ProviderSuburbBusiness.Load(aUserKey, vProviderSuburb);
        //    return XmlUtils.Serialize<ProviderSuburb>(vProviderSuburb, true);
        //}

        ///// <summary>
        /////   The <c>GetProviderSuburbCollection</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="ProviderSuburbCollection"/> object.
        /////   It invokes the <c>Insert</c> method of <see cref="ProviderSuburbBusiness"/> with the newly deserialized <see cref="ProviderSuburbCollection"/> object.
        /////   Finally, it returns the collection object as a serialized <see cref="string"/> of XML.
        ///// </summary>
        ///// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        ///// <returns><see cref="ProviderSuburbCollection"/> as XML <see cref="string"/>.</returns>
        ///// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        //public static string GetProviderSuburbCollection(UserKey aUserKey, string aXmlArgument)
        //{
        //    if (aXmlArgument == null)
        //    {
        //        throw new ArgumentNullException("aXmlArgument of GetProviderSuburbCollection");
        //    }
        //    ProviderSuburbCollection vProviderSuburbCollection = new ProviderSuburbCollection();
        //    vProviderSuburbCollection = XmlUtils.Deserialize<ProviderSuburbCollection>(aXmlArgument);
        //    ProviderSuburbBusiness.Load(aUserKey, vProviderSuburbCollection);
        //    return XmlUtils.Serialize<ProviderSuburbCollection>(vProviderSuburbCollection, true);
        //}

        ///// <summary>
        ///// Saves the provider suburb.
        ///// </summary>
        ///// <param name="aUserKey">A user key.</param>
        ///// <param name="aXmlArgument">A XML argument.</param>
        ///// <returns>A string of XML representing a ProviderSuburbCollection</returns>
        ///// <exception cref="System.ArgumentNullException">aXmlArgument of SaveProviderSuburb</exception>
        //public static string SaveProviderSuburb(UserKey aUserKey, string aXmlArgument)
        //{
        //    if (aXmlArgument == null)
        //    {
        //        throw new ArgumentNullException("aXmlArgument of SaveProviderSuburb");
        //    }
        //    ProviderSuburbCollection vProviderSuburbCollection = new ProviderSuburbCollection();
        //    vProviderSuburbCollection = XmlUtils.Deserialize<ProviderSuburbCollection>(aXmlArgument);
        //    ProviderSuburbBusiness.Save(aUserKey, vProviderSuburbCollection);
        //    return XmlUtils.Serialize<ProviderSuburbCollection>(vProviderSuburbCollection, true);
        //}

        //#endregion

        #region Language Methods

        /// <summary>
        ///   Gets the <see cref="Language"/> by Key.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns>Language as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetLanguage(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetLanguage");
            }
            Language vLanguage = new Language();
            vLanguage = XmlUtils.Deserialize<Language>(aXmlArgument);
            LanguageBusiness.Load(aUserKey, vLanguage);
            return XmlUtils.Serialize<Language>(vLanguage, true);
        }

        /// <summary>
        ///   The <c>GetLanguageCollection</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="LanguageCollection"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="LanguageBusiness"/> with the newly deserialized <see cref="LanguageCollection"/> object.
        ///   Finally, it returns the collection object as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="LanguageCollection"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetLanguageCollection(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetLanguageCollection");
            }
            LanguageCollection vLanguageCollection = new LanguageCollection();
            vLanguageCollection = XmlUtils.Deserialize<LanguageCollection>(aXmlArgument);
            LanguageBusiness.Load(aUserKey, vLanguageCollection);
            return XmlUtils.Serialize<LanguageCollection>(vLanguageCollection, true);
        }

        /// <summary>
        ///   The <c>AddLanguage</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="Language"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="LanguageBusiness"/> with the newly deserialized <see cref="Language"/> object.
        ///   Finally, it returns the inserted object (now with an assigned Language Key) as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="Language"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string AddLanguage(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of AddLanguage");
            }
            Language vLanguage = new Language();
            vLanguage = XmlUtils.Deserialize<Language>(aXmlArgument);
            LanguageBusiness.Insert(aUserKey, vLanguage);
            return XmlUtils.Serialize<Language>(vLanguage, true);
        }

        /// <summary>
        ///   The <c>EditLanguage</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="Language"/> object.
        ///   It invokes the <c>Update</c> method of <see cref="LanguageBusiness"/> with the newly deserialized <see cref="Language"/> object.
        ///   Finally, it returns the updated object unchanged as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="Language"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string EditLanguage(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of EditLanguage");
            }
            Language vLanguage = new Language();
            vLanguage = XmlUtils.Deserialize<Language>(aXmlArgument);
            LanguageBusiness.Update(aUserKey, vLanguage);
            return XmlUtils.Serialize<Language>(vLanguage, true);
        }

        /// <summary>
        ///   The <c>DeleteLanguage</c> implementation method deserializes an incoming XML Argument as a new <see cref="Language"/> object.
        ///   It invokes the <c>Delete</c> method of <see cref="LanguageBusiness"/> with the newly deserialized <see cref="Language"/> object.
        ///   Finally, it returns the Deleted object unchanged as a serialized <c>string</c> of XML.
        /// </summary>
        /// <param name="aXmlArgument">A XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="Language"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string DeleteLanguage(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of DeleteLanguage");
            }
            Language vLanguage = new Language();
            vLanguage = XmlUtils.Deserialize<Language>(aXmlArgument);
            LanguageBusiness.Delete(aUserKey, vLanguage);
            return XmlUtils.Serialize<Language>(vLanguage, true);
        }

        #endregion

        #region RoleFunction Methods

        /// <summary>
        ///   Gets the <see cref="RoleFunction"/> by Key.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns>RoleFunction as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetRoleFunction(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetRoleFunction");
            }
            RoleFunction vRoleFunction = new RoleFunction();
            vRoleFunction = XmlUtils.Deserialize<RoleFunction>(aXmlArgument);
            RoleFunctionBusiness.Load(aUserKey, vRoleFunction);
            return XmlUtils.Serialize<RoleFunction>(vRoleFunction, true);
        }

        /// <summary>
        ///   The <c>GetRoleFunctionCollection</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="RoleFunctionCollection"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="RoleFunctionBusiness"/> with the newly deserialized <see cref="RoleFunctionCollection"/> object.
        ///   Finally, it returns the collection object as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="RoleFunctionCollection"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetRoleFunctionCollection(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetRoleFunctionCollection");
            }
            RoleFunctionCollection vRoleFunctionCollection = new RoleFunctionCollection();
            vRoleFunctionCollection = XmlUtils.Deserialize<RoleFunctionCollection>(aXmlArgument);
            RoleFunctionBusiness.Load(aUserKey, vRoleFunctionCollection);
            return XmlUtils.Serialize<RoleFunctionCollection>(vRoleFunctionCollection, true);
        }

        /// <summary>
        ///   The <c>AddRoleFunction</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="RoleFunction"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="RoleFunctionBusiness"/> with the newly deserialized <see cref="RoleFunction"/> object.
        ///   Finally, it returns the inserted object (now with an assigned RoleFunction Key) as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="RoleFunction"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string AddRoleFunction(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of AddRoleFunction");
            }
            RoleFunction vRoleFunction = new RoleFunction();
            vRoleFunction = XmlUtils.Deserialize<RoleFunction>(aXmlArgument);
            RoleFunctionBusiness.Insert(aUserKey, vRoleFunction);
            return XmlUtils.Serialize<RoleFunction>(vRoleFunction, true);
        }

        /// <summary>
        ///   The <c>EditRoleFunction</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="RoleFunction"/> object.
        ///   It invokes the <c>Update</c> method of <see cref="RoleFunctionBusiness"/> with the newly deserialized <see cref="RoleFunction"/> object.
        ///   Finally, it returns the updated object unchanged as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="RoleFunction"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string EditRoleFunction(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of EditRoleFunction");
            }
            RoleFunction vRoleFunction = new RoleFunction();
            vRoleFunction = XmlUtils.Deserialize<RoleFunction>(aXmlArgument);
            RoleFunctionBusiness.Update(aUserKey, vRoleFunction);
            return XmlUtils.Serialize<RoleFunction>(vRoleFunction, true);
        }

        /// <summary>
        ///   The <c>DeleteRoleFunction</c> implementation method deserializes an incoming XML Argument as a new <see cref="RoleFunction"/> object.
        ///   It invokes the <c>Delete</c> method of <see cref="RoleFunctionBusiness"/> with the newly deserialized <see cref="RoleFunction"/> object.
        ///   Finally, it returns the Deleted object unchanged as a serialized <c>string</c> of XML.
        /// </summary>
        /// <param name="aXmlArgument">A XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="RoleFunction"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string DeleteRoleFunction(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of DeleteRoleFunction");
            }
            RoleFunction vRoleFunction = new RoleFunction();
            vRoleFunction = XmlUtils.Deserialize<RoleFunction>(aXmlArgument);
            RoleFunctionBusiness.Delete(aUserKey, vRoleFunction);
            return XmlUtils.Serialize<RoleFunction>(vRoleFunction, true);
        }

        #endregion

        #region Role Methods

        /// <summary>
        ///   Gets the <see cref="Role"/> by Key.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns>Role as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetRole(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetRole");
            }
            Role vRole = new Role();
            vRole = XmlUtils.Deserialize<Role>(aXmlArgument);
            RoleBusiness.Load(aUserKey, vRole);
            return XmlUtils.Serialize<Role>(vRole, true);
        }

        /// <summary>
        ///   The <c>GetRoleCollection</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="RoleCollection"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="RoleBusiness"/> with the newly deserialized <see cref="RoleCollection"/> object.
        ///   Finally, it returns the collection object as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="RoleCollection"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetRoleCollection(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetRoleCollection");
            }
            RoleCollection vRoleCollection = new RoleCollection();
            vRoleCollection = XmlUtils.Deserialize<RoleCollection>(aXmlArgument);
            RoleBusiness.Load(aUserKey, vRoleCollection);
            return XmlUtils.Serialize<RoleCollection>(vRoleCollection, true);
        }

        /// <summary>
        ///   The <c>AddRole</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="Role"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="RoleBusiness"/> with the newly deserialized <see cref="Role"/> object.
        ///   Finally, it returns the inserted object (now with an assigned Role Key) as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="Role"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string AddRole(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of AddRole");
            }
            Role vRole = new Role();
            vRole = XmlUtils.Deserialize<Role>(aXmlArgument);
            RoleBusiness.Insert(aUserKey, vRole);
            return XmlUtils.Serialize<Role>(vRole, true);
        }

        /// <summary>
        ///   The <c>EditRole</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="Role"/> object.
        ///   It invokes the <c>Update</c> method of <see cref="RoleBusiness"/> with the newly deserialized <see cref="Role"/> object.
        ///   Finally, it returns the updated object unchanged as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="Role"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string EditRole(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of EditRole");
            }
            Role vRole = new Role();
            vRole = XmlUtils.Deserialize<Role>(aXmlArgument);
            RoleBusiness.Update(aUserKey, vRole);
            return XmlUtils.Serialize<Role>(vRole, true);
        }

        /// <summary>
        ///   The <c>DeleteRole</c> implementation method deserializes an incoming XML Argument as a new <see cref="Role"/> object.
        ///   It invokes the <c>Delete</c> method of <see cref="RoleBusiness"/> with the newly deserialized <see cref="Role"/> object.
        ///   Finally, it returns the Deleted object unchanged as a serialized <c>string</c> of XML.
        /// </summary>
        /// <param name="aXmlArgument">A XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="Role"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string DeleteRole(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of DeleteRole");
            }
            Role vRole = new Role();
            vRole = XmlUtils.Deserialize<Role>(aXmlArgument);
            RoleBusiness.Delete(aUserKey, vRole);
            return XmlUtils.Serialize<Role>(vRole, true);
        }

        #endregion

        #region UserRole Methods

        /// <summary>
        ///   Gets the <see cref="UserRole"/> by Key.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns>UserRole as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetUserRole(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetUserRole");
            }
            UserRole vUserRole = new UserRole();
            vUserRole = XmlUtils.Deserialize<UserRole>(aXmlArgument);
            UserRoleBusiness.Load(aUserKey, vUserRole);
            return XmlUtils.Serialize<UserRole>(vUserRole, true);
        }

        /// <summary>
        ///   The <c>GetUserRoleCollection</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="UserRoleCollection"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="UserRoleBusiness"/> with the newly deserialized <see cref="UserRoleCollection"/> object.
        ///   Finally, it returns the collection object as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="UserRoleCollection"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetUserRoleCollection(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetUserRoleCollection");
            }
            UserRoleCollection vUserRoleCollection = new UserRoleCollection();
            vUserRoleCollection = XmlUtils.Deserialize<UserRoleCollection>(aXmlArgument);
            UserRoleBusiness.Load(aUserKey, vUserRoleCollection);
            return XmlUtils.Serialize<UserRoleCollection>(vUserRoleCollection, true);
        }

        /// <summary>
        ///   The <c>AddUserRole</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="UserRole"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="UserRoleBusiness"/> with the newly deserialized <see cref="UserRole"/> object.
        ///   Finally, it returns the inserted object (now with an assigned UserRole Key) as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="UserRole"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string AddUserRole(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of AddUserRole");
            }
            UserRole vUserRole = new UserRole();
            vUserRole = XmlUtils.Deserialize<UserRole>(aXmlArgument);
            UserRoleBusiness.Insert(aUserKey, vUserRole);
            return XmlUtils.Serialize<UserRole>(vUserRole, true);
        }

        /// <summary>
        ///   The <c>EditUserRole</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="UserRole"/> object.
        ///   It invokes the <c>Update</c> method of <see cref="UserRoleBusiness"/> with the newly deserialized <see cref="UserRole"/> object.
        ///   Finally, it returns the updated object unchanged as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="UserRole"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string EditUserRole(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of EditUserRole");
            }
            UserRole vUserRole = new UserRole();
            vUserRole = XmlUtils.Deserialize<UserRole>(aXmlArgument);
            UserRoleBusiness.Update(aUserKey, vUserRole);
            return XmlUtils.Serialize<UserRole>(vUserRole, true);
        }

        /// <summary>
        ///   The <c>DeleteUserRole</c> implementation method deserializes an incoming XML Argument as a new <see cref="UserRole"/> object.
        ///   It invokes the <c>Delete</c> method of <see cref="UserRoleBusiness"/> with the newly deserialized <see cref="UserRole"/> object.
        ///   Finally, it returns the Deleted object unchanged as a serialized <c>string</c> of XML.
        /// </summary>
        /// <param name="aXmlArgument">A XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="UserRole"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string DeleteUserRole(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of DeleteUserRole");
            }
            UserRole vUserRole = new UserRole();
            vUserRole = XmlUtils.Deserialize<UserRole>(aXmlArgument);
            UserRoleBusiness.Delete(aUserKey, vUserRole);
            return XmlUtils.Serialize<UserRole>(vUserRole, true);
        }

        #endregion

        #region User Methods

        /// <summary>
        ///   Gets the <see cref="User"/> by UserID.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns>User as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetUserByID(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetUserByID");
            }
            User vUser = new User();
            vUser = XmlUtils.Deserialize<User>(aXmlArgument);
            UserBusiness.LoadByID(vUser, vUser);
            return XmlUtils.Serialize<User>(vUser, true);
        }

        /// <summary>
        ///   Gets the <see cref="User"/> by Key.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns>User as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetUser(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetUser");
            }
            User vUser = new User();
            vUser = XmlUtils.Deserialize<User>(aXmlArgument);
            UserBusiness.Load(aUserKey, vUser);
            return XmlUtils.Serialize<User>(vUser, true);
        }

        /// <summary>
        ///   The <c>GetUserCollection</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="UserCollection"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="UserBusiness"/> with the newly deserialized <see cref="UserCollection"/> object.
        ///   Finally, it returns the collection object as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="UserCollection"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetUserCollection(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetUserCollection");
            }
            UserCollection vUserCollection = new UserCollection();
            vUserCollection = XmlUtils.Deserialize<UserCollection>(aXmlArgument);
            UserBusiness.Load(aUserKey, vUserCollection);
            return XmlUtils.Serialize<UserCollection>(vUserCollection, true);
        }

        /// <summary>
        ///   The <c>AddUser</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="User"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="UserBusiness"/> with the newly deserialized <see cref="User"/> object.
        ///   Finally, it returns the inserted object (now with an assigned User Key) as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="User"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string AddUser(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of AddUser");
            }
            User vUser = new User();
            vUser = XmlUtils.Deserialize<User>(aXmlArgument);
            UserBusiness.Insert(aUserKey, vUser);
            return XmlUtils.Serialize<User>(vUser, true);
        }

        /// <summary>
        ///   The <c>EditUser</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="User"/> object.
        ///   It invokes the <c>Update</c> method of <see cref="UserBusiness"/> with the newly deserialized <see cref="User"/> object.
        ///   Finally, it returns the updated object unchanged as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="User"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string EditUser(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of EditUser");
            }
            User vUser = new User();
            vUser = XmlUtils.Deserialize<User>(aXmlArgument);
            UserBusiness.Update(aUserKey, vUser);
            return XmlUtils.Serialize<User>(vUser, true);
        }

        /// <summary>
        ///   The <c>DeleteUser</c> implementation method deserializes an incoming XML Argument as a new <see cref="User"/> object.
        ///   It invokes the <c>Delete</c> method of <see cref="UserBusiness"/> with the newly deserialized <see cref="User"/> object.
        ///   Finally, it returns the Deleted object unchanged as a serialized <c>string</c> of XML.
        /// </summary>
        /// <param name="aXmlArgument">A XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="User"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string DeleteUser(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of DeleteUser");
            }
            User vUser = new User();
            vUser = XmlUtils.Deserialize<User>(aXmlArgument);
            UserBusiness.Delete(aUserKey, vUser);
            return XmlUtils.Serialize<User>(vUser, true);
        }

        #endregion   
        
        #region WorkItem Methods

        /// <summary>
        ///   The <c>GetWorkItemCollection</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="WorkItemCollection"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="WorkItemBusiness"/> with the newly deserialized <see cref="WorkItemCollection"/> object.
        ///   Finally, it returns the collection object as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="WorkItemCollection"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetWorkItemCollection(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetWorkItemCollection");
            }
            WorkItemCollection vWorkItemCollection = new WorkItemCollection();
            vWorkItemCollection = XmlUtils.Deserialize<WorkItemCollection>(aXmlArgument);
            WorkItemBusiness.Load(aUserKey, vWorkItemCollection);
            return XmlUtils.Serialize<WorkItemCollection>(vWorkItemCollection, true);
        }

        /// <summary>
        ///   Gets the <see cref="WorkItem"/> by Key.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns>WorkItem as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetWorkItem(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetWorkItem");
            }
            WorkItem vWorkItem = new WorkItem();
            vWorkItem = XmlUtils.Deserialize<WorkItem>(aXmlArgument);
            WorkItemBusiness.Load(aUserKey, vWorkItem);
            return XmlUtils.Serialize<WorkItem>(vWorkItem, true);
        }

        /// <summary>
        ///   The <c>AddWorkItem</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="WorkItem"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="WorkItemBusiness"/> with the newly deserialized <see cref="WorkItem"/> object.
        ///   Finally, it returns the inserted object (now with an assigned WorkItem Key) as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="WorkItem"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string AddWorkItem(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of AddWorkItem");
            }
            WorkItem vWorkItem = new WorkItem();
            vWorkItem = XmlUtils.Deserialize<WorkItem>(aXmlArgument);
            WorkItemBusiness.Insert(aUserKey, vWorkItem);
            return XmlUtils.Serialize<WorkItem>(vWorkItem, true);
        }

        /// <summary>
        ///   The <c>EditWorkItem</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="WorkItem"/> object.
        ///   It invokes the <c>Update</c> method of <see cref="WorkItemBusiness"/> with the newly deserialized <see cref="WorkItem"/> object.
        ///   Finally, it returns the updated object unchanged as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="WorkItem"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string EditWorkItem(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of EditWorkItem");
            }
            WorkItem vWorkItem = new WorkItem();
            vWorkItem = XmlUtils.Deserialize<WorkItem>(aXmlArgument);
            WorkItemBusiness.Update(aUserKey, vWorkItem);
            return XmlUtils.Serialize<WorkItem>(vWorkItem, true);
        }

        /// <summary>
        ///   The <c>DeleteWorkItem</c> implementation method deserializes an incoming XML Argument as a new <see cref="WorkItem"/> object.
        ///   It invokes the <c>Delete</c> method of <see cref="WorkItemBusiness"/> with the newly deserialized <see cref="WorkItem"/> object.
        ///   Finally, it returns the Deleted object unchanged as a serialized <c>string</c> of XML.
        /// </summary>
        /// <param name="aXmlArgument">A XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="WorkItem"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string DeleteWorkItem(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of DeleteWorkItem");
            }
            WorkItem vWorkItem = new WorkItem();
            vWorkItem = XmlUtils.Deserialize<WorkItem>(aXmlArgument);
            WorkItemBusiness.Delete(aUserKey, vWorkItem);
            return XmlUtils.Serialize<WorkItem>(vWorkItem, true);
        }

        #endregion

    }
}