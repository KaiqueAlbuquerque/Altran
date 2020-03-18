using System;

namespace WeirdNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem vindo ao desafio Weird number! \r\nInforme um número x para descobrir os x primeiros Weird number.");
            
            int number;
            while (!int.TryParse(Console.ReadLine(), out number))
                Console.WriteLine("Ops... Insira apenas números inteiros. \r\nInforme um número x para descobrir os x primeiros Weird number");

            Console.WriteLine($"Os {number} primeiros Weird number são: {string.Join(", ", WeirdNumberRules.GenerateWeirdNumber(number))}"); 
        }
    }
}
