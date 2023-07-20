using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Ybrary.Command
{
    public class CMD
    {
        private static System.Diagnostics.ProcessStartInfo pri;
        private static System.Diagnostics.Process pro;

        /// <summary>
        /// CMD 명령어 실행
        /// </summary>
        /// <param name="isShow">CMD 창 띄우기 false : 띄우기 / true : 숨기기 </param>
        /// <param name="command">명령어</param>
        public static void Command(bool isShow, string command)
        {
            pri = new System.Diagnostics.ProcessStartInfo();
            pro = new System.Diagnostics.Process();

            // 실행할 파일 명 입력하기
            pri.FileName = "cmd.exe";
            // CMD 창 띄우기
            pri.CreateNoWindow = isShow; // false가 띄우기, true가 안 띄우기
            pri.UseShellExecute = false;

            pri.RedirectStandardInput = true;
            pri.RedirectStandardOutput = true;
            pri.RedirectStandardError = true;
            pri.Verb = "runas";

            pro.StartInfo = pri;
            pro.Start();

            pro.StandardInput.Write(command + Environment.NewLine);

            pro.StandardInput.Close();
            string resultValue = pro.StandardOutput.ReadToEnd();

            pro.WaitForExit();
            pro.Close();

            Console.WriteLine(resultValue);
        }

        /// <summary>
        /// IpConfig 명령어 실행
        /// </summary>
        /// <param name="isShow">CMD 창 띄우기 false : 띄우기 / true : 숨기기 </param>
        /// <param name="command">명령어</param>
        public static void IpConfig(bool isShow)
        {
            pri = new System.Diagnostics.ProcessStartInfo();
            pro = new System.Diagnostics.Process();

            // 실행할 파일 명 입력하기
            pri.FileName = "cmd.exe";
            // CMD 창 띄우기
            pri.CreateNoWindow = isShow; // false가 띄우기, true가 안 띄우기
            pri.UseShellExecute = false;

            pri.RedirectStandardInput = true;
            pri.RedirectStandardOutput = true;
            pri.RedirectStandardError = true;
            pri.Verb = "runas";

            pro.StartInfo = pri;
            pro.Start();

            pro.StandardInput.Write(@"ipconfig" + Environment.NewLine);

            pro.StandardInput.Close();
            string resultValue = pro.StandardOutput.ReadToEnd();

            pro.WaitForExit();
            pro.Close();

            Console.WriteLine(resultValue);
        }
    }
}
