using Res.DomainLayer.Interfaces;
using Res.DomainLayer.Models;
using Res.Infra.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using System.Data.Entity;

namespace Res.Infra.DataLayer.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomerRespository : ICustomerRepository
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ReservationDbContext _context;

        public CustomerRespository(ReservationDbContext cdb)
        {
            _context = cdb;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Customer> GetCustomers()
        {
            try
            {
                return _context.Customers;
            }
            catch
            {
                return new List<Customer>();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Customer> GetReserveDetails(int? id)
        {
            var customer = _context.Customers
                .Include(r => r.ContactType)
                .SingleOrDefault(m => m.Id == id);

            if (customer == null)
            {
                return null;
            }

            return new List<Customer>() { customer };
        }

        public void Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Customer> entities)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> Find(Expression<Func<Customer, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAllCustomersData()
        {
            throw new NotImplementedException();
        }

        public Customer GetSingleOrDefault(Expression<Func<Customer, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetTopActiveCustomers(int count)
        {
            throw new NotImplementedException();
        }

        public void Remove(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Customer> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<Customer> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetCustomersDataByName(string customerName)
        {
            throw new NotImplementedException();
        }
    }
}
