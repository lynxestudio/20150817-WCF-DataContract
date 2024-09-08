CREATE OR REPLACE FUNCTION usp_createauthor(p_name character varying,
	p_lastname character varying,
	p_date date,
	p_gender boolean)
RETURNS integer AS
'DECLARE
	p_authorid int;
BEGIN
	p_authorid := nextval(''authors_authorid_seq'');
	INSERT INTO authors(authorid,authorname,authorlastname,birthdate,gender)
	VALUES(p_authorid,p_name,p_lastname,p_date,p_gender);
	return p_authorid;
END
'
LANGUAGE plpgsql
