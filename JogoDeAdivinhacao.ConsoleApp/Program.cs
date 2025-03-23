namespace JogoDeAdivinhacao.ConsoleApp
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

                int[] numerosTentados = new int[totalTentativas];
                int tentativasFeitas = 0;
                int pontuacao = 1000;

                for (int tentativa = 1; tentativa <= totalTentativas; tentativa++)
                {
                    Console.Clear();
                    Console.WriteLine($"Tentativa {tentativa} de {totalTentativas}");
                    Console.WriteLine($"Total de pontos: {pontuacao}");
    
                    Console.Write("> Digite um número (1 á 20) de chute: ");
                    int numeroChute = Convert.ToInt32(Console.ReadLine());

                    bool numeroRepetido = false;
                    for (int i = 0; i < tentativasFeitas; i++)
                    {
                        if (numerosTentados[i] == numeroChute)
                        {
                            numeroRepetido = true;
                            break;
                        }
                    }
                    
                    if (numeroRepetido == true)
                    {
                        Console.WriteLine("Você já digitou este número!");
                        Console.ReadLine();
                        tentativa--;
                        continue;
                    }

                    numerosTentados[tentativasFeitas] = numeroChute;
                    tentativasFeitas++;

                    if (numeroChute == numeroSecretoRandom)
                    {
                        Console.WriteLine($"Parabéns, você acertou!");
                        Console.WriteLine($"O número secreto era {numeroSecretoRandom}");
                        Console.WriteLine($"Você fez {pontuacao} pontos!");
                        break;
                    }
                    else if (numeroChute > numeroSecretoRandom)
                    {
                        Console.WriteLine($"O número secreto é menor!");
                        pontuacao -= Math.Abs((numeroChute - numeroSecretoRandom) / 2);
                        if (pontuacao < 0) pontuacao = 0;
                        Console.WriteLine($"Pontos: {pontuacao}");
                    }
                    else if (numeroChute < numeroSecretoRandom)
                    {
                        Console.WriteLine($"O número secreto é maior!");
                        pontuacao = Math.Abs((numeroChute - numeroSecretoRandom) / 2);
                        if (pontuacao < 0) pontuacao = 0;
                        Console.WriteLine($"Pontos: {pontuacao}");
                    }
                    else
                    {
                        Console.WriteLine($"Que pena, você errou o número!");
                        pontuacao-= Math.Abs((numeroChute - numeroSecretoRandom) / 2);
                        if (pontuacao < 0) pontuacao = 0;
                        Console.WriteLine($"Pontos: {pontuacao}");
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