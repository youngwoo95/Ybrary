using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ybrary.Logger
{
   

    public class Json
    {
        /// <summary>
        /// Object를 Object에 종속
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static JObject CreateTitle(JObject obj, string title)
        {
            JObject newobj = new JObject();
            newobj.Add(title, obj);

            return newobj;
        }

        /// <summary>
        /// Array 를 Object에 종속
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="jarr"></param>
        /// <param name="Title"></param>
        /// <returns></returns>
        public static JObject CreateTitle(JObject obj,JArray jarr, string Title)
        {
            obj.Add(Title, jarr);

            return obj;
        }


        /// <summary>
        /// JSON DATA INSERT
        /// </summary>
        /// <param name="json"></param>
        /// <param name="title"></param>
        /// <param name="contents"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static JObject Insert(JObject json,string title, object contents, ValueType type)
        {
            switch (type)
            {
                // Bool Type Data Input
                case ValueType.Boolean:
                    bool boolValue = bool.Parse(contents.ToString());
                    json.Add(title, boolValue);
                    return json;
                
                // Byte Type Data Input
                case ValueType.Byte:
                    byte byteValue = byte.Parse(contents.ToString());
                    json.Add(title, byteValue);
                    return json;

                // SByte Type Data Input
                case ValueType.SByte:
                    sbyte sbyteValue = sbyte.Parse(contents.ToString());
                    json.Add(title, sbyteValue);
                    return json;
                
                // Short Type Data Input
                case ValueType.Int16:
                    short shortValue = short.Parse(contents.ToString());
                    json.Add(title, shortValue);
                    return json;

                // Int Type Data Input
                case ValueType.Int32:
                    int intValue = int.Parse(contents.ToString());
                    json.Add(title, intValue);
                    return json;

                // Long Type Data Input
                case ValueType.Int64:
                    long longValue = long.Parse(contents.ToString());
                    json.Add(title, longValue);
                    return json;
                    
                // Ushort Type Data Input
                case ValueType.UInt16:
                    ushort ushortValue = ushort.Parse(contents.ToString());
                    json.Add(title, ushortValue);
                    return json;
                    
                // Uint Type Data Input
                case ValueType.UInt32:
                    uint uintValue = uint.Parse(contents.ToString());
                    json.Add(title, uintValue);
                    return json;
                    
                
                // Ulong Type Data Input
                case ValueType.UInt64:
                    ulong ulongValue = ulong.Parse(contents.ToString());
                    json.Add(title, ulongValue);
                    return json;

                // Float Type Data Input
                case ValueType.Float:
                    float floatValue = float.Parse(contents.ToString());
                    json.Add(title, floatValue);
                    return json;

                // Double Type Data Input
                case ValueType.Double:
                    double doubleValue = double.Parse(contents.ToString());
                    json.Add(title, doubleValue);
                    return json;

                // Deciaml Type Data Input
                case ValueType.Decimal:
                    decimal decimalValue = decimal.Parse(contents.ToString());
                    json.Add(title, decimalValue);
                    return json;

                // Char Type Data Input
                case ValueType.Char:
                    char charValue = char.Parse(contents.ToString());
                    json.Add(title, charValue);
                    return json;

                // String Type Data Input
                case ValueType.String:
                    string stringValue = contents.ToString();
                    json.Add(title, stringValue);
                    return json;

                // default
                default:
                    return null;
            }
        }

        /// <summary>
        /// JSON ARRAY DATA INSERT
        /// </summary>
        /// <param name="jarr"></param>
        /// <param name="contents"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static JArray Insert(JArray jarr, object contents, ValueType type)
        {
            switch(type)
            {
                // Bool Type Array Data Input
                case ValueType.Boolean:
                    bool boolValue = bool.Parse(contents.ToString());
                    jarr.Add(boolValue);
                    return jarr;

                // Byte Type Array Data Input
                case ValueType.Byte:
                    byte byteValue = byte.Parse(contents.ToString());
                    jarr.Add(byteValue);
                    return jarr;

                // SByte Type Array Data Input
                case ValueType.SByte:
                    sbyte sbyteValue = sbyte.Parse(contents.ToString());
                    jarr.Add(sbyteValue);
                    return jarr;

                // Short Type Array Data Input
                case ValueType.Int16:
                    short shortValue = short.Parse(contents.ToString());
                    jarr.Add(shortValue);
                    return jarr;

                // Int Type Data Input
                case ValueType.Int32:
                    int intValue = int.Parse(contents.ToString());
                    jarr.Add(intValue);
                    return jarr;

                // Long Type Data Input
                case ValueType.Int64:
                    long longValue = long.Parse(contents.ToString());
                    jarr.Add(longValue);
                    return jarr;

                // Ushort Type Data Input
                case ValueType.UInt16:
                    ushort ushortValue = ushort.Parse(contents.ToString());
                    jarr.Add(ushortValue);
                    return jarr;

                // Uint Type Data Input
                case ValueType.UInt32:
                    uint uintValue = uint.Parse(contents.ToString());
                    jarr.Add(uintValue);
                    return jarr;

                // Ulong Type Data Input
                case ValueType.UInt64:
                    ulong ulongValue = ulong.Parse(contents.ToString());
                    jarr.Add(ulongValue);
                    return jarr;

                // Float Type Data Input
                case ValueType.Float:
                    float floatValue = float.Parse(contents.ToString());
                    jarr.Add(floatValue);
                    return jarr;

                // Double Type Data Input
                case ValueType.Double:
                    double doubleValue = double.Parse(contents.ToString());
                    jarr.Add(doubleValue);
                    return jarr;

                // Decimal Type Data Input
                case ValueType.Decimal:
                    decimal decimalValue = decimal.Parse(contents.ToString());
                    jarr.Add(decimalValue);
                    return jarr;

                // Char Type Data Input
                case ValueType.Char:
                    char charValue = char.Parse(contents.ToString());
                    jarr.Add(charValue);
                    return jarr;

                // String Type Data Input
                case ValueType.String:
                    string stringValue = contents.ToString();
                    jarr.Add(stringValue);
                    return jarr;

                default:
                    return null;
            }

            
        }




    }
}
