using AutoMapper;
using BillReimbursement.Repository.Interfaces;
using BillReimbursement.Repository.Models;
using BillReimbursement.Service.Interfaces;
using BillReimbursement.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillReimbursement.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly Mapper _mapper;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<EmployeeModel,EmployeeModelService >().ReverseMap()));
        }
        public void Add(EmployeeModelService employee)
        {
            EmployeeModel _employee = _mapper.Map<EmployeeModelService, EmployeeModel>(employee);
            _employeeRepository.Add(_employee);
        }

        public void Delete(int id)
        {
            _employeeRepository.Delete(id);
        }

        public IEnumerable<EmployeeModelService> GetAll()
        {
            IEnumerable<EmployeeModel> _employee = _employeeRepository.GetAll();
            return _mapper.Map<IEnumerable<EmployeeModel>, IEnumerable<EmployeeModelService>>(_employee);
        }

        public EmployeeModelService GetById(string id)
        {
            EmployeeModel _employee = _employeeRepository.GetById(id);
            return _mapper.Map<EmployeeModel, EmployeeModelService>(_employee);

        }

        public void update(EmployeeModelService employee)
        {
            EmployeeModel _employee = _mapper.Map<EmployeeModelService, EmployeeModel>(employee);
            _employeeRepository.update(_employee);
        }

    }
}
