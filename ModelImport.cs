using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MapsterAutoField
{
    public class ModelImport
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


        public Dictionary<string, string> Test(string basePath, string modelSrc, string modelDes)
        {
            var srcPath = Path.Combine(basePath, string.Format("{0}.cs", modelSrc));
            var desPath = Path.Combine(basePath, string.Format("{0}.cs", modelDes));

            var srcText = ReadFile(srcPath);
            var desText = ReadFile(desPath);

            var info = new List<FieldInfo>();

            var srcField = LoadFields(srcText);
            var desField = LoadFields(desText);
            var srcDest = LoadDest(srcText);
            var desDest = LoadDest(desText);

            desField.ForEach(x =>
            {
                var fd = new FieldInfo()
                {
                    desField = x,
                    srcField = 
                };

                info.Add(fd);
            });

            return this.Tactics(srcField, desField, srcDest, desDest);
        }

        private string ReadFile(string path)
        {
            using (StreamReader reader = new StreamReader(path, Encoding.Default))
            {
                return reader.ReadToEnd();
            }
        }

        /// <summary>
        /// 提取字段
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private List<string> LoadFields(string model)
        {
            var match = Regex.Matches(model, @"public(\s+\w+){2}\s*{\s*get\s*;\s*set\s*;\s*}");
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
            var match = Regex.Matches(model, "Description\\(\"[\u4E00-\u9FA5\\s\\(\\)]+\"\\)");
            var result = new List<string>();
            foreach (Match item in match)
            {
                var value = Regex.Match(item.Value, "(?<=Description\\(\")([\u4E00-\u9FA5\\s\\(\\)]+)(?=\"\\))").Value;
                result.Add(value.Trim());
            }
            return result;
        }


        /// <summary>
        /// 匹配策略
        /// </summary>
        /// <returns></returns>
        public virtual Dictionary<string, string> Tactics(List<string> desField, List<string> srcField, List<string> srcDest, List<string> desDest)
        {
            var dis = new LevenshteinDistance();
            var result = new Dictionary<string, string>();
            var list = new List<decimal>();
            for (int i = 0; i < desDest.Count; i++)
            {
                var des = desDest[i];
                if (srcDest.Count == 0) break;
                for (int j = 0; j < srcDest.Count; j++)
                {
                    var src = srcDest[j];
                    var n = dis.LevenshteinDistancePercent(des, src);
                    list.Add(n);
                }
                var index = list.IndexOf(list.Max());
                result.Add(desField[i], srcField[index]);
                srcField.RemoveAt(index);
                srcDest.RemoveAt(index);
                list.Clear();
            }
            return result;
        }

    }
}
