using FluentNHibernate.Mapping;

namespace FluentNhibernateCodeFirst
{
    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Id(c => c.CustomerId);
            Map(c => c.FirstName);
            Map(c => c.LastName);
        }
    }

    
}