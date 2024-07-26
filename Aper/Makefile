proj = --project Aper.Api
ct = --context Aper.Api.Database
down:
	docker compose down
up:
	docker load -i dockerimage.tar
	docker compose up -d
re:
	docker compose down
	docker load -i dockerimage.tar
	docker compose up -d
wr:
	dotnet watch run $(proj)
open:
	explorer Aper.sln
au:
	dotnet ef migrations add "$(name)" $(ct) $(proj) && dotnet ef database update $(ct) $(proj)
u:
	dotnet ef database update $(ct) $(proj)