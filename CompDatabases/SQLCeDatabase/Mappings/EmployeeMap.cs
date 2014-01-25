using FluentNHibernateExamples.CompDatabases.SQLCeDatabase.Entities;
using FluentNHibernate.Mapping;

namespace FluentNHibernateExamples.CompDatabases.SQLCeDatabase.Mappings
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