##### 
Running on raspberry pi and reachable at [sars.lt](https://sars.lt).



##### Flow
```mermaid
flowchart LR
Contenter.App --"youtube data"--> Aper.Api --> YouTube.Api
subgraph Contenter
Contenter.App
end
subgraph Aper
Aper.Api
end
subgraph External
YouTube.Api
end
```
