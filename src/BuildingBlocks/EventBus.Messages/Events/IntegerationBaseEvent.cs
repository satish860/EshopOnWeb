using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.Events
{
    public class IntegerationBaseEvent
    {
        public IntegerationBaseEvent()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
        }

        public IntegerationBaseEvent(Guid id,DateTime createdDateTime)
        {
            Id=id;
            CreatedDate = createdDateTime;
        }

        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
