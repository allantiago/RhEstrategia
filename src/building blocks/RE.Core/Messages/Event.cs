using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RE.Core.Messages
{
    public class Event : Message, INotification
    {
        public DateTime Time { get; private set; }

        protected Event()
        {
            Time = DateTime.Now;
        }
    }
}
