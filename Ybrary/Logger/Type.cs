using System;
using System.Collections.Generic;
using System.Text;

namespace Ybrary.Logger
{
    /// <summary>
    /// Boolean - [0] : System.Boolean == bool type
    /// Byte - [1] : System.Byte == byte type
    /// SByte - [2] : System.SByte == sbyte type
    /// Int16 - [3] : System.Int16 == short type
    /// Int32 - [4] : System.Int32 == int type
    /// Int64 - [5] : System.Int64 == long type
    /// UInt16 - [6] : System.UInt16 == ushort type
    /// UInt32 - [7] : System.UInt32 == uint type
    /// Ulnt64 - [8] : System.Uint64 == ulong
    /// Float - [9] : System.Single == float
    /// Double - [10] : System.Double == double
    /// Decimal - [11] : System.Decimal == decimal
    /// Char - [12] : System.Char == char
    /// String - [13] : System.String == string
    /// </summary>
    public enum ValueType
    {
        Boolean,
        Byte,
        SByte,
        Int16,
        Int32,
        Int64,
        UInt16,
        UInt32,
        UInt64,
        Float,
        Double,
        Decimal,
        Char,
        String
    };

    public class Type
    {
        /// <summary>
        /// Int 타입 최대값
        /// </summary>
        /// <returns></returns>
        public int IntMaxValue()
        {
            return int.MaxValue;
        }

        /// <summary>
        /// Int 타입 최소값
        /// </summary>
        /// <returns></returns>
        public int IntMinValue()
        {
            return int.MinValue;
        }

        /// <summary>
        /// Byte Type 최대값
        /// </summary>
        /// <returns></returns>
        public byte ByteMaxValue()
        {
            return byte.MaxValue;
        }

        /// <summary>
        /// Byte Type 최소값
        /// </summary>
        /// <returns></returns>
        public byte ByteMinValue()
        {
            return byte.MinValue;
        }

        /// <summary>
        /// SByte Type 최대값
        /// </summary>
        /// <returns></returns>
        public sbyte SByteMaxValue()
        {
            return sbyte.MaxValue;
        }

        /// <summary>
        /// SByte Type 최소값
        /// </summary>
        /// <returns></returns>
        public sbyte SByteMinValue()
        {
            return sbyte.MinValue;
        }

        /// <summary>
        /// Short Type 최대값
        /// </summary>
        /// <returns></returns>
        public short ShortMaxValue()
        {
            return short.MaxValue;
        }

        /// <summary>
        /// Short Type 최소값
        /// </summary>
        /// <returns></returns>
        public short ShortMinValue()
        {
            return short.MinValue;
        }

        /// <summary>
        /// Long Type 최대값
        /// </summary>
        /// <returns></returns>
        public long LongMaxValue()
        {
            return long.MaxValue;
        }

        /// <summary>
        /// Long Type 최소값
        /// </summary>
        /// <returns></returns>
        public long LongMinValue()
        {
            return long.MinValue;
        }

        /// <summary>
        /// Ushort Type 최대값
        /// </summary>
        /// <returns></returns>
        public ushort UshortMaxValue()
        {
            return ushort.MaxValue;
        }

        /// <summary>
        /// Ushort Type 최소값
        /// </summary>
        /// <returns></returns>
        public ushort UshortMinValue()
        {
            return ushort.MinValue;
        }

        /// <summary>
        /// Uint Type 최대값
        /// </summary>
        /// <returns></returns>
        public uint UintMaxValue()
        {
            return uint.MaxValue;
        }

        /// <summary>
        /// Uint Type 최소값
        /// </summary>
        /// <returns></returns>
        public uint UintMinValue()
        {
            return uint.MinValue;
        }

        /// <summary>
        /// Ulong Type 최대값
        /// </summary>
        /// <returns></returns>
        public ulong UlongMaxValue()
        {
            return ulong.MaxValue;
        }

        /// <summary>
        /// Ulong Type 최소값
        /// </summary>
        /// <returns></returns>
        public ulong UlongMinValue()
        {
            return ulong.MinValue;
        }

        /// <summary>
        /// Float Type 최대값
        /// </summary>
        /// <returns></returns>
        public float FloatMaxValue()
        {
            return float.MaxValue;
        }

        /// <summary>
        /// Float Type 최소값
        /// </summary>
        /// <returns></returns>
        public float FloatMinValue()
        {
            return float.MinValue;
        }

        /// <summary>
        /// Double Type 최대값
        /// </summary>
        /// <returns></returns>
        public double DoubleMaxValue()
        {
            return double.MaxValue;
        }

        /// <summary>
        /// Double Type 최소값
        /// </summary>
        /// <returns></returns>
        public double DoubleMinValue()
        {
            return double.MinValue;
        }

        /// <summary>
        /// Decimal Type 최대값
        /// </summary>
        /// <returns></returns>
        public decimal DecimalMaxValue()
        {
            return decimal.MaxValue;
        }

        /// <summary>
        /// Decimal Type 최소값
        /// </summary>
        /// <returns></returns>
        public decimal DecimalMinValue()
        {
            return decimal.MinValue;
        }

        
    }
}
