using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDriven.Command
{
    public class CircleJoinCommand
    {
        public CircleJoinCommand(string userId, string circleId)
        {
            UserId = userId;
            CircleId = circleId;
        }
        public string UserId { get; }
        public string CircleId { get; }
    }
}
