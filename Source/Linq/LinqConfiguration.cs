namespace LinqToDB.Linq
{
	public class LinqConfiguration
	{
		public LinqConfiguration()
		{
			PreloadGroups = Common.Configuration.Linq.PreloadGroups;
			IgnoreEmptyUpdate = Common.Configuration.Linq.IgnoreEmptyUpdate;
			AllowMultipleQuery = Common.Configuration.Linq.AllowMultipleQuery;
			GenerateExpressionTest = Common.Configuration.Linq.GenerateExpressionTest;
			DoNotClearOrderBys = Common.Configuration.Linq.DoNotClearOrderBys;
			OptimizeJoins = Common.Configuration.Linq.OptimizeJoins;
		}

		public bool PreloadGroups;
		public bool IgnoreEmptyUpdate;
		public bool AllowMultipleQuery;
		public bool GenerateExpressionTest;
		public bool DoNotClearOrderBys;
		public bool OptimizeJoins;
	}
}
