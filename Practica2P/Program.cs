using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Practica2P
{
    struct Mascota 
    {
        public int codigo;
        public string nombre;
        public string raza;
        public double años;
        public char pelaje;

        public Mascota(int codigo, string nombre, string raza, double años, char pelaje)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.raza = raza;
            this.años = años;
            this.pelaje = pelaje;
        }
    }
    internal class Program
    {
        static List <Mascota> mascotas = new List <Mascota> ();

        static string[] meses = {"enero", "febrero", "marzo","abril", "junio", "julio", "mayo", "agosto", "septiembre", "octubre", "noviembre", "diciembre"};

        static string[] razasComunes = {"caniche", "salchicha", "golden", "policia", "galgo"};
        
        static int[,] visitasVeterinarias = new int[24, 12];

        static int codigo = 1;
        

        static void Main(string[] args)
        {
            mascotas.Add(new Mascota(30, "Luke", "caniche", 10, 'C'));
            mascotas.Add(new Mascota(30, "Chimuelo", "salchicha", 20, 'M'));
            mascotas.Add(new Mascota(30, "Lolo", "caniche", 7, 'C'));
            mascotas.Add(new Mascota(30, "Leila", "golden", 2, 'L'));

            string opcion;
            do
            {
                //Menu principal 
                Console.WriteLine("1. Cargar mascotas");
                Console.WriteLine("2. Lista de mascotas");
                Console.WriteLine("3. Busqueda de mascota por nombre");
                Console.WriteLine("4. Ordenar mascota por nombre");
                Console.WriteLine("5. Mostrar mascotas por tipo de pelaje");
                Console.WriteLine("6. Cargar visita veterinaria");
                Console.WriteLine("7. Salir");

                opcion = Console.ReadLine();
                switch (opcion) 
                {
                    case "1":
                        cargarMascotas();
                        break;
                    case "2":
                        listarMascotas();
                        break;
                    case "3":
                        buscarNombre();
                        break;
                    case "4":
                        ordenarNombre();
                        break;
                    case "5":
                        mostrarPorPelaje();
                        break;
                    case "6":
                        cargarVisita();
                        mostrarMatriz();
                        break;
                    case "7":
                        Console.WriteLine("Saliendo");
                        break;
                    default:
                        Console.WriteLine("Opcion Incorrecta, vuelva a ingresar otra opcion");
                        break;
                }
            } while (opcion != "7");
        }
        static void cargarMascotas()
        {

            string opcion;
            do
            {
                Console.WriteLine("Desea ingresar una nueva mascota?(S/N)");
                opcion = Console.ReadLine();
                if (opcion == "S") 
                {
                    Mascota nuevaMascota;

                    nuevaMascota.codigo = codigo;
                    codigo++;

                    Console.Write("Ingrese nombre de la mascota: ");
                    nuevaMascota.nombre = Console.ReadLine();

                    Console.WriteLine("Ingrese la raza(1-5): ");
                    for (int i = 0; i < razasComunes.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}. {razasComunes[i]}");
                    }
                    int opcionElegida = int.Parse(Console.ReadLine());
                    nuevaMascota.raza = razasComunes[opcionElegida - 1];

                    Console.Write("Ingrese edad: ");
                    nuevaMascota.años = double.Parse(Console.ReadLine());

                    Console.Write("Ingrese pelaje('C-corto, M-medio, L-largo): ");
                    nuevaMascota.pelaje = char.ToUpper(Console.ReadKey().KeyChar);
                    Console.WriteLine();

                    mascotas.Add(nuevaMascota);
                }
            }
            while (opcion != "N");
            
        }

        static void listarMascotas()
        {
            foreach(var mascota in mascotas) 
            {
                Console.WriteLine($"Codigo: {mascota.codigo}  Nombre: {mascota.nombre}  Raza: {mascota.raza}  Años: {mascota.años}   Pelaje: {mascota.pelaje} ");
            }
        }

        static void buscarNombre()
        {
            Console.WriteLine("Ingrese nombre que desea buscar");
            string nombreIngresado = Console.ReadLine();
            foreach (var mascota in mascotas) 
            {    
                if (nombreIngresado == mascota.nombre) 
                {
                    Console.WriteLine("Nombre encontrado!");
                }
            }
        }

        static void ordenarNombre() 
        {
            
            for (int i = 0; i < mascotas.Count - 1; i++) 
            {
                for (int j = 0; j < mascotas.Count -i - 1 ; j++)
                {
                    if (string.Compare(mascotas[j].nombre, mascotas[j + 1].nombre, StringComparison.OrdinalIgnoreCase) > 0)
                    {
                        Mascota tempp = mascotas[j];
                        mascotas[j] = mascotas[j + 1];
                        mascotas[j + 1] = tempp;
                    }
                }
            }
        }

        static void mostrarPorPelaje() 
        {
            Console.WriteLine("Ingrese tipo de pelaje");
            char pelajeElegido = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();
            foreach (var mascota in mascotas) 
            {
                if (mascota.pelaje == pelajeElegido) 
                {
                    Console.WriteLine($"{mascota.nombre}");
                }
            }
        }

        static void cargarVisita() 
        {
            for(int i = 0; i < mascotas.Count ; i++)//Cantidad de mascotas 
            {
                Console.WriteLine($"{mascotas[i].nombre}");
                for (int j = 0; j < 12; j++)//mes
                {
                    Console.Write($"ingrese cantidad de visitas en {meses[j]}: ");
                    visitasVeterinarias[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }

        static void mostrarMatriz() 
        {
            for (int i = 0; i < mascotas.Count; i++) 
            {
                for (int j = 0; j < 12; j++) 
                {
                    Console.Write($"{visitasVeterinarias[i,j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
