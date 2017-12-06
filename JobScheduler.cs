using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Quartz;
using Quartz.Impl;

namespace PWdEEBudget.QuartZExample
{
    public class JobScheduler
    {
        public static void Start()
        {
            IJobDetail emailJob = JobBuilder.Create<SendBDaySMS>()
                  .WithIdentity("job1")
                  .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .StartNow()
                //Sec Min Hours Date Month ? Year       
                //.WithCronSchedule("0 20 17 18 1 ? 2017")
                .WithDailyTimeIntervalSchedule
                 (s =>
                    //s.WithIntervalInMinutes(58)//for Interval in minites
                    s.WithIntervalInHours(5)
                  .OnEveryDay()

                    .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(6, 00))
                )
                       .Build();
            ISchedulerFactory sf = new StdSchedulerFactory();
            IScheduler sc = sf.GetScheduler();
            sc.ScheduleJob(emailJob, trigger);
            sc.Start();
        }
    }
}