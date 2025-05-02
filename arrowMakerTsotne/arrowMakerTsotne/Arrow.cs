namespace arrowMakerTsotne;

internal class Arrow
{
    public enum ArrowheadType { Steel, Wood, Obsidian }
    public enum FletchingType { Plastic, TurkeyFeathers, GooseFeathers }

    private readonly ArrowheadType arrowhead;
    private readonly FletchingType fletching;
    private float _length;

    public Arrow(ArrowheadType arrowhead, FletchingType fletching, float length)
    {
        this.arrowhead = arrowhead;
        this.fletching = fletching;
        this.Length = length;
    }

    public ArrowheadType Arrowhead => arrowhead;
    public FletchingType Fletching => fletching;

    public float Length
    {
        get => _length;
        private set
        {
            if (value < 60 || value > 100)
            {
                throw new ArgumentOutOfRangeException("Length must be between 60 and 100 cm.");
            }
            _length = value;
        }
    }

    public float GetCost()
    {
        float arrowHeadCost = arrowhead switch
        {
            ArrowheadType.Steel => 10f,
            ArrowheadType.Wood => 3f,
            ArrowheadType.Obsidian => 5f,
            _ => 0f
        };

        float fletchingCost = fletching switch
        {
            FletchingType.Plastic => 10f,
            FletchingType.TurkeyFeathers => 5f,
            FletchingType.GooseFeathers => 3f,
            _ => 0f
        };

        float shaftCost = _length * 0.05f;
        return arrowHeadCost + fletchingCost + shaftCost;
    }

    public static Arrow CreateArrow()
    {
        ArrowheadType arrowhead = GetArrowheadType();
        FletchingType fletching = GetFletchingType();
        float length = GetShaftLength();

        return new Arrow(arrowhead, fletching, length);
    }

    private static ArrowheadType GetArrowheadType()
    {
        Console.WriteLine("Choose arrowhead type (Steel, Wood, Obsidian): ");
        while (true)
        {
            string input = Console.ReadLine();
            if (Enum.TryParse(input, true, out ArrowheadType result)) return result;
            Console.WriteLine("Invalid arrowhead type. Please enter Steel, Wood, or Obsidian.");
        }
    }

    private static FletchingType GetFletchingType()
    {
        Console.WriteLine("Choose fletching type (Plastic, TurkeyFeathers, GooseFeathers): ");
        while (true)
        {
            string input = Console.ReadLine();
            if (Enum.TryParse(input, true, out FletchingType result)) return result;
            Console.WriteLine("Invalid fletching type. Please enter Plastic, TurkeyFeathers, or GooseFeathers.");
        }
    }

    private static float GetShaftLength()
    {
        Console.WriteLine("Enter length of the shaft (between 60 and 100 cm): ");
        while (true)
        {
            if (float.TryParse(Console.ReadLine(), out float length) && length >= 60 && length <= 100)
                return length;

            Console.WriteLine("Invalid length. Please enter a value between 60 and 100 cm.");
        }
    }
}
