using DomainDriven.Entity;

namespace DomainDriven.Interface
{
    /// <summary>
    /// サークルリポジトリ インタフェース
    /// </summary>
    public interface ICircleRepository
    {
        /// <summary>
        /// 保存処理
        /// </summary>
        /// <param name="circle">サークル</param>
        void Save(Circle circle);

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="id">サークルID</param>
        /// <returns>サークル</returns>
        Circle Find(CircleId id);

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="name">サークル名</param>
        /// <returns>サークル</returns>
        Circle Find(CircleName name);
    }
}
