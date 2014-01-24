using FluentNHibernateExamples.CompDatabases.SQLCeDatabase.Entities;

namespace FluentNHibernateExamples.CompDatabases.SQLCeDatabase.Entities
{
    public class Employee
    {
        public virtual int Id { get; protected set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual Store Store { get; set; }
    }
}