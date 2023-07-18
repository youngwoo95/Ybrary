using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace Ybrary.Logger
{
    public class Log
    {
        /// <summary>
        /// 폴더 생성
        /// </summary>
        /// <param name="path">상위폴더 경로</param>
        /// <param name="dirname">생성할 폴더명</param>
        /// <returns>해당폴더 경로</returns>
        public static bool CreateFolder(string path, string dirname)
        {
            bool result = false;
            try
            {
                string filepath = String.Format(@"{0}\\{1}", path, dirname);

                DirectoryInfo di = new DirectoryInfo(filepath);

                // 폴더가 존재하지 않을 때 생성
                if (!di.Exists)
                {
                    di.Create();
                    result = true;
                }
            }
            catch(Exception ex)
            {
                result = false;
                Console.WriteLine(ex);
            }
            return result;
        }

        /// <summary>
        /// 메시지 작성 - 없으면 파일생성
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool Message(string path, string filename, string message)
        {
            bool result = false;
            try
            {
                string filepath = Path.Combine(path, string.Format("{0}.txt", filename));

                using (StreamWriter sw = new StreamWriter(filepath, true))
                {
                    sw.WriteLine(message);
                    result = true;
                }
            }
            catch(Exception ex)
            {
                result = false;
                Console.WriteLine(ex);
            }
            return result;
        }

        /// <summary>
        /// 로그 파일 생성
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool LogMessage(string message)
        {
            bool result = false;
            try
            {
                DateTime today = DateTime.Now;

                string path = String.Format(@"{0}\\log", Event.Systems.BinDirectory);

                DirectoryInfo di = new DirectoryInfo(path);

                // 폴더가 존재하지 않을 때
                if (!di.Exists) di.Create();

                // 오늘에 해당하는 년도의 '년도' 파일 경로
                path = String.Format(@"{0}/{1}", path, today.Year);
                di = new DirectoryInfo(path);
                if (!di.Exists) di.Create();

                // 오늘에 해당하는 년도의 '월' 파일 경로
                path = String.Format(@"{0}/{1}", path, today.Month);
                di = new DirectoryInfo(path);
                if (!di.Exists) di.Create();

                // 오늘에 해당하는 년도의 '일' 파일 경로
                string filepath = Path.Combine(path, String.Format("{0}.txt", today.Day));

                using (StreamWriter sw = new StreamWriter(filepath, true))
                {
                    sw.WriteLine($"[{today.ToString()}]\t{message}");
                    result = true;
                }
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
