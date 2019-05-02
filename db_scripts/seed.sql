\connect postgres

create table users
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

create table accounts
(
  id serial primary key,
  resource_type varchar(50),
  resource_id integer
);

insert into accounts
(
  resource_type,
  resource_id
)
values
(
  'user',
  1
);

create table user_accounts
(
  id serial primary key,
  user_id integer references users(id),
  account_id integer references accounts(id)
);

insert into user_accounts
(
  user_id,
  account_id
)
values
(
  1,
  1
);