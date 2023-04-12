FROM nginx

COPY nginx/nginx.local.conf /etc/nginx/nginx.conf
COPY nginx/accesshiveapi.local.crt /etc/ssl/certs/accesshiveapi.local.com.crt
COPY nginx/accesshiveapi.local.key /etc/ssl/private/accesshiveapi.local.com.key