F:
cd F:\MyPocketHistoryBook\Serve
dotnet publish
copy F:\MyPocketHistoryBook\Serve\bin\Debug\netcoreapp3.0\publish F:\MyPocketHistoryBook\root\HelloChinaApi\api
cd F:\MyPocketHistoryBook\UI
ng build --prod --build-optimizer
copy F:\MyPocketHistoryBook\UI\dist\UI F:\MyPocketHistoryBook\root\HelloChinaApi\ui
