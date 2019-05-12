\connect postgres

/*
  This function allows us to auto-update
  `updated_at` columns on all of our models.
*/

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

/*
  Here we are importing all of our tables + seed data.

  NOTES:
    - DO NOT modify the order of these imports. Some are reliant
      on a previous import.

    - These kind of imports only work on PSQL/Postgres
*/
\i /app/db/models/users.sql
\i /app/db/models/accounts.sql
\i /app/db/models/user_accounts.sql
\i /app/db/models/tanks.sql
\i /app/db/models/parameters.sql
\i /app/db/models/parameter_values.sql
\i /app/db/models/sump_thing_boxes.sql
\i /app/db/models/registrations.sql
