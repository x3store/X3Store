using System.Web.Management;

namespace X3Store.Logger
{
    public abstract class WebCustomEvent : WebBaseEvent
    {
        public WebCustomEvent(string message, object eventSource, int eventCode) : base(message, eventSource, eventCode)
        {

        }
    }
}
