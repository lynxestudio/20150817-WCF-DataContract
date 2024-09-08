
create table authors
(
	authorid serial primary key,
	authorname char(64) NOT NULL,
	authorlastname char(64) NOT NULL,
	birthdate date,
	gender boolean
);
