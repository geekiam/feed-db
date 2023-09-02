using System.Diagnostics.CodeAnalysis;
using Models;

namespace Geekiam.Persistence;
[ExcludeFromCodeCoverage]
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
        
        #region Sources

        // Initial seed with some default sources
        if (!context.Set<Sources>().Any())
        {
            context.Set<Sources>().AddRange(
                new Sources
                {
                    Id = Guid.Parse("56bdbe5f-4edc-4002-8a94-e053a0652c80"),
                    Identifier = "g_garywoodfine_0001" ,
                    Name = "Gary Woodfine",
                    Description = "Opinionated Software Developer",
                    Domain = "garywoodfine.com",
                    FeedUrl = "/feed",
                    Protocol = "https",
                    StatusId = 1,
                    MediaTypeId = 4
                },
                new Sources
                {
                    Id = Guid.Parse("f9545f8f-b99d-4d02-8750-5f4471a7ba24"),
                    Identifier = "g_cryptonews_0001" ,
                    Name = "Crypto News",
                    Description = "Latest Cryptocurrency News, Bitcoin News, Ethereum News and Price Data",
                    Domain = "cryptonews.com",
                    FeedUrl = "news/feed",
                    Protocol = "https",
                    StatusId = 1,
                    MediaTypeId = 6
                },
                new Sources
                {
                    Id = Guid.Parse("e222d926-d171-44ab-a805-c7318afa5f27"),
                    Identifier = "g_bitcoinmagazine_0001" ,
                    Name = "Bitcoin Magazine",
                    Description = "Bitcoin News, Articles and Expert Insights",
                    Domain = "bitcoinmagazine.com",
                    FeedUrl = "/.rss/full/",
                    Protocol = "https",
                    StatusId = 1,
                    MediaTypeId = 5
                },
                new Sources
                {
                    Id = Guid.Parse("2aa5ceac-3a12-40f6-bb01-907ad669c66c"),
                    Identifier = "g_cointelegraph_0001" ,
                    Name = "Coin Telegraph",
                    Description = "Bitcoin, Ethereum, Crypto News & Price Indexes",
                    Domain = "cointelegraph.com",
                    FeedUrl = "/rss",
                    Protocol = "https",
                    StatusId = 1,
                    MediaTypeId = 6
                },
                new Sources
                {
                    Id = Guid.Parse("b445dcc8-c2b6-4717-9b50-8feaf933f48c"),
                    Identifier = "g_bitcoinist_0001" ,
                    Name = "Bitcoinist",
                    Description = "Bitcoin news portal providing breaking news, guides, price and analysis about decentralized digital money and blockchain technology.",
                    Domain = "bitcoinist.com",
                    FeedUrl = "/feed",
                    Protocol = "https",
                    StatusId = 1,
                    MediaTypeId = 6
                }
                
                );
        }
        
        #endregion
        
        context.SaveChanges();
    }
}