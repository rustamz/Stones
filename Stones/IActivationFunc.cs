
namespace Stones
{
    /// <summary>
    /// Интерфейс для функции активации.
    /// </summary>
    interface IActivationFunc
    {
        double GetValue(double X);
        double GetWeight(double X, double F);
        IActivationFunc Clone();
    }
}
