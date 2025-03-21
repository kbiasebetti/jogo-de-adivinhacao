﻿namespace JogoDeAdivinhacao.ConsoleApp
{
    internal class Program
    {
        // Versão 04: Criar múltiplas tentativas
        static void Main(string[] args)
        {

            while (true)
            {
                // Cabeçalho
                Console.Clear();
                Console.WriteLine("-------------------------------");
                Console.WriteLine("| Jogo de Adivinhação |");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("| 1 - Fácil (10 tentativas) |");
                Console.WriteLine("| 2 - Normal 5 tentativas) |");
                Console.WriteLine("| 3 - Difícil (3 tentativas) |");
                Console.WriteLine("-------------------------------");

                // Escolha de dificulade
                Console.Write("Escolha um nível de dificuldade: ");
                string escolhaDificuldade = Console.ReadLine();

                int totalTentativas = 0;

                if (escolhaDificuldade == "1")
                    totalTentativas = 10;
                else if (escolhaDificuldade == "2")
                    totalTentativas = 5;
                else
                    totalTentativas = 3;

                // Lógica do Jogo
                Random gerarNumeroAleatorio = new Random(); // Método para gerar número aleatório
                int numeroSecretoRandom = gerarNumeroAleatorio.Next(1, 21);

                for (int tentativa = 1; totalTentativas <= totalTentativas; tentativa++)
                {
                    Console.Clear();
                    Console.WriteLine($"Tentativa {tentativa} de {totalTentativas}");
    
                    Console.Write("> Digite um número (1 á 20) de chute: ");
                    int numeroChute = Convert.ToInt32(Console.ReadLine());

                    if (numeroChute == numeroSecretoRandom)
                    {
                        Console.WriteLine($"Parabéns, você acertou!");
                        Console.WriteLine($"O número secreto era {numeroSecretoRandom}");
                        break;
                    }
                    else if (numeroChute > numeroSecretoRandom)
                        Console.WriteLine($"O número secreto é menor!");
                    else if (numeroChute < numeroSecretoRandom)
                        Console.WriteLine($"O número secreto é maior!");
                    else
                    {
                        Console.WriteLine($"Que pena, você errou o número!");
                    }

                    Console.WriteLine("Pressione ENTER para tentar novamente!");
                    Console.ReadLine();
                }

                Console.Write("Deseja continuar (S/N): ");
                string opcaoContinar = Console.ReadLine();
                
                if (opcaoContinar != "S")
                    break;
            }
        }
    }
}