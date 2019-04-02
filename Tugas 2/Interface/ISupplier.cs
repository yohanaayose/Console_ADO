using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tugas_2
{
   
        public interface ISupplier
        {
        List<TB_M_Supplier> Get();
        TB_M_Supplier get(int Id);
        bool insert(TB_M_Supplier supplier);
        bool update(int Id, TB_M_Supplier supplier);
        bool delete(int Id);
    }

}
