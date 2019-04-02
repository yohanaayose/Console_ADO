using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tugas_2
{
        public interface IItem
        {
            List<TB_M_Item> get();
            TB_M_Item Get(int Id);
            bool insert(TB_M_Item item);
            bool Update(int Id, TB_M_Item item);
            bool Delete(int Id);
        }
    }

