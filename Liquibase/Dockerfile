FROM liquibase/liquibase

COPY changelog /liquibase/changelog

ENTRYPOINT ["liquibase", "--defaultsFile=/liquibase/changelog/liquibase.properties", "update"]