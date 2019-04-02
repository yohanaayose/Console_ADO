using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Tugas_2
{
    public class SupplierController : ISupplier
    {
        private MyContexttt SupplierContext = new MyContexttt();
        bool status = false;

        //List Supplier//
        public List<TB_M_Supplier> Get()
        {
            var get = SupplierContext.TB_M_Supplier.Where(x => x.IsDelete == false).ToList();
            Console.WriteLine("------------------");
            Console.WriteLine("Data Supplier");
            Console.WriteLine("------------------");
            foreach (var list in get)
            {
                Console.Write("Id");
                Console.WriteLine(list.Id);
                Console.Write("Supplier Name");
                Console.WriteLine(list.Name);
                Console.WriteLine("");
            }
            return get;

        }

        //Get Supplier by Id//
        public TB_M_Supplier get(int Id)
        {

            Console.Write("Insert your Id : ");
            Id = Convert.ToInt16(Console.ReadLine());
            var get = SupplierContext.TB_M_Supplier.SingleOrDefault(xo => xo.Id == Id);
            Console.Write("Id");
            Console.WriteLine(get.Id);
            Console.Write("Supplier Name");
            Console.WriteLine(get.Name);
            Console.WriteLine("");
            return get;
        }

        //Insert Data Supplier//

        public bool insert(TB_M_Supplier supplier)
        {
            string Name;
            Console.Write("Insert Name :");
            Name = Console.ReadLine();
            TB_M_Supplier suppliers = new TB_M_Supplier();
            suppliers.Name = Name;
            SupplierContext.TB_M_Supplier.Add(suppliers);
            var result = SupplierContext.SaveChanges();
            validation valid = new validation();
            return valid.validate(result);

        }

        //Update data Item//

        public bool update(int Id, TB_M_Supplier supplier)
        {

            Console.Write("Insert Supplier ID :");
            Id = Convert.ToInt16(Console.ReadLine());
            var get = SupplierContext.TB_M_Supplier.Find(Id);
            //var get2 = context.suppliers.singleordefault(x => x.id == id);
            if (get != null)
            {
                string Name;
                Console.Write("Insert Name:");
                Name = Console.ReadLine();
                get.Name = Name;
                SupplierContext.Entry(get).State = EntityState.Modified;
                var result = SupplierContext.SaveChanges();
                validation valid = new validation();
                return valid.validate(result);

            }
            return status;
        }

        //Delete data Supplier//
        public bool delete(int Id)
        {

            Console.Write("Insert Id:");
            Id = Convert.ToInt16(Console.ReadLine());
            //var get = SupplierContext.TB_M_Supplier.Find(Id);
            var get = SupplierContext.TB_M_Supplier.SingleOrDefault(x => x.Id == Id);
            if (get != null)
            {
                SupplierContext.Entry(get).State = EntityState.Deleted;
                var result = SupplierContext.SaveChanges();
                validation valid = new validation();
                return valid.validate(result);
            }
            return status;
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
                    Console.Write("NotSuccess");
                }
                return status;
            }
        }
    }
}
 

