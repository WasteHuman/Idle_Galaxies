namespace OtherUtils
{
    public class Calculator
    {
        public float Calculate(float startValue, float finalValue, float difference, float outValue, float count)
        {
            difference = finalValue - startValue;
            outValue = difference / count;

            return outValue;
        }
    }
}