using System;
using System.Web; 
using System.Web.Services;
using System.Collections.Generic;
using Zephry;

namespace Z2Z
{
    public partial class AjaxExample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User vUser = new User();
            vUser.UsrID = "schulie";
            vUser.UsrPassword = "theboss";
            ServerSession.Logon(Session, vUser);
        }

        [WebMethod(EnableSession = false)]
        public static List<Client> HelloWorld()
        {
            //Client vClient = new Client();
            //vClient.ClnKey = 3;
            //UserServiceConsumer.GetClient(ServerSession.GetUserToken(HttpContext.Current.Session), vClient);
            //return vClient;

            ClientCollection vClientCollection = new ClientCollection();
            UserServiceConsumer.GetClientCollection(ServerSession.GetUserToken(HttpContext.Current.Session), vClientCollection);
            return vClientCollection.ClientList;

            //return "Hello: " + DateTime.Now.Millisecond;
        }
    }
}