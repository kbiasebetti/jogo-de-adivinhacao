namespace JogoDeAdivinhacao.ConsoleApp
{
    internal class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.Clear();
                ExibirMenu();
                int totalTentativas = EscolherDificuldade();
                Jogar(totalTentativas);

                Console.Write("Deseja continuar (S/N): ");
                if (Console.ReadLine()?.ToUpper() != "S")
                    break;
            }
        }

        static void ExibirMenu()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("|     Jogo de Adivinhação     |");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("| 1 - Fácil    (10 tentativas) |");
            Console.WriteLine("| 2 - Normal   (5 tentativas)  |");
            Console.WriteLine("| 3 - Difícil  (3 tentativas)  |");
            Console.WriteLine("-------------------------------");
        }

        static int EscolherDificuldade()
        {
            Console.Write("Escolha um nível de dificuldade: ");
            return Console.ReadLine() switch
            {
                "1" => 10,
                "2" => 5,
                _ => 3
            };
        }

        static void Jogar(int totalTentativas)
        {
            Random random = new Random();
            int numeroSecreto = random.Next(1, 21);
            int[] numerosTentados = new int[totalTentativas];
            int tentativasFeitas = 0, pontuacao = 1000;

            for (int tentativa = 1; tentativa <= totalTentativas; tentativa++)
            {
                Console.Clear();
                Console.WriteLine($"Tentativa {tentativa} de {totalTentativas}");
                Console.WriteLine($"Total de pontos: {pontuacao}");

                int numeroChute = ObterChute();

                if (NumeroJaTentado(numerosTentados, numeroChute, tentativasFeitas))
                {
                    Console.WriteLine("Você já digitou este número!");
                    Console.ReadLine();
                    tentativa--;
                    continue;
                }

                numerosTentados[tentativasFeitas++] = numeroChute;
                pontuacao = AvaliarChute(numeroChute, numeroSecreto, pontuacao);

                if (numeroChute == numeroSecreto)
                    break;
            }
        }

        static int ObterChute()
        {
            Console.Write("> Digite um número (1 a 20): ");
            return Convert.ToInt32(Console.ReadLine());
        }

        static bool NumeroJaTentado(int[] numerosTentados, int numero, int tentativas)
        {
            for (int i = 0; i < tentativas; i++)
            {
                if (numerosTentados[i] == numero)
                    return true;
            }
            return false;
        }

        static int AvaliarChute(int chute, int numeroSecreto, int pontuacao)
        {
            if (chute == numeroSecreto)
            {
                Console.WriteLine($"Parabéns, você acertou! O número secreto era {numeroSecreto}");
                Console.WriteLine($"Você fez {pontuacao} pontos!");
                return pontuacao;
            }

            string dica = chute > numeroSecreto ? "menor" : "maior";
            Console.WriteLine($"O número secreto é {dica}!");
            pontuacao -= Math.Abs(chute - numeroSecreto) / 2;
            pontuacao = Math.Max(pontuacao, 0);
            Console.WriteLine($"Pontos: {pontuacao}");
            Console.WriteLine("Pressione ENTER para tentar novamente!");
            Console.ReadLine();
            return pontuacao;
        }
    }
}
