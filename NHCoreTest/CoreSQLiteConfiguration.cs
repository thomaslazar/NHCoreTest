using System;
using FluentNHibernate.Cfg.Db;
using NHibernate.Dialect;

namespace NHCoreTest
{
    public class CoreSQLiteConfiguration : PersistenceConfiguration<CoreSQLiteConfiguration>
    {
        public static CoreSQLiteConfiguration Standard
        {
            get { return new CoreSQLiteConfiguration(); }
        }

        public CoreSQLiteConfiguration()
        {
            Driver<CoreSQLiteDriver>();
            Dialect<SQLiteDialect>();
            Raw("query.substitutions", "true=1;false=0");
        }

        public CoreSQLiteConfiguration InMemory()
        {
            Raw("connection.release_mode", "on_close");
            return ConnectionString(c => c
                .Is("Data Source=:memory:;Version=3;New=True;"));

        }

        public CoreSQLiteConfiguration UsingFile(string fileName)
        {
            return ConnectionString(c => c
                .Is(string.Format("Data Source={0};Version=3;New=True;", fileName)));
        }

        public CoreSQLiteConfiguration UsingFileWithPassword(string fileName, string password)
        {
            return ConnectionString(c => c
                .Is(string.Format("Data Source={0};Version=3;New=True;Password={1};", fileName, password)));
        }
    }
}
