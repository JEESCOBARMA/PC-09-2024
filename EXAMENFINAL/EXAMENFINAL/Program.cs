using System;
using System.Collections.Generic;

public class Client // clase del cliente donde tiene su nombre, su ID del gimnasio, telefono y direccion
{
    public int ID_Client { get; set; }
    public string Nombre { get; set; }
    public string Num_telefono { get; set; }
    public string Direccion { get; set; }

    public Client(int id, string nombre, string numTelefono, string direccion)
    {
        ID_Client = id;
        Nombre = nombre;
        Num_telefono = numTelefono;
        Direccion = direccion;
    }
}

public class Membership // clase de la membresia, como el numero de la misma, su nombre, su tier o rango y el horario de la membresia
{
    public int ID_membership { get; set; }
    public string Name_membership { get; set; }
    public string Tier_membership { get; set; }
    public int Schedule { get; set; }

    public Membership(int id, string name, string tier, int schedule)
    {
        ID_membership = id;
        Name_membership = name;
        Tier_membership = tier;
        Schedule = schedule;
    }
}

public class Lesson_Class // lecciones, como su numero, el nombre, la descripcion, el horario de la clase y su duración
{
    public int Lesson_number { get; set; }
    public string Lesson_Name { get; set; }
    public string Description { get; set; }
    public DateTime Horario { get; set; }
    public int Time { get; set; }

    public Lesson_Class(int lessonNumber, string lessonName, string description, DateTime horario, int time)
    {
        Lesson_number = lessonNumber;
        Lesson_Name = lessonName;
        Description = description;
        Horario = horario;
        Time = time;
    }
}

public class Instructor // informacion del instructor que impartira la clase, como su nombre, su numero de ID y su especialidad
{ 
    public int ID { get; set; }
    public string Instructor_name { get; set; }
    public string Instructor_num { get; set; }
    public string Speciality { get; set; }

    public Instructor(int id, string name, string num, string speciality)
    {
        ID = id;
        Instructor_name = name;
        Instructor_num = num;
        Speciality = speciality;
    }
}

public class Administration // area administrativa del gimnasio, busca el numero de ID de administrador, su nombre, informacion de contacto y su rol o empleo
{
    public int ID { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }
    public string Rol { get; set; }

    public Administration(int id, string nombre, string email, string telefono, string rol)
    {
        ID = id;
        Nombre = nombre;
        Email = email;
        Telefono = telefono;
        Rol = rol;
    }
}

public class Reservation // clase para reservacion de lecciones, como el numero de caso o ticket de la reservacion, su fecha de creacíón y el estado 
{
    public int ID { get; set; }
    public DateTime Fecha { get; set; }
    public string Estado { get; set; }

    public Reservation(int id, DateTime fecha, string estado)
    {
        ID = id;
        Fecha = fecha;
        Estado = estado;
    }
}
public class Gimnasio // listas donde se almacenan la informacion de las clases descritas en el codigo mas arriba
{
    private List<Client> clients = new List<Client>();
    private List<Membership> memberships = new List<Membership>();
    private List<Lesson_Class> lessons = new List<Lesson_Class>();
    private List<Instructor> instructors = new List<Instructor>();
    private List<Administration> administrations = new List<Administration>();
    private List<Reservation> reservations = new List<Reservation>();

    public void MostrarMenu()
    {
        int opcion;
        do
        {
            Console.Clear();
            Console.WriteLine("Menu Principal:");
            Console.WriteLine("1. Ingreso de datos");
            Console.WriteLine("2. Mostrar datos");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = ValidarEntradaEntero();

            /* Primero se le pide al admin que es lo que quiere hacer
             * Ya sea desde ingresar algun dato o bien que muestre que dato encontrar, si en dado caso haya uno ingresado
             * Si se busca algun dato con la lista vacia, no mostrara nada, solo indicara que toque cualquier tecla para continuar
            */
             

            switch (opcion)
            {
                case 1:
                    IngresoDatos();
                    break;
                case 2:
                    MostrarDatos();
                    break;
                case 3:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }
        } while (opcion != 3);
    }

    private void IngresoDatos()
    {
        Console.Clear();
        Console.WriteLine("Ingreso de datos:");
        Console.WriteLine("1. Ingreso de Cliente");
        Console.WriteLine("2. Ingreso de Membresía");
        Console.WriteLine("3. Ingreso de Clase");
        Console.WriteLine("4. Ingreso de Instructor");
        Console.WriteLine("5. Ingreso de Administrador");
        Console.WriteLine("6. Ingreso de Reservación");
        Console.Write("Seleccione una opción: ");
        int opcion = ValidarEntradaEntero();

        switch (opcion)
        {
            case 1:
                IngresarCliente();
                break;
            case 2:
                IngresarMembresia();
                break;
            case 3:
                IngresarClase();
                break;
            case 4:
                IngresarInstructor();
                break;
            case 5:
                IngresarAdministrador();
                break;
            case 6:
                IngresarReservacion();
                break;
            default:
                Console.WriteLine("Opción no válida.");
                break;
        }
    }

    private void MostrarDatos()
    {
        Console.Clear();
        Console.WriteLine("Mostrar datos:");
        Console.WriteLine("1. Listado de clientes con membresía activa");
        Console.WriteLine("2. Consultar catálogo de clases");
        Console.WriteLine("3. Listado de instalaciones disponibles");
        Console.Write("Seleccione una opción: ");
        int opcion = ValidarEntradaEntero();

        switch (opcion)
        {
            case 1:
                ListarClientesActivos();
                break;
            case 2:
                ConsultarCatalogoClases();
                break;
            case 3:
                ListarInstalacionesDisponibles();
                break;
            default:
                Console.WriteLine("Opción no válida.");
                break;
        }
    }

