namespace ValdadorCpfCnpj.Models;

public class Cnpj
{
    public Cnpj(string numberCnpj)
    {
        NumberCnpj = numberCnpj;
    }

    public string NumberCnpj { get; set; }
    
    public void Check()
    {

        string digitosDeVerificacao = NumberCnpj.Substring(12, 2);
        int multiplicador = 5;
        int startOfRange = 0;
        int endOfrange = 4;
        bool checkSecondDigit = false;

        foreach (char digitoVerificador in digitosDeVerificacao)
        {
            int calculoDosDigitos = 0;
            foreach (char digito in NumberCnpj.Substring(startOfRange, endOfrange))
            {
                int cnpjDigit = digito - '0';
                calculoDosDigitos += cnpjDigit * multiplicador;
                --multiplicador;
            }

            multiplicador = 9;
            if (!checkSecondDigit)
            {
                startOfRange = 4;
                endOfrange = 8;
            } 
            else
            {
                startOfRange = 5;
                endOfrange = 8;
            }


            foreach (char digito in NumberCnpj.Substring(startOfRange, endOfrange))
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

            if (digitoVerificado != digitoVerificador - '0' )
            {
                Console.WriteLine("Cnpj Inválido");
                return;
            }

            multiplicador = 6;
            startOfRange = 0;
            endOfrange = 5;
            checkSecondDigit = true;

        }
        
        Console.WriteLine("Cnpj Válido");

    }

}