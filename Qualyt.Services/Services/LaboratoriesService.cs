using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Qualyt.Data.Repositories;
using Qualyt.Domain.Models.Laboratories;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.Patients;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Qualyt.Services.Services
{
    public interface ILaboratoriesService : IBaseService<Laboratory>
    {
        void SaveIcon(IFormFile icon, long id);
        IQueryable<Laboratory> GetLaboratoriesWithoutIcon();
        byte[] DownloadIcon(long id);
    }
    public class LaboratoriesService : BaseService<Laboratory>, ILaboratoriesService
    {
        public LaboratoriesService(ILaboratoriesRepository repository):base(repository)
        {

        }

        public byte[] DownloadIcon(long id)
        {
            return repo.Get(id)?.IconBytes;
        }

        public IQueryable<Laboratory> GetLaboratoriesWithoutIcon()
        {
            return ((ILaboratoriesRepository)repo).GetLaboratoriesWithoutIcon();
        }

        public void SaveIcon(IFormFile icon, long id)
        {
            byte[] bytes;
            var laboratory = repo.Get(id);
            using (MemoryStream ms = new MemoryStream())
            {
                var input = icon.OpenReadStream();
                input.CopyTo(ms);
                bytes = ms.ToArray();
                laboratory.IconBytes = bytes;
                laboratory.IconType = icon.ContentType;
            }
            repo.Update(laboratory);
        }
    }
}
