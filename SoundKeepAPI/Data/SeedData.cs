using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SoundKeepAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemeBank.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SoundKeepAPIContext(
                serviceProvider.GetRequiredService<DbContextOptions<SoundKeepAPIContext>>()))
            {
                // Look for any movies.
                if (context.TrackItem.Count() > 0)
                {
                    return;   // DB has been seeded
                }

                context.TrackItem.AddRange(
                    new TrackItem
                    {
                        TrackID = "253508261",
                        TrackURL = "https://soundcloud.com/rick-astley-official/never-gonna-give-you-up",
                        ArtworkURL = "https://i1.sndcdn.com/artworks-NYa30RprqObZ-0-t500x500.jpg",
                        Artist = "Rick Astley",
                        Title = "Never Gonna Give You Up",
                        Status = "PASS",
                        Comment = "Good memes never die.﻿",
                        DateAdded = "21-11-2018",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
