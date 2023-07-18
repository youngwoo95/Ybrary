using System;
using System.IO;

namespace Ybrary.Event
{
    public class Dialog
    {
        /// <summary>
        /// 파일 유무 검사
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool FileCheck(string path)
        {
            bool result = false;
            try
            {
                result = File.Exists(path);
            }
            catch(Exception ex)
            {
                result = false;
                Console.WriteLine(ex);
            }
            return result;
        }

        

    }
}
