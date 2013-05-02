
namespace Stones
{
    /// <summary>
    /// Интерфейс для функции активации.
    /// </summary>
    interface IActivationFunc
    {
        double GetValue(double X);
        IActivationFunc Clone();
    }
}
