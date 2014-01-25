using FluentNHibernateExamples.DataVisualization.SQLiteDatabase.Entities;
using FluentNHibernate.Mapping;

namespace FluentNHibernateExamples.DataVisualization.SQLiteDatabase.Mappings
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Price);
            HasManyToMany(x => x.StoresStockedIn)
                .Cascade.All()
                .Inverse()
                .Table("StoreProduct");

            Component(x => x.Location);
        }
    }
}