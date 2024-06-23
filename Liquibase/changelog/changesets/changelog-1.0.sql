-- changelog-1.0.sql

-- Changeset ID: 1, Author: alassane
-- Creating table 'users'

CREATE TABLE users
(
    id uuid NOT NULL,
    name character varying,
    firstname character varying,
    birthdate date,
    PRIMARY KEY (id)
);

