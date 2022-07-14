create schema graphql_demo;

create table graphql_demo.user (
    id serial primary key,
    name text,
    email text,
    phone_number text 
);
