## Synopsis

.Net Core 2.0 Microsoft.Data.SQLite driver for NHibernate 5.1 and FluentNHibernate

## Motivation

With release of [NHibernate 5.1](https://github.com/nhibernate/nhibernate-core/releases/tag/5.1.0) the framework is now compatible with .Net Core 2.0 and .Net Standard 2.0. So I fired up my Visual Studio Mac and wanted to try it out a bit. I also wanted to take a look at [FluentNHibernate](https://github.com/FluentNHibernate/fluent-nhibernate), which doesn't provide .Net Standard or .Net Core packages yet but it still works with warnings.

So I was trying out the [sample project](https://github.com/FluentNHibernate/fluent-nhibernate/wiki/Getting-started) that FluentNHibernate provides and ran into the problem that `System.Data.SQLite` isn't working on Mac with .Net Core projects. Some searching pointed me towards [Microsoft.Data.SQLite](https://github.com/aspnet/Microsoft.Data.Sqlite) implementation that is compatible with .Net Core. I couldn't make it work at first though because SQLite NHibernate and FluentNHibernate access always wanted to use `System.Data.SQLite`. 

Then I stumbled over this [StackOverflow Answer](https://stackoverflow.com/a/7645822/3018064). I was able to adapt it to use `Microsoft.Data.SQLite` which you can find the `MicrosoftDataSQLiteDriver` and `MicrosoftCoreSQLiteConfiguration` classes.  

## Usage

Copy the `MicrosoftDataSQLiteDriver.cs` into your project and point to it in your NHibernate configuration.

````
<property name="connection.driver_class">NHCoreTest.MicrosoftDataSQLiteDriver</property>
<property name="dialect">NHibernate.Dialect.SQLiteDialect</property> 
````

If you use FluentNHibernate copy `MicrosoftCoreSQLiteConfiguration.cs` into your project and use it to fluently configure your SessionFactory. 

```
private static ISessionFactory CreateSessionFactory() {
    return Fluently.Configure()
                    .Database(
                        MicrosoftCoreSQLiteConfiguration.Standard
                        .UsingFile("nhcoretest.db")
                        )
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Program>())
                    .ExposeConfiguration(BuildSchema)
                    .BuildSessionFactory();
}
```

## Miscellaneous

If you have any comments about this feel free to contact me. 
