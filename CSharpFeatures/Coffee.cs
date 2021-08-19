namespace CSharpFeatures
{
    internal class Coffee
    {
        public Coffee()
        {
        }

        public Coffee(string type)
        {
            CoffeeType = type;
        }

        public string CoffeeType { get; }

        public override string ToString()
        {
            return CoffeeType;
        }
    }
}