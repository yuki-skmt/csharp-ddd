using DomainDriven.Interface;
using DomainDriven.Repository;
using DomainDriven.Service;
using Microsoft.Extensions.DependencyInjection;

namespace DomainDriven
{
    /// <summary>
    /// プログラムメインクラス
    /// </summary>
    public class Program
    {
        /// <summary>サービスプロバイダ</summary>
        public static ServiceProvider Provider;

        /// <summary>
        /// メインメソッド
        /// </summary>
        /// <param name="args">パラメータ</param>
        static void Main(string[] args)
        {
            // DIコンテナに登録
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<IUserRepository, UserRepository>();
            serviceCollection.AddTransient<IUserFactory, UserFactory>();
            serviceCollection.AddTransient<UserApplicationService>();
            serviceCollection.AddTransient<UserService>();
            Provider = serviceCollection.BuildServiceProvider();

            // DIコンテナからサービスを取得
            var userApplicationService = Provider.GetService<UserApplicationService>();
        }
    }
}
