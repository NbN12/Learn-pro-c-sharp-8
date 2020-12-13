if exist csharp.il (
    del csharp.il
)

if exist csharp.res (
    del csharp.res
)

ildasm /all /METADATA /out=csharp.il .\bin\Debug\net5.0\FunWithStrings.dll
