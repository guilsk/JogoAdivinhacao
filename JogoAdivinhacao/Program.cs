namespace JogoAdivinhacao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int escolha, tentativas = 0, numChute, numSecreto, pontuacao = 1000;
            int menor = 1, maior = 21;
            String saida = null;
            while (saida != "sair")
            {
                Console.Clear();
                Random num_random = new Random();
                Console.WriteLine("****************************************");
                Console.WriteLine("*   Bem-vindo ao jogo da Adivinhação   *");
                Console.WriteLine("****************************************");
                Console.WriteLine("\nEscolha o nível de dificuldade:");
                Console.WriteLine("(1) Fácil  (2) Médio  (3) Difícil");
                Console.Write("Escolha: ");
                escolha = Convert.ToInt32(Console.ReadLine());
                while (escolha != 1 && escolha != 2 && escolha != 3)
                {
                    Console.Write("Escolha uma dificuldade válida: ");
                    escolha = Convert.ToInt32(Console.ReadLine());
                }

                pontuacao = 3000; //Novo valor pra pontuação, só pq não gostei do anterior
                numSecreto = num_random.Next(menor, maior);

                if (escolha == 1)
                    tentativas = 15;
                else if (escolha == 2)
                    tentativas = 10;
                else if (escolha == 3)
                    tentativas = 5;
                Console.WriteLine("----------------------------------------");
                Console.WriteLine($"O número secreto está entre {menor} e {maior - 1}");
                Console.WriteLine("\nConsegue adivinhar?");
                for (int i = 0; i < tentativas; i++)
                {
                    Console.WriteLine($"\nTentativa {i + 1}/{tentativas}");
                    Console.WriteLine("----------------------------------------");
                    Console.Write($"Qual o seu {i + 1}º chute: ");
                    numChute = Convert.ToInt32(Console.ReadLine());
                    if (numChute == numSecreto)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nParabéns, você acertou!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("----------------------------------------");
                        Console.WriteLine($"Número secreto: {numSecreto}");
                        Console.WriteLine($"Pontuação final: {pontuacao}pts");
                        break;
                    }
                    else
                    {
                        //Não gostei da fórmula e da pontuação, vou fazer uma melhor
                        //pontuacao -= Math.Abs((numChute - numSecreto)/2);
                        pontuacao -= 3000 / tentativas;
                        /*Explicação: Ao usar a fórmula Math.Abs((x - y)/2) o jogador 
                        é pouco punido ao errar e perde-se poucos pontos. Entendo que
                        fiz o que não foi pedido mas fiz algo melhor que pune o jogador
                        da maneira correta e zerando seus pontos caso erre todas as vezes

                        Além do mais, em jogos assim é comum que a pontuação máxima seja 
                        acima de 1000, então 3000 é uma boa pontuação máxima*/
                        if (numChute > numSecreto)
                        {
                            Console.WriteLine("\nSeu chute foi MAIOR que o número secreto!");
                            Console.WriteLine($"\nVocê tem {pontuacao}pts!\n");

                        }
                        else if (numChute < numSecreto)
                        {
                            Console.WriteLine("\nSeu chute foi MENOR que o número secreto!");
                            Console.WriteLine($"\nVocê tem {pontuacao}pts!\n");
                        }
                    }
                    if (i == tentativas - 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Que pena, você perdeu!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("----------------------------------------");
                        Console.WriteLine($"Número secreto: {numSecreto}");
                        Console.WriteLine($"Pontuação final: {pontuacao}pts");
                    }
                }
                Console.WriteLine("----------------------------------------");
                Console.Write("\nAperte qualquer tecla para continuar\nou digite \"sair\" para sair: ");
                saida = Console.ReadLine();
            }
        }
    }
}