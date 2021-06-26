namespace DomainDriven.Command
{
    /// <summary>
    /// ユーザ登録コマンドクラス
    /// </summary>
    public class UserRegisterCommand
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name">ユーザ名</param>
        public UserRegisterCommand(string name)
        {
            Name = name;
        }

        /// <summary>ユーザ名</summary>
        public string Name { get; }
    }
}
