using LibreriaCalcolatrice;

namespace ClassLibrary1
{
    public class Calcolatrice
    {
        public ICLock Clock { get; }
        public Calcolatrice(ICLock clock)
        {
            this.Clock = clock;
        }
        public int Somma(int a, int b)
        {
            DateTime oggi = Clock.Now();
            var giorno = oggi.DayOfWeek;
            if(giorno == DayOfWeek.Tuesday)
            {
                return (a*a) + (b*b);
            }
            else 
                return a + b;
        }

    }
}
