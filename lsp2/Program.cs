using static System.Console;

namespace DotNetDesignPatternDemos.SOLID.LiskovSubstitutionPrinciple

{

    // bir tipten objeler kendi base class'i tipine cevrilip, hic bir kayba ugramadan

    // kullanilabilmeli

    // Bunu saglamak icin base class'ta gerekli methodlari virtual yapmak gerekir

    // Base class cinsinden bir liste olsun, icine base class tipinde

    // ya da bundan tureyen child class tipinde nesneler eklenebilir,

    // listeyi isleyen kod base class'a gore yazilir

    // Child class override yapilmis methodlar icin virtual method tablosunda dogru

    // methodu gosterir

    // using a classic example

    public class Rectangle

    {

        //public int Width { get; set; }

        //public int Height { get; set; }
        public virtual int Width { get; set; }

        public virtual int Height { get; set; }

        public Rectangle()

        {

        }

        public Rectangle(int width, int height)

        {

            Width = width;

            Height = height;

        }

        public override string ToString()

        {

            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";

        }

    }

    public class Square : Rectangle

    {
        //public new int Width
        public override int Width

        {

            set { base.Width = base.Height = value; }

        }
        //public new int Height
        public override int Height

        {

            set { base.Width = base.Height = value; }

        }

    }

    public class Demo

    {

        static public int Area(Rectangle r) => r.Width * r.Height;

        static void Main(string[] args)

        {

            Rectangle rc = new Rectangle(2, 3);

            WriteLine($"{rc} has area {Area(rc)}");

            /*Square*/

            Square sq = new Square();

            sq.Width = 5;

            WriteLine($"{sq} has area {Area(sq)}");

            // should be able to substitute a base type for a subtype

            /*Square*/

            Rectangle sq2 = new Square();

            sq2.Width = 4;

            WriteLine($"{sq2} has area {Area(sq2)}");

        }

    }

}
