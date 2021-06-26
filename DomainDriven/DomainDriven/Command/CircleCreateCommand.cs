using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDriven.Command
{
    public class CircleCreateCommand
    {
        public CircleCreateCommand(string userId, string name)
        {
            UserId = userId;
            Name = name;
        }
        public string UserId { get; }
        public string Name { get; }
    }
}
