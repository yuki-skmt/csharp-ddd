using DomainDriven.Entity;
using DomainDriven.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDriven.Service
{
    /// <summary>
    /// ユーザ ドメインサービス
    /// </summary>
    public class UserService
    {
        /// <summary>ユーザリポジトリ</summary>
        private readonly IUserRepository userRepository;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="userRepository">ユーザリポジトリ</param>
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        /// <summary>
        /// 重複確認
        /// </summary>
        /// <param name="user">ユーザ</param>
        /// <returns>重複している=true/重複していない=false</returns>
        public bool Exists(User user)
        {
            var duplicatedUser = userRepository.Find(user.Name);
            return duplicatedUser != null;
        }
    }
}
