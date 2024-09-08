using System;
using System.Collections.Generic;
using Npgsql;
using System.Data;

namespace Samples.AuthorsService
{
	internal static class AuthorsDataHelper
	{
		public static string Create (string Firstname,
			string Lastname,
			DateTime? Birthdate,
			bool? Gender)
		{
			const string commandText = "usp_createauthor";
			int rowAffected = 0;
			string msg = null;
			try {
				using(NpgsqlConnection conn = GetConnection())
				{
					using(NpgsqlCommand cmd = new NpgsqlCommand(commandText,conn))
					{
						cmd.CommandType = CommandType.StoredProcedure;
						cmd.Parameters.Add(new NpgsqlParameter("p_name",Firstname));
						cmd.Parameters.Add(new NpgsqlParameter("p_lastname",Lastname));
						cmd.Parameters.Add(new NpgsqlParameter("p_date",Birthdate));
						cmd.Parameters.Add(new NpgsqlParameter("p_gender",Gender));
						rowAffected = Convert.ToInt32(cmd.ExecuteScalar());
						if(rowAffected > 0)
							msg = "(1) row affected";
						else
							msg = "No row affected";
					}
				}

			} catch (Exception ex) {
				Console.WriteLine (ex.Message);
			}
			return msg;
		}

		public static List<Author> GetAuthors ()
		{
			List<Author> authors = null;
			const string commandText = @"select authorid,authorname,authorlastname,birthdate,gender
from authors order by authorid desc";
			try {
				using(NpgsqlConnection conn = GetConnection())
				{
					using(NpgsqlCommand cmd = new NpgsqlCommand(commandText,conn))
					{
						authors = new List<Author>();
						cmd.CommandType = CommandType.Text;
						using(NpgsqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
						{
							while(reader.Read())
							{
								Author a =  new Author();
								a.Id = reader.GetInt32(0);
								a.FirstName = reader["authorname"].ToString();
								a.LastName = reader["authorlastname"].ToString();
								if(!DBNull.Value.Equals(reader["birthdate"]))
									a.BirthDate =  Convert.ToDateTime(reader["birthdate"]);
								if(!DBNull.Value.Equals(reader["gender"]))
									a.Gender = Convert.ToBoolean(reader["gender"]);
								authors.Add(a);
							}
						}
					}
				}
			} catch (Exception ex) {
				Console.WriteLine (ex.Message);
			}
			return authors;
		}

		static NpgsqlConnection GetConnection()
		{
			const string conStr = @"Server=127.0.0.1;Port=5432;Database=Books;User ID=postgres;Password=Pa$$W0rd";
			NpgsqlConnection connection = new NpgsqlConnection (conStr);
			connection.Open ();
			return connection;
		}
	}
}

