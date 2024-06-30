proj = --project Contenter
ct = --context Contenter.Data.Database $(proj)
au:
	dotnet ef migrations add "$(name)" $(ct) && dotnet ef database update $(ct)
u:
	dotnet ef database update $(ct)
wr r:
	dotnet watch run $(proj)
open:
	explorer Contenter.sln
clean:
	for /d %%d in (*) do if exist %%d\bin (rmdir /s /q %%d\bin)
	for /d %%d in (*) do if exist %%d\obj (rmdir /s /q %%d\obj)
