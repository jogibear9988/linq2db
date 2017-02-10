using System;
using LinqToDB.Linq;

namespace LinqToDB.Common
{
	public static class Configuration
	{
		/// <summary>
		/// Use Property of Mapping Schema instead
		/// </summary>
		public static bool IsStructIsScalarType = true;

		/// <summary>
		/// Use Property of Mapping Schema instead
		/// </summary>
		public static bool AvoidSpecificDataProviderAPI;

		public static class Linq
		{
			public static bool PreloadGroups;
			public static bool IgnoreEmptyUpdate;
			public static bool AllowMultipleQuery;
			public static bool GenerateExpressionTest;
			public static bool DoNotClearOrderBys;
			public static bool OptimizeJoins = true;
		}

		public static class LinqService
		{
			public static bool SerializeAssemblyQualifiedName;
			public static bool ThrowUnresolvedTypeException;
		}
	}
}
