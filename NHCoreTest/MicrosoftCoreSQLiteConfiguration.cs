using System;
using FluentNHibernate.Cfg.Db;
using NHibernate.Dialect;

namespace NHCoreTest
{
    public class MicrosoftCoreSQLiteConfiguration : PersistenceConfiguration<MicrosoftCoreSQLiteConfiguration>
    {
        public static MicrosoftCoreSQLiteConfiguration Standard
        {
            get { return new MicrosoftCoreSQLiteConfiguration(); }
        }

        public MicrosoftCoreSQLiteConfiguration()
        {
            Driver<MicrosoftDataSQLiteDriver>();
            Dialect<SQLiteDialect>();
            Raw("query.substitutions", "true=1;false=0");
        }

        public MicrosoftCoreSQLiteConfiguration InMemory()
        {
            Raw("connection.release_mode", "on_close");
            return ConnectionString(c => c
                                    .Is("Data Source=:memory:;Mode=Memory;Cache=Shared"));
        }

        public MicrosoftCoreSQLiteConfiguration UsingFile(string fileName)
        {
            return ConnectionString(c => c
                .Is(string.Format("Data Source={0};Cache=Shared", fileName)));
        }
    }
}
