namespace WorkerServiceAutoSendMail
{
    public class Worker : BackgroundService
    {
        IConfiguration configuration;
        public Worker()
        {
            configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        }   

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                using(AutoSendMailRepository repository = new AutoSendMailRepository(configuration))
                {
                    IEnumerable<AutoSendMail> list = repository.GetAutoSendMails();
                    if (list != null && list.Count()>0)
                    {
                        List<int> ids = SendMailHelper.Send(list, configuration);
                        if (ids != null)
                        {
                            Console.WriteLine($"Successfully Delete: {repository.Delete(ids)}");
                        }
                    }
                }
                    //1 phút chạy 1 lần
                await Task.Delay(60000, stoppingToken);
            }
        }
    }
}