    private void IngresarCliente()
    {
        Console.Clear();
        Console.Write("Ingrese el ID del cliente: ");
        int id = ValidarEntradaEntero();
        Console.Write("Ingrese el nombre del cliente: ");
        string nombre = Console.ReadLine();
        Console.Write("Ingrese el número de teléfono del cliente: ");
        string numTelefono = Console.ReadLine();
        Console.Write("Ingrese la dirección del cliente: ");
        string direccion = Console.ReadLine();

        clients.Add(new Client(id, nombre, numTelefono, direccion));
        Console.WriteLine("Cliente agregado exitosamente.");
    }

    private void IngresarMembresia()
    {
        Console.Clear();
        Console.Write("Ingrese el ID de la membresía: ");
        int id = ValidarEntradaEntero();
        Console.Write("Ingrese el nombre de la membresía: ");
        string nombre = Console.ReadLine();
        Console.Write("Ingrese el tipo de membresía: ");
        string tipo = Console.ReadLine();
        Console.Write("Ingrese el horario: ");
        int horario = ValidarEntradaEntero();

        memberships.Add(new Membership(id, nombre, tipo, horario));
        Console.WriteLine("Membresía agregada exitosamente.");
    }

    private void IngresarClase()
    {
        Console.Clear();
        Console.Write("Ingrese el número de la clase: ");
        int numero = ValidarEntradaEntero();
        Console.Write("Ingrese el nombre de la clase: ");
        string nombre = Console.ReadLine();
        Console.Write("Ingrese la descripción de la clase: ");
        string descripcion = Console.ReadLine();
        Console.Write("Ingrese el horario de la clase (dd/MM/yyyy HH:mm): ");
        DateTime horario = ValidarEntradaFechaHora();
        Console.Write("Ingrese la duración en minutos: ");
        int duracion = ValidarEntradaEntero();

        lessons.Add(new Lesson_Class(numero, nombre, descripcion, horario, duracion));
        Console.WriteLine("Clase agregada exitosamente.");
    }

    private void IngresarInstructor()
    {
        Console.Clear();
        Console.Write("Ingrese el ID del instructor: ");
        int id = ValidarEntradaEntero();
        Console.Write("Ingrese el nombre del instructor: ");
        string nombre = Console.ReadLine();
        Console.Write("Ingrese el número del instructor: ");
        string num = Console.ReadLine();
        Console.Write("Ingrese la especialidad del instructor: ");
        string especialidad = Console.ReadLine();

        instructors.Add(new Instructor(id, nombre, num, especialidad));
        Console.WriteLine("Instructor agregado exitosamente.");
    }

    private void IngresarAdministrador()
    {
        Console.Clear();
        Console.Write("Ingrese el ID del administrador: ");
        int id = ValidarEntradaEntero();
        Console.Write("Ingrese el nombre del administrador: ");
        string nombre = Console.ReadLine();
        Console.Write("Ingrese el email del administrador: ");
        string email = Console.ReadLine();
        Console.Write("Ingrese el teléfono del administrador: ");
        string telefono = Console.ReadLine();
        Console.Write("Ingrese el rol del administrador: ");
        string rol = Console.ReadLine();

        administrations.Add(new Administration(id, nombre, email, telefono, rol));
        Console.WriteLine("Administrador agregado exitosamente.");
    }

    private void IngresarReservacion()
    {
        Console.Clear();
        Console.Write("Ingrese el ID de la reservación: ");
        int id = ValidarEntradaEntero();
        Console.Write("Ingrese la fecha de la reservación (dd/MM/yyyy HH:mm): ");
        DateTime fecha = ValidarEntradaFechaHora();
        Console.Write("Ingrese el estado de la reservación: ");
        string estado = Console.ReadLine();

        reservations.Add(new Reservation(id, fecha, estado));
        Console.WriteLine("Reservación agregada exitosamente.");
    }

    private void ListarClientesActivos()
    {
        Console.Clear();
        Console.WriteLine("Listado de clientes con membresía activa:");
        foreach (var client in clients)
        {
            Console.WriteLine($"ID: {client.ID_Client}, Nombre: {client.Nombre}, Teléfono: {client.Num_telefono}, Dirección: {client.Direccion}");
        }
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    private void ConsultarCatalogoClases()
    {
        Console.Clear();
        Console.WriteLine("Catálogo de clases:");
        foreach (var lesson in lessons)
        {
            Console.WriteLine($"Número: {lesson.Lesson_number}, Nombre: {lesson.Lesson_Name}, Descripción: {lesson.Description}, Horario: {lesson.Horario}, Duración: {lesson.Time} minutos");
        }
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    private void ListarInstalacionesDisponibles()
    {
        Console.Clear();
        Console.WriteLine("Listado de instalaciones disponibles:");
        // Aquí iría la lógica para mostrar las instalaciones disponibles
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    private int ValidarEntradaEntero()
    {
        int valor;
        while (!int.TryParse(Console.ReadLine(), out valor))
        {
            Console.Write("Entrada no válida. Ingrese un número entero: ");
        }
        return valor;
    }

    private DateTime ValidarEntradaFechaHora()
    {
        DateTime fecha;
        while (!DateTime.TryParse(Console.ReadLine(), out fecha))
        {
            Console.Write("Entrada no válida. Ingrese una fecha y hora en formato dd/MM/yyyy HH:mm: ");
        }
        return fecha;
    }

    public static void Main(string[] args)
    {
        Gimnasio gimnasio = new Gimnasio();
        gimnasio.MostrarMenu();
    }
}
