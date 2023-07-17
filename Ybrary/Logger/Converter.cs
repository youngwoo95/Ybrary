using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Ybrary.Logger
{
    internal class Converter
    {
        /// <summary>
        /// Split
        /// 시작 키워드 ~ 종료 키워드 내 데이터 추출
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static MatchCollection Split(string path, string start, string end)
        {
            string filepath = File.ReadAllText(path);
            string pattern = String.Format(@"{0}([^>\*]){1}", start, end);
            
            return Regex.Matches(filepath, pattern);
        }

    }
}
