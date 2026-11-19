int opcion;

do
{
    Console.Clear();
    Console.WriteLine("=========================================");
    Console.WriteLine("   MENÚ DE EJERCICIOS - DELEGADOS        ");
    Console.WriteLine("=========================================");
    Console.WriteLine("1. Multiplicar dos números");
    Console.WriteLine("2. Verificar palíndromo");
    Console.WriteLine("3. Convertir Celsius a Fahrenheit");
    Console.WriteLine("4. Es mayor que diez");
    Console.WriteLine("5. Comparar longitud de cadenas");
    Console.WriteLine("6. Calcular factorial");
    Console.WriteLine("7. Contar caracteres");
    Console.WriteLine("8. Procesar número (Par o Impar)");
    Console.WriteLine("9. Filtrar productos en stock");
    Console.WriteLine("10. Filtrar empleados por edad");
    Console.WriteLine("11. Filtrar libros por categoría");
    Console.WriteLine("12. Filtrar vehículos antiguos");
    Console.WriteLine("0. Salir");
    Console.WriteLine("=========================================");
    Console.Write("Elige una opción: ");

    if (!int.TryParse(Console.ReadLine(), out opcion))
    {
        opcion = -1;
    }

    Console.WriteLine();

    switch (opcion)
    {
        case 1: Ejercicio1(); break;
        case 2: Ejercicio2(); break;
        case 3: Ejercicio3(); break;
        case 4: Ejercicio4(); break;
        case 5: Ejercicio5(); break;
        case 6: Ejercicio6(); break;
        case 7: Ejercicio7(); break;
        case 8: Ejercicio8(); break;
        case 9: Ejercicio9(); break;
        case 10: Ejercicio10(); break;
        case 11: Ejercicio11(); break;
        case 12: Ejercicio12(); break;
        case 0: Console.WriteLine("Saliendo del programa..."); break;
        default: Console.WriteLine("Opción no válida. Inténtalo de nuevo."); break;
    }

    if (opcion != 0)
    {
        Console.WriteLine("\nPulsa cualquier tecla para volver al menú...");
        Console.ReadKey();
    }

} while (opcion != 0);

void Ejercicio1()
{
    Multiplicar multiplicar = delegate (int a, int b)
    {
        return a * b;
    };

    Console.WriteLine($"4 * 3 = {multiplicar(4, 3)}");
    Console.WriteLine($"7 * 5 = {multiplicar(7, 5)}");
}

void Ejercicio2()
{
    VerificarPalindromo verificar = delegate (string texto)
    {
        char[] caracteres = texto.ToLower().ToCharArray();
        Array.Reverse(caracteres);
        string invertido = new string(caracteres);
        return texto.ToLower() == invertido;
    };

    Console.WriteLine($"'radar' es un palíndromo: {verificar("radar")}");
    Console.WriteLine($"'puerta' es un palíndromo: {verificar("puerta")}");
}

void Ejercicio3()
{
    ConvertirTemperatura convertir = delegate (double celsius)
    {
        return (celsius * 9 / 5) + 32;
    };

    Console.WriteLine($"0°C -> {convertir(0)}°F");
    Console.WriteLine($"30°C -> {convertir(30)}°F");
}

void Ejercicio4()
{
    EsMayorQueDiez esMayor = delegate (int numero)
    {
        return numero > 10;
    };

    Console.WriteLine($"8 es mayor que 10: {esMayor(8)}");
    Console.WriteLine($"15 es mayor que 10: {esMayor(15)}");
}

void Ejercicio5()
{
    CompararLongitud comparar = delegate (string s1, string s2)
    {
        return s1.Length == s2.Length;
    };

    Console.WriteLine($"Las palabras 'gato' y 'perro' tienen la misma longitud: {comparar("gato", "perro")}");
}

void Ejercicio6()
{
    CalcularFactorial factorial = delegate (int n)
    {
        int resultado = 1;
        for (int i = 2; i <= n; i++)
        {
            resultado *= i;
        }
        return resultado;
    };

    Console.WriteLine($"Factorial de 4 es {factorial(4)}");
    Console.WriteLine($"Factorial de 6 es {factorial(6)}");
}

void Ejercicio7()
{
    ContarCaracteres contar = delegate (string palabra)
    {
        return palabra.Length;
    };

    Console.WriteLine($"La palabra 'mundo' tiene {contar("mundo")} caracteres");
    Console.WriteLine($"La palabra 'programa' tiene {contar("programa")} caracteres");
}

void Ejercicio8()
{
    Operacion esPar = delegate (int n)
    {
        return n % 2 == 0;
    };

    ProcesarNumero(4, esPar);
    ProcesarNumero(7, esPar);
}

