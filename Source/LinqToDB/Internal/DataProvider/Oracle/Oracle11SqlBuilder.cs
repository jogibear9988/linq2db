using System.Linq;

using LinqToDB.DataProvider;
using LinqToDB.Internal.SqlProvider;
using LinqToDB.Internal.SqlQuery;
using LinqToDB.Mapping;

namespace LinqToDB.Internal.DataProvider.Oracle
{
	public class Oracle11SqlBuilder : OracleSqlBuilderBase
	{
		public Oracle11SqlBuilder(IDataProvider? provider, MappingSchema mappingSchema, DataOptions dataOptions, ISqlOptimizer sqlOptimizer, SqlProviderFlags sqlProviderFlags)
			: base(provider, mappingSchema, dataOptions, sqlOptimizer, sqlProviderFlags)
		{
		}

		private Oracle11SqlBuilder(BasicSqlBuilder parentBuilder) : base(parentBuilder)
		{
		}

		protected override ISqlBuilder CreateSqlBuilder()
		{
			return new Oracle11SqlBuilder(this) { HintBuilder = HintBuilder };
		}

		protected override string GetPhysicalTableName(ISqlTableSource table, string? alias,
			bool ignoreTableExpression = false, string? defaultDatabaseName = null, bool withoutSuffix = false)
		{
			var name = base.GetPhysicalTableName(table, alias, ignoreTableExpression : ignoreTableExpression, defaultDatabaseName : defaultDatabaseName, withoutSuffix : withoutSuffix);

			return table.SqlTableType switch
			{
				SqlTableType.Function => $"TABLE({name})",
				_ => name,
			};
		}

		protected override void BuildTableNameExtensions(SqlTable table)
		{
			var ext = table.SqlQueryExtensions?.LastOrDefault(e => e.Scope == Sql.QueryExtensionScope.TableNameHint);

			if (ext is { BuilderType: not null })
			{
				var extensionBuilder = GetExtensionBuilder(ext.BuilderType);

				switch (extensionBuilder)
				{
					case ISqlQueryExtensionBuilder queryExtensionBuilder:
						queryExtensionBuilder.Build(NullabilityContext, this, StringBuilder, ext);
						break;
				}
			}
		}
	}
}
