using FluentNHibernateExamples.CompDatabases.SQLiteDatabase.Entities;
using FluentNHibernate.Mapping;

namespace FluentNHibernateExamples.CompDatabases.SQLiteDatabase.Mappings
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