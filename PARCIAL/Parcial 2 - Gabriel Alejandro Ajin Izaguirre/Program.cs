namespace Parcial2_GabrielAjin
{
    class Program
    {
        static void Main(string[] args)
        {
            menu();
        }


        static void menu()
        {

            string[] nombres = new string[10];
            int[] notas = new int[10];
            int suma = 0;
            Console.WriteLine("Ingrese 10 nombres con sus respectivas 10 notas:");
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"{i + 1}) Ingrese el nombre {i + 1}: ");
                nombres[i] = Console.ReadLine();
                Console.Write($"Ingrese la nota de la persona {i + 1}: ");
                notas[i] = Convert.ToInt32(Console.ReadLine());
                while (notas[i] < 0 || notas[i] > 100)
                {
                    Console.Write("El datos que ingreso no es valido para la nota:");
                    notas[i] = Convert.ToInt32(Console.ReadLine());
                }
                suma += notas[i];
            }

            bool mostrarMenu = true;
            while (mostrarMenu)
            {
                Console.WriteLine("");
                Console.WriteLine("MENU DE USUARIO");
                Console.WriteLine("1. NOMBRE Y NOTAS DE QUIENES APROBARON");
                Console.WriteLine("2. NOMBRE Y NOTAS DE QUIENES NO APROBARON");
                Console.WriteLine("3. NOTA PROMEDIO");
                Console.WriteLine("4. SALIR");
                Console.WriteLine("");
                Console.WriteLine("INGRESE LA OPCION QUE DESEA EFECTUAR");
                int opcion = int.Parse(Console.ReadLine());
                int notamin = 65;
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("NOMBRE DE QUIENES SI APROBARON");

                        for (int i = 0; i < notas.Length; i++)
                        {
                            if (notas[i] >= notamin)
                            {
                                Console.WriteLine($"{nombres[i]} aprobro con: {notas[i]}");
                            }
                        }
                        Console.ReadKey();
                        break;

                    case 2:
                        Console.WriteLine("NOMBRES DE QUIENES NO APROBARON");

                        for (int i = 0; i < notas.Length; i++)
                        {
                            if (notas[i] <= notamin)
                            {
                                Console.WriteLine($"{nombres[i]} reprobo con: {notas[i]}");
                            }
                        }
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("NOTA PROMEDIO");

                        double promedio = (double)suma / notas.Length;
                        Console.WriteLine("El promedio es de: " + promedio);

                        Console.ReadKey();
                        break;
                    case 4:
                        Console.WriteLine("SALIR");
                        Environment.Exit(0);
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("La opción seleccionada no es válida.");
                        break;
                }
            }
        }
    }
}
