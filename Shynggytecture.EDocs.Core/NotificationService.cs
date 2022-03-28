using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.Core
{
    public class NotificationService
    {
        private readonly List<string> _messages;

        public NotificationService()
        {
            _messages = new List<string>();
        }

        public NotificationService AddMessage(string message) 
        {
            _messages.Add(message);
            return this;
        }

        public void Write() 
        {
#if DEBUG

            System.Diagnostics.Debug.WriteLine("------------------");
            System.Diagnostics.Debug.WriteLine("");
            System.Diagnostics.Debug.WriteLine("Notification!");
            foreach (var item in _messages) 
            {
                System.Diagnostics.Debug.WriteLine(item);
            }
            System.Diagnostics.Debug.WriteLine("");
            System.Diagnostics.Debug.WriteLine("------------------");

#endif
        }

    }
}
