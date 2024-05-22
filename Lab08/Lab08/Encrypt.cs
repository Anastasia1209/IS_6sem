using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab08
{
    public class RC4
    {
            byte[] S = new byte[256];
            int x = 0;
            int y = 0;

            public RC4(byte[] key)
            {
                for (int i = 0; i < 256; i++)
                {
                    S[i] = (byte)i;
                }

                int j = 0;
                for (int i = 0; i < 256; i++)
                {
                    j = (j + S[i] + key[i % key.Length]) % 256; 
                    S.Swap(i, j);      
                }
            }

            public byte[] Encode(byte[] dataB, int size)
            {
                byte[] data = dataB.Take(size).ToArray();
                byte[] cipher = new byte[data.Length];

                for (int m = 0; m < data.Length; m++)
                {
                    cipher[m] = (byte)(data[m] ^ ItemKey());
                }
                return cipher;
            }

            private byte ItemKey()
            {
                x = (x + 1) % 256;
                y = (y + S[x]) % 256;

                S.Swap(x, y);

                return S[(S[x] + S[y]) % 256];
            }
        }

    public static class SwapExt
    {
        public static void Swap<T>(this T[] array, int index1, int index2)
        {
            T temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
    }
}
