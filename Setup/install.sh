# Download the latest stable `nuget.exe` to `/usr/local/bin`
sudo curl -o /usr/local/bin/nuget.exe https://dist.nuget.org/win-x86-commandline/latest/nuget.exe
# Create as alias for nuget
alias nuget="mono /usr/local/bin/nuget.exe"