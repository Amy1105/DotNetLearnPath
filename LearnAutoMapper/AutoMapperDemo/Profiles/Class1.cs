using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AutoMapperDemo.Profiles
{

    public class LambdaNamingConvention : INamingConvention
    {
        private readonly Func<Match, string> _replaceValue;
        private readonly Regex _splittingExpression;

        public LambdaNamingConvention(Func<Match, string> replaceValue, Regex splittingExpression)
        {
            _replaceValue = replaceValue;
            _splittingExpression = splittingExpression;
        }

        public Regex SplittingExpression => _splittingExpression;
        public string SeparatorCharacter => "";
        public string ReplaceValue(Match match) => _replaceValue(match);

        public string[] Split(string input)
        {
            throw new NotImplementedException();
        }
    }


    // 自定义命名约定类
    public class CustomNamingConvention : INamingConvention
    {
        private readonly INamingConvention _baseConvention;
        private readonly string _prefix;

        public CustomNamingConvention(INamingConvention baseConvention, string prefix)
        {
            _baseConvention = baseConvention;
            _prefix = prefix;
        }

        public Regex SplittingExpression => _baseConvention.SplittingExpression;
        public string SeparatorCharacter => _baseConvention.SeparatorCharacter;

        public string ReplaceValue(Match match)
        {
            var value = match.Value;
            if (value.StartsWith(_prefix))
            {
                return value.Substring(_prefix.Length);
            }
            return value;
        }
    }
}
