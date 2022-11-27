// See https://aka.ms/new-console-template for more information
using ConsoleTest.Mock;
using YouTubeViewers.Domain.Model;
using YouTubeViewers.Domain.Services;
using YouTubeViewers.EFLayer.Repositories;

Console.WriteLine("Hello, World!");

YouTubeViewer.CreateYouTubeViewerWithId(new Guid(), "Test User", true, true);

YouTubeViewerService service = new YouTubeViewerService(new YoutubeViewerRepositoryEF(@"Data Source=msi\sqlexpress;Initial Catalog=YouTubeViewer;Integrated Security=True"));

List<YouTubeViewer> list = service.GetAllYouTubeViewers().Result;

service.UpdateYouTubeViewer(list[0].Id, "Test300", true, true);
list = service.GetAllYouTubeViewers().Result;

service.DeleteYouTubeViewer(list[0].Id);
list = service.GetAllYouTubeViewers().Result;

list.ForEach(li => Console.WriteLine($"{li.Id} {li.Username} {(li.IsMember ? "Member" : "")} {(li.IsSubscribed ? "Subscribed" : "")}"));