﻿using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;

namespace Google.Apis.YouTube.Samples
{
  /// <summary>
  /// YouTube Data API v3 sample: create a playlist.
  /// Relies on the Google APIs Client Library for .NET, v1.7.0 or higher.
  /// See https://developers.google.com/api-client-library/dotnet/get_started
  /// </summary>
  internal class PlaylistUpdates
  {
    [STAThread]
    static void Main(string[] args)
    {
      Console.WriteLine("YouTube Data API: Playlist Updates");
      Console.WriteLine("==================================");
      
      Console.Read();
      return;
      try
      {
        new PlaylistUpdates().Run().Wait();
      }
      catch (AggregateException ex)
      {
        foreach (var e in ex.InnerExceptions)
        {
          Console.WriteLine("Error: " + e.Message);
        }
      }

      Console.WriteLine("Press any key to continue...");
      Console.ReadKey();
    }

    private async Task Run()
    {
      UserCredential credential;
      using (var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
      {
        credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
            GoogleClientSecrets.Load(stream).Secrets,
            // This OAuth 2.0 access scope allows for full read/write access to the
            // authenticated user's account.
            new[] { YouTubeService.Scope.Youtube },
            "user",
            CancellationToken.None,
            new FileDataStore(this.GetType().ToString())
        );
      }

      var youtubeService = new YouTubeService(new BaseClientService.Initializer() {
        HttpClientInitializer = credential,
        ApplicationName = this.GetType().ToString()
      });

      // Create a new, private playlist in the authorized user's channel.
      var newPlaylist = new Playlist();
      newPlaylist.Snippet = new PlaylistSnippet();
      newPlaylist.Snippet.Title = "Test Playlist";
      newPlaylist.Snippet.Description = "A playlist created with the YouTube API v3";
      newPlaylist.Status = new PlaylistStatus();
      newPlaylist.Status.PrivacyStatus = "public";
      newPlaylist = await youtubeService.Playlists.Insert(newPlaylist, "snippet,status").ExecuteAsync();

      // Add a video to the newly created playlist.
      var newPlaylistItem = new PlaylistItem();
      newPlaylistItem.Snippet = new PlaylistItemSnippet();
      newPlaylistItem.Snippet.PlaylistId = newPlaylist.Id;
      newPlaylistItem.Snippet.ResourceId = new ResourceId();
      newPlaylistItem.Snippet.ResourceId.Kind = "youtube#video";
      newPlaylistItem.Snippet.ResourceId.VideoId = "GNRMeaz6QRI";
      newPlaylistItem = await youtubeService.PlaylistItems.Insert(newPlaylistItem, "snippet").ExecuteAsync();

      Console.WriteLine("Playlist item id {0} was added to playlist id {1}.", newPlaylistItem.Id, newPlaylist.Id);
    }
  }
}