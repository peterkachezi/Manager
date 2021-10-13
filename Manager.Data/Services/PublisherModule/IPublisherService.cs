using Manager.Data.DTOs.PublisherModule;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Data.Services.PublisherModule
{
    public interface IPublisherService
    {
        Task<List<PublisherDTO>> GetAll();
        Task<PublisherDTO> GetbyId(Guid Id);
        Task<bool> Create(PublisherDTO publisherDTO);
        Task<bool> Delete(Guid Id);
        Task<bool> Update(PublisherDTO publisherDTO);
    }
}
