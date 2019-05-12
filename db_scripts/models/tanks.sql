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