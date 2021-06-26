namespace DomainDriven.Command
{
    /// <summary>
    /// ユーザ更新コマンドクラス
    /// </summary>
    public class UserUpdateCommand
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="id">ユーザID</param>
        public UserUpdateCommand(string id)
        {
            Id = id;
        }

        /// <summary>ユーザID</summary> 
        public string Id { get; }

        /// <summary>ユーザ名</summary> 
        /// <remarks>
        /// データが設定されると変更される
        /// </remarks>
        public string Name { get; set; }
    }
}
