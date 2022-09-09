# emqx-exhook-aspnetcore
 
This is a EMQX Broker exhook demo server written in dotnet for exhook

[多语言的 钩子扩展](https://www.emqx.io/docs/zh/v5/advanced/lang-exhook.html)

# emqx-http-auth-api and resolve MQTT messages via HTTP webhooks
1. test for emqx http auth api ：http://emqxhookaspnet:82/auth 
2. data bridge with webhook: http://emqxhookaspnet:82/hook/${clientid}


- [Password Authentication Using HTTP](https://www.emqx.io/docs/en/v5.0/security/authn/http.html)
- [authorization  http](https://www.emqx.io/docs/en/v5.0/security/authz/http.html)
- [Introduction to Data Bridges](https://www.emqx.io/docs/zh/v5.0/data-integration/data-bridges.html)

## Prerequisites

- .NET 6 or higher

## Run 

```
dotnet run --project  .\EmqxHookASPNET\EmqxHookASPNET.csproj
```
or visual studio 2022 debug with docker-compose
- set Built-in Database auth 
username : mqttx_e163c7ba  password:1234567890

- set ExHook with aspnet
![exhook](image/setexhook.png)

enable aspnet exhook
![enablehook](image/enableexhook.png)

aspnet exhook list
![aspnethooklist](image/aspnethooklist.png)

## License
[MIT](./LICENSE)