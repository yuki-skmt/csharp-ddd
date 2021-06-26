using DomainDriven.Entity;
using DomainDriven.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDriven.Service
{
    public class CircleService
    {
        private readonly ICircleRepository circleRepository;

        public CircleService(ICircleRepository circleRepository)
        {
            this.circleRepository = circleRepository;
        }

        public bool Exists(Circle circle)
        {
            var duplicated = circleRepository.Find(circle.Name);
            return duplicated != null;
        }
    }
}
