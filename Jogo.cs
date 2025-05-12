using System;
using System.Collections.Generic;

public class Jogo
{
    private List<Carta> cartas;
    private Random random = new Random();
    private int vitorias = 0;
    private int derrotas = 0;
    private int empates = 0;

    public Jogo()
    {
        cartas = new List<Carta>
        {
            new Carta { Nome = "Leão", Forca = 90, Velocidade = 70, Inteligencia = 40 },
            new Carta { Nome = "Tigre", Forca = 85, Velocidade = 75, Inteligencia = 45 },
            new Carta { Nome = "Elefante", Forca = 95, Velocidade = 40, Inteligencia = 60 },
            new Carta { Nome = "Guepardo", Forca = 60, Velocidade = 100, Inteligencia = 50 },
            new Carta { Nome = "Coruja", Forca = 30, Velocidade = 60, Inteligencia = 90 }
        };
    }

    public void Jogar()
    {
        bool continuar = true;

        while (continuar)
        {
            Carta jogadorCarta = cartas[random.Next(cartas.Count)];
            Carta computadorCarta = cartas[random.Next(cartas.Count)];

            Console.WriteLine("\nSua carta:");
            jogadorCarta.Mostrar();

            Console.WriteLine("\nEscolha um atributo para competir:");
            Console.WriteLine("1 - Força");
            Console.WriteLine("2 - Velocidade");
            Console.WriteLine("3 - Inteligência");
            Console.Write("Opção: ");
            string opcao = Console.ReadLine();

            int valorJogador = 0;
            int valorComputador = 0;

            switch (opcao)
            {
                case "1":
                    valorJogador = jogadorCarta.Forca;
                    valorComputador = computadorCarta.Forca;
                    break;
                case "2":
                    valorJogador = jogadorCarta.Velocidade;
                    valorComputador = computadorCarta.Velocidade;
                    break;
                case "3":
                    valorJogador = jogadorCarta.Inteligencia;
                    valorComputador = computadorCarta.Inteligencia;
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    continue;
            }

            Console.WriteLine("\nCarta do computador:");
            computadorCarta.Mostrar();

            Console.WriteLine("\nResultado da rodada:");
            if (valorJogador > valorComputador)
            {
                Console.WriteLine("Você venceu!");
                vitorias++;
            }
            else if (valorJogador < valorComputador)
            {
                Console.WriteLine("Você perdeu!");
                derrotas++;
            }
            else
            {
                Console.WriteLine("Empate!");
                empates++;
            }

            Console.Write("\nDeseja jogar novamente? (s/n): ");
            continuar = Console.ReadLine().ToLower() == "s";
        }

        Console.WriteLine($"\nPlacar final: {vitorias} Vitórias, {derrotas} Derrotas, {empates} Empates");
    }
}
