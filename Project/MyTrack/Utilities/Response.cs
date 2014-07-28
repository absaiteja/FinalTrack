using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyTrack.Utilities
{
    public class Response
    {
        private string p1;
        private string p2;

        public int id { get; set; }
        public string Message { get; set; }
        public string ExtendedMessage { get; set; }

        public Response(int intId, string strMessage)
        {
            this.id = intId;
            this.Message = strMessage;
        }
        public Response(int intId, string strMessage, string strExtendedMessage)
        {
            this.id = intId;
            this.Message = strMessage;
            this.ExtendedMessage = strExtendedMessage;
        }

        public Response(string p1, string p2)
        {
            // TODO: Complete member initialization
            this.p1 = p1;
            this.p2 = p2;
        }
    }
}
   