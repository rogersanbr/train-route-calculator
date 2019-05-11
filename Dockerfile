FROM microsoft/dotnet:2.1-sdk
WORKDIR ./app

# copy project and restore as distinct layers
COPY . ./
RUN dotnet restore && dotnet publish -c Release -o out

ENTRYPOINT ["dotnet", "TrainRoute.Application/out/TrainRoute.Application.dll"]