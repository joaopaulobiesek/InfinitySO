using InfinitySO.Data;
using InfinitySO.Models.ModelsSystem;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfinitySO.Services.ServicesSystem
{
    public class DownloadFileService
    {
        private readonly ApplicationDbContext _context;

        public DownloadFileService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DownloadFile> FindByIdAsync(int id)
        {
            return await _context.DownloadFile.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task<List<DownloadFile>> FindSystemAllAsync()
        {
            return await _context.DownloadFile.Where(obj => obj.TypeFile == 0).OrderBy(x => x.DateUpload).ToListAsync();
        }
    }
}