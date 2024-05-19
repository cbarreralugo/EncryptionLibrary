using System;
using EncryptionLibrary;
using System.Text;

namespace EncryptionConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido al programa de encriptación AES.");
            Console.Write("Ingrese la contraseña: ");
            string key = ReadPassword();

            AESEncryptor encryptor = new AESEncryptor(key);

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nMenú:");
                Console.WriteLine("1. Encriptar texto");
                Console.WriteLine("2. Desencriptar texto");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Write("Ingrese el texto a encriptar: ");
                        string textToEncrypt = Console.ReadLine();
                        string encryptedText = encryptor.Encrypt(textToEncrypt);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"Texto encriptado: {encryptedText}");
                        Console.ResetColor();
                        break;

                    case "2":
                        Console.Write("Ingrese el texto encriptado: ");
                        string textToDecrypt = Console.ReadLine();
                        try
                        {
                            string decryptedText = encryptor.Decrypt(textToDecrypt);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"Texto desencriptado: {decryptedText}");
                            Console.ResetColor();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error al desencriptar: {ex.Message}");
                        }
                        break;

                    case "3":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }

            Console.WriteLine("Gracias por usar el programa de encriptación.");
        }

        private static string ReadPassword()
        {
            StringBuilder password = new StringBuilder();
            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey(intercept: true);
                if (keyInfo.Key != ConsoleKey.Backspace && keyInfo.Key != ConsoleKey.Enter)
                {
                    password.Append(keyInfo.KeyChar);
                    Console.Write("*");
                }
                else if (keyInfo.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password.Remove(password.Length - 1, 1);
                    Console.Write("\b \b");
                }
            }
            while (keyInfo.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return password.ToString();
        }
    }
}
