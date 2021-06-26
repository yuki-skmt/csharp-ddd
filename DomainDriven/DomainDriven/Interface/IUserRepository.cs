using DomainDriven.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDriven.Interface
{
    /// <summary>
    /// ユーザリポジトリ インタフェース
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="id">ユーザID</param>
        /// <returns>ユーザ</returns>
        User Find(UserId id);

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="name">ユーザ名</param>
        /// <returns>ユーザ</returns>
        User Find(UserName name);

        /// <summary>
        /// 保存処理
        /// </summary>
        /// <param name="user">ユーザ</param>
        void Save(User user);

        /// <summary>
        /// 削除処理
        /// </summary>
        /// <param name="user">ユーザ</param>
        void Delete(User user);
    }
}
