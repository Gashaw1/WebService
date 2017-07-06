using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebServiceClient
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        MessageServiceReference.MessageWebServiceSoapClient client;
        protected void Page_Load(object sender, EventArgs e)
        {
            client = new MessageServiceReference.MessageWebServiceSoapClient();
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            client.sendMessagePerUser(txtSenderID.Text, txtReciverID.Text, txtMessage.Text);
            var result = from r in client.GetMessage(txtSenderID.Text, txtReciverID.Text)
                         select r;

            GridView1.DataSource = result;
            GridView1.DataBind();
            
        }
    }
}