using Newtonsoft.Json.Linq;
using Ybrary.Event;

namespace LibTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var test = Ybrary.Logger.Converter.Split(@"C:\Users\user\Desktop\새 폴더 (3)\LC 2020-04-06 AM\LM Log 2020-04-06 14-00.txt", "\u0002", "\u0003");
            Console.WriteLine("");

            /*
            var test1 = Ybrary.Logger.Converter.GetDirectList("C:\\Users\\user\\Desktop\\새 폴더 (3)");
            Console.WriteLine("");

            var test2 = Ybrary.Logger.Converter.GetFileList("C:\\Users\\user\\Desktop\\새 폴더 (3)\\LC 2020-04-06 AM");
            Console.WriteLine("");

            var test3 = Ybrary.Logger.Log.CreateFolder("C:\\Users\\user\\Desktop\\새 폴더 (3)", "dddd");
            Console.WriteLine(test3);

            var test4 = Ybrary.Logger.Log.Message("C:\\Users\\user\\Desktop\\새 폴더 (3)", "filename", "afsdhadsfhsd");
            Console.WriteLine(test4);
            */
            
            string[] str = new string[5];
            str[0] = "C:";
            str[1] = "Users";
            str[2] = "user";
            str[3] = "source";
            str[4] = "repos";

            var path = Ybrary.Logger.Converter.ConvertPath(str);
            Console.WriteLine(path);

            JObject json = new JObject();
            Ybrary.Logger.Json.Insert(json,"Title1", "false", Ybrary.Logger.ValueType.Boolean);
            Ybrary.Logger.Json.Insert(json,"Title2", "Content2", Ybrary.Logger.ValueType.String);
            Ybrary.Logger.Json.Insert(json,"Title3", "Content3", Ybrary.Logger.ValueType.String);
            json = Ybrary.Logger.Json.CreateTitle(json, "제목");
            Console.WriteLine(json.ToString());

            JObject jsontest = new JObject();
            jsontest.Add("asdfasdf", "agsdg");
            JArray jarr = new JArray();
            jarr = Ybrary.Logger.Json.Insert(jarr, "asdgasg", Ybrary.Logger.ValueType.String);
            jarr = Ybrary.Logger.Json.Insert(jarr, "asdgasg1", Ybrary.Logger.ValueType.String);
            jarr = Ybrary.Logger.Json.Insert(jarr, "asdgasg2", Ybrary.Logger.ValueType.String);
            jarr = Ybrary.Logger.Json.Insert(jarr, 1, Ybrary.Logger.ValueType.Int32);
            Console.WriteLine(jarr);

            jsontest = Ybrary.Logger.Json.CreateTitle(jsontest, jarr, "타이틀");
            Console.WriteLine(jsontest);

            /*
            jarr.Add("asdfasdf");
            jarr.Add("asdfasdf1");
            jarr.Add("asdfasdf2");
            jarr.Add("asdfasdf3");
            jarr.Add(1);
            jsontest.Add("tewt", jarr);
            */
            //Console.WriteLine(jarr);
            //Console.WriteLine(jsontest);

            Console.WriteLine(Systems.SystemFolder);
            Console.WriteLine(Systems.DotNetVersion);
            Console.WriteLine(Systems.OSVersion);
            Console.WriteLine(Systems.ComputerName);
            Console.WriteLine(Systems.UserName);
            Console.WriteLine(Systems.ProjectName);
            Console.WriteLine(Systems.ProjectPath);

            Console.WriteLine(Systems.ExePath);
            Console.WriteLine(Systems.BinDirectory+String.Format(@"{0}.exe",Systems.ProjectName));

            //bool test1 = Ybrary.Event.Scheduler.AddScheduler("스케쥴러 테스트");
            //Console.WriteLine(test1);

            //bool test2 = Ybrary.Event.Scheduler.DeleteScheduler();
            //Console.WriteLine(test2);

            string s = Ybrary.Web.WebControl.RequestURL("http://arong.info:7003/posts");


            Console.ReadLine();
        }
    }
}