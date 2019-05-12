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