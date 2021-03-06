echo == Setting vars...
set projpath=H:\Users\ej\git\FloridaMan\
set gamename=FloridaMan
set buildname=b1
set basepath=%projpath%Builds\%buildname%\

set buildargs=-projectPath "%projpath%" -batchmode -logFile "%projpath%build-%gamename%-%buildname%.log" -quit

echo == Making folders...
set winpath=%basepath%win
mkdir "%winpath%32\"
mkdir "%winpath%64\"
set buildargs=-buildWindowsPlayer "%winpath%32\%gamename%.exe" -buildWindows64Player "%winpath%64\%gamename%.exe" %buildargs%

set linuxpath=%basepath%linux\
mkdir "%linuxpath%"
set buildargs=-buildLinuxUniversalPlayer "%linuxpath%%gamename%" %buildargs%

set macpath=%basepath%mac\
mkdir "%macpath%"
set buildargs=-buildOSXUniversalPlayer "%macpath%%gamename%.app" %buildargs%

set webpath=%basepath%web
mkdir "%webpath%\"
mkdir "%webpath%gl\"
set buildargs=-buildWebPlayer "%webpath%\%gamename%" -buildWebPlayerStreamed "%webpath%gl\%gamename%" %buildargs%

echo == Beginning build...
"C:\Program Files\Unity\Editor\Unity.exe" %buildargs%
echo == Reviewing output...
notepad "%projpath%\build-%gamename%-%buildname%.log"