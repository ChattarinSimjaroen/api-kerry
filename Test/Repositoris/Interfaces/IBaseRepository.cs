using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Repositoris.Interfaces
{
	public interface IBaseRepository
	{
		IEnumerable<T> QueryString<T>(string sql);

		int ExecuteString<T>(string sql);
		object Query<T>(string sql);

	}
}
