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
);
