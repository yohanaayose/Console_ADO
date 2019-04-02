using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tugas_2
{
    public class ItemController : IItem
    {
        private MyContexttt ItemContext = new MyContexttt();
        bool status = false;

        //List Item//
        public List<TB_M_Item> get()
        {
            var get = ItemContext.TB_M_Item.Where(x => x.IsDelete == false).ToList();
            Console.WriteLine("------------------");
            Console.WriteLine("Data Item");
            Console.WriteLine("------------------");
            foreach (var list in get)
            {
                Console.Write("Id:          ");
                Console.WriteLine(list.Id);
                Console.Write("Item Name:   ");
                Console.WriteLine(list.Name);
                Console.Write("Supplier Id: ");
                Console.WriteLine(list.Supplier_id);
                Console.Write("Price:       ");
                Console.WriteLine(list.Price);
                Console.Write("Stock:       ");
                Console.WriteLine(list.Stock);
                Console.WriteLine("");
            }
            return get;

        }

        //Get Item by Id//
            public TB_M_Item Get (int Id)
        {

            Console.Write("Insert your Id : ");
            Id = Convert.ToInt16(Console.ReadLine());
            var get = ItemContext.TB_M_Item.SingleOrDefault(xo => xo.Id == Id);
                Console.Write("Id");
                Console.WriteLine(get.Id);
                Console.Write("Item Name");
                Console.WriteLine(get.Name);
                Console.Write("Supplier Id");
                Console.WriteLine(get.Supplier_id);
                Console.Write("Price");
                Console.WriteLine(get.Price);
                Console.Write("Stock");
                Console.WriteLine(get.Stock);
                Console.WriteLine("");
                return get;
            }

    //Insert Data Item//

    public bool insert(TB_M_Item item)
        {
            string Name;
            int Supplier_id, Price, Stock;

            Console.Write("Insert Name :          ");
            Name = Console.ReadLine();
            Console.Write("Insert Supplier ID :   ");
            Supplier_id = Convert.ToInt16(Console.ReadLine());
            Console.Write("Insert Price :         ");
            Price = Convert.ToInt32(Console.ReadLine());
            Console.Write("Insert Stock :         ");
            Stock = Convert.ToInt16(Console.ReadLine());

            TB_M_Item items = new TB_M_Item();
            item.Name = Name;
            item.Supplier_id = Supplier_id;
            item.Price = Price;
            item.Stock = Stock;
            ItemContext.TB_M_Item.Add(item);
            var result = ItemContext.SaveChanges();
            validation valid = new validation();
            return valid.validate(result);
            
        }

        //Update data Item//

        public bool Update(int Id, TB_M_Item item)
        {
            string Name;
            int Stock, Price;
            Console.Write("Insert your Id:");
            Id = Convert.ToInt16(Console.ReadLine());
            var get = ItemContext.TB_M_Item.Find(Id);
            //var get2 = context.suppliers.singleordefault(x => x.id == id);
            if (get != null)
            {

                Console.Write("Insert new Name:");
                Name = Console.ReadLine();
                Console.Write("Insert Item Price :");
                Stock = Convert.ToInt32(Console.ReadLine());
                Console.Write("Insert Stock :");
                Price = Convert.ToInt32(Console.ReadLine());
                get.Name = Name;
                get.Stock = Stock;
                get.Price = Price;
                ItemContext.Entry(get).State= EntityState.Modified;
                var result = ItemContext.SaveChanges();
                validation valid = new validation();
                return valid.validate(result);
                
            }
            else
            {
                Console.Write("No Data Found");
                status = false;
            }
            return status;
        }

        //Delete data Item//
        public bool Delete(int Id)
        {
            
            Console.Write("Insert Id:");
            Id = Convert.ToInt16(Console.ReadLine());
            var get = ItemContext.TB_M_Item.Find(Id);
            //var get2 = myContext.Suppliers.SingleOrDefault(x => x.Id == Id);
            if (get != null)
            {
                ItemContext.Entry(get).State = EntityState.Deleted;
                var result = ItemContext.SaveChanges();
                validation valid = new validation();
                return valid.validate(result);
            }
            else
            {
                Console.Write("No Data Found");
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