void ProcesarNumero(int numero, Operacion operacion)
{
    Console.WriteLine($"El número {numero} es par: {operacion(numero)}");
}

void Ejercicio9()
{
    List<Producto> productos = new()
    {
        new Producto { Nombre = "Televisor", Cantidad = 10 },
        new Producto { Nombre = "Ratón", Cantidad = 3 },
        new Producto { Nombre = "Refrigerador", Cantidad = 7 }
    };

    Filtro filtroStock = delegate (Producto p)
    {
        return p.Cantidad > 5;
    };

    MostrarProductosFiltrados(productos, filtroStock);
}

void MostrarProductosFiltrados(List<Producto> lista, Filtro filtro)
{
    Console.WriteLine("Productos con cantidad mayor a 5:");
    foreach (var p in lista)
    {
        if (filtro(p))
        {
            Console.WriteLine($"- {p.Nombre} (Cantidad: {p.Cantidad})");
        }
    }
}

void Ejercicio10()
{
    List<Empleado> empleados = new()
    {
        new Empleado { Nombre = "Ana", Edad = 35 },
        new Empleado { Nombre = "Carlos", Edad = 25 },
        new Empleado { Nombre = "Luis", Edad = 42 }
    };

    FiltroEmpleado filtroEdad = delegate (Empleado e)
    {
        return e.Edad > 30;
    };

    FiltrarEmpleados(empleados, filtroEdad);
}

void FiltrarEmpleados(List<Empleado> lista, FiltroEmpleado filtro)
{
    Console.WriteLine("Empleados mayores de 30 años:");
    foreach (var e in lista)
    {
        if (filtro(e))
        {
            Console.WriteLine($"- {e.Nombre} (Edad: {e.Edad})");
        }
    }
}

void Ejercicio11()
{
    List<Libro> libros = new()
    {
        new Libro { Titulo = "El Hobbit", Categoria = "Ficción" },
        new Libro { Titulo = "Breve historia del tiempo", Categoria = "Ciencia" },
        new Libro { Titulo = "Harry Potter", Categoria = "Ficción" }
    };

    FiltroLibros filtroFiccion = delegate (Libro l)
    {
        return l.Categoria == "Ficción";
    };

    MostrarLibrosPorCategoria(libros, filtroFiccion);
}

void MostrarLibrosPorCategoria(List<Libro> lista, FiltroLibros filtro)
{
    Console.WriteLine("Libros de la categoría Ficción:");
    foreach (var l in lista)
    {
        if (filtro(l))
        {
            Console.WriteLine($"- {l.Titulo}");
        }
    }
}

void Ejercicio12()
{
    List<Vehiculo> vehiculos = new()
    {
        new Vehiculo { Marca = "Toyota", Modelo = "Corolla", AnioFabricacion = 2005 },
        new Vehiculo { Marca = "Ford", Modelo = "Focus", AnioFabricacion = 2018 },
        new Vehiculo { Marca = "Honda", Modelo = "Civic", AnioFabricacion = 2008 }
    };

    FiltroVehiculo filtroAntiguos = delegate (Vehiculo v)
    {
        return v.AnioFabricacion < 2010;
    };

    MostrarVehiculosAntiguos(vehiculos, filtroAntiguos);
}

void MostrarVehiculosAntiguos(List<Vehiculo> lista, FiltroVehiculo filtro)
{
    Console.WriteLine("Vehículos fabricados antes de 2010:");
    foreach (var v in lista)
    {
        if (filtro(v))
        {
            Console.WriteLine($"- {v.Marca} {v.Modelo} ({v.AnioFabricacion})");
        }
    }
}

// Delegados y clases

delegate int Multiplicar(int a, int b);
delegate bool VerificarPalindromo(string cadena);
delegate double ConvertirTemperatura(double celsius);
delegate bool EsMayorQueDiez(int numero);
delegate bool CompararLongitud(string cadena1, string cadena2);
delegate int CalcularFactorial(int numero);
delegate int ContarCaracteres(string cadena);
delegate bool Operacion(int numero);
delegate bool Filtro(Producto producto);
delegate bool FiltroEmpleado(Empleado empleado);
delegate bool FiltroLibros(Libro libro);
delegate bool FiltroVehiculo(Vehiculo vehiculo);

class Producto
{
    public string Nombre { get; set; } = "";
    public int Cantidad { get; set; }
}

class Empleado
{
    public string Nombre { get; set; } = "";
    public int Edad { get; set; }
}

class Libro
{
    public string Titulo { get; set; } = "";
    public string Categoria { get; set; } = "";
}

class Vehiculo
{
    public string Marca { get; set; } = "";
    public string Modelo { get; set; } = "";
    public int AnioFabricacion { get; set; }
}
