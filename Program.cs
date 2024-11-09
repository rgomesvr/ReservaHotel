using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Pessoa> hospedes = new List<Pessoa>
        {
            new Pessoa("João", "Silva"),
            new Pessoa("Maria", "Oliveira"),
            new Pessoa("Carlos", "Silveira"),
        };

        Suite suite = new Suite("Luxo", 3, 150.0m);

        Reserva reserva = new Reserva(11);
        reserva.CadastrarSuite(suite);
        reserva.CadastrarHospedes(hospedes);

        Console.WriteLine($"Quantidade de Hóspedes: {reserva.ObterQuantidadeHospedes()}");
        Console.WriteLine($"Valor Total da Reserva: {reserva.CalcularValorDiaria():C}");
    }
}

class Pessoa
{
    public string Nome { get; set; }
    public string Sobrenome { get; set; }

    public Pessoa(string nome, string sobrenome)
    {
        Nome = nome;
        Sobrenome = sobrenome;
    }
}

class Suite
{
    public string TipoSuite { get; set; }
    public int Capacidade { get; set; }
    public decimal ValorDiaria { get; set; }

    public Suite(string tipoSuite, int capacidade, decimal valorDiaria)
    {
        TipoSuite = tipoSuite;
        Capacidade = capacidade;
        ValorDiaria = valorDiaria;
    }
}

class Reserva
{
    private List<Pessoa> Hospedes { get; set; }
    private Suite Suite { get; set; }
    private int DiasReservados { get; set; }

    public Reserva(int diasReservados)
    {
        DiasReservados = diasReservados;
        Hospedes = new List<Pessoa>();
    }

    public void CadastrarHospedes(List<Pessoa> hospedes)
    {
        if (hospedes.Count <= Suite.Capacidade)
        {
            Hospedes = hospedes;
        }
        else
        {
            throw new Exception("Número de hóspedes excede a capacidade da suíte.");
        }
    }

    public void CadastrarSuite(Suite suite)
    {
        Suite = suite;
    }

    public int ObterQuantidadeHospedes()
    {
        return Hospedes.Count;
    }

    public decimal CalcularValorDiaria()
    {
        decimal valorTotal = DiasReservados * Suite.ValorDiaria;

        if (DiasReservados > 10)
        {
            valorTotal *= 0.9m;
        }

        return valorTotal;
    }
}
