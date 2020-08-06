using System.Data.Entity.Migrations;
using System.Linq;

namespace Common.Data.Extension
{
    public static class EF
    {
        public static bool ExisteColumna(this DbMigration dbMigration, string nombreTabla, string nombreColumna)
        {
            using (var context = new Context())
            {
                int count = context.Database.SqlQuery<int>(@"IF COL_LENGTH(@p0, @p1) IS NOT NULL
                                                                    select 1;
                                                                ELSE
                                                                    select 0;",
                                                                nombreTabla, nombreColumna).FirstOrDefault();

                return count > 0;
            }
        }
    }
}
