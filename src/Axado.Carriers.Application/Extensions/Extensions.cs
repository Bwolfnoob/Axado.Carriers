using System;
using System.Reflection;

namespace Axado.Carriers.Application.Extensions
{
    public static class Extensions
    {
        public static object GetPropertyFromString(this object obj, string propertyName)
        {
            return obj == null ? null : obj.GetType().GetProperty(propertyName).GetValue(obj, null);
        }

        /// <summary>
        /// Essa função faz um Split por Espaço e retorna a posicao solicitada
        /// </summary>
        /// <param name="splitPosition">Posição desejada</param>
        /// <returns></returns>
        public static string SplitSpace(this string str, int splitPosition)
        {
            try
            {
                return str.Split(' ')[splitPosition];
            }
            catch
            {
                return null;
            }
        }
    }
}
