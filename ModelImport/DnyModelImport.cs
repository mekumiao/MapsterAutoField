using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TempTop;

namespace MapsterAutoField.ModelImport
{
    /// <summary>
    /// 取得字段及描述
    /// </summary>
    public class DnyModelImport : IModelImport
    {
        protected static ITempBuild Build;

        /// <summary>
        /// 编译加载类文件
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        protected Dictionary<string, Type> LoadTypes(string path)
        {
            var ass = Assembly.LoadFile(path);
            return ass.GetTypes().Where(x => x.BaseType.Name.ToLower() == "modelbase").ToDictionary(x => x.Name, y => y);
        }

        /// <summary>
        /// 获取字段及描述
        /// </summary>
        /// <param name="dir">实体所在文件夹</param>
        /// <param name="modelSrc">源实体名称</param>
        /// <param name="modelDes">目标实体名称</param>
        /// <returns></returns>
        public Tuple<List<FieldInfo>, List<FieldInfo>> GetFields(string dir, string srcName, string desName)
        {
            var types = LoadTypes(dir);
            var srcModel = default(Type);
            var desModel = default(Type);

            if (types.ContainsKey(srcName)) srcModel = types[srcName];
            if (types.ContainsKey(srcName)) desModel = types[desName];

            var srcProps = srcModel.GetProperties().Where(x => x.CustomAttributes.Any()).ToList();
            var desProps = desModel.GetProperties().Where(x => x.CustomAttributes.Any()).ToList();

            var srcfields = default(List<FieldInfo>);
            var desfields = default(List<FieldInfo>);

            srcfields = srcProps.Select(x => new FieldInfo() { Field = x.Name, Dest = GetDescription(x) }).ToList();
            desfields = desProps.Select(x => new FieldInfo() { Field = x.Name, Dest = GetDescription(x) }).ToList();

            return new Tuple<List<FieldInfo>, List<FieldInfo>>(srcfields, desfields);
        }

        protected string GetDescription(PropertyInfo info)
        {
            return (info.GetCustomAttribute(typeof(DescriptionAttribute), false) as DescriptionAttribute)?.Description;
        }
    }
}
