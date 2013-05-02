using System;

namespace Stones
{
    /// <summary>
    /// Представляет модель классического нейрона.
    /// </summary>
    class Neuron
    {
        #region Скрытые поля

        /// <summary>
        /// Синаптический вес нейрона.
        /// </summary>
        private double weight = 0;

        /// <summary>
        /// Функция активации.
        /// </summary>
        private IActivationFunc actFunc = null;

        #endregion

        #region Создание и уничтожение

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Neuron()
        {
            //
        }

        /// <summary>
        /// Конструктор с установкой веса
        /// </summary>
        /// <param name="Weight">Устанавливаемый вес.</param>
        public Neuron(double Weight)
        {
            this.Weight = Weight;
        }


        /// <summary>
        /// Конструктор с установкой функции активации
        /// </summary>
        /// <param name="ActFunc">Функция активации.</param>
        public Neuron(IActivationFunc ActFunc)
        {
            this.actFunc = ActFunc.Clone();
        }

        /// <summary>
        /// Конструктор с установкой веса
        /// </summary>
        /// <param name="Weight">Устанавливаемый вес.</param>
        /// <param name="ActFunc">Функция активации.</param>
        public Neuron(double Weight, IActivationFunc ActFunc)
        {
            this.Weight = Weight;
            this.actFunc = ActFunc.Clone();
        }


        #endregion

        #region Публичные свойства

        /// <summary>
        /// Возвращает или устанавливает значение веса для нейрона.
        /// </summary>
        public double Weight
        {
            get { return weight; }
            set { this.weight = value; }
        }

        #endregion

        #region Публичные методы

        /// <summary>
        /// Вычисляет выход нейрона
        /// </summary>
        /// <param name="Summa"></param>
        /// <returns></returns>
        public double Output(double Summa)
        {
            if (actFunc == null)
            {
                throw new MemberAccessException("Не установлена функция активации");
            }

            return actFunc.GetValue(weight * Summa);
        }

        public void SetWeight(double InputSignal, double OutputSignal)
        {
 
        }

        #endregion
    }
}
