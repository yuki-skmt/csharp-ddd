using DomainDriven.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDriven.Interface
{
    /// <summary>
    /// ユーザファクトリ インタフェース
    /// </summary>
    public interface IUserFactory
    {
        /// <summary>
        /// ユーザ作成処理
        /// </summary>
        /// <param name="name">ユーザ名</param>
        /// <returns>ユーザ</returns>
        User Create(UserName name);
    }
}
