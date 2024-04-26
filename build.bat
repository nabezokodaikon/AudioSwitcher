@SET PATH="C:\Program Files\Microsoft Visual Studio\2022\Community\Msbuild\Current\Bin";%PATH%
@SET OUTPUT_PATH=%CD%\bin

dotnet restore src\AudioSwitcher.sln

MSBuild src\AudioSwitcher.sln /t:Rebuild ^
  /p:OutputPath="%OUTPUT_PATH%" ^
  /p:Configuration=Release ^
  /p:Platform="Any CPU" ^
  /p:DebugType=None ^
  /p:GenerateDependencyFile=false

DEL "%OUTPUT_PATH%\*.pdb"

RENAME "%OUTPUT_PATH%\AudioSwitcher.runtimeconfig.json" "temp"
DEL "%OUTPUT_PATH%\*.runtimeconfig.json"
RENAME "%OUTPUT_PATH%\temp" "AudioSwitcher.runtimeconfig.json"
