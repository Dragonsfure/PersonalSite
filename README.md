# Personal Website Template 

This is a Template to create a Basic Website.


Only change a few Fields in the following Files after creating those Files in the following Path "~/PersonalSite" and copying the content in there.

appsettings.json

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "Default": "Server=IPADRESS;Port = PORT;User ID=USERID;Password=PASSWORD;Database=DATABASENAME"
  },
  "MailAdress": "MAILADRESSNAME",
  "AppPassword": "APP_PASSWORD",
  "SMTPAdress": "SMTPADRESS"
}
```

appsettings.Development.json

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "Default": "Server=IPADRESS;Port = PORT;User ID=USERID;Password=PASSWORD;Database=DATABASENAME"
  },
  "MailAdress": "MAILADRESSNAME",
  "AppPassword": "APP_PASSWORD",
  "SMTPAdress": "SMTPADRESS"
}
```