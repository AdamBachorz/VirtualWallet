using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Web;

namespace VirtualWallet.Common.Extensions
{
    public static class ObjectExtensions
    {
        public static string ToQueryParametersString(this object ob)
        {
            var queryString = new List<string>();

            var properties = ob.GetType().GetProperties().Where(p => p.MemberType == MemberTypes.Property);

            foreach (var prop in properties)
            {
                string key = prop.Name.ToCamelCase();
                string value = prop.GetValue(ob, null)?.ToString() ?? string.Empty;
                queryString.Add($"{key}={value}".RemoveText("&"));
            }

            return queryString.Join("&");
        }

        public static byte[] ToByteArray(this object obj)
        {
            if (obj == null)
            {
                return null;
            }
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
    }
}
