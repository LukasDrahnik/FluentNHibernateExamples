using FluentNHibernateExamples.CompDatabases.Entities;
using FluentNHibernate.Mapping;

namespace FluentNHibernateExamples.CompDatabases.Mappings
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