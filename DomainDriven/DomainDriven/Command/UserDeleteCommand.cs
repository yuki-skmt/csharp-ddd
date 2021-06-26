namespace DomainDriven.Command
{
    /// <summary>
    /// ユーザ削除コマンドクラス
    /// </summary>
    public class UserDeleteCommand
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="id">ユーザID</param>
        public UserDeleteCommand(string id)
        {
            Id = id;
        }

        /// <summary>ユーザID</summary>
        public string Id { get; }
    }
}