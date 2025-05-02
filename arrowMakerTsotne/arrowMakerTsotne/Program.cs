
using arrowMakerTsotne;

try
{
    Arrow arrow = Arrow.CreateArrow();
    Console.WriteLine($"The cost of your arrow is: {arrow.GetCost()} gold");
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}
