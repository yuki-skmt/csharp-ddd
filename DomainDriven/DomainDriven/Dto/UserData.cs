namespace DomainDriven
{
    /// <summary>
    /// ユーザ DTOクラス
    /// </summary>
    public class UserData
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="id">ユーザID</param>
        /// <param name="name">ユーザ名</param>
        public UserData(string id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>ユーザID</summary>
        public string Id { get; }
        /// <summary>ユーザ名</summary>
        public string Name { get; }
    }
}
