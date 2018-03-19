using System;
using Microsoft.Data.Sqlite;

namespace NHCoreTest
{
    public class MicrosoftDataSQLiteDriver : NHibernate.Driver.ReflectionBasedDriver  
{  
        public MicrosoftDataSQLiteDriver() 
            : base(
                "Microsoft.Data.Sqlite",
                "Microsoft.Data.Sqlite",  
                "Microsoft.Data.Sqlite.SqliteConnection",  
                "Microsoft.Data.Sqlite.SqliteCommand")  
    {  
    }  

    public override bool UseNamedPrefixInParameter {  
        get {  
            return true;  
        }  
    }  

    public override bool UseNamedPrefixInSql {  
        get {  
            return true;  
        }  
    }  

    public override string NamedPrefix {  
        get {  
            return "@";  
        }  
    }  

    public override bool SupportsMultipleOpenReaders {  
        get {  
            return false;  
        }  
    }  
}  
}
