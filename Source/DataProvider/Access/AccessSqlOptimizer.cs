using System;
using LinqToDB.Linq;

namespace LinqToDB.DataProvider.Access
{
	using SqlProvider;
	using SqlQuery;

	class AccessSqlOptimizer : BasicSqlOptimizer
	{
		public AccessSqlOptimizer(SqlProviderFlags sqlProviderFlags) : base(sqlProviderFlags)
		{
		}

		public override SelectQuery Finalize(SelectQuery selectQuery, LinqConfiguration linqConfiguration)
		{
			selectQuery = base.Finalize(selectQuery, linqConfiguration);

			switch (selectQuery.QueryType)
			{
				case QueryType.Delete : return GetAlternativeDelete(selectQuery);
				default               : return selectQuery;
			}
		}

		public override bool ConvertCountSubQuery(SelectQuery subQuery)
		{
			return !subQuery.Where.IsEmpty;
		}
	}
}
