using DomainDriven.Command;
using DomainDriven.Entity;
using DomainDriven.Interface;
using System;
using System.Transactions;

namespace DomainDriven.Service
{
    public class CircleApplicationService
    {
        private readonly ICircleFactory circleFactory;
        private readonly ICircleRepository circleRepository;
        private readonly CircleService circleService;
        private readonly IUserRepository userRepository;

        public CircleApplicationService(ICircleFactory circleFactory, 
            ICircleRepository circleRepository, 
            CircleService circleService, 
            IUserRepository userRepository)
        {
            this.circleFactory = circleFactory;
            this.circleRepository = circleRepository;
            this.circleService = circleService;
            this.userRepository = userRepository;
        }

        public void Create(CircleCreateCommand command)
        {
            using (var transaction = new TransactionScope())
            {
                var ownerId = new UserId(command.UserId);
                var owner = userRepository.Find(ownerId);
                if (owner == null)
                {
                    throw new Exception("サークルのオーナーとなるユーザーが見つかりませんでした。");
                }

                var name = new CircleName(command.Name);
                var circle = circleFactory.Create(name, owner);
                if (circleService.Exists(circle))
                {
                    throw new Exception("サークルは既に存在しています。");
                }
                circleRepository.Save(circle);
                transaction.Complete();
            }
        }

        public void Join(CircleJoinCommand command)
        {
            using (var transaction = new TransactionScope())
            {
                var memberId = new UserId(command.UserId);
                var member = userRepository.Find(memberId);
                if (member != null)
                {
                    throw new Exception("ユーザーが見つかりませんでした。");
                }

                var id = new CircleId(command.CircleId);
                var circle = circleRepository.Find(id);
                if (circle == null)
                {
                    throw new Exception("サークルが見つかりませんでした。");
                }

                circle.Join(member);
                circleRepository.Save(circle);

                transaction.Complete();
            }
        }
    }
}
