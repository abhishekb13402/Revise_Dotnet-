using MyBank.Data;
using MyBank.common.Mail;

namespace MyBank.common.Service
{
    public class BirthdayEmailJob : CronJobService
    {
        private readonly IServiceProvider _serviceProvider;

        public BirthdayEmailJob(IServiceProvider serviceProvider) : base("28 18 * * *", TimeZoneInfo.Local) 
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
