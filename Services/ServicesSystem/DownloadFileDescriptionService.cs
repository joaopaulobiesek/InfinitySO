using InfinitySO.Data;
using InfinitySO.Models.ModelsSystem;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfinitySO.Services.ServicesSystem
{
    public class DownloadFileDescriptionService
    {
        private readonly ApplicationDbContext _context;

        public DownloadFileDescriptionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DownloadFileDescription> FindByIdAsync(int id)
        {
            return await _context.DownloadFileDescription.Include(obj => obj.DownloadFile).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task<List<DownloadFileDescription>> FindByIdListAsync(int id)
        {
            return await _context.DownloadFileDescription.Include(obj => obj.DownloadFile).Include(obj => obj.Period.Course).Include(obj => obj.Period.Semester).Where(obj => obj.DownloadFileId == id).ToListAsync();
        }
    }
}