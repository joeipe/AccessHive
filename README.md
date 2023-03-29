# AccessHive

## Topics covered

#### Docker Compose
#### Kubernetes
> - Run 
> - `kubectl apply -f .\k8s\accesshive-namespace.yml`
> - `kubectl apply -f .\k8s\sqlserver.yml`
> - `kubectl apply -f .\k8s\rabbitmq.yml`
> - `kubectl apply -f .\k8s\accesshiveapi.configmap.yml`
> - `kubectl apply -f .\k8s\accesshiveapi.yml`
> - `kubectl apply -f .\k8s\accesshive-ingress.yml`

> - `create secret generic accesshive-api-secrets --from-literal=ConnectionStrings__DBConnectionString="" --from-literal=ConnectionStrings__RMQConnectionString=""`
> - `kubectl scale deployment accesshive-api --replicas=2`


> - `kubectl config get-contexts`
> - `kubectl config current-context`
> - `kubectl config use-context <CONTEXT_NAME>`

> - `kubectl delete all --all`
> - `kubectl delete namespace ingress-nginx`


> - `az login`
> - `az acr login --name accesshiveregistry`
> - `docker login accesshiveregistry.azurecr.io`

> - `docker tag accesshiveapi:dev accesshiveregistry.azurecr.io/accesshiveapi`
> - `docker push accesshiveregistry.azurecr.io/accesshiveapi`


> - `az aks get-credentials --resource-group k8sLearning-rg --name accesshiveaks`
