using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.JSInterop;
using MudBlazor;
using System.Text;
using WMS_Lists.Data;

namespace WMS_Lists.Services
{
    public class DataService
    {
        public readonly ApplicationDbContext _context;
        public readonly MAIRDbContext _maircontext;

        public DataService(ApplicationDbContext context, MAIRDbContext maircontext) 
        {  
            _context = context;
            _maircontext = maircontext;
        }

        public async Task<List<T>> GetAllWMSP1<T>() where T : class
        {
            try
            {
                var result = await _context.Set<T>().ToListAsync();
                return result ?? new List<T>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return new List<T>();  // Return an empty list on failure
            }
        }

        public async Task<List<T>> SkipIrrelevantWMSP1<T>(int count) where T : class
        {
            try
            {
                var result = await _context.Set<T>()
                                            .Skip(count)
                                            .ToListAsync();

                return result ?? new List<T>();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return new List<T>();
            }
        }

        public async Task<List<T>> SkipIrrelevantMAIRWeight<T>(int count) where T : class
        {
            try
            {
                var result = await _maircontext.Set<T>()
                                            .Skip(count)
                                            .ToListAsync();

                return result ?? new List<T>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return new List<T>();
            }
        }

        public async Task<List<T>> GetAllMAIRCombo<T>() where T : class
        {
            try
            {
                var result = await _context.Set<T>().ToListAsync();
                return result ?? new List<T>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured: {ex.Message}");
                return new List<T>();
            }
        }
    }

    public static class MudDataGridExtensions
    {
        public static async Task DownloadCsv<T>(this MudDataGrid<T> grid, IJSRuntime js, string filename)
        {
            string csvContent = GenerateCsv(grid.RenderedColumns, grid.FilteredItems);
            byte[] bytes = Encoding.UTF8.GetBytes(csvContent);
            await js.InvokeVoidAsync("saveAsFile", filename, Convert.ToBase64String(bytes));
        }
        private static string GenerateCsv<T>(IEnumerable<Column<T>> columns, IEnumerable<T> items)
        {
            StringBuilder csv = new StringBuilder();
            // Add header
            csv.AppendLine(string.Join(",", columns.Select(c => $"\"{c.Title}\"")));
            // Add rows
            foreach (var item in items)
            {
                var row = columns.Select(c =>
                {
                    var value = GetPropertyValue(item, c.PropertyName)?.ToString() ?? "";
                    return $"\"{value.Replace("\"", "\"\"")}\""; // Escape quotes in the field
                });
                csv.AppendLine(string.Join(",", row));
            }
            return csv.ToString();
        }
        private static object GetPropertyValue(object obj, string propertyName)
        {
            return obj.GetType().GetProperty(propertyName)?.GetValue(obj, null);
        }
    }
}
