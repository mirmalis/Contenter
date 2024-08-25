##### 
Running on raspberry pi and reachable at [sars.lt](https://sars.lt).



##### Flow
```mermaid
flowchart LR
app(Contenter.App) ---> api(Aper.Api) --> yt("YouTube Data APIv3")
subgraph Contenter
app
end
subgraph Aper
    api
end
subgraph External
    yt
end
```
