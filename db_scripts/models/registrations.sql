create table registrations
(
  id serial primary key,
  account_id integer references accounts(id),
  sump_thing_box_id integer references sump_thing_boxes(id)
);

CREATE TRIGGER set_timestamp
BEFORE UPDATE ON registrations
FOR EACH ROW
EXECUTE PROCEDURE update_timestamp();

insert into registrations
(
  account_id,
  sump_thing_box_id
)
values
(
  1,
  1
);