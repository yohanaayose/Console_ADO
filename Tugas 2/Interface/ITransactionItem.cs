using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tugas_2
{
    public interface ITransactionItem
    {
        int SaveDate();
        
        bool BeliBarang(int itemId, int Stock);
    }
    
    }

