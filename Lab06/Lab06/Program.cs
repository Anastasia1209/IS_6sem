using System;

namespace Lab06
{
    public class Program
    {
        public static void Main()
        {
            EnigmaMachine enigmaMachine = new EnigmaMachine();

            string encodeMessage = enigmaMachine.Encrypt("ANASTASIYAGOLODOK", 1, 0, 1);

            Console.WriteLine("Зашифрованный текст: " + encodeMessage);

            Console.WriteLine("Расшифрованный текст: " + enigmaMachine.Decrypt(encodeMessage, 1, 0, 1));
        }
    }
}