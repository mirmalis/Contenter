proj = --project Aper.Api
ct = --context Aper.Api.Brokers.Storages.StorageBroker
dbfile = D:\git\-\dbs\Aper-youtube.db3
wr:
	dotnet watch run $(proj)
open:
	explorer Aper.sln
au:
	dotnet ef migrations add "$(name)" $(ct) $(proj) && dotnet ef database update $(ct) $(proj)
dau:
	@if exist Aper.Api\Migrations (rmdir /s /q Aper.Api\Migrations)
	@if exist $(dbfile) (del $(dbfile))
	dotnet ef migrations add "1" $(ct) $(proj)
	dotnet ef database update $(ct) $(proj)
	dotnet watch run $(proj)
u:
	dotnet ef database update $(ct) $(proj)
tar:
	docker build -f Dockerfile -t contenter .
	docker save -o //pi401/configs/projects/Aper/dockerimage.tar contenter:latest
