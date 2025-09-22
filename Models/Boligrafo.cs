namespace Bindings.Models;

public class Boligrafo
{
    public string Codigo { get; set; }
    public string Color {get; set;}

    public override string ToString()
    {
        return "Codigo: "+Codigo + " Color: " + Color;
    }
}