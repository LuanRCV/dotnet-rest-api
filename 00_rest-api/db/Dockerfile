FROM mysql:8.0.27
EXPOSE 3306

# Copy Migrations, Datasets and Commands do init db
COPY ./rest-api/db/migrations/ /home/database/
COPY ./rest-api/db/dataset/ /home/database/
COPY ./rest-api/CI/init_database.sh /docker-entrypoint-initdb.d/init_database.sh