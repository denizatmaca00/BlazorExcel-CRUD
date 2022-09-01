using BlazorOne.Models;
using Microsoft.JSInterop;




namespace BlazorOne.XLS

{
    public class Excel
    {

        public async Task GenerateEmployeeAsync(IJSRuntime js, Employee[] employees, string filename = "export.xlsx")
        {
            var e = new EmployeeXLS();
            
            var XLSStream = e.Edition(employees);

            
            await js.InvokeVoidAsync("BlazorDowlandFile", filename, XLSStream);
        }

    }

}
