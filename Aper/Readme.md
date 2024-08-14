### Servisų, brokerių ryšiai

```mermaid
graph LR;
    ChannelController --> ChannelOrchestrationService --> ChannelProcessingService --> ChannelService;
    VideoController --> VideoOrchestrationService --> VideoProcessingService --> VideoService;
    PlaylistController --> PlaylistOrchestrationService --> PlaylistProcessingService --> PlaylistService;
    PlaylistItemController --> PlaylistItemOrchestrationService --> PlaylistItemProcessingService --> PlaylistItemService;

    VideoService & ChannelService & PlaylistService & PlaylistItemService --> StorageBroker --> db[(SQLite db)];
    TruthProcessingService --> TruthService --> TruthBroker --> yt;

    PlaylistVideoController -->
    Playlist_Video_OrchestrationService --> PlaylistItemOrchestrationService & VideoOrchestrationService;

    subgraph External
        yt[(youtube api)];
    end
    subgraph Controllers
        PlaylistVideoController;
        ChannelController;
        VideoController;
        PlaylistController;
        PlaylistItemController;
    end;
    

    subgraph Orchestration
        subgraph 1
            ChannelOrchestrationService;
            VideoOrchestrationService;
            PlaylistOrchestrationService;
            PlaylistItemOrchestrationService;
        end
        Playlist_Video_OrchestrationService;
    end
    1 --> DateTimeBroker & TruthProcessingService & LoggingBroker;
    subgraph Processing
        VideoProcessingService;
        ChannelProcessingService;
        PlaylistProcessingService;
        PlaylistItemProcessingService;
        TruthProcessingService;
    end
    subgraph Foundation
        ChannelService;
        VideoService;
        PlaylistService;
        PlaylistItemService;
        TruthService;
    end
    subgraph Brokers
        StorageBroker;
        TruthBroker;
    end
    subgraph SubBrokers
        LoggingBroker;
        DateTimeBroker;
    end
```
