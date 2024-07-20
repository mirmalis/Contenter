proj = --project Contenter
ct = --context Contenter.Data.Database
dockertest:
	docker run --rm -it -p 80:80 mirmalis/contenter
dockerbuild:
	docker build -t mirmalis/contenter .
dockerbuildpush:
	dotnet publish Contenter --os linux -a arm64 -o publish
	docker build -f Dockerfile.rpi.justcopy -t mirmalis/contenter .
	docker push mirmalis/contenter
	rmdir publish /S /q
test:
	docker save -o \\\\pi401\\configs\\projects\\Contenter\\data\\Contenter.tar mirmalis/contenter:latest
au:
	dotnet ef migrations add "$(name)" $(ct) $(proj) && dotnet ef database update $(ct) $(proj)
u:
	dotnet ef database update $(ct) $(proj)
wr r:
	dotnet watch run $(proj)
open:
	explorer Contenter.sln
clean:
	for /d %%d in (*) do if exist %%d\bin (rmdir /s /q %%d\bin)
	for /d %%d in (*) do if exist %%d\obj (rmdir /s /q %%d\obj)
tar:
	dotnet publish Contenter --os linux -a arm64 -o publish
	docker build -f Dockerfile.rpi.justcopy -t contenter .
	docker save -o //pi401/configs/projects/Contenter/dockerimage.tar contenter:latest
