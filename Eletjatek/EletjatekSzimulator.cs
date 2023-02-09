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

        public int[,] Matrix { get; set; }
        private int OszlopokSzama { get; set; }
        private int SorokSzama { get; set; }

        private bool Kulso(int s, int o) =>
            s == 0 || o == 0 ||
            s == Matrix.GetLength(0) - 1 ||
            o == Matrix.GetLength(1) - 1;

        private int SzomszedokSzam(int sk, int ok)
        {
            int szsz = 0;
            for (int s = sk-1; s <= sk+1; s++)
            {
                for (int o = ok-1; o <= ok+1; o++)
                {
                    if (Matrix[s, o] == 1) szsz++;
                }
            }

            if (Matrix[sk, ok] == 1) szsz--;

            return szsz;
        }

        private int[,] KovetkezoAllapot()
        {
            int[,] kov = new int[Matrix.GetLength(0), Matrix.GetLength(1)];
            for (int s = 1; s < Matrix.GetLength(0) - 1; s++)
            {
                for (int o = 1; o < Matrix.GetLength(1) - 1; o++)
                {
                    int szsz = SzomszedokSzam(s, o);
                    if (Matrix[s, o] == 1)
                    {
                        if (szsz == 2 || szsz == 3) kov[s, o] = 1;
                        else kov[s, o] = 0;
                    }
                    else if (Matrix[s, o] == 0)
                    {
                        if (szsz == 3) kov[s, o] = 1;
                        else kov[s, o] = 0;
                    }
                }
            }
            return kov;
        }

        private void MatrixMasolas(int[,] forras)
        {
            for (int s = 0; s < forras.GetLength(0); s++)
            {
                for (int o = 0; o < forras.GetLength(1); o++)
                {
                    Matrix[s, o] = forras[s, o];
                }
            }
        }


        private void Megjelenit()
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
        public void Run()
        {
            Console.Clear();
            Megjelenit();
            Matrix = KovetkezoAllapot();
            Thread.Sleep(500);
        }

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
