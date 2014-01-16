using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zephry;
using System.Web.Services;

namespace Z2Z
{
    public partial class _default : System.Web.UI.Page
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
        public static TransactionStatus userLogon(User aUser)
        {
            ServerSession.ClearSessionBusiness(HttpContext.Current.Session);
            TransactionStatus vTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);
            try
            {
                ServerSession.Logon(HttpContext.Current.Session, aUser);
                vTransactionStatus.TransactionResult = TransactionResult.OK;
                vTransactionStatus.Message = "Login succesful";
                vTransactionStatus.TargetUrl = "/admindashboard.aspx";
                ServerSession.SetTransactionStatus(HttpContext.Current.Session, vTransactionStatus);
            }
            catch (TransactionStatusException tx)
            {

                vTransactionStatus.AssignFromSource(tx.TransactionStatus);
                return vTransactionStatus;
            }
            catch (Exception ex)
            {
                vTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vTransactionStatus.Message = "Login Unsuccesful - please check your username and password are correct" + ex.Message;
                vTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
                return vTransactionStatus;
            }

            return vTransactionStatus;
        }

        [WebMethod(EnableSession = false)]
        public static TransactionStatus clientLogon(Client aClient)
        {
        //    ServerSession.ClearSessionBusiness(HttpContext.Current.Session);
            TransactionStatus vTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);
        //    try
        //    {
        //        ServerSession.Logon(HttpContext.Current.Session, aClient);
        //        vTransactionStatus.TransactionResult = TransactionResult.OK;
        //        vTransactionStatus.Message = "Login succesful";
        //        vTransactionStatus.TargetUrl = "/fandashboard.aspx";
        //        ServerSession.SetTransactionStatus(HttpContext.Current.Session, vTransactionStatus);
        //    }
        //    catch (TransactionStatusException tx)
        //    {

        //        vTransactionStatus.AssignFromSource(tx.TransactionStatus);
        //        return vTransactionStatus;
        //    }
        //    catch (Exception ex)
        //    {
        //        vTransactionStatus.TransactionResult = TransactionResult.GeneralException;
        //        vTransactionStatus.Message = "Login Unsuccesful - please check your username and password are correct" + ex.Message;
        //        vTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
        //        return vTransactionStatus;
        //    }

            return vTransactionStatus;
        }

        [WebMethod(EnableSession = false)]
        public static TransactionStatus clientRegister(Client aClient)
        {
            ServerSession.ClearSessionBusiness(HttpContext.Current.Session);
            TransactionStatus vTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);
            try
            {
                UserToken aUserToken = new UserToken();
                aUserToken.UserID = "Register";
                aUserToken.Password = "Register";
                aUserToken.Url = "http://localhost/z2zsoap/Z2ZService.asmx";
                aClient.ClnName = "fanatic";
                UserServiceConsumer.AddClient(aUserToken, aClient);
                vTransactionStatus.TransactionResult = TransactionResult.OK;
                vTransactionStatus.Message = "You have been succesfully registered!";
                vTransactionStatus.TargetUrl = "/clientdashboard.aspx";
                ServerSession.SetTransactionStatus(HttpContext.Current.Session, vTransactionStatus);
            }
            catch (TransactionStatusException tx)
            {
                vTransactionStatus.AssignFromSource(tx.TransactionStatus);
                return vTransactionStatus;
            }
            catch (Exception ex)
            {
                vTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vTransactionStatus.Message = ex.Message;
                vTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
                return vTransactionStatus;
            }

            return vTransactionStatus;
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
    }
}