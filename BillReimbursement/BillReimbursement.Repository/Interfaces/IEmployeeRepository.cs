using BillReimbursement.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillReimbursement.Repository.Interfaces
{
    public interface IEmployeeRepository
    {
        public void Add(EmployeeModel employee);

        public IEnumerable<EmployeeModel> GetAll();
        public EmployeeModel GetById(string id);

        public void update(EmployeeModel employee);

        public void Delete(int id);

    }
}
