﻿using DomainDriven.Entity;
using DomainDriven.Interface;
using System.Configuration;
using System.Data.SqlClient;

namespace DomainDriven.Repository
{
    /// <summary>
    /// DBアクセス用ユーザリポジトリ
    /// </summary>
    public class UserRepository : IUserRepository
    {
        /// <summary>接続文字列</summary>
        private string connectionString = 
            ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="userId">ユーザID</param>
        /// <returns>ユーザ</returns>
        public User Find(UserId userId)
        {
            using (var connection = new SqlConnection(connectionString)) using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = "SELECT * FROM users WHERE id = @id";
                command.Parameters.Add(new SqlParameter("@id", userId.Value));
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var id = reader["id"] as string;
                        var name = reader["name"] as string;
                        return new User(new UserId(id), new UserName(name));
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="userId">ユーザ名</param>
        /// <returns>ユーザ</returns>
        public User Find(UserName userName)
        {
            using (var connection = new SqlConnection(connectionString)) using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = "SELECT * FROM users WHERE name = @name";
                command.Parameters.Add(new SqlParameter("@name", userName.Value));
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var id = reader["id"] as string;
                        var name = reader["name"] as string;
                        return new User(new UserId(id), new UserName(name));
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        /// <summary>
        /// 保存処理
        /// </summary>
        /// <param name="user">ユーザ</param>
        public void Save(User user)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = @"
MERGE INTO users USING ( SELECT @id AS id, @name AS name ) AS data 
ON users.id = data.id 
WHEN MATCHED THEN UPDATE SET name = data.name
WHEN NOT MATCHED THEN INSERT (id, name) VALUES (data.id, data.name);";
                command.Parameters.Add(new SqlParameter("@id", user.Id.Value));
                command.Parameters.Add(new SqlParameter("@name", user.Name.Value));
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 削除処理
        /// </summary>
        /// <param name="user">ユーザ</param>
        public void Delete(User user)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = "DELETE FROM users WHERE name = @name";
                command.Parameters.Add(new SqlParameter("@name", user.Name.Value));
                command.ExecuteReader();
            }
        }
    }
}
