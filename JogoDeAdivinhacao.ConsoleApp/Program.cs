using System.Security.Cryptography;

namespace JogoDeAdivinhacao.ConsoleApp
{
    internal class Program
    {
        // Versão 03: Verificar se o Jogador Acertou
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

            if (numeroChute == numeroSecretoRandom)
            {
                Console.WriteLine($"Parabéns, você acertou!");
                Console.WriteLine($"O número secreto era {numeroSecretoRandom}");
            } 
            else if (numeroChute > numeroSecretoRandom)
                Console.WriteLine($"O número secreto é menor!");
            else if (numeroChute < numeroSecretoRandom)
                Console.WriteLine($"O número secreto é maior!");
            else
            {
                Console.WriteLine($"Que pena, você errou o número!");

            }

                Console.ReadLine();
        }
    }
}
