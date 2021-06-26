using DomainDriven.Command;
using DomainDriven.Entity;
using DomainDriven.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Transactions;

namespace DomainDriven.Service
{
    /// <summary>
    /// アプリケーションサービス
    /// </summary>
    public class UserApplicationService
    {
        #region【privateメンバ】
        /// <summary>リポジトリ</summary>
        private readonly IUserRepository userRepository;
        /// <summary>ファクトリ</summary>
        private readonly IUserFactory userFactory;
        /// <summary>ドメインサービス</summary>
        private readonly UserService userService;
        #endregion【privateメンバ】

        #region【コンストラクタ】
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public UserApplicationService()
        {
            this.userRepository = Program.Provider.GetService<IUserRepository>();
            this.userFactory = Program.Provider.GetService<IUserFactory>();
            this.userService = Program.Provider.GetService<UserService>();
        }
        #endregion【コンストラクタ】

        #region【publicメソッド】
        /// <summary>
        /// 登録処理
        /// </summary>
        /// <param name="command">コマンド</param>
        public void Register(UserRegisterCommand command)
        {
            using (var transaction = new TransactionScope())
            {
                var userName = new UserName(command.Name);
                var user = userFactory.Create(userName);
                if (userService.Exists(user))
                {
                    throw new Exception("ユーザは既に存在しています。");
                }
                userRepository.Save(user);
                transaction.Complete();
            }
        }

        /// <summary>
        /// 更新処理
        /// </summary>
        /// <param name="command">コマンド</param>
        public void Update(UserUpdateCommand command)
        {
            var targetId = new UserId(command.Id);
            var user = userRepository.Find(targetId);
            if (user == null)
            {
                throw new Exception();
            }
            var name = command.Name; if (name != null)
            {
                var newUserName = new UserName(name);
                user.ChangeName(newUserName);
                if (userService.Exists(user))
                {
                    throw new Exception("ユーザは既に存在しています。");
                }
            }
            userRepository.Save(user);
        }

        /// <summary>
        /// 取得処理
        /// </summary>
        /// <param name="userId">ユーザID</param>
        public UserData Get(string userId)
        {
            var targetId = new UserId(userId);
            var user = userRepository.Find(targetId);
            var userData = new UserData(user.Id.Value, user.Name.Value);
            return userData;
        }

        /// <summary>
        /// 削除処理
        /// </summary>
        /// <param name="command">コマンド</param>
        public void Delete(UserDeleteCommand command)
        {
            var targetId = new UserId(command.Id);
            var user = userRepository.Find(targetId);
            if (user == null)
            {
                return;
            }
            userRepository.Delete(user);
        }
        #endregion【publicメソッド】
    }
}
