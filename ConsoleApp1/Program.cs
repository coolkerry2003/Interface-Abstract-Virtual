using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //介面(interface)
            //抽象(abstract)
            //虛擬(virtual)

            Console.WriteLine("Hello World!");
            SportsCar CarA = new SportsCar();
            CarA.model = "海神";
            CarA.price = 5000000000;
            CarA.TaxRate = 0.3M;
            motorcycle CarB = new motorcycle() { model = "小50", price = 30000, TaxRate = 0.1M };
            Shoes ShoesA = new Shoes() { model = "愛迪達", price = 3000, TaxRate = 0.07M };
            Console.WriteLine($"{CarA.model} 售價：{CarA.price} 需繳稅：{CarA.Tax().ToString("N0")}");
            Console.WriteLine($"{CarB.model} 售價：{CarB.price} 需繳稅：{CarB.Tax().ToString("N0")}");
            Console.WriteLine($"{ShoesA.model} 售價：{ShoesA.price} 需繳稅：{ShoesA.Tax().ToString("N0")}");
        }
    }
    interface IProduct
    {
        //string model; --錯誤的寫法。介面不能實作，只能宣告
        //型號
        string model { get; set; }//宣告 model這個屬性需有 get 與 set 兩個方法
        decimal price { get; set; }
        //要繳給國家的稅
        decimal Tax();
    }

    //鞋子
    class Shoes : IProduct
    {
        //string model; --錯誤的寫法。必須明確實作介面屬性的方法
        /*屬性宣告的完整寫法
        private string _model = "";
        string IProduct.model {
            get {
                return _model;
            }
            set {
                _model = value;
            }
        }
        */
        public string model { get; set; } //語法糖。與介面的 string model { get; set; } 是不一樣的意思 
        public decimal price { get; set; } //售價
        public decimal TaxRate; //稅率
        public int Size;
        public decimal Tax()
        {
            return price * TaxRate;
        }

    }
    //車
    abstract class Car : IProduct
    {
        public string model { get; set; } //型號
        public int CC;  //CC數
        public decimal price { get; set; } //售價
        public decimal TaxRate; //稅率


        public string Start()
        {
            return $"引擎啟動";
        }

        abstract public string run();

        public decimal Tax()
        {
            return price * TaxRate;
        }

    }
    //跑車
    class SportsCar : Car
    {
        //乘客數
        public int passengers = 4;
        //幾門
        public int Door = 4;

        public virtual string openDoor()
        {
            return "側開";
        }

        public override string run()
        {
            return $"{model} 跑超快";
        }
    }
    //上開車款
    class SpecialSportsCar : SportsCar
    {
        public override string openDoor()
        {
            return "上開";
        }

    }
    //機車
    class motorcycle : Car
    {
        //乘客數
        public int passengers = 2;
        public override string run()
        {
            return $"{model} 跑不快";
        }
    }
}
