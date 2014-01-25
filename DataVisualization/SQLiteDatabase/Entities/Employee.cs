using FluentNHibernateExamples.DataVisualization.SQLiteDatabase.Entities;

namespace FluentNHibernateExamples.DataVisualization.SQLiteDatabase.Entities
{
    public class Employee
    {
        public virtual int Id { get; protected set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual Store Store { get; set; }
    }
}