using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tugas_2
{
    class TransactionController : ITransactionItem
    {
        int Id;
        static MyContexttt TransactionContext = new MyContexttt();
        public TB_M_Sell sell = new TB_M_Sell();
        bool status = false;


        public int SaveDate()
        {
            TB_M_Sell sell = new TB_M_Sell();
            sell.Orderdate = DateTime.Now;
            TransactionContext.TB_M_Sell.Add(sell);
            var result = TransactionContext.SaveChanges();
            validation valid = new validation();
            valid.validate(result);
            return sell.Id;
            
        }

        public TB_M_Sell Get(int Id)
        {
            var get = TransactionContext.TB_M_Sell.SingleOrDefault(x => x.Id == Id);
            return get;
        }

        public bool BeliBarang(int itemId, int Stock)
        {
            
            ItemController iItem = new ItemController();
            int sell = SaveDate();
            TB_T_TransactionItem detail = new TB_T_TransactionItem();
            detail.Quantity = Stock;
            detail.TB_M_Item = iItem.Get(itemId);
            detail.TB_M_Sell = Get(sell);
            TransactionContext.TB_T_TransactionItem.Add(detail);
            var result = TransactionContext.SaveChanges();
            validation valid = new validation();
            return valid.validate(result);

        }

        public class validation
        {
            bool status = false;
            public bool validate(int result)
            {
                if (result > 0)
                {
                    Console.Write("Success");
                    status = true;
                }
                else
                {
                    Console.Write("Not Success");
                }
                return status;
            }
        }
    }
}
