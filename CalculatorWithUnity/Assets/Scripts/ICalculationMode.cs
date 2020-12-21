namespace Calculator
{
    public interface ICalculationMode
    {
        void OnUnaryOperation();
        void OnBinaryOperation();
    }
}