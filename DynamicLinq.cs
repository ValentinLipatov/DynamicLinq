using System;
using System.Linq.Dynamic.Core;
using System.Linq.Dynamic.Core.Parser;
using System.Linq.Expressions;

namespace DynamicLinq
{
    public static class DynamicLinq
    {
        static DynamicLinq()
        {
            _parsingConfig = new ParsingConfig();
        }

        private static ParsingConfig _parsingConfig;

        public static TOut Invoke<TIn, TOut>(string expression, string parameterName, TIn parameter)
        {
            return (TOut)Invoke(typeof(TIn), typeof(TOut), expression, parameterName, parameter);
        }

        public static object Invoke(Type typeIn, Type typeOut, string expression, string parameterName, object parameter)
        {
            var expressionParameter = Expression.Parameter(typeIn, parameterName);
            var expressionParser = new ExpressionParser(new[] { expressionParameter }, expression, new object[] { }, _parsingConfig);
            var body = expressionParser.Parse(typeOut);
            return Expression.Lambda(body, expressionParameter).Compile().DynamicInvoke(parameter);
        }
    }
}