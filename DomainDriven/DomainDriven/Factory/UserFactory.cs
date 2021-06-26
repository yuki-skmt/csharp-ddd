using DomainDriven.Entity;
using DomainDriven.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDriven
{
    /// <summary>
    /// DBアクセス用ユーザファクトリ
    /// </summary>
    public class UserFactory : IUserFactory
    {
        /// <summary>
        /// ユーザ作成処理
        /// </summary>
        /// <param name="name">ユーザ名</param>
        /// <returns>ユーザ</returns>
        public User Create(UserName name)
        {
            string seqId;
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = "SELECT seq = (NEXT VALUE FOR UserSeq)";
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var rawSeqId = reader["seq"];
                        seqId = rawSeqId.ToString();
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
            var id = new UserId(seqId); return new User(id, name);
        }
    }
}
