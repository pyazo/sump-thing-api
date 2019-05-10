\connect postgres

CREATE OR REPLACE FUNCTION update_timestamp()
RETURNS TRIGGER AS $$
BEGIN
   IF row(NEW.*) IS DISTINCT FROM row(OLD.*) THEN
      NEW.updated_at = now(); 
      RETURN NEW;
   ELSE
      RETURN OLD;
   END IF;
END;
$$ language 'plpgsql';

create table users
(
  id serial primary key,
  auth0_token varchar(255),
  first_name varchar(50),
  last_name varchar(50),
  email varchar(255),
  phone_number varchar(15),
  created_at timestamptz not null default now(),
  updated_at timestamptz not null default now()
);

CREATE TRIGGER set_timestamp
BEFORE UPDATE ON users
FOR EACH ROW
EXECUTE PROCEDURE update_timestamp();

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
  resource_id integer,
  created_at timestamptz not null default now(),
  updated_at timestamptz not null default now()
);

CREATE TRIGGER set_timestamp
BEFORE UPDATE ON accounts
FOR EACH ROW
EXECUTE PROCEDURE update_timestamp();

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
  account_id integer references accounts(id),
  created_at timestamptz not null default now(),
  updated_at timestamptz not null default now()
);

CREATE TRIGGER set_timestamp
BEFORE UPDATE ON user_accounts
FOR EACH ROW
EXECUTE PROCEDURE update_timestamp();


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

create table tanks
(
  id serial primary key,
  name varchar(50),
  water_type varchar(10),
  tank_type varchar(50),
  volume integer,
  volume_unit varchar(2),
  is_system boolean,
  number_of_tanks integer,
  account_id integer references accounts(id),
  created_at timestamptz not null default now(),
  updated_at timestamptz not null default now()
);

CREATE TRIGGER set_timestamp
BEFORE UPDATE ON tanks
FOR EACH ROW
EXECUTE PROCEDURE update_timestamp();

insert into tanks
(
  name,
  water_type,
  tank_type,
  volume,
  volume_unit,
  is_system,
  number_of_tanks,
  account_id
)
values
(
  'Default Tank',
  'salt',
  'Bowfront',
  75,
  'G',
  false,
  1,
  1
);

create table parameters
(
  id serial primary key,
  name varchar(50),
  unit varchar(50),
  max integer,
  min integer,
  change_warning_inverval integer,
  tank_id integer references tanks(id),
  created_at timestamptz not null default now(),
  updated_at timestamptz not null default now()
);

CREATE TRIGGER set_timestamp
BEFORE UPDATE ON parameters
FOR EACH ROW
EXECUTE PROCEDURE update_timestamp();

insert into parameters
(
  name,
  unit,
  max,
  min,
  change_warning_inverval,
  tank_id
)
values
(
  'Temperature',
  'F',
  82,
  75,
  5,
  1
);

create table parameter_values
(
  id serial primary key,
  value integer,
  notes varchar,
  parameter_id integer references parameters(id),
  created_at timestamptz not null default now(),
  updated_at timestamptz not null default now()
);

CREATE TRIGGER set_timestamp
BEFORE UPDATE ON parameter_values
FOR EACH ROW
EXECUTE PROCEDURE update_timestamp();

insert into parameter_values
(
  value,
  notes,
  parameter_id
)
values
(
  81,
  'The tank is getting a little hot',
  1
)