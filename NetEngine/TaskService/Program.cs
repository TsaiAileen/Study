using Common;
using DistributedLock.Redis;
using Logger.DataBase;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using StackExchange.Redis;
using TaskService.Libraries;
using TaskService.Models;
using TencentCloud.Cloudhsm.V20191112.Models;

namespace TaskService
{
    class Program
    {
        static void Main(string[] args)
        {
            const int sffff = 1;

            Console.WriteLine(sffff);


            //sffff = 2;


            //int se = 65;
            StudyHelper study = new();

            List<string> sds = new() { "Ann", "John", "Amy", "Aay", "amy", "5" };

            sds = sds.OrderBy(t => t).ToList();

            foreach (string item in sds)
            {
                Console.WriteLine(item);
            }




            List<int> sf = new() { 153, 207, 145, 207 };

            sf.Add(65);

            //sf = sf.OrderBy(t=>t).ToList();
            sf = sf.Distinct().OrderByDescending(t => t).ToList();

            foreach (int item in sf)
            {
                bool ss = study.IsEvenNum(item);

                if (ss == true)
                {
                    Console.WriteLine($"{item}是偶数");
                }
                else
                {
                    Console.WriteLine($"{item}是奇數");
                }
            }


            int[] sss = [153, 107, 230];
            sss[3] = 140;


            int[] xs = new int[5];
            xs[0] = 153;
            xs[1] = 107;
            xs[20] = 230;

            // for (int i = 100; i >0; i--)
            // {
            //     bool ss = study.IsEvenNum(i);

            //     if (ss == true)
            //     {
            //         Console.WriteLine($"{i}是偶数");
            //     }
            //     else
            //     {
            //         Console.WriteLine($"{i}是奇數");
            //     }
            // }

            int ia = -1;
            while (ia > 0)
            {
                bool ss = study.IsEvenNum(ia);

                if (ss == true)
                {
                    Console.WriteLine($"{ia}是偶数");
                }
                else
                {
                    Console.WriteLine($"{ia}是奇數");
                }

                ia--;
            }



            do
            {
                bool ss = study.IsEvenNum(ia);

                if (ss == true)
                {
                    Console.WriteLine($"{ia}是偶数");
                }
                else
                {
                    Console.WriteLine($"{ia}是奇數");
                }

                ia--;
            } while (ia > 0);





            int a = 9;
            int b = 15;
            int c = a - b; //-6
            int d = a + b; // 24
            int e = a * b; // 135
            double f = double.Parse(b.ToString()) / Convert.ToDouble(a); // 1.666
            f = Math.Round(f, 2);
            int g = b % a; // 6

            DateTime oldTime = DateTime.Parse("2024-01-25");
            Study s = new();


            s.S1 = -9454;

            s.I1 = 3545555;

            s.Ld = 5655555555555555557;

            s.Password = 1.12F;
            s.MobilePhone = 891.123;
            s.UserName = decimal.Parse("616");
            s.Nickname = "S";
            s.user_name = true;
            s.Dx = DateTime.Now;
            s.DC = DateTimeOffset.Now;
            s.Dxx = DateOnly.FromDateTime(s.Dx);
            s.Tx = TimeOnly.FromDateTime(s.Dx);
            s.TxT = s.Dx - oldTime;

            s.Id = Guid.NewGuid();

            Console.WriteLine($"s1={s.S1}");


            ThreadPool.SetMinThreads(128, 1);

            EnvironmentHelper.ChangeDirectory(args);

            List<Type>? initSingletonServiceTypes = [];

            IHost host = Host.CreateDefaultBuilder(args).UseWindowsService()
                .ConfigureLogging((hostContext, builder) =>
                {
                    //注册数据库日志服务
                    //builder.AddDataBaseLogger(options => { });

                    //注册本地文件日志服务
                    //builder.AddLocalFileLogger(options => { });
                })
                .ConfigureServices((hostContext, services) =>
                {

                    services.AddDbContextPool<Repository.Database.DatabaseContext>(options =>
                    {
                        var connectionString = hostContext.Configuration.GetConnectionString("dbConnection");

                        options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 36)));

                    }, 30);


                    //services.BatchRegisterServices();





                    //注册雪花ID算法
                    services.AddSingleton(new IDHelper(0, 0));


                    // //注册分布式锁 Redis模式
                    // services.AddRedisLock(options =>
                    // {
                    //     options.Configuration = hostContext.Configuration.GetConnectionString("redisConnection")!;
                    //     options.InstanceName = "lock";
                    // });


                    // //注册缓存服务 Redis模式
                    // services.AddStackExchangeRedisCache(options =>
                    // {
                    //     options.Configuration = hostContext.Configuration.GetConnectionString("redisConnection");
                    //     options.InstanceName = "cache";
                    // });


                    // //注册 Redis 驱动
                    // services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(hostContext.Configuration.GetConnectionString("redisConnection")!));


                    #region 注册HttpClient

                    services.AddHttpClient("", options =>
                    {
                        options.DefaultVersionPolicy = HttpVersionPolicy.RequestVersionOrHigher;
                    }).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
                    {
                        AllowAutoRedirect = false,
                        AutomaticDecompression = System.Net.DecompressionMethods.All,
                        UseCookies = false
                    });

                    #endregion

                })
                .Build();

            host.Start();


#if DEBUG

            var queueMethodList = Libraries.QueueTask.QueueTaskBuilder.queueMethodList;

            var scheduleMethodList = Libraries.ScheduleTask.ScheduleTaskBuilder.scheduleMethodList;

        StartActionTag:

            int indexNo = 1;
            Console.WriteLine();

            Dictionary<int, (string, string)> actionList = [];

            foreach (var item in queueMethodList)
            {
                string actionStatus = item.Value.IsEnable ? "已启动" : "";

                if (item.Value.IsEnable)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                Console.WriteLine($"[{indexNo}] " + "队列任务：" + item.Key + " " + actionStatus);

                actionList.Add(indexNo, ("队列任务", item.Key));
                indexNo++;

                Console.ResetColor();
            }

            foreach (var item in scheduleMethodList)
            {
                string actionStatus = item.Value.IsEnable ? "已启动" : "";

                if (item.Value.IsEnable)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                Console.WriteLine($"[{indexNo}] " + "定时任务：" + item.Key + " " + actionStatus);
                actionList.Add(indexNo, ("定时任务", item.Key));
                indexNo++;

                Console.ResetColor();
            }

            Console.WriteLine();
            Console.WriteLine("请选择要启用的服务，输入序号回车即可（支持空格分割一次输入多个序号）");

            var startIndexNoStr = Console.ReadLine();

            if (startIndexNoStr != null)
            {
                try
                {
                    foreach (var startIndexNo in startIndexNoStr.Split(" "))
                    {
                        var startActionName = actionList.GetValueOrDefault(int.Parse(startIndexNo));

                        if (startActionName != default)
                        {

                            if (startActionName.Item1 == "队列任务")
                            {
                                var actionInfo = queueMethodList.Where(t => t.Key == startActionName.Item2).First();
                                actionInfo.Value.IsEnable = true;
                            }
                            else
                            {
                                var actionInfo = scheduleMethodList.Where(t => t.Key == startActionName.Item2).First();
                                actionInfo.Value.IsEnable = true;
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("无效的服务序号：" + startIndexNo);
                            Console.ResetColor();
                        }
                    }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("无效的服务序号：" + startIndexNoStr);
                    Console.ResetColor();
                }

                goto StartActionTag;
            }

#endif
            host.WaitForShutdown();

        }

    }
}
