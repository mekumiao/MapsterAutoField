using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MapsterAutoField.ModelImport
{
    /// <summary>
    /// 通过正则取得字段及描述
    /// </summary>
    public class RegModelImport : IModelImport
    {
        /// <summary>
        /// 获取字段及描述
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="modelSrc"></param>
        /// <param name="modelDes"></param>
        /// <returns></returns>
        public Tuple<List<FieldInfo>, List<FieldInfo>> GetFields(string dir, string modelSrc, string modelDes)
        {
            var srcPath = Path.Combine(dir, string.Format("{0}.cs", modelSrc));
            var desPath = Path.Combine(dir, string.Format("{0}.cs", modelDes));

            var srcText = ReadFile(srcPath);
            var desText = ReadFile(desPath);

            var srcField = LoadFields(srcText);
            var desField = LoadFields(desText);
            var srcDest = LoadDest(srcText);
            var desDest = LoadDest(desText);

            var list1 = new List<FieldInfo>();
            var list2 = new List<FieldInfo>();


            srcField.ForEach(x => list1.Add(new FieldInfo() { Field = x }));
            srcDest.ForEach((x, i) => list1[i].Dest = x);

            desField.ForEach(x => list2.Add(new FieldInfo() { Field = x }));
            desDest.ForEach((x, i) => list2[i].Dest = x);

            var result = new Tuple<List<FieldInfo>, List<FieldInfo>>(list1, list2);

            return result;
        }

        /// <summary>
        /// 提取字段
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private List<string> LoadFields(string model)
        {
            var match = Regex.Matches(model, @"public(\s+[\w<>\[\].]+){2}\s*{\s*get\s*;\s*set\s*;\s*}");
            var result = new List<string>();
            foreach (Match item in match)
            {
                var value = Regex.Match(item.Value, @"(\s+\w+\s*)(?=({\s*get\s*;\s*set\s*;\s*}))").Value;
                result.Add(value.Trim());
            }
            return result;
        }
        /// <summary>
        /// 提取描述
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private List<string> LoadDest(string model)
        {
            var match = Regex.Matches(model, "Description\\(\"[\\w\u4E00-\u9FA5\\s\\(\\)【】（）]+\"\\)");
            var result = new List<string>();
            foreach (Match item in match)
            {
                var value = Regex.Match(item.Value, "(?<=Description\\(\")([\\w\u4E00-\u9FA5\\s\\(\\)【】（）]+)(?=\"\\))").Value;
                result.Add(value.Trim());
            }
            return result;
        }

        /// <summary>
        /// 文件读取
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private string ReadFile(string path)
        {
            using (StreamReader reader = new StreamReader(path, Encoding.Default))
            {
                return reader.ReadToEnd();
            }
        }

    }
}
