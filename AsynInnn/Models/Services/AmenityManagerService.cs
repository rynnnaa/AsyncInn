using AsynInnn.Models.Interfaces;
using AsynInnn.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsynInnn.Models.Services
{
    public class AmenityManagerService : IAmenityManager
    {
        private AsyncInnDbContext _context { get; }

        public AmenityManagerService(AsyncInnDbContext context)
        {
            _context = context;
        }
    }
}
