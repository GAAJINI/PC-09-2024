using System;
using System.Collections.Generic;

namespace Sistema_Bancario
{
    // Clases de Transacciones
    class Cliente
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Numero { get; set; }

        public Cliente(string nombre, string direccion, int numero)
        {
            Nombre = nombre;
            Direccion = direccion;
            Numero = numero;
        }
    }

    class Restaurante
    {
        public string Sede { get; set; }
        public string Menu { get; set; }

        public Restaurante(string sede, string menu)
        {
            Sede = sede;
            Menu = menu;
        }
    }

    class Pedido
    {
        public string FormaDePago { get; set; }
        public string TipoComida { get; set; }
        public double Total { get; set; }
        public DateTime Fecha { get; set; }

        public Pedido(string formaDePago, string tipoComida, double total)
        {
            FormaDePago = formaDePago;
            TipoComida = tipoComida;
            Total = total;
            Fecha = DateTime.Now;
        }
    }

    class Program
    {
        // Aqui se invocaron a las 3 listas
        static List<Cliente> AgregarClientes = new List<Cliente>();
        static List<Restaurante> funciones3usuarios = new List<Restaurante>();
        static List<Pedido> pedidos = new List<Pedido>();

        // Declaracion de Variables
        private static string Nombre = "";
        private static string Direccion = "";
        private static int Numeros = 0;
        private static bool mostrarMenu;

        static void Main(string[] args)
        {
            IngresoDatos();
            Menu();
        }

        // INGRESO DE DATOS
        static void IngresoDatos()
        {
            Console.WriteLine("DATOS DEL USUARIO\n");

            Console.WriteLine("Ingrese Su Nombre Completo");
            Nombre = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("Ingrese su Direccion: ");
            Direccion = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("Ingrese su Numero: ");
            Numeros = int.Parse(Console.ReadLine());
            Console.WriteLine("");

            AgregarClientes.Add(new Cliente(Nombre, Direccion, Numeros));
        }

        // MENU
        static void Menu()
        {
            mostrarMenu = true;
            while (mostrarMenu)
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("MENU DE USUARIO\n");
                Console.WriteLine("1. VER NOMBRE DEL CLIENTE");
                Console.WriteLine("2. COMPRAR");
                Console.WriteLine("3. SALIR");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("INGRESE LA OPCION QUE DESEA EFECTUAR");

                if (!int.TryParse(Console.ReadLine(), out int numero))
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                    continue;
                }

                switch (numero)
                {
                    case 1:
                        InfoCuenta();
                        break;
                    case 2:
                        Comprar();
                        break;
                    case 3:
                        Console.WriteLine("GRACIAS POR SU PREFERENCIA!");
                        mostrarMenu = false;
                        break;
                    default:
                        Console.WriteLine("La opción seleccionada no es válida.");
                        break;
                }
            }
        }

        public static void InfoCuenta()
        {
            foreach (var cliente in AgregarClientes)
            {
                Console.WriteLine($"Nombre: {cliente.Nombre}, Dirección: {cliente.Direccion}, Número: {cliente.Numero}");
            }
            Console.ReadKey();
        }

        public static void Comprar()
        {
            Console.WriteLine("Indique la forma de pago TARJETA O EFECTIVO: ");
            string pago = Console.ReadLine();

            double total = 0;
            bool seguirComprando = true;

            while (seguirComprando)
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("MENU DE ARTICULOS");
                Console.WriteLine("1- PIZZA - Q 60.00");
                Console.WriteLine("2- HAMBURGUESA DOBLE CARNE - Q 55.45");
                Console.WriteLine("3- DESAYUNO TRADICIONAL - Q 49.99");
                Console.WriteLine("4- LASAGNA - Q. 60.00");
                Console.WriteLine("5- MENU FAMILIA - Q 123.59");
                Console.WriteLine("6- VER TOTAL");
                Console.WriteLine("7- VER HISTORIAL DE LA COMPRA");
                Console.WriteLine("8- TERMINAR PEDIDO");
                Console.WriteLine("INGRESE LA OPCION QUE DESEA EFECTUAR");
                Console.WriteLine("-------------------------------------");

                if (!int.TryParse(Console.ReadLine(), out int numeroS))
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                    continue;
                }

                string tComida = "";
                double precio = 0;

                switch (numeroS)
                {
                    case 1:
                        tComida = "Pizza";
                        precio = 60;
                        Console.ReadKey();
                        break;
                    case 2:
                        tComida = "Hamburguesa Doble Carne";
                        precio = 55.45;
                        Console.ReadKey();
                        break;
                    case 3:
                        tComida = "Desayuno Tradicional";
                        precio = 49.99;
                        Console.ReadKey();
                        break;
                    case 4:
                        tComida = "Lasagna";
                        precio = 60;
                        Console.ReadKey();
                        break;
                    case 5:
                        tComida = "Menu Familiar";
                        precio = 123.59;
                        Console.ReadKey();
                        break;
                    case 6:
                        Console.WriteLine($"PRECIO TOTAL: Q{total}");
                        Console.ReadKey();
                        break;
                    case 7:
                        foreach (var pedir in pedidos)
                        {
                            Console.WriteLine($"Tipo de Pago: {pedir.FormaDePago}, Comida: {pedir.TipoComida}, Precio Total: {pedir.Total}, Fecha: {pedir.Fecha}");
                        }
                        Console.ReadKey();
                        break;
                    case 8:
                        seguirComprando = false;
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("La opción seleccionada no es válida.");
                        Console.WriteLine($"PRECIO TOTAL: Q{total}");
                        Console.ReadKey();
                        break;
                }

                pedidos.Add(new Pedido(pago, tComida, precio));
                total += precio;
                Console.WriteLine($"Se ha agregado {tComida} al pedido por Q{precio}");

                Console.WriteLine("Desea Comprar Otro Producto? Si=1 / No=2");

                if (int.TryParse(Console.ReadLine(), out int opcion) && opcion == 2)
                {
                    seguirComprando = false;
                }
            }
        }
    }
}
