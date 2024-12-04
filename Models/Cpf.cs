namespace ValdadorCpfCnpj.Models;

public class Cpf
{
    public Cpf(string numberCpf)
    {
        NumberCpf = numberCpf;
    }

    public string NumberCpf { get; set; }
    public void Check()
    {

        string digitosDeVerificacao = NumberCpf.Substring(9, 2);
        int multiplicador = 10;
        int startOfRange = 0;
        int endOfrange = 9;

        foreach (char digitoVerificador in digitosDeVerificacao)
        {
            int calculoDosDigitos = 0;

            foreach (char digito in NumberCpf.Substring(startOfRange, endOfrange))
            {

                int digitoParaInt = digito - '0';
                calculoDosDigitos += digitoParaInt * multiplicador;
                --multiplicador;

            }

            int resultadoDivisao = calculoDosDigitos % 11;
            int digitoVerificado = 11 - resultadoDivisao;

            if (digitoVerificado >= 10)
            {
                digitoVerificado = 0;
            }

            if (digitoVerificado != digitoVerificador - '0')
            {
                Console.WriteLine("Cpf Inválido");
                return;
            }

            multiplicador = 11;
            startOfRange = 9;
            endOfrange = 2;

        }

        Console.WriteLine("Cpf Válido");

    }

}