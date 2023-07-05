using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using TestApp.Data.Repositories;
using TestApp.Data;
using TestApp.Services;
using Autofac;
using TestApp.Models;

class Program
{
    static void Main(string[] args)
    {
        var builder = new ContainerBuilder();
        builder.RegisterType<DbContextFactory>().As<IDesignTimeDbContextFactory<PaymentContext>>();
        builder.RegisterType<PaymentContext>()
            .AsSelf()
            .WithParameter("options", new DbContextOptionsBuilder<PaymentContext>().UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=testDb;Integrated Security=True;").Options);
        builder.RegisterType<PaymentRepository>().As<IPaymentRepository>();
        builder.RegisterType<ExcelReportGenerator>().As<IReportGenerator>();
        Autofac.IContainer container = builder.Build();

        using (var scope = container.BeginLifetimeScope())
        {
            var reportGenerator = scope.Resolve<IReportGenerator>();
            reportGenerator.GenerateReport("report.xlsx");
        }

        Console.WriteLine("Отчет успешно создан.");
    }
}