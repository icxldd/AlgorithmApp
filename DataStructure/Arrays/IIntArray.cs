using System.Threading.Tasks;

namespace DataStructure.Arrays
{
    /// <summary>
    /// 数组
    /// </summary>
    public interface IIntArray
    {
        /// <summary>
        /// 插入
        /// </summary>
        public void Add(int value);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="index"></param>
        public void Remove(int index);

        /// <summary>
        /// 删除全部
        /// </summary>
        public void RemoveAll();

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="index"></param>
        public int Get(int index);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Update(int index, int value);

        public int Count { get; }
    }
}