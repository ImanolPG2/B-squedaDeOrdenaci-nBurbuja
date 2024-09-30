using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n--- Menú Principal ---");
            Console.WriteLine("1. Generar y ordenar un nuevo arreglo");
            Console.WriteLine("2. Buscar un número en el arreglo actual");
            Console.WriteLine("X. Salir del programa");
            Console.Write("Seleccione una opción: ");

            string option = Console.ReadLine().ToUpper();

            if (option == "X")
            {
                Console.WriteLine("Gracias por usar el programa. ¡Hasta luego!");
                break;
            }

            switch (option)
            {
                case "1":
                    GenerateAndSortArray();
                    break;
                case "2":
                    SearchInArray();
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
                    break;
            }
        }
    }

    static int[] currentArray = null;

    static void GenerateAndSortArray()
    {
        Console.Write("Ingrese el tamaño del arreglo: ");
        if (!int.TryParse(Console.ReadLine(), out int size) || size <= 0)
        {
            Console.WriteLine("Tamaño no válido. Por favor, ingrese un número entero positivo.");
            return;
        }

        currentArray = GenerateRandomArray(size);

        Console.WriteLine("Arreglo original:");
        PrintArray(currentArray);

        BubbleSortRecursive(currentArray, currentArray.Length);

        Console.WriteLine("\nArreglo ordenado:");
        PrintArray(currentArray);
    }

    static void SearchInArray()
    {
        if (currentArray == null || currentArray.Length == 0)
        {
            Console.WriteLine("No hay un arreglo generado. Por favor, genere un arreglo primero.");
            return;
        }

        Console.Write("Ingrese el número a buscar: ");
        if (!int.TryParse(Console.ReadLine(), out int searchNumber))
        {
            Console.WriteLine("Número no válido. Por favor, ingrese un número entero.");
            return;
        }

        int position = SequentialSearch(currentArray, searchNumber);

        if (position != -1)
        {
            Console.WriteLine($"El número {searchNumber} se encuentra en la posición {position + 1}.");
        }
        else
        {
            Console.WriteLine($"El número {searchNumber} no se encuentra en el arreglo.");
        }
    }

    static int[] GenerateRandomArray(int size)
    {
        Random random = new Random();
        int[] array = new int[size];

        for (int i = 0; i < size; i++)
        {
            array[i] = random.Next(1, 101);
        }

        return array;
    }

    static void BubbleSortRecursive(int[] arr, int n)
    {
        if (n == 1)
            return;

        for (int i = 0; i < n - 1; i++)
        {
            if (arr[i] > arr[i + 1])
            {
                int temp = arr[i];
                arr[i] = arr[i + 1];
                arr[i + 1] = temp;
            }
        }

        BubbleSortRecursive(arr, n - 1);
    }

    static int SequentialSearch(int[] arr, int target)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == target)
            {
                return i;
            }
        }
        return -1;
    }

    static void PrintArray(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write($"{arr[i]} ");
        }
        Console.WriteLine();
    }
}