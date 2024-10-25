using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Producto
{
    public int ID { get; set; }
    public string Nombre { get; set; }
    public int Cantidad { get; set; }
    public decimal Precio { get; set; }

    public Producto(int id, string nombre, int cantidad, decimal precio)
    {
        ID = id;
        Nombre = nombre;
        Cantidad = cantidad;
        Precio = precio;
    }
}

class Program
{
    static void Main(string[] args)
    {
        string filePath = "productos.dat";
        var productos = IngresarProductos();
        EscribirProductos(filePath, productos);
        var productosLeidos = LeerProductos(filePath);

        Console.WriteLine("Ingrese el ID del producto a buscar:");
        int id = int.Parse(Console.ReadLine());
        var producto = BuscarProductoPorID(productosLeidos, id);

        if (producto != null)
        {
            Console.WriteLine($"ID: {producto.ID}, Nombre: {producto.Nombre}, Cantidad: {producto.Cantidad}, Precio: {producto.Precio}");
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }
    }

    static Producto[] IngresarProductos()
    {
        var productos = new List<Producto>();
        Console.WriteLine("Ingrese la cantidad de productos:");
        int cantidadProductos = int.Parse(Console.ReadLine());

        for (int i = 0; i < cantidadProductos; i++)
        {
            Console.WriteLine($"Producto {i + 1}:");
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Cantidad: ");
            int cantidad = int.Parse(Console.ReadLine());
            Console.Write("Precio: ");
            decimal precio = decimal.Parse(Console.ReadLine());

            productos.Add(new Producto(id, nombre, cantidad, precio));
            Console.Clear();
        }
        return productos.ToArray();
    }

    static void EscribirProductos(string filePath, Producto[] productos)
    {
        using (var writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
        {
            foreach (var producto in productos)
            {
                writer.Write(producto.ID);
                writer.Write(producto.Nombre);
                writer.Write(producto.Cantidad);
                writer.Write(producto.Precio);
            }
        }
    }

    static Producto[] LeerProductos(string filePath)
    {
        var productos = new List<Producto>();
        using (var reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
        {
            while (reader.BaseStream.Position != reader.BaseStream.Length)
            {
                productos.Add(new Producto(reader.ReadInt32(), reader.ReadString(), reader.ReadInt32(), reader.ReadDecimal()));
            }
        }
        return productos.ToArray();
    }

    static Producto BuscarProductoPorID(Producto[] productos, int id)
    {
        foreach (var producto in productos)
        {
            if (producto.ID == id)
            {
                return producto;
            }
        }
        return null;
    }
}