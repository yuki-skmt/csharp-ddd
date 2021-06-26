using DomainDriven.Entity;
using DomainDriven.Interface;
using System.Collections.Generic;
using System.Linq;

namespace DomainDriven.Repository
{
    /// <summary>
    /// インメモリ用ユーザリポジトリ
    /// </summary>
    public class InMemoryUserRepository : IUserRepository
    {
        /// <summary>
        /// データストア
        /// </summary>
        /// <remarks>
        /// テストケースによってはデータを確認したいことがある 
        /// 確認のための操作を外部から行えるようにするためpublicにしている 
        /// </remarks>
        public Dictionary <UserId, User> Store { get; }
            = new Dictionary <UserId, User>();

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="userId">ユーザID</param>
        /// <returns>ユーザ</returns>
        public User Find(UserId id)
        {
            var targets = Store.Where(x => x.Key.Value == id.Value);
            if (targets.Any())
            {
                // インスタンスを直接返さずディープコピーを行う 
                return Clone(targets.First().Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="userId">ユーザ名</param>
        /// <returns>ユーザ</returns>
        public User Find(UserName userName)
        {
            var target = Store.Values.FirstOrDefault(user => userName.Equals(user.Name));
            if (target != null)
            {
                // インスタンスを直接返さずディープコピーを行う 
                return Clone(target);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 保存処理
        /// </summary>
        /// <param name="user">ユーザ</param>
        public void Save(User user)
        {
            // 保存時もディープコピーを行う
            Store[user.Id] = Clone(user);
        }

        /// <summary>
        /// 削除処理
        /// </summary>
        /// <param name="user">ユーザ</param>
        public void Delete(User user)
        {
            Store.Remove(user.Id);
        }

        /// <summary>
        /// ディープコピーを行う
        /// </summary>
        /// <param name="user">ユーザ</param>
        /// <returns>ユーザ</returns>
        private User Clone(User user)
        {
            return new User(user.Id, user.Name);
        }
    }
}
