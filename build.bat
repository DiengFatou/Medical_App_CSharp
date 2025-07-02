@echo off
echo ========================================
echo Compilation du Projet Groupe2
echo ========================================

echo.
echo 1. Compilation du projet MetierRvMedical...
msbuild MetierRvMedical\MetierRvMedical.csproj /p:Configuration=Debug /p:Platform="Any CPU"

if %ERRORLEVEL% NEQ 0 (
    echo ERREUR: Compilation de MetierRvMedical echouee
    pause
    exit /b 1
)

echo.
echo 2. Compilation du projet AppGroupe2...
msbuild AppGroupe2\AppGroupe2.csproj /p:Configuration=Debug /p:Platform="Any CPU"

if %ERRORLEVEL% NEQ 0 (
    echo ERREUR: Compilation de AppGroupe2 echouee
    pause
    exit /b 1
)

echo.
echo ========================================
echo Compilation terminee avec succes !
echo ========================================
echo.
echo Pour demarrer l'application :
echo 1. Demarrer le service WCF (MetierRvMedical)
echo 2. Demarrer l'application (AppGroupe2)
echo.
pause 