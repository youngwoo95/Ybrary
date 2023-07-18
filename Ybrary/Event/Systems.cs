using System;
using System.Collections.Generic;
using System.Text;

namespace Ybrary.Event
{
    public class Systems
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
        /// 시스템의 도메인 명
        /// </summary>
        public static readonly string UserDomainName = Environment.UserDomainName;

        /// <summary>
        /// 현재 폴더
        /// </summary>
        public static readonly string CurrentDirectory = Environment.CurrentDirectory;

        /// <summary>
        /// 프로그램 설치파일 경로
        /// </summary>
        public static readonly string BinDirectory = AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// 현재 솔루션 이름구하기
        /// </summary>
        public static readonly string ProjectName = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;

        /// <summary>
        /// 프로젝트 경로 구하기
        /// </summary>
        public static readonly string ProjectPath = System.IO.Directory.GetParent(CurrentDirectory).Parent.FullName;

        /// <summary>
        /// 프로그램 dll 파일 경로
        /// </summary>
        public static readonly string DllPath = System.Reflection.Assembly.GetExecutingAssembly().Location;

        /// <summary>
        /// 프로그램 exe 파일 경로
        /// </summary>
        public static readonly string ExePath = String.Format(Systems.BinDirectory + String.Format(@"{0}.exe", Systems.ProjectName));
    }
}
