[![Develop on Okteto](https://okteto.com/develop-okteto.svg)](https://cloud.okteto.com/deploy?repository=https://github.com/kubeopsskills/dotnet-core-web-api&branch=develop)

# .NET Core Web API Starter Project

This is a boilerplate template for building / deploying a .NET Core Web API microservice on Kubernetes

## Versioning
| GitHub Release | .NET Core Version | Diagnostics HealthChecks Version |
|----------------|------------ |---------------------|
| main | 6.0.100-preview.6.21355.2 | 2.2.0 |

## Project Structure
```
├── Controllers
│   └── KubeOpsController.cs
├── Dockerfile
├── KubernetesLocalProcessConfig.yaml
├── LICENSE
├── Models
│   └── DatabaseConfig.cs
├── Program.cs
├── Properties
│   └── launchSettings.json
├── README.md
├── Services
│   └── APIService.cs
├── Startup.cs
├── appsettings.Development.json
├── bin
│   └── Debug
├── configs
│   └── prod
├── dotnet-core-web-api.csproj
├── dotnet-core-web-api.sln
├── manifests
│   ├── deployment.yaml
│   └── service.yaml
```

- `Dockerfile` is .NET Core Web API Multistage Dockerfile (following Docker Best Practices)
- `KubernetesLocalProcessConfig.yaml` is [Bridge to Kubernetes](https://devblogs.microsoft.com/visualstudio/bridge-to-kubernetes-ga/) config to supports developing .NET Core Web API microservice on Kubernetes
- `configs` folder will contain .NET Core Web API centralized config structure
- `appsettings.Development.json` is .NET Core Web API development environment config
- `manifests` folder will contain Kubernetes manifests (deployment, service)
- `Startup.cs` is .NET Core Web API startup & path routing config 
- `Program.cs` is .NET Core Web API environment variable mapping config 

## Setting Up

To setup this project, you need to clone the git repo

```sh
$ git clone https://github.com/kubeopsskills/dotnet-core-web-api.git
$ cd dotnet-core-web-api
```

followed by

```sh
$ dotnet restore
```

## Deploying a .NET Core Web API microservice

### Prerequisite:

- .NET Core Web API Docker Image

Preparing Config Map for .NET Core Web API microservice

```sh
$ kubectl apply -k configs/prod
```

To deploy the microservice on Kubernetes, run following command:

```sh
$ kubectl apply -f manifests
```

This will deploy it on Kubernetes with the centralized config.