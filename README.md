# Рутокен 2FA Демо


## Описание демо стенда


Продукт Рутокен 2FA Демо предназначен для демонстрации применения и функциональных возможностей устройств Рутокен MFA и Рутокен OTP в сценариях двухфакторной и беспарольной аутентификации.
Для демонстрации возможностей аутентификации используются технологии FIDO2 (CTAP2 + WebAuthn) и OATH TOTP (Time-based One-Time Password Algorithm, RFC 6238).

В системе реализован следущий функционал:  

- регистрация пользователей. 
- традиционная (однофакторная) аутентификация (логин и пароль).   
- личный кабинет пользователя. 
- добавление/удаление второго фактора аутентификации (FIDO2 2-Step, FIDO2 Passwordless, TOTP). 
- двухфакторная и беспарольная аутентификация.  
    

## Стек технологий

| <!-- -->         | <!-- -->              | 
| ---              | ---                   | 
| Веб-сервер:      | .NET Core 6.          |   
| Фронтенд:        | React                 |
| База данных:     | PostgreSQL            |
| Библиотеки:      | [Passwordless - FIDO2 for .NET](https://github.com/passwordless-lib/fido2-net-lib), [OTP .NET](https://github.com/kspearrin/Otp.NET), [QrCoder](https://github.com/codebude/QRCoder), [Bouncy Castle Cryptography Library For .NET](https://github.com/bcgit/bc-csharp).   |



## Аутентификация с использованием ЭЦП

В продукте реализована двухфакторная аутентификация с использованием электронной цифровой подписи (ЭЦП).<br />
Для работы с PKI применяется библиотека [Bouncy Castle Cryptography Library For .NET](https://github.com/bcgit/bc-csharp).<br />
Взаимодействие с токеном в браузере обеспечивается следующими библиотеками:

- [Модуль для Рутокен плагин](https://github.com/AktivCo/rutoken-plugin-js)
- [Модуль инициализации Рутокен Плагин](https://github.com/AktivCo/rutoken-plugin-bootstrap)

Для выпуска сертификатов пользователей требуется развернуть [Демо УЦ - модуль сертификации](https://github.com/AktivCo/certification-demo-module).<br />
Генерация ключевой пары выполняется по алгоритму <b>ГОСТ Р 34.10-2012 256-бит</b>.<br />
Взаимодействие с модулем сертификации осуществляется через API.<br />
Перед запуском необходимо указать соответствующий URL в разделе `CAConfig` файла `RutokenTotpFido2Demo/appsettings.json`.


## FIDO2

![Fido2 Architecture](https://developers.yubico.com/WebAuthn/WebAuthn_Developer_Guide/fido2_app_architecture.png?raw=true "Fido2 Architecture") 

В продукте реализованы следующие компоненты архитектуры FIDO2:

- Client-Side JS, Server-Side App & User Store.
- FIDO2 Server реализован с помощью библиотеки [Passwordless - FIDO2 for .NET](https://github.com/passwordless-lib/fido2-net-lib).
- Продукт позволяет осуществлять аутентификацию в режиме Passwordless, для этого устройство должно поддерживать [Режим верификации пользователя](https://developers.yubico.com/WebAuthn/WebAuthn_Developer_Guide/User_Presence_vs_User_Verification.html).
- PasswordLess аутентификация включается на сервере путем установки параметров:
```
    var authenticatorSelection = new AuthenticatorSelection
    {
        RequireResidentKey = true,
        UserVerification = UserVerificationRequirement.Required
    };
```




## OTP

В продукте реализована двухфакторная аутентификация по протоколу TOTP (Time-based One-time Password) с помощью библиотеки [OTP .NET](https://github.com/kspearrin/Otp.NET).  
Сервер позволяет вводить seed (секретный) ключ в форматах Base32 или HEX. 


## Установка зависимостей и запуск сервиса

Для сборки и запуска веб-сервиса необходим установленный в системе [.NET SDK 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0).  
Для сборки фронтенд части системы необходимо установить [Node.js](https://nodejs.org/ru).  
В качестве хранилища данных сервис использует СУБД PostgreSQL.  
ConnectionString к базе необходимо установить в файле `RutokenTotpFido2Demo/appsettings.json`


### Сборка фронтенд части

```cd RutokenTotpFido2Demo/ClientApp```

```npm install```

### Запуск сервера

```cd RutokenTotpFido2Demo```

```dotnet run```
