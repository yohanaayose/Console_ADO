using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tugas_2;

namespace ButcampV2
{
    class Program
    {
        int Id;
        static Program program = new Program();
        ISupplier iSupplier = new SupplierController();
        TB_M_Supplier supplier = new TB_M_Supplier();
        MyContexttt myContext = new MyContexttt();

        IItem iItem = new ItemController();
        TB_M_Item item = new TB_M_Item();
        static void Main(string[] args)
        {

            
            program.Menu();
        }

        public void Menu()
        {
            int Choice;
            Console.WriteLine("============Pilihan Menu=============");
            Console.WriteLine("=====================================");
            Console.WriteLine("1. Menu Supplier");
            Console.WriteLine("2. Menu Item");
            Console.WriteLine("3. Beli Barang");
            Console.WriteLine("=====================================");
            Console.Write("Tentukan Pilihanmu");
            Choice = Convert.ToInt16(Console.ReadLine());
            switch (Choice)
            {
                case 1:
                    program.MenuSupplier();
                    break;
                case 2:
                    program.MenuItem();
                    break;
                case 3:
                    program.BeliBarang();
                    break;
                default:
                    Console.WriteLine("Exiting.........");
                    Console.Read();
                    break;
            }

        }

        public void MenuSupplier()
        {
            int Choice;
            Console.WriteLine("=====================================");
            Console.WriteLine("=======     MENU SUPPLIER      ======");
            Console.WriteLine("=====================================");
            Console.WriteLine("||        1. View All Data          ||");
            Console.WriteLine("||        2. Insert                 ||");
            Console.WriteLine("||        3. Update                 ||");
            Console.WriteLine("||        4 Delete                  ||");
            Console.WriteLine("======================================");
            Console.Write("Pilihan.....");
            Choice = Convert.ToInt16(Console.ReadLine());
            switch (Choice)
            {
                case 1:
                    iSupplier.Get();
                    Console.Read();
                    break;
                case 2:
                    iSupplier.insert(supplier);
                    Console.Read();
                    break;
                case 3:
                    iSupplier.update(Id, supplier);
                    Console.Read();
                    break;
                case 4:
                    iSupplier.delete(Id);
                    Console.Read();
                    break;
                default:
                    Console.WriteLine("Exiting......");
                    Console.Read();
                    break;
            }
        }


        public void MenuItem()
        {
            int Choice;
            Console.WriteLine("=====================================");
            Console.WriteLine("=======     MENU ITEM     ======");
            Console.WriteLine("=====================================");
            Console.WriteLine("||        1. View All Data          ||");
            Console.WriteLine("||        2. Insert                 ||");
            Console.WriteLine("||        3. Update                 ||");
            Console.WriteLine("||        4 Delete                  ||");
            Console.WriteLine("======================================");
            Console.Write("Pilihan.....");
            Choice = Convert.ToInt16(Console.ReadLine());
            switch (Choice)
            {
                case 1:
                    iItem.get();
                    Console.Read();
                    break;
                case 2:
                    iItem.insert(item);
                    Console.Read();
                    break;
                case 3:
                    iItem.Update(Id, item);
                    Console.Read();
                    break;
                case 4:
                    iItem.Delete(Id);
                    Console.Read();
                    break;
                default:
                    Console.WriteLine("Exiting......");
                    Console.Read();
                    break;
            }
            Console.Read();
        }
        public void BeliBarang()
        {
            int itemId,  Stock;
            TransactionController ct = new TransactionController();
            ItemController iItem = new ItemController();
            TB_M_Item item = new TB_M_Item();
            iItem.get();
            Console.Write(" Masukkan Kode Barang (Id) : ");
            itemId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" Masukkan Jumlah Barang (Stock) : ");
            Stock = Convert.ToInt32(Console.ReadLine());
            ct.BeliBarang(itemId, Stock);
        }
    }
        
}

  
 
