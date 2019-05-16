create table parameters
(
  id serial primary key,
  name varchar(50),
  unit varchar(50),
  max integer,
  min integer,
  change_warning_interval integer,
  tank_id integer references tanks(id),
  sump_thing_box_id integer references sump_thing_boxes(id),
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
  change_warning_interval,
  sump_thing_box_id,
  tank_id
)
values
(
  'Temperature',
  'F',
  82,
  75,
  5,
  1,
  1
);