using System.Collections.Generic;
using System;

namespace TinhLienThong
{
    class Program
    {
        public const int max = 9;
        public static int[,] m = new int[,]
        {
            {0, 1, 1, 0, 0, 0, 0, 0, 0},
            {1, 0, 1, 0, 0, 0, 0, 0, 1},
            {1, 1, 0, 1, 1, 0, 0, 0, 0},
            {0, 0, 1, 0, 1, 0, 0, 0, 1},
            {0, 0, 1, 1, 0, 1, 1, 0, 0},
            {0, 0, 0, 0, 1, 0, 0, 0, 0},
            {0, 0, 0, 0, 1, 0, 0, 1, 0},
            {0, 0, 0, 0, 0, 0, 1, 0, 0},
            {0, 1, 0, 1, 0, 0, 0, 0, 0},
        };
        public static bool[] chuaxet = new bool[max];
        public static bool[,] ke = new bool[max, max];
        //danh dau cac dinh xem no thuoc thanh phan lien thong nao
        public static int[] index = new int[max];
        public static int SoTplt = 0;

        // duyet do thi theo chieu sau su dung de quy
        public static void DFSdequy(int v)
        {
            //duyet dinh v
            chuaxet[v] = false;
            index[v] = SoTplt;
            for (int u = 0; u < max; u++)
            {
                if (ke[u, v] == true && chuaxet[u] == true)
                {
                    DFSdequy(u);
                }
            }
        }

        // duyet do thi theo chieu rong su dung QUEUE
        public static void BFSqueue(int v)
        {
            Queue<int> QUEUE = new Queue<int>();
            QUEUE.Enqueue(v);
            chuaxet[v] = false;
            while (QUEUE.Count != 0)
            {
                int p = QUEUE.Dequeue();
                // Duyet dinh p
                chuaxet[p] = false;
                index[p] = SoTplt;
                for (int u = 0; u < max; u++)
                {
                    if (ke[u, p] == true && chuaxet[u] == true)
                    {
                        QUEUE.Enqueue(u);
                        chuaxet[u] = false;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            // tao mang ke
            for (int i = 0; i < max; i++)
            {
                for (int j = 0; j < max; j++)
                {
                    if (m[i, j] == 1)
                    {
                        ke[i, j] = true;
                    }
                }
            }
            // tao nhan cho dinh
            for (int i = 0; i < max; i++)
            {
                chuaxet[i] = true;
            }

            // duyet do thi theo chieu sau su dung de quy (co huong va vo huong deu dc)
            for (int i = 0; i < max; i++)
            {
                if (chuaxet[i])
                {
                    SoTplt++;
                    DFSdequy(i);
                }
            }

            // duyet do thi theo chieu rong su dung QUEUE
            for (int i = 0; i < max; i++)
            {
                if (chuaxet[i])
                {
                    SoTplt++;
                    BFSqueue(i);
                }
            }

        }
    }
}
