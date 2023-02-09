using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eletjatek
{
    internal class EletjatekSzimulator
    {
        private static Random rnd = new();

        private int[,] Matrix { get; set; }
        private int OszlopokSzama { get; set; }
        private int SorokSzama { get; set; }

        private bool Kulso(int s, int o) =>
            s == 0 || o == 0 ||
            s == Matrix.GetLength(0) - 1 ||
            o == Matrix.GetLength(1) - 1;

        private void KovetkezoAllapot() { }
        public void Megjelenit()
        {
            for (int s = 0; s < Matrix.GetLength(0); s++)
            {
                for (int o = 0; o < Matrix.GetLength(1); o++)
                {
                    if (Kulso(s, o)) Console.Write('X');
                    else if (Matrix[s, o] == 1) Console.Write('S');
                    else Console.Write(' ');
                }
                Console.Write('\n');
            }
        }
        public void Run() { }

        public EletjatekSzimulator(int sorokSzam, int oszlopokSzama)
        {
            OszlopokSzama = oszlopokSzama;
            SorokSzama = sorokSzam;

            Matrix = new int[SorokSzama + 2, OszlopokSzama + 2];
            for (int s = 0; s < Matrix.GetLength(0); s++)
            {
                for (int o = 0; o < Matrix.GetLength(1); o++)
                {
                    if (Kulso(s, o)) Matrix[s, o] = 0;
                    else Matrix[s, o] = rnd.Next(2);
                }
            }
        }
    }
}
