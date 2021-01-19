FROM microsoft/dotnet:2.2-sdk
WORKDIR ./app

# copy project and restore as distinct layers
COPY . ./
RUN ls -la
RUN dotnet restore && dotnet publish -c Release -o out

ENTRYPOINT ["dotnet", "src/TrainRoute.Application/out/TrainRoute.Application.dll"]