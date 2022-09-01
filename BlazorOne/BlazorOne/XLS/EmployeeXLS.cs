using BlazorOne.Models;
using ClosedXML.Excel;
using System.Linq;

namespace BlazorOne.XLS
{
    public class EmployeeXLS
    {//Employee employee2 = new Employee();
        /* List<Employee> people = new List<Employee>();
         var array = people.ToArray();*/


        public byte[] Edition(Employee[] employees)
        {
            //List<Employee> employees = new List<Employee>();
            var array = employees.ToArray();
            var wb = new XLWorkbook();
            wb.Properties.Author = "the Author";
            wb.Properties.Title = "the Title";
            wb.Properties.Subject = "the Subject";
            wb.Properties.Category = "the Category";
            wb.Properties.Keywords = "the Keywords";
            wb.Properties.Comments = "the Comments";
            wb.Properties.Status = "the Status";
            wb.Properties.LastModifiedBy = "the Last Modified By";
            wb.Properties.Company = "the Company";
            wb.Properties.Manager = "the Manager";

            var ws = wb.Worksheets.Add("Employee");

            ws.Cell(1, 1).Value = "Id";
            ws.Cell(1, 2).Value = "İsim";
            ws.Cell(1, 3).Value = "Şirket";
            ws.Cell(1, 4).Value = "DeneyımYılı";

            // Fill a cell with a date
            //var cellDateTime = ws.Cell(1, 2);
            //cellDateTime.Value = new DateTime(2010, 9, 2);
            //cellDateTime.Style.DateFormat.Format = "yyyy-MMM-dd";
            
            for (int row = 0; row < employees.Length; row++)
            {
                // The apostrophe is to force ClosedXML to treat the date as a string
                ws.Cell(row + 1, 1).Value = "'" + employees[row].Id;
                ws.Cell(row + 1, 2).Value = employees[row].Name;
                ws.Cell(row + 1, 3).Value = employees[row].Company;
                ws.Cell(row + 1, 4).Value = employees[row].YearsOfExperience;
            }

            MemoryStream XLSStream = new();
            wb.SaveAs(XLSStream);

            return XLSStream.ToArray();
        }

    }
}
