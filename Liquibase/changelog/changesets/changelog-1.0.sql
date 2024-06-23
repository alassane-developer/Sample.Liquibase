--liquibase formatted sql

-- changeset alassane:1
-- comment: Creating users table

CREATE TABLE users
(
    id uuid NOT NULL,
    name character varying,
    firstname character varying,
    birthdate date,
    PRIMARY KEY (id)
);

