Pro spuštění ve VS možná bude třeba přidat do zdroje balíčků zdroj https://api.nuget.org/v3/index.json.  \
(Nástroje --> Možnosti --> Správce balíčků NuGet --> zdroje balíčků --> + --> https://api.nuget.org/v3/index.json) 


Následně v konozli balíčků nugget spustit příkaz ```Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r```  \
(Nástroje --> Správce balíčků NuGet --> Konzola správce balíčků --> ```Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r```)
