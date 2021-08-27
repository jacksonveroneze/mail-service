![Image](https://github.com/jacksonveroneze/mail-service/blob/main/assets/mail.png)

# MailService

API para envio de e-mail desenvolvida em .NET 5

![GitHub](https://img.shields.io/github/license/jacksonveroneze/mail-service?logoColor=%20)
![GitHub last commit](https://img.shields.io/github/last-commit/jacksonveroneze/mail-service)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=jacksonveroneze_mail-service&metric=alert_status)](https://sonarcloud.io/dashboard?id=jacksonveroneze_mail-service)


| Branch        | Main           | Develop  |
| ------------- |:-------------:| -----:|
| Status CI      | [![Pipeline](https://github.com/jacksonveroneze/mail-service/actions/workflows/pipeline-commit.yml/badge.svg?branch=main)](https://github.com/jacksonveroneze/mail-service/actions/workflows/pipeline-commit.yml) | [![Pipeline](https://github.com/jacksonveroneze/mail-service/actions/workflows/pipeline-commit.yml/badge.svg?branch=main)](https://github.com/jacksonveroneze/mail-service/actions/workflows/pipeline-commit.yml) |


## 💻 Sobre o projeto

Tabela de conteúdos
=================
<!--ts-->
* [Sobre](#sobre)
* [Tabela de Conteudo](#tabela-de-conteudo)
* [Status do Projeto](#status-do-projeto)
* [Features](#features)
* [Demonstração da aplicação](#demonstracao-da-aplicação)
* [Rodar com Docker](#rodar-com-Docker)
* [Tecnologias](#tecnologias)
* [Contribuição](#contribuição)
* [Licença](#licença)
<!--te-->

## Status do Projeto

🚧  Em construção...  🚧

## ✅ Features

- [ x ] Envio

## 🎲 Demonstração da aplicação

## 🎲 Rodar com Docker

```dockerfile
version: "3.8"
services:
    mail_api:
        container_name: mail_api
        image: docker.pkg.github.com/jacksonveroneze/mail-service/mail-service:latest
        restart: always
        tty: true
        environment:
            - ASPNETCORE_URLS=http://+:80
            - DOTNET_RUNNING_IN_CONTAINER=true
            - ASPNETCORE_ENVIRONMENT=Production
            - APP_CONFIG_Urls_Allow_Cors=*;
            - APP_CONFIG_ApplicationInsights_InstrumentationKey=
            - APP_CONFIG_Serilog__MinimumLevel__Default=Debug
            - APP_CONFIG_Serilog__MinimumLevel__Override__Microsoft=Information
            - APP_CONFIG_Serilog__MinimumLevel__Override__System=Information
            - APP_CONFIG_SmtpSettings__SmtpHost=in-v3.mailjet.com
            - APP_CONFIG_SmtpSettings__SmtpPort=587
            - APP_CONFIG_SmtpSettings__SmtpUser=
            - APP_CONFIG_SmtpSettings__SmtpPass=
            - APP_CONFIG_Jaeger__Enabled=true
            - APP_CONFIG_Jaeger__AgentHost=172.17.0.1
            - APP_CONFIG_Jaeger__AgentPort=6831
        healthcheck:
            test: curl --silent --fail http://mail_api/health || exit 1
            interval: 60s
            timeout: 3s
            start_period: 5s
            retries: 3
        ports:
            - "8089:80"
        logging:
            driver: "json-file"
            options:
                max-file: 2
                max-size: 1m
        deploy:
            resources:
                limits:
                    cpus: 0.50
                    memory: 256M
                reservations:
                    memory: 128M

```

| Variável   |      Descrição      |  Valor |
|:----------|:-------------|:------|
| ASPNETCORE_URLS | | http://+:80 |
| DOTNET_RUNNING_IN_CONTAINER | | true |
| ASPNETCORE_ENVIRONMENT | | Development |
| APP_CONFIG_Urls_Allow_Cors | | *; |
| APP_CONFIG_ApplicationInsights_InstrumentationKey | | |
| APP_CONFIG_Serilog__MinimumLevel__Default | | Information |
| APP_CONFIG_Serilog__MinimumLevel__Override__Microsoft | | Information |
| APP_CONFIG_Serilog__MinimumLevel__Override__System | | Information |
| APP_CONFIG_SmtpSettings__SmtpHost | | in-v3.mailjet.com |
| APP_CONFIG_SmtpSettings__SmtpPort | | 587 |
| APP_CONFIG_SmtpSettings__SmtpUser | | |
| APP_CONFIG_SmtpSettings__SmtpPass | | |
| APP_CONFIG_Jaeger__Enabled | | false |
| APP_CONFIG_Jaeger__AgentHost | | jaeger |
| APP_CONFIG_Jaeger__AgentPort | | 6831 |

## 🛠 Tecnologias

As seguintes libs/ferramentas foram usadas na construção da aplicação

- [C# 9.0](https://docs.microsoft.com/pt-br/dotnet/csharp/)
- [ASP.NET 5](https://dotnet.microsoft.com/)
- [ASP.NET WebApi 5](https://dotnet.microsoft.com/apps/aspnet)
- [Serilog](https://serilog.net/)

As seguintes ferramentas foram usadas na infra da aplicação

- [OAuth2 (Auth0 Service)](https://auth0.com/)
- [Jaeger](https://www.jaegertracing.io/)
- [Docker](https://www.docker.com/)
- [Docker-compose](https://docs.docker.com/compose/)
- [Traefik Proxy](https://doc.traefik.io/traefik/)

## ✅ Contribuição

1. Faça um **fork** do projeto.
2. Crie uma nova branch com as suas alterações: `git checkout -b my-feature`
3. Salve as alterações e crie uma mensagem de commit contando o que você fez: `git commit -m "feature: My new feature"`
4. Envie as suas alterações: `git push origin my-feature`
> Caso tenha alguma dúvida confira este [guia de como contribuir no GitHub](https://github.com/firstcontributions/first-contributions)

## 📝 Licença

Este projeto esta sobe a licença MIT.

Feito por Jackson Veroneze 👋🏽 [Entre em contato!](https://www.linkedin.com/in/jacksonveroneze/)
