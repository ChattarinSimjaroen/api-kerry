using Dapper;
using Test.Repositoris.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Repositoris.Imprements
{
	public class BaseRepository : IBaseRepository
	{
		private readonly string ConnectionStrings;
		public BaseRepository(string ConnectionStrings)
		{
			this.ConnectionStrings = ConnectionStrings;
		}
		private T WithConnection<T>(Func<IDbConnection, T> getData)
		{
			try
			{
				using (var connection = new SqlConnection(ConnectionStrings))
				{
					connection.Open();
					return getData(connection);
				}
			}
			catch (SqlException e)
			{
				throw e;
			}
		}

		public int ExecuteString<T>(string sql)
		{
			return WithConnection (c => c.Execute(sql));
		}

		public IEnumerable<T> QueryString<T>(string sql)
		{
			return WithConnection(c => c.Query<T>(sql));
		}
		public object Query<T>(string sql)
		{
			throw new NotImplementedException();
		}
	}
}
