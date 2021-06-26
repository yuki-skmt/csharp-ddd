using DomainDriven.Entity;
using DomainDriven.Interface;

namespace DomainDriven
{
    /// <summary>
    /// インメモリ用ユーザファクトリ
    /// </summary>
    public class InMemoryUserFactory : IUserFactory
    {
        /// <summary>現在のID</summary>
        private int currentId;

        /// <summary>
        /// ユーザ作成処理
        /// </summary>
        /// <param name="name">ユーザ名</param>
        /// <returns>ユーザ</returns>
        public User Create(UserName name)
        {
            // ユーザが生成されるたびにインクリメント
            currentId++;

            return new User(
                new UserId(currentId.ToString()),
                name
            );
        }
    }
}
