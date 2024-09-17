using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
}
