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
    public class ApplyBillService : IApplyBillService
    {
        private readonly IApplyBillRepository _repository;
        private readonly Mapper _mapper;
        private readonly Mapper _mapper1;
        public ApplyBillService(IApplyBillRepository repository)
        {
            _repository = repository;
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<ApplyBillModel, ApplyBillModelService>().ReverseMap()));
            _mapper1 = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<ViewApplyBillModel, ViewApplyBillModelService>().ReverseMap()));
        }
        public void Add(ApplyBillModelService bill)
        {
            ApplyBillModel _bill = _mapper.Map<ApplyBillModelService,ApplyBillModel>(bill);
            _repository.Add(_bill);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<ViewApplyBillModelService> GetAll()
        {
            IEnumerable<ViewApplyBillModel> bill = _repository.GetAll();
            IEnumerable<ViewApplyBillModelService> _bill = _mapper1.Map<IEnumerable<ViewApplyBillModel>, IEnumerable<ViewApplyBillModelService>>(bill);
            return _bill;
        }

        public IEnumerable<ViewApplyBillModelService> GetByIdAll(string EmailId)
        {
            IEnumerable<ViewApplyBillModel> bill = _repository.GetByIdAll(EmailId);
            IEnumerable<ViewApplyBillModelService> _bill = _mapper1.Map<IEnumerable<ViewApplyBillModel>, IEnumerable<ViewApplyBillModelService>>(bill);
            return _bill;
        }

        public void update(ApplyBillModelService bill)
        {
            ApplyBillModel _bill = _mapper.Map<ApplyBillModelService, ApplyBillModel>(bill);
            _repository.update(_bill);
        }
        public void updateApproved(ApplyBillModelService bill)
        {
            ApplyBillModel _bill = _mapper.Map<ApplyBillModelService, ApplyBillModel>(bill);
            _repository.updateApproved(_bill);
        }
        public void updateDeclined(ApplyBillModelService bill)
        {
            ApplyBillModel _bill = _mapper.Map<ApplyBillModelService, ApplyBillModel>(bill);
            _repository.updateDeclined(_bill);
        }
    }
}
