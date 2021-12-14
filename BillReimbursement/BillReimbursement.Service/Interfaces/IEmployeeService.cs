using BillReimbursement.Repository.Models;
using BillReimbursement.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillReimbursement.Service.Interfaces
{
    public interface IEmployeeService
    {
        public void Add(EmployeeModelService employee);

        public IEnumerable<EmployeeModelService> GetAll();
        public EmployeeModelService GetById(string id);

        public void update(EmployeeModelService employee);

        public void Delete(int id);
    }
}
