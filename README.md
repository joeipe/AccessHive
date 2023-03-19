# AccessHive

## Topics covered

#### Docker Compose
#### Kubernetes
> - Run 
> - `kubectl apply -f .\k8s\sqlserver.yml`
> - `kubectl apply -f .\k8s\rabbitmq.yml`
> - `kubectl apply -f .\k8s\accesshiveapi.configmap.yml`
> - `kubectl apply -f .\k8s\accesshiveapi.yml`
> - `kubectl apply -f .\k8s\accesshive-ingress.yml`

> - `create secret generic accesshive-api-secrets --from-literal=ConnectionStrings__DBConnectionString="" --from-literal=ConnectionStrings__RMQConnectionString=""`
> - `kubectl scale deployment accesshive-api --replicas=2`
