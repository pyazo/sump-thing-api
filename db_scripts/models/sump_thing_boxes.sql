create table sump_thing_boxes
(
  id serial primary key,
  tank_id integer references tanks(id),
  access_token varchar,
  uuid varchar unique,
  created_at timestamptz not null default now(),
  updated_at timestamptz not null default now()
);

CREATE TRIGGER set_timestamp
BEFORE UPDATE ON sump_thing_boxes
FOR EACH ROW
EXECUTE PROCEDURE update_timestamp();

insert into sump_thing_boxes (tank_id) values (1);