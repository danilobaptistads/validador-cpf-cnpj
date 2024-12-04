using ValdadorCpfCnpj.Models;

string continuar = "";

do 
{

    Console.Write("Digite um CPF ou CNPJ: ");
    string numeroCadastral;
    numeroCadastral = Console.ReadLine().Replace("-","").Replace("/","").Replace(".","");
    
    switch (numeroCadastral.Length)
    {

        case 11 :
            var cpf = new Cpf(numeroCadastral);
            cpf.Check();
            break;
        case 14 :
            var cnpj = new Cnpj(numeroCadastral);
            cnpj.Check();
            break;
        default:
            Console.WriteLine("Cpf ou Cnpj inválido");
            break;

    }

    Thread.Sleep(1000);
    Console.WriteLine("\nDeseja fazer uma nova verificação?");
    Console.Write("Tecle [Enter] para Continuar ou digite [S] para sair: ");
    continuar  = Console.ReadLine().ToLower();
    
    Console.Clear();

}  while(continuar != "n");

Console.WriteLine("Até logo...");
Thread.Sleep(1000);




