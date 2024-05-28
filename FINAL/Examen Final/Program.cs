using System;
using System.Collections.Generic;

namespace Gimnasio
{
    // Clases de Transacciones
    class Clientes
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string TipoMembresia { get; set; }

        public Clientes(string nombre, int edad, string tipomembresia)
        {
            Nombre = nombre;
            Edad = edad;
            TipoMembresia = tipomembresia;
        }
    }

    class Sedes
    {
        public string Direccion { get; set; }
        public string NombreLugar { get; set; }

        public Sedes(string direccion, string nombrelugar)
        {
            Direccion = direccion;
            NombreLugar = nombrelugar;
        }
    }

    class Catalogo
    {
        public string NombreCurso { get; set; }
        public int Precio { get; set; }

        public Catalogo(string nombreCurso, int precio)
        {
            NombreCurso = nombreCurso;
            Precio = precio;
        }
    }

    class Program
    {
        // Aqui se invocaron a las 3 listas
        static List<Clientes> AgregarClientes = new List<Clientes>();
        static List<Catalogo> catalogo = new List<Catalogo>();
        static List<Sedes> sedes = new List<Sedes>();

        // Declaracion de Variables
        private static string Nombre = "";
        private static string Membresia = "";
        private static int Edad = 0;
        private static bool mostrarMenu;

        static void Main(string[] args)
        {
            // Inicializa el catálogo y las sedes

            catalogo.Add(new Catalogo("Curso de Danza", 190));
            catalogo.Add(new Catalogo("Curso de Boxeo", 300));
            catalogo.Add(new Catalogo("Curso de Levantamiento de Pesas", 300));
            catalogo.Add(new Catalogo("Coach Personal", 200));

            sedes.Add(new Sedes("Modulo 18-13 A Zona 21", "Gimnasio Sede 1"));
            sedes.Add(new Sedes("14 Calle zona 5", "Gimnasio Sede 2"));
            sedes.Add(new Sedes("2 Avenida zona 10", "Gimnasio Sede 3"));

            IngresoDatos();
            Menu();
        }

        // INGRESO DE DATOS
            static void IngresoDatos()
            {
            string Nombre;
            int Edad;
            string Membresia;

            Console.WriteLine("DATOS DEL USUARIO\n");

            Console.WriteLine("Ingrese Su Nombre Completo");
            Nombre = Console.ReadLine();
            Console.WriteLine("");

            while (true)
            {
                Console.WriteLine("Ingrese su Edad: ");
                if (int.TryParse(Console.ReadLine(), out Edad) && Edad > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese una edad válida.");
                }
                Console.WriteLine("");
            }

            while (true)
            {
                Console.WriteLine("Ingrese su Tipo de Membresia Anual/Mensual: ");
                Membresia = Console.ReadLine();
                if (Membresia.Equals("Anual") || Membresia.Equals("Mensual"))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un tipo de membresía válido (Anual o Mensual).");
                }
                Console.WriteLine("");
            }

            AgregarClientes.Add(new Clientes(Nombre, Edad, Membresia));
            AgregarClientes.Add(new Clientes("Javier Muñoz", 32, "Anual"));
            AgregarClientes.Add(new Clientes("Alejandro", 32, "Mensual"));
            }

    

            // MENU
            static void Menu()
            {
            mostrarMenu = true;
            while (mostrarMenu)
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("MENU DE USUARIO\n");
                Console.WriteLine("1. Ver Clientes");
                Console.WriteLine("2. Ver Catalogo");
                Console.WriteLine("3. Ver Sedes");
                Console.WriteLine("4. SALIR");
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
                        InfoClientes();
                        break;
                    case 2:
                        VerCatalogo();
                        break;
                    case 3:
                        VerSedes();
                        break;
                    case 4:
                        Console.WriteLine("GRACIAS POR SU PREFERENCIA!");
                        mostrarMenu = false;
                        break;
                    default:
                        Console.WriteLine("La opción seleccionada no es válida.");
                        break;
                }
            }
        }

        public static void InfoClientes()
        {
            foreach (var cliente in AgregarClientes)
            {
                Console.WriteLine($"Nombre: {cliente.Nombre}, Edad: {cliente.Edad}, Membresia: {cliente.TipoMembresia}");
            }
            Console.ReadKey();
        }

        public static void VerCatalogo()
        {
            foreach (var catalog in catalogo)
            {
                Console.WriteLine($"Nombre del Curso: {catalog.NombreCurso}, Precio: {catalog.Precio}");
            }
            Console.ReadKey();
        }

        public static void VerSedes()
        {
            foreach (var sede in sedes)
            {
                Console.WriteLine($"Nombre del Lugar: {sede.NombreLugar}, Dirección: {sede.Direccion}");
            }
            Console.ReadKey();
        }
    }
}
