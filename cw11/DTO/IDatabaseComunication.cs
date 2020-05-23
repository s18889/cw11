using cw11.ComunicationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw11.DTO
{
    public interface IDatabaseComunication
    {

        public void DatabaseExampleData();
        object GetDoctors();
        void AddDoctor(AddDoctor dr);
        void ModDoctor(ModyfyDoctor dr);
        void DeleteDoctor(int dr);
    }
}
