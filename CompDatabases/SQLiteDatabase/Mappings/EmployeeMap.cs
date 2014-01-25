using FluentNHibernateExamples.CompDatabases.SQLiteDatabase.Entities;
using FluentNHibernate.Mapping;

namespace FluentNHibernateExamples.CompDatabases.SQLiteDatabase.Mappings
{
    public class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Id(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            References(x => x.Store);
        }
    }
}