class Program
{
    static void Main(string[] args)
    {
        string palavra;
        int acertos = 0;
        int erros = 0;

        Console.WriteLine("--Forca--");
        Console.WriteLine("Digite uma Palavra: ");
        palavra = Console.ReadLine();

        char[] letra = palavra.ToCharArray();
        char[] forca = palavra.ToCharArray();
        char[] difirado = palavra.ToCharArray();

        char digitios;

        for(int i = 0; i < palavra.Length; i++)
        {
            if (letra[i] == ' ')
                forca[i] = ' ';
            else
                forca[i] = '_';
        }
        Console.Clear();

        do
        {
            Console.WriteLine("--Forca--");

            Console.Write("_________\n " +
                          "|      | \n " +
                          "|      | \n " +
                          "| \n " +
                          "| \n " +
                          "| \n " +
                          "| \n " +
                          "| \n\n");

            Console.SetCursorPosition(2, Console.CursorTop - 2);

            for (int i = 0; i < palavra.Length; i++)
            {
                Console.WriteLine(forca[i] + " ");
            }
            Console.WriteLine("Digite uma Letra: ");
            digitios = Convert.ToChar(Console.ReadLine());

            for (int i = 0; i < palavra.Length; i++)
            {
                if (digitios == forca[i])
                {
                    Console.WriteLine("Letra ja digitada!");
                    Console.WriteLine("--Press Enter--");
                    Console.ReadKey();
                }
                else if (digitios == letra[i])
                {
                    forca[i] = digitios;
                    acertos++;
                }
            }

            Console.Clear();
        } while (acertos < palavra.Length);

        Console.Clear();

        Console.WriteLine("--Forca--");
        Console.WriteLine("Voce venceu!!");
        Console.ReadKey();

    }
}