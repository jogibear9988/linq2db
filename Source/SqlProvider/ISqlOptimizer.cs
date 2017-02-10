using System;
using LinqToDB.Linq;

namespace LinqToDB.SqlProvider
{
	using SqlQuery;

	public interface ISqlOptimizer
	{
		SelectQuery    Finalize         (SelectQuery selectQuery, LinqConfiguration linqConfiguration);
		ISqlExpression ConvertExpression(ISqlExpression expression);
		ISqlPredicate  ConvertPredicate (SelectQuery selectQuery, ISqlPredicate  predicate);
	}
}
