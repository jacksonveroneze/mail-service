FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build-env

WORKDIR /app

ADD ./src app
ADD ./Directory.Build.props app

RUN dotnet restore app/JacksonVeroneze.MailService.Api/JacksonVeroneze.MailService.Api.csproj && \
    dotnet publish app/JacksonVeroneze.MailService.Api/JacksonVeroneze.MailService.Api.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine

ENV ASPNETCORE_URLS=http://+:80
ENV DOTNET_RUNNING_IN_CONTAINER=true
ENV ASPNETCORE_ENVIRONMENT=Production
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
ENV TZ=America/Sao_Paulo
ENV LANG pt-BR
ENV LANGUAGE pt-BR

RUN apk add icu-libs curl tzdata && \
    rm -rf /var/cache/apk/* && \
    ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && \
    echo $TZ > /etc/timezone

WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "JacksonVeroneze.MailService.Api.dll"]
