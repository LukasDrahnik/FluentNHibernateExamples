using FluentNHibernateExamples.CompDatabases.SQLCeDatabase.Entities;
using FluentNHibernate.Mapping;

namespace FluentNHibernateExamples.CompDatabases.SQLCeDatabase.Mappings
{
    public class LocationMap : ComponentMap<Location>
    {
        public LocationMap()
        {
            Map(x => x.Aisle);
            Map(x => x.Shelf);
        }
    }
}