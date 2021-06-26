using System;

namespace DomainDriven.Entity
{
    /// <summary>
    /// ユーザクラス
    /// </summary>
    public class User
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="id">ユーザID</param>
        /// <param name="name">ユーザ名</param>
        /// <remarks>
        /// インスタンスを再構成する際に利用する
        /// </remarks>
        public User(UserId id, UserName name)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Id = id;
            Name = name;
        }

        /// <summary>ユーザID</summary>
        public UserId Id { get; }
        /// <summary>ユーザ名</summary>
        public UserName Name { get; private set; }

        /// <summary>
        /// ユーザ名を変更する
        /// </summary>
        /// <param name="name">ユーザ名</param>
        public void ChangeName(UserName name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Name = name;
        }
    }

    /// <summary>
    /// ユーザID
    /// </summary>
    public class UserId
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="value">値</param>
        public UserId(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("valueがnullまたは空文字です");
            }
            Value = value;
        }

        /// <summary>値</summary>
        public string Value { get; }
    }

    /// <summary>
    /// ユーザ名
    /// </summary>
    public class UserName
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="value">値</param>
        public UserName(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            if (value.Length < 3)
            {
                throw new ArgumentException("ユーザ名は3文字以上です。", nameof(value));
            }
            if (value.Length > 20)
            {
                throw new ArgumentException("ユーザ名は20文字以下です。", nameof(value));
            }
            Value = value;
        }

        /// <summary>値</summary>
        public string Value { get; }
    }
}
