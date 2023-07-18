using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ybrary.Event
{
    public class Scheduler
    {
        /// <summary>
        /// 작업 스케줄러 등록
        /// </summary>
        /// <param name="comment">설명</param>
        /// <returns></returns>
        public static bool AddScheduler(string comment)
        {
            try
            {
                using (TaskService service = new TaskService())
                {
                    if (!service.RootFolder.Tasks.Exists(Ybrary.Event.Systems.ProjectName))
                    {
                        TaskDefinition definition = service.NewTask();

                        // 일반
                        definition.Principal.DisplayName = Ybrary.Event.Systems.ProjectName; // 프로젝트 명
                        definition.RegistrationInfo.Description = comment;

                        LogonTrigger trigger = new LogonTrigger();
                        definition.Principal.UserId = string.Concat(Systems.UserDomainName, "\\", Systems.UserName);
                        definition.Principal.LogonType = TaskLogonType.InteractiveToken;
                        definition.Principal.RunLevel = TaskRunLevel.Highest;
                        definition.Triggers.Add(trigger);


                        // 조건
                        definition.Settings.MultipleInstances = TaskInstancesPolicy.IgnoreNew;
                        definition.Settings.DisallowStartIfOnBatteries = false;
                        definition.Settings.StopIfGoingOnBatteries = false;
                        definition.Settings.AllowHardTerminate = false;
                        definition.Settings.StartWhenAvailable = false;
                        definition.Settings.RunOnlyIfNetworkAvailable = false;
                        definition.Settings.IdleSettings.StopOnIdleEnd = false;
                        definition.Settings.IdleSettings.RestartOnIdle = false;

                        // 설정
                        definition.Settings.AllowDemandStart = false;
                        definition.Settings.Enabled = true;
                        definition.Settings.Hidden = false;
                        definition.Settings.RunOnlyIfIdle = false;
                        definition.Settings.RunOnlyIfIdle = false;
                        definition.Settings.ExecutionTimeLimit = TimeSpan.Zero;
                        definition.Settings.Priority = System.Diagnostics.ProcessPriorityClass.High;

                        // 동작
                        definition.Actions.Add($"{Systems.ExePath}");
                        service.RootFolder.RegisterTaskDefinition(Ybrary.Event.Systems.ProjectName, definition);

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 등록하고싶은 작업스케줄러 명이 있을경우.
        /// </summary>
        /// <param name="title">스케줄러명</param>
        /// <param name="comment">설명</param>
        /// <returns></returns>
        public static bool AddScheduler(string title, string comment)
        {
            try
            {
                using (TaskService service = new TaskService())
                {
                    if (!service.RootFolder.Tasks.Exists(title))
                    {
                        TaskDefinition definition = service.NewTask();

                        // 일반
                        definition.Principal.DisplayName = title; // 등록할 스케줄러 명
                        definition.RegistrationInfo.Description = comment;

                        LogonTrigger trigger = new LogonTrigger();
                        definition.Principal.UserId = string.Concat(Systems.UserDomainName, "\\", Systems.UserName);
                        definition.Principal.LogonType = TaskLogonType.InteractiveToken;
                        definition.Principal.RunLevel = TaskRunLevel.Highest;
                        definition.Triggers.Add(trigger);

                        // 조건
                        definition.Settings.MultipleInstances = TaskInstancesPolicy.IgnoreNew;
                        definition.Settings.DisallowStartIfOnBatteries = false;
                        definition.Settings.StopIfGoingOnBatteries = false;
                        definition.Settings.AllowHardTerminate = false;
                        definition.Settings.StartWhenAvailable = false;
                        definition.Settings.RunOnlyIfNetworkAvailable = false;
                        definition.Settings.IdleSettings.StopOnIdleEnd = false;
                        definition.Settings.IdleSettings.RestartOnIdle = false;

                        // 설정
                        definition.Settings.AllowDemandStart = false;
                        definition.Settings.Enabled = true;
                        definition.Settings.Hidden = false;
                        definition.Settings.RunOnlyIfIdle = false;
                        definition.Settings.RunOnlyIfIdle = false;
                        definition.Settings.ExecutionTimeLimit = TimeSpan.Zero;
                        definition.Settings.Priority = System.Diagnostics.ProcessPriorityClass.High;

                        // 동작
                        definition.Actions.Add($"{Systems.ExePath}");
                        service.RootFolder.RegisterTaskDefinition(title, definition);

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// 작업 스케줄러 삭제
        /// </summary>
        /// <returns></returns>
        public static bool DeleteScheduler()
        {
            try
            {
                using (TaskService service = new TaskService())
                {
                    if (service.RootFolder.Tasks.Exists(Ybrary.Event.Systems.ProjectName))
                    {
                        service.RootFolder.DeleteTask(Ybrary.Event.Systems.ProjectName);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 지정된 작업 스케줄러 삭제
        /// </summary>
        /// <returns></returns>
        public static bool DeleteScheduler(string title)
        {
            try
            {
                using (TaskService service = new TaskService())
                {
                    if (service.RootFolder.Tasks.Exists(title))
                    {
                        service.RootFolder.DeleteTask(title);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

    }
}
