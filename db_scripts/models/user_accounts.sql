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