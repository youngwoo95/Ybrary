using System;
using System.Collections.Generic;
using System.Text;

namespace Ybrary.Event
{
    public class Environments
    {
        /// <summary>
        /// 시스템 폴더 경로
        /// </summary>
        public static readonly string SystemFolder = Environment.SystemDirectory;

        /// <summary>
        /// 닷넷 기준 버전
        /// </summary>
        public static readonly string DotNetVersion = Environment.Version.ToString();

        /// <summary>
        /// OS 버전
        /// </summary>
        public static readonly string OSVersion = Environment.OSVersion.VersionString;

        /// <summary>
        /// 컴퓨터 이름
        /// </summary>
        public static readonly string ComputerName = Environment.MachineName;

        /// <summary>
        /// 사용자 이름
        /// </summary>
        public static readonly string UserName = Environment.UserName;

        /// <summary>
        /// 현재 폴더
        /// </summary>
        public static readonly string CurrentDirectory = Environment.CurrentDirectory;

        /// <summary>
        /// 프로그램 설치파일 경로
        /// </summary>
        public static readonly string BinDirectory = AppDomain.CurrentDomain.BaseDirectory;

    }
}
