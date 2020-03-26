using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapsterAutoField.ModelImport
{
    public class FieldInfo
    {
        /// <summary>
        /// 字段
        /// </summary>
        public string Field { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Dest { get; set; }

    }

    public interface IModelImport
    {
        /// <summary>
        /// 获取字段及描述
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="modelSrc"></param>
        /// <param name="modelDes"></param>
        /// <returns></returns>
        Tuple<List<FieldInfo>, List<FieldInfo>> GetFields(string dir, string srcName, string desName);

    }
}
