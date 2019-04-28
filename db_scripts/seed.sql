\connect postgres

create table "users"
(
  id serial primary key,
  auth0_token varchar(255),
  first_name varchar(50),
  last_name varchar(50),
  email varchar(255),
  phone_number varchar(15)
);

insert into users
(
  auth0_token,
  first_name,
  last_name,
  email,
  phone_number
)
values
(
  'auth0|5cc5ba36613fb90e0f1d0bf6',
  'Test',
  'User',
  'test@test.test',
  '(111)111-1111'
);