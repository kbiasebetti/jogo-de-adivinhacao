namespace JogoDeAdivinhacao.ConsoleApp
{
    internal class Program
    {
        // Versão 01: Estrutura Básica e Entrada do Usuário
        static void Main(string[] args)
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("| Jogo de Adivinhação |");
            Console.WriteLine("-------------------------------");

            // Lógica do Jogo
            Console.Write("> Digite um número de chute: ");
            int numeroChute = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Você digitou o número: {numeroChute}");

            Console.ReadLine();
        }
    }
}
