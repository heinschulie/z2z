using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zephry;
using System.Web.Services;
using System.IO;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using System.Drawing;

namespace Z2Z
{
    public partial class _admindashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ServerSession.GetUserToken(HttpContext.Current.Session) == null)
            {
                setUserToken();
            }
        }

        private static void setUserToken()
        {
            User vUser = new User();
            vUser.UsrID = "heinvh@zephry.co.za";
            vUser.UsrPassword = "theboss";
            ServerSession.Logon(HttpContext.Current.Session, vUser); 
        }

        [WebMethod(EnableSession = false)]
        public static List<Client> AjaxClnDocCollection()
        {
            if (ServerSession.GetUserToken(HttpContext.Current.Session) == null)
            {
                setUserToken(); 
            }

            ClientCollection vClientCollection = new ClientCollection();
            UserServiceConsumer.GetClientCollection(ServerSession.GetUserToken(HttpContext.Current.Session), vClientCollection);

            foreach (Client vClient in vClientCollection.ClientList)
            {
                DocumentCollection vDocumentCollection = new DocumentCollection();
                vDocumentCollection.DocumentFilter.IsFiltered = true; 
                vDocumentCollection.DocumentFilter.DocumentClientKeyFilter = vClient.ClnKey;
                UserServiceConsumer.GetDocumentCollection(ServerSession.GetUserToken(HttpContext.Current.Session), vDocumentCollection);
                foreach (Document vDocument in vDocumentCollection.DocumentList)
                {
                    //if (vClient.ClnKey == vDocument.ClnKey)
                        vClient.children.Add(vDocument); 
                }
            }
            return vClientCollection.ClientList;
        }

        [WebMethod(EnableSession = false)]
        public static List<Client> AjaxClnJobCollection()
        {           
            if (ServerSession.GetUserToken(HttpContext.Current.Session) == null)
            {
                setUserToken();               
            }
            UserToken vUserToken = new UserToken();
            vUserToken.AssignFromSource(ServerSession.GetUserToken(HttpContext.Current.Session));
            
            ClientCollection vClientCollection = new ClientCollection();
            UserServiceConsumer.GetClientCollection(vUserToken, vClientCollection);

            foreach (Client vClient in vClientCollection.ClientList)
            {
                JobCollection vJobCollection = new JobCollection();
                vJobCollection.JobFilter.IsFiltered = true; 
                vJobCollection.JobFilter.ClientKeyFilter = vClient.ClnKey;
                UserServiceConsumer.GetJobCollection(vUserToken, vJobCollection);
                foreach (Job vJob in vJobCollection.JobList)
                {
                    WorkItemCollection vWorkItemCollection = new WorkItemCollection();
                    vWorkItemCollection.WorkItemFilter.IsFiltered = true;
                    vWorkItemCollection.WorkItemFilter.ClientKeyFilter = vJob.ClnKey; 
                    vWorkItemCollection.WorkItemFilter.JobKeyFilter = vJob.JobbKey;
                    UserServiceConsumer.GetWorkItemCollection(vUserToken, vWorkItemCollection);
                    foreach (WorkItem vWorkItem in vWorkItemCollection.WorkItemList)
                    {
                        vJob.children.Add(vWorkItem); 
                    }
                    vJob.value = vJob.children.Count(); 
                    if (vClient.ClnKey == vJob.ClnKey)
                        vClient.children.Add(vJob);
                }
                vClient.value = vClient.children.Count(); 
            }
            return vClientCollection.ClientList;
        }

        


        [WebMethod(EnableSession = false)]
        public static List<Language> AjaxLanCollection()
        {
            if (ServerSession.GetUserToken(HttpContext.Current.Session) == null)
            {
                setUserToken();
            }
            UserToken vUserToken = new UserToken();
            vUserToken.AssignFromSource(ServerSession.GetUserToken(HttpContext.Current.Session));

            LanguageCollection vLanguageCollection = new LanguageCollection();
            UserServiceConsumer.GetLanguageCollection(vUserToken, vLanguageCollection);

            return vLanguageCollection.LanguageList;
        }

        [WebMethod(EnableSession = false)]
        public static List<JobType> AjaxJbtCollection()
        {
            if (ServerSession.GetUserToken(HttpContext.Current.Session) == null)
            {
                setUserToken();
            }
            UserToken vUserToken = new UserToken();
            vUserToken.AssignFromSource(ServerSession.GetUserToken(HttpContext.Current.Session));

            JobTypeCollection vJobTypeCollection = new JobTypeCollection();
            UserServiceConsumer.GetJobTypeCollection(vUserToken, vJobTypeCollection);
            

            return vJobTypeCollection.JobTypeList;
        }


        [WebMethod(EnableSession = false)]
        public static List<Contributor> AjaxConLanCollection()
        {
            if (ServerSession.GetUserToken(HttpContext.Current.Session) == null)
            {
                setUserToken();
            }
            UserToken vUserToken = new UserToken();
            vUserToken.AssignFromSource(ServerSession.GetUserToken(HttpContext.Current.Session));

            ContributorCollection vContributorCollection = new ContributorCollection();
            UserServiceConsumer.GetContributorCollection(vUserToken, vContributorCollection);

            foreach (Contributor vContributor in vContributorCollection.ContributorList)
            {
                LanguageCollection vLanguageCollection = new LanguageCollection();
                UserServiceConsumer.GetLanguageCollection(vUserToken, vLanguageCollection);
                foreach (Language vLanguage in vLanguageCollection.LanguageList)
                {
                    vContributor.children.Add(vLanguage);
                }

                vContributor.value = vContributor.children.Count();
            }
            return vContributorCollection.ContributorList;
        }

        [WebMethod(EnableSession = false)]
        public static string UploadDocument(string json)
        {
            //Capture File From Post
            //HttpPostedFile file = context.Request.Files["fileToUpload"];

            //Optional: Convert to File to binary if you need to forward it to a video encoding service like Panda Stream
            //BinaryReader vBinaryReader = new BinaryReader(file.InputStream);
            //byte[] binData = vBinaryReader.ReadBytes(file.ContentLength);
            //vBinaryReader.Close();


            string result = json + "Shine your lonely light me";
            return result;  

            //context.Response.ContentType = "text/plain";
            //context.Response.Write(result);
        }
    }
}