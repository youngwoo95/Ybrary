using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Ybrary.Logger
{
    public class Converter
    {
        /// <summary>
        /// 프로그램 설치파일 경로
        /// </summary>
        public static string BASEDIRECTPATH = AppDomain.CurrentDomain.BaseDirectory;


        /// <summary>
        /// Split
        /// 시작 키워드 ~ 종료 키워드 내 데이터 추출
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static MatchCollection Split(string path, string start, string end)
        {
            try
            {
                string filepath = File.ReadAllText(path);
                string pattern = String.Format(@"{0}([^>]*){1}", start, end);

                return Regex.Matches(filepath, pattern);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        /// <summary>
        /// 해당 폴더 내 Directory List 구하기
        /// </summary>
        /// <param name="path"></param>
        /// <returns>List<string> Type</returns>
        public static List<DirectoryInfo> GetDirectList(string path)
        {
            try
            {
                List<DirectoryInfo> list = new List<DirectoryInfo>();

                if (System.IO.Directory.Exists(path))
                {
                    var di = new System.IO.DirectoryInfo(path);
                    list = di.GetDirectories().ToList();
                }
                return list;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        /// <summary>
        /// 해당 폴더 내 File List 구하기
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<FileInfo> GetFileList(string path)
        {
            try
            {
                List<FileInfo> list = new List<FileInfo>();

                if (System.IO.Directory.Exists(path))
                {
                    var di = new System.IO.DirectoryInfo(path);
                    list = di.GetFiles().ToList();
                }
                return list;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        /// <summary>
        /// 경로를 자동으로 만들어준다.
        /// </summary>
        /// <param name="paths"></param>
        /// <returns></returns>
        public static string ConvertPath(string[] paths)
        {
            string path = string.Empty;

            for(int i = 0; i < paths.Length; i++)
            {
                if(String.IsNullOrEmpty(path))
                {
                    path += String.Format(@"{0}", paths[i]);
                }
                else
                {
                    path += String.Format(@"\{0}", paths[i]);
                }
            }
            return path;
        }



    }
}
