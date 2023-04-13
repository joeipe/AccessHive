# AccessHive

## Topics covered

#### Docker Compose
#### Kubernetes
> - Run 
> - `kubectl apply -f https://raw.githubusercontent.com/kubernetes/ingress-nginx/controller-v1.5.1/deploy/static/provider/cloud/deploy.yaml`
> - `kubectl apply -f .\k8s\accesshive-namespace.yml`
> - `kubectl apply -f .\k8s\sqlserver.yml`
> - `kubectl apply -f .\k8s\rabbitmq.yml`
> - `kubectl apply -f .\k8s\accesshiveapi.configmap.yml`
> - `kubectl apply -f .\k8s\accesshiveapi.yml`
> - `kubectl apply -f .\k8s\accesshive-ingress.yml`
> - `kubectl create secret tls accesshiveapidev-tls --key=".\k8s\accesshiveapi.dev.key" --cert=".\k8s\accesshiveapi.dev.crt" -n development`

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
#### Helm
> - Run
> - `helm install local-accesshive .\chart\accesshive`
> - `helm install prod-accesshive .\chart\accesshive --set environment.name=Production --set service.typeSql=LoadBalancer --set service.type=ClusterIP --set image.repository=accesshiveregistry.azurecr.io/accesshiveapi --set image.tag="262"`
> - `helm upgrade prod-accesshive .\chart\accesshive --set environment.name=Production --set service.typeSql=LoadBalancer --set service.type=ClusterIP --set image.repository=accesshiveregistry.azurecr.io/accesshiveapi --set image.tag="262"`

> - `helm upgrade local-accesshive .\chart\accesshive`
> - `helm rollback local-accesshive 1`
> - `helm history local-accesshive`
> - `helm status local-accesshive`
> - `helm get all local-accesshive`
> - `helm uninstall local-accesshive`
> - `helm list`
> - `helm template .\chart\accesshive`
> - `helm install local-accesshive .\chart\accesshive --dry-run --debug`