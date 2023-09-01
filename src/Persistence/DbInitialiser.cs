using System.Linq;
using Models;

namespace Persistence;

public static class DbInitialiser
{
    public static void Initialise(FeedsDbContext context)
    {
        context.Database.EnsureCreated();

        #region Status

        if (!context.Set<Status>().Any())
        {
            context.Set<Status>().AddRange(
                new Status { Id = 1, Name = "Moderate", Description = "Default status for new feeds"},
                new Status { Id = 2, Name = "Under Review", Description = "Administrators are reviewing this feed"},
                new Status { Id = 3, Name = "Banned", Description = "This feed has been banned"},
                new Status { Id = 4, Name = "Approved", Description = "This feed has been approved"}
            );
        }

        #endregion
        
        #region MediaTypes

        if (!context.Set<MediaTypes>().Any())
        {
            context.Set<MediaTypes>().AddRange(
                new MediaTypes { Id = 1, Name = "Image", Description = "Primary image feed"},
                new MediaTypes { Id = 2, Name = "Video", Description = "Video based feed"},
                new MediaTypes { Id = 3, Name = "Audio", Description = "Audio based feed" },
                new MediaTypes { Id = 4, Name = "Blog" , Description = "Blog based feed" },
                new MediaTypes { Id = 5, Name = "Article",  Description = "Article based feed" },
                new MediaTypes { Id = 6, Name = "News", Description = "News based feed" },
                new MediaTypes { Id = 7, Name = "Podcast", Description = "Podcast based feed" },
                new MediaTypes { Id = 8, Name = "Text", Description = "Text based feed" }
            );
                
        }
        
        #endregion
        
        context.SaveChanges();
    }
}