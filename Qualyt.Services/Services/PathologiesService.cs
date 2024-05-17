using Qualyt.Data.Repositories;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.Stats;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qualyt.Services.Services
{
    public interface IPathologiesService : IBaseService<Pathology>
    {
        List<Pathology> GetByPatient(long id);
        long GetPathologiesCountLastMonth(DashboardFilter filter);
        long GetPathologiesCount(DashboardFilter filter);
    }
    public class PathologiesService: BaseService<Pathology>, IPathologiesService
    {
        public PathologiesService(IPathologiesRepository repository):base(repository)
        {

        }
        public long GetPathologiesCount(DashboardFilter filter) {
            return ((IPathologiesRepository)repo).GetPathologiesCount(filter);
        }
        public long GetPathologiesCountLastMonth(DashboardFilter filter) {
            return ((IPathologiesRepository)repo).GetPathologiesCountLastMonth(filter);
        }

        public List<Pathology> GetByPatient(long id)
        {
            return ((IPathologiesRepository)repo).GetByPatient(id);
        }
    }
}
