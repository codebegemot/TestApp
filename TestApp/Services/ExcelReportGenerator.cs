using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Data.Repositories;
using TestApp.Models;

namespace TestApp.Services
{
    public class ExcelReportGenerator : IReportGenerator
    {
        private IPaymentRepository _paymentRepository;

        public ExcelReportGenerator(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public void GenerateReport(string filePath)
        {
            List<Payment> payments = _paymentRepository.GetPayments();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Отчет");

                worksheet.Cells[1, 1].Value = "Ид. платежа";
                worksheet.Cells[1, 2].Value = "Номер квитанции";
                worksheet.Cells[1, 3].Value = "Сумма платежа";
                worksheet.Cells[1, 4].Value = "Комиссия плательщика";
                worksheet.Cells[1, 5].Value = "Лицевой счет";
                worksheet.Cells[1, 6].Value = "Адрес";
                worksheet.Cells[1, 7].Value = "Период оплаты(MMГГ)";

                int row = 2;
                foreach (Payment payment in payments)
                {
                    worksheet.Cells[row, 1].Value = payment.RowId;
                    worksheet.Cells[row, 2].Value = payment.Ticket;
                    worksheet.Cells[row, 3].Value = payment.Total;
                    worksheet.Cells[row, 4].Value = payment.Commission;
                    worksheet.Cells[row, 5].Value = GetAttributeValue(payment, "R_account");
                    worksheet.Cells[row, 6].Value = GetAttributeValue(payment, "R_address");
                    worksheet.Cells[row, 7].Value = GetPeriodAttributeValue(payment);

                    row++;
                }

                excelPackage.SaveAs(new FileInfo(filePath));
            }
        }

        private string GetAttributeValue(Payment payment, string attributeName)
        {
            PaymentAttribute attribute = payment.Attributes.FirstOrDefault(a => a.Name == attributeName);
            return attribute != null ? attribute.Value : null;
        }

        private string GetPeriodAttributeValue(Payment payment)
        {
            string month = GetAttributeValue(payment, "Month");
            string year = GetAttributeValue(payment, "Year");
            return !string.IsNullOrEmpty(month) && !string.IsNullOrEmpty(year) ? month + year : null;
        }
    }
}
