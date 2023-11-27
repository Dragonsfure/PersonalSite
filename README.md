# Personal Website Template 

This is a Template to create a Basic Website.

> [!WARNING]
> This is not finished yet

Only change a few Fields in the following Files after creating those Files in the following Path "~/PersonalSite" and copying the content in there.

---
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
---

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

---
You can also change the Text-Resources in the "Texts.resx" File and in "Textsde-DE.resx".
For easier changing i would advise to use the VisualStudio Addon "Resx Manager".
