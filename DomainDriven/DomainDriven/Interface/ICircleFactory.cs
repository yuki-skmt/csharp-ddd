using DomainDriven.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDriven.Interface
{
    public interface ICircleFactory
    {
        Circle Create(CircleName name, User owner);
    }
}
