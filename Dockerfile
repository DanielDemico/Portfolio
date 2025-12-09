# Imagem oficial do PostgreSQL
FROM postgres:16-alpine

# Variáveis de ambiente para configuração do PostgreSQL
ENV POSTGRES_USER=portfolio
ENV POSTGRES_PASSWORD=123456
ENV POSTGRES_DB=portfoliodb

# Porta padrão do PostgreSQL
EXPOSE 5432

# Volume para persistência de dados
VOLUME ["/var/lib/postgresql/data"]
