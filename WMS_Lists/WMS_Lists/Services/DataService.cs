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

        public async Task<List<T>> GetAll<T>(int type) where T : class
        {
            try
            {
                if (type == 0)
                {
                    var result = await _context.Set<T>().ToListAsync();
                    return result ?? new List<T>();
                }
                else
                {
                    var result = await _maircontext.Set<T>().ToListAsync();
                    return result ?? new List<T>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return new List<T>();  // Return an empty list on failure
            }
        }

        public async Task<List<T>> SkipIrrelevant<T>() where T : class
        {
            try
            {
                var result = await _context.Set<T>()
                                            .Skip(370000)
                                            .ToListAsync();

                return result ?? new List<T>();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return new List<T>();
            }
        }
    }
}
