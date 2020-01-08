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
        /// 执行匹配
        /// </summary>
        /// <param name="basePath"></param>
        /// <param name="modelSrc"></param>
        /// <param name="modelDes"></param>
        /// <returns></returns>
        public Dictionary<string, string> Build(string basePath, string modelSrc, string modelDes)
        {
            var srcPath = Path.Combine(basePath, string.Format("{0}.cs", modelSrc));
            var desPath = Path.Combine(basePath, string.Format("{0}.cs", modelDes));

            var srcText = ReadFile(srcPath);
            var desText = ReadFile(desPath);

            var srcField = LoadFields(srcText);
            var desField = LoadFields(desText);
            var srcDest = LoadDest(srcText);
            var desDest = LoadDest(desText);

            return this.Tactics(srcField, desField, srcDest, desDest);

        }

        //提取字段
        List<string> LoadFields(string model)
        {
            var match = Regex.Matches(model, @"public(\s+[\w<>\[\]]+){2}\s*{\s*get\s*;\s*set\s*;\s*}");
            var result = new List<string>();
            foreach (Match item in match)
            {
                var value = Regex.Match(item.Value, @"(\s+\w+\s*)(?=({\s*get\s*;\s*set\s*;\s*}))").Value;
                result.Add(value.Trim());
            }
            return result;
        }
        //提取描述
        List<string> LoadDest(string model)
        {
            var match = Regex.Matches(model, "Description\\(\"[\\w\u4E00-\u9FA5\\s\\(\\)]+\"\\)");
            var result = new List<string>();
            foreach (Match item in match)
            {
                var value = Regex.Match(item.Value, "(?<=Description\\(\")([\\w\u4E00-\u9FA5\\s\\(\\)]+)(?=\"\\))").Value;
                result.Add(value.Trim());
            }
            return result;
        }

        //文件读取
        string ReadFile(string path)
        {
            using (StreamReader reader = new StreamReader(path, Encoding.Default))
            {
                return reader.ReadToEnd();
            }
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
