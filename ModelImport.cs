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

        public Dictionary<string, string> Test(string basePath, string modelSrc, string modelDes)
        {
            var srcPath = Path.Combine(basePath, string.Format("{0}.cs", modelSrc));
            var desPath = Path.Combine(basePath, string.Format("{0}.cs", modelDes));

            var srcText = ReadFile(srcPath);
            var desText = ReadFile(desPath);
            var srcField = LoadFields(srcText);
            var desField = LoadFields(desText);

            var dis = new LevenshteinDistance();
            var result = new Dictionary<string, string>();
            var list = new List<decimal>();
            foreach (var des in desField)
            {
                if (srcField.Count == 0) break;
                foreach (var src in srcField)
                {
                    var n = dis.LevenshteinDistancePercent(des, src);
                    list.Add(n);
                }
                var index = list.IndexOf(list.Max());
                result.Add(des, srcField[index]);
                srcField.RemoveAt(index);
                list.Clear();
            }
            return result;
        }

        private string ReadFile(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                return reader.ReadToEnd();
            }
        }

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

    }
}
