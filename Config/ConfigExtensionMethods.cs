using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Envivo.Fresnel.ModelAttributes.Config
{
    internal static class ConfigExtensionMethods
    {
        internal static PropertyInfo GetPropertyInfo<T>(this Expression<Func<T, object>> expression)
        {
            switch (expression?.Body)
            {
                case null:
                    throw new ArgumentNullException(nameof(expression));

                case UnaryExpression unaryExp when unaryExp.Operand is MemberExpression memberExp:
                    return (PropertyInfo)memberExp.Member;

                case MemberExpression memberExp:
                    return (PropertyInfo)memberExp.Member;

                default:
                    throw new ArgumentException($"Unable to determine Property from [ {expression} ]");
            }
        }

        internal static MethodInfo GetMethodInfo<T>(this Expression<Func<T, Delegate>> expression)
        {
            switch (expression?.Body)
            {
                case null:
                    throw new ArgumentNullException(nameof(expression));

                case UnaryExpression unaryExp when unaryExp.Operand is MethodCallExpression methodExp:
                    return (MethodInfo)(methodExp.Object as ConstantExpression)?.Value;

                case MethodCallExpression methodExp:
                    return methodExp.Method;

                default:
                    throw new ArgumentException($"Unable to determine Method from [ {expression} ]");
            }
        }
    }
}
