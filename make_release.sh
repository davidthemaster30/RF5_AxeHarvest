rm -rf obj
rm -rf bin

dotnet build RF5_AxeHarvest.csproj -f net6.0 -c Release

zip -j 'RF5_AxeHarvest_v1.1.1.zip' './bin/Release/net6.0/RF5_AxeHarvest.dll'