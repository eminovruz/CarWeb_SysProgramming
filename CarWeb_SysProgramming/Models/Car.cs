namespace CarWeb_SysProgramming.Models;
#nullable disable
public class Car
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }


    public Car(string make, string model, int year)
    {
        Make = make;
        Model = model;
        Year = year;
    }
}
