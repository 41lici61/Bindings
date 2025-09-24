using System;

namespace Bindings.Models;

public class Boligrafo
{
    public string Codigo { get; set; }
    public string Color {get; set;}
    
    public DateTime Fecha { get; set; } = DateTime.Today;

    public override string ToString()
    {
        return "Codigo: "+Codigo + " Color: " + Color;
    }
}