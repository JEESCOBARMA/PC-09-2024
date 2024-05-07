using System;
// Codigo realizado por Johan Escobar - 1309924
// Para parcial II de Pensamiento Computacional
class Program
{
    static void Main(string[] args)
    {
        string[] nombres = new string[10];
        int[] notas = new int[10];

        for (int i = 0; i < 10; i++)
        {
            Console.Write("Ingrese el nombre del estudiante " + (i + 1) + ": ");
            nombres[i] = Console.ReadLine();

            Console.Write("Ingrese la nota del estudiante " + (i + 1) + ": ");
            while (!int.TryParse(Console.ReadLine(), out notas[i]) || notas[i] < 0 || notas[i] > 100)
            {
                Console.Write("Por favor, ingrese un número válido entre 0 y 100: ");
            }
        }

        int opcion = 0;
        do
        {
            Console.WriteLine("1 Mostrar estudiantes que aprobaron el curso.");
            Console.WriteLine("2 Mostrar estudiantes que NO aprobaron el curso.");
            Console.WriteLine("3 Mostrar el promedio de notas del grupo.");
            Console.WriteLine("4 Salir del programa.");
            Console.Write("Seleccione una opción: ");

            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 4)
            {
                Console.Write("Por favor, seleccione una opción válida: ");
            }

            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Estudiantes que aprobaron el curso:");
                    for (int i = 0; i < 10; i++)
                    {
                        if (notas[i] >= 65)
                        {
                            Console.WriteLine(nombres[i] + " - " + notas[i]);
                        }
                    }
                    break;
                case 2:
                    Console.WriteLine("Estudiantes que NO aprobaron el curso:");
                    for (int i = 0; i < 10; i++)
                    {
                        if (notas[i] < 65)
                        {
                            Console.WriteLine(nombres[i] + " - " + notas[i]);
                        }
                    }
                    break;
                case 3:
                    int suma = 0;
                    for (int i = 0; i < 10; i++)
                    {
                        suma += notas[i];
                    }
                    Console.WriteLine("El promedio de notas del grupo es: " + suma / 10.0);
                    break;
            }
        } while (opcion != 4);
    }
}
