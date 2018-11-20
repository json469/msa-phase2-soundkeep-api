using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SoundKeepAPI.Models
{
    public class SoundKeepAPIContext : DbContext
    {
        public SoundKeepAPIContext (DbContextOptions<SoundKeepAPIContext> options)
            : base(options)
        {
        }

        public DbSet<SoundKeepAPI.Models.TrackItem> TrackItem { get; set; }
    }
}
