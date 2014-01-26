using FluentNHibernateExamples.CompDatabases.FirebirdDatabase.Entities;
using FluentNHibernate.Mapping;

namespace FluentNHibernateExamples.CompDatabases.FirebirdDatabase.Mappings
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