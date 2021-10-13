using Manager.Data.DTOs.StreamModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.StreamModule
{
    public interface IStreamService
    {

        Task<Tuple<bool, StreamDTO, string>> UpdateStream(StreamDTO streamDTO);
        Task<bool> DeleteStream(Guid Id);
        Task<List<StreamDTO>> GetAllStream();
        Task<StreamDTO> GetstreamById(Guid Id);
        Task<Tuple<bool, StreamDTO, string>> CreateStream(StreamDTO streamDTO);
    }
}
