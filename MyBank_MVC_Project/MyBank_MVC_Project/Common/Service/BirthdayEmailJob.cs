using MyBank_MVC_Project.Common.Mail;
using MyBank_MVC_Project.Data;
namespace MyBank_MVC_Project.Common.Service
{
    public class BirthdayEmailJob : CronJobService
    {
        private readonly IServiceProvider _serviceProvider;

        public BirthdayEmailJob(IServiceProvider serviceProvider) : base("20 11 * * *", TimeZoneInfo.Local)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task DoWork(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var myBankDbContext = scope.ServiceProvider.GetRequiredService<MyBankDbContext>();
                var mailService = scope.ServiceProvider.GetRequiredService<IMailService>();

                var today = DateOnly.FromDateTime(DateTime.Today);
                var persons = myBankDbContext.Person.Where(p => p.DOB.Month == today.Month && p.DOB.Day == today.Day).ToList();

                foreach (var person in persons)
                {
                    await mailService.SendBirthdayEmailAsync(person.Email, person.FirstName);
                }
            }
        }
    }
}
