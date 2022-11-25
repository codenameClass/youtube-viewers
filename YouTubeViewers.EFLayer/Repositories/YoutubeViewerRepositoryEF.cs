using YouTubeViewers.EFLayer.Exceptions;
using YouTubeViewers.EFLayer.Mappers;
using YouTubeViewers.EFLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouTubeViewers.Domain.Interfaces;
using YouTubeViewers.Domain.Model;

namespace YouTubeViewers.EFLayer.Repositories
{
    public class YoutubeViewerRepositoryEF : IYouTubeViewerRepository
    {
        DbContextOptions options;
        YouTubeViewersDbContextEF ctx;
        public YoutubeViewerRepositoryEF(string connectionString)
        {
            options = new DbContextOptionsBuilder().UseSqlServer(connectionString).Options;
            ctx = new YouTubeViewersDbContextEF(options, connectionString);
        }

        public Task Add(YouTubeViewer youTubeViewer)
        {
            try
            {
                    ctx.YouTubeViewers.Add(MapYouTubeViewer.MapToDB(youTubeViewer));
                    return SaveAndClear(ctx);
            }
            catch (Exception ex)
            {
                throw new YoutubeViewerRepositoryException("Add", ex);
            }
        }

        public Task Delete(Guid id)
        {
            try
            {

                    ctx.YouTubeViewers.Remove(new YouTubeViewerEF() { Id = id });
                    return SaveAndClear(ctx);
                
            }
            catch (Exception ex)
            {
                throw new YoutubeViewerRepositoryException("Delete", ex);
            }
        }

        public Task<List<YouTubeViewer>> Load()
        {
            try
            {
                    return ctx.YouTubeViewers.Select(x => MapYouTubeViewer.MapToDomain(x)).ToListAsync();
                
            }
            catch (Exception ex)
            {
                throw new YoutubeViewerRepositoryException("Load", ex);
            }
        }

        public Task Update(YouTubeViewer youTubeViewer)
        {
            try
            {
                    ctx.YouTubeViewers.Update(MapYouTubeViewer.MapToDB(youTubeViewer));
                    return SaveAndClear(ctx);
                
            }
            catch (Exception ex)
            {
                throw new YoutubeViewerRepositoryException("Update", ex);
            }
        }

        public async Task SaveAndClear(YouTubeViewersDbContextEF ctx)
        {
            await ctx.SaveChangesAsync();
            ctx.ChangeTracker.Clear();
        }
    }
}
