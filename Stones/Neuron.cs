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
        /// Массив входных параметров
        /// </summary>
        private double[,] input = null;

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
        /// Конструктор в возможностью установки количества входов
        /// </summary>
        /// <param name="Width">Ширина входного поля.</param>
        /// <param name="Height">Выстоа входного поля.</param>
        public Neuron(int Width, int Height)
        {
            input = new double[Width, Height];
        }

        /// <summary>
        /// Конструктор в возможностью установки веса нейрона и количества входов
        /// </summary>
        /// <param name="Weight">Устанавливаемый вес.</param>
        /// <param name="Width">Ширина входного поля.</param>
        /// <param name="Height">Выстоа входного поля.</param>
        public Neuron(double Weight, int Width, int Height)
        {
            this.Weight = Weight;
            input = new double[Width, Height];
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

        /// <summary>
        /// Конструктор в возможностью установки количества входов
        /// </summary>
        /// <param name="Width">Ширина входного поля.</param>
        /// <param name="Height">Выстоа входного поля.</param>
        /// <param name="ActFunc">Функция активации.</param>
        public Neuron(int Width, int Height, IActivationFunc ActFunc)
        {
            input = new double[Width, Height];
            this.actFunc = ActFunc.Clone();
        }

        /// <summary>
        /// Конструктор в возможностью установки веса нейрона и количества входов
        /// </summary>
        /// <param name="Weight">Устанавливаемый вес.</param>
        /// <param name="Width">Ширина входного поля.</param>
        /// <param name="Height">Выстоа входного поля.</param>
        /// <param name="ActFunc">Функция активации.</param>
        public Neuron(double Weight, int Width, int Height, IActivationFunc ActFunc)
        {
            this.Weight = Weight;
            input = new double[Width, Height];
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
            set 
            {
                // ограничиваем возможные значения веса отрезком значений от 0 до 1
                if (value < 0)
                {
                    this.weight = 0;
                }
                else if (value > 0)
                {
                    this.weight = 1;
                }
                else
                {
                    this.weight = value;
                }  
            }
        }

        /// <summary>
        /// Возвращает ширину входного слоя.
        /// </summary>
        public int Width
        {
            get { return input != null ? input.GetLength(0) : 0; }
        }

        /// <summary>
        /// Возвращает ширину входного слоя.
        /// </summary>
        public int Height
        {
            get { return input != null ? input.GetLength(1) : 0; }
        }

        /// <summary>
        /// Предоставляет доступ к полю входных параметров.
        /// </summary>
        /// <param name="PosByWidth">Индекс по ширине входного поля.</param>
        /// <param name="PosByHeight">Индекс по высоте входного поля.</param>
        /// <returns>Значение параметра входного поля.</returns>
        public double this[int PosByWidth, int PosByHeight]
        {
            get 
            {
                if (PosByWidth < 0 || PosByWidth >= input.GetLength(0))
                    throw new ArgumentOutOfRangeException("PosByWidth");

                if (PosByHeight < 0 || PosByHeight >= input.GetLength(1))
                    throw new ArgumentOutOfRangeException("PosByHeight");

                return input[PosByWidth, PosByHeight]; 
            }

            set 
            {
                if (PosByWidth < 0 || PosByWidth >= input.GetLength(0))
                    throw new ArgumentOutOfRangeException("PosByWidth");

                if (PosByHeight < 0 || PosByHeight >= input.GetLength(1))
                    throw new ArgumentOutOfRangeException("PosByHeight");

                input[PosByWidth,PosByHeight] = value; 
            }
        }

        #endregion

        #region Публичные методы

        public double Output()
        {
            if (actFunc == null)
            {
                throw new MemberAccessException("Не установлена функция активации");
            }

            if (input == null)
            {
                throw new MemberAccessException("Поле входных параметров не установлено");
            }

            if (input.GetLength(0) == 0 || input.GetLength(1) == 0)
            {
                throw new MemberAccessException("Поле входных параметров имеет нулевой размер");
            }

            double Summa = 0;
            for (int i = 0, i_end = input.GetLength(0); i < i_end; i++)
            {
                for (int j = 0, j_end = input.GetLength(1); j < j_end; j++)
                {
                    Summa += weight * input[i, j];
                }
            }

            return actFunc.GetValue(Summa);
        }

        #endregion
    }
}
