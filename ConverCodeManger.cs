using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MapsterAutoField
{
    public class ConverCodeManger
    {

        public string SourceCode { get; set; }
        protected const string temp1 = "\n\t\t\t\t.Map(dest => dest.{0}, src => src.{1})";
        protected const string temp2 = "\n\t\t\t\t.Map(dest => dest.{0}, src => {1})";
        protected const string temp3 = "Config.ForType<{0}, {1}>()";
        protected const string temp4 = "\n\t\t\t\t.IgnoreNonMapped(true);";

        protected const string nowtime = "T";

        /// <summary>
        /// 生成代码
        /// </summary>
        /// <returns></returns>
        public string ConvertCode()
        {
            var tabName = this.GetModelNames();
            if (tabName.Length != 2) throw new Exception("实体名称格式错误");
            var srcName = tabName[0];
            var destName = tabName[1];

            var fieldNames = GetFieldNames();

            var bulder = new StringBuilder();
            bulder.AppendFormat(temp3, srcName, destName);

            fieldNames.ForEach(x =>
            {
                switch (x.Type)
                {
                    case 3://当前时间
                        bulder.AppendFormat(temp2, x.Dest, "DateTime.Now");
                        break;
                    case 5://字段
                        bulder.AppendFormat(temp1, x.Dest, x.Src);
                        break;
                    default://默认值、数字、bool
                        bulder.AppendFormat(temp2, x.Dest, x.Src);
                        break;
                }
            });
            bulder.Append(temp4);
            return bulder.ToString();
        }

        /// <summary>
        /// 获取实体名称
        /// </summary>
        /// <returns></returns>
        public string[] GetModelNames()
        {
            var index = this.SourceCode.IndexOf(']');
            var title = this.SourceCode.Substring(0, index + 1).Trim();
            var match = Regex.Match(title, @"(?<=\[)(.*?)(?=\])");
            var result = match.Value.Split(',');
            Array.ForEach(result, x => x = x.Trim());
            return result;
        }

        /// <summary>
        /// 获取字段名称
        /// </summary>
        /// <returns></returns>
        public List<FieldValue> GetFieldNames()
        {
            var index = this.SourceCode.IndexOf(']');
            var code = this.SourceCode.Substring(index + 1).Trim();

            var list = code.Split('\n').ToList();
            var tb1 = list.Select(x => x.Split(',').ToList()).ToList();

            var result = new List<FieldValue>();
            if (tb1.Any() && tb1.First().Any())
            {
                tb1.ForEach(item =>
                {
                    if (item.Count >= 2)
                    {
                        var fd = new FieldValue();
                        fd.Dest = item[0].Trim();
                        fd.Src = item[1].Trim();

                        if (Regex.IsMatch(fd.Src, @"\d")) fd.Type = 1;
                        else if (Regex.IsMatch(fd.Src, "^[\"]{1}.*[\"]$")) fd.Type = 2;
                        else if (nowtime == fd.Src) fd.Type = 3;
                        else if (Regex.IsMatch(fd.Src, "^true|false$")) fd.Type = 4;
                        else fd.Type = 5;
                        result.Add(fd);
                    }
                });
            }
            return result;
        }

        public class FieldValue
        {
            public string Dest { get; set; }

            public string Src { get; set; }

            /// <summary>
            /// 源字段类型
            /// 1 数字
            /// 2 字符串
            /// 3 当前时间
            /// 4 bool类型
            /// 5 字段
            /// </summary>
            public int Type { get; set; }

        }

    }
}
