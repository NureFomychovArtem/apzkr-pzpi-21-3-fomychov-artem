using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service.Interfaces
{
    public interface ISchoolService
    {
        Task<IEnumerable<SchoolDTO>> GetAllAsync();
        Task<SchoolDTO> GetByIdAsync(int id);
        Task<SchoolDTO> CreateAsync(CreateSchoolDTO data);
        Task UpdateAsync(int id, UpdateSchoolDTO data);
        Task DeleteAsync(int id);

    }
}