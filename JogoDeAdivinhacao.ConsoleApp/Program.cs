using System.Security.Cryptography;

namespace JogoDeAdivinhacao.ConsoleApp
{
    internal class Program
    {
        // Versão 02:Gerar um Número Secreto Aleatório
        static void Main(string[] args)
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("| Jogo de Adivinhação |");
            Console.WriteLine("-------------------------------");

            // Lógica do Jogo
            Random gerarNumeroAleatorio = new Random(); // Método para gerar número aleatório
            int numeroSecretoRandom = gerarNumeroAleatorio.Next(1, 21);

            Console.Write("> Digite um número (1 á 20) de chute: ");
            int numeroChute = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Você digitou: {numeroChute}");
            Console.WriteLine($"O número secreto era: {numeroSecretoRandom}");

            Console.ReadLine();
        }
    }
}
