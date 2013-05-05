using System;
using System.Drawing;

namespace Stones
{
    /// <summary>
    /// Определяем пороговую функцию для нейросети
    /// </summary>
    class LimitActivationFunction : IActivationFunc
    {

        /// <summary>
        /// Возвращает значение пороговой функции активации
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public double GetValue(double X)
        {
            return X > 127 ? 1 : 0;
        }

        /// <summary>
        /// На основе входного и выходного параметра вычисляется вес.
        /// </summary>
        /// <param name="X">Входной параметр</param>
        /// <param name="F">Выходной параметр</param>
        /// <returns></returns>
        public double GetWeight(double X, double F)
        {
            return F == 1 && X > 127 ? 1 : -1; 
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="Param"></param>
        public LimitActivationFunction()
        {
        }

        /// <summary>
        /// Создаёт клон объекта
        /// </summary>
        /// <returns></returns>
        public IActivationFunc Clone()
        {
            return new LimitActivationFunction();
        }
    }
    
    class DoubleLayerPerceptron
    {
        
        #region Скрытые поля

        /// <summary>
        /// Набор входных параметров
        /// </summary>
        private double[,] input = null;


        /// <summary>
        /// Набор выходных параметров
        /// </summary>
        private double[,] output = null;

        /// <summary>
        /// Первый слой нейронов.
        /// </summary>
        private Neuron[,] firstNeuronLayer = null;

        /// <summary>
        /// Второй слой нейронов.
        /// </summary>
        private Neuron[,] secondNeuronLayer = null;

        /// <summary>
        /// Сигмоидальная функция активации
        /// </summary>
        private LimitActivationFunction ActFunc = new LimitActivationFunction();

        #endregion

        #region Создание и уничтожение
        
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public DoubleLayerPerceptron()
        {
            //
        }

        /// <summary>
        /// Конструктор в возможностью установки количества входов.
        /// </summary>
        /// <param name="Width">Ширина входного поля.</param>
        /// <param name="Height">Выстоа входного поля.</param>
        public DoubleLayerPerceptron(int Width, int Height)
        {
            input = new double[Width, Height];
            output = new double[Width, Height];
            

            // Инициализируем первой слой нейронов
            firstNeuronLayer = new Neuron[Width, Height];
            for (int i = 0; i < firstNeuronLayer.GetLength(0); i++)
            {
                for (int j = 0; j < firstNeuronLayer.GetLength(1); j++)
                {
                    firstNeuronLayer[i, j] = new Neuron(ActFunc.Clone());
                }
            }
            
            
            // Инициализируем второй слой нейронов
            secondNeuronLayer = new Neuron[Width, Height];
            for (int i = 0; i < secondNeuronLayer.GetLength(0); i++)
            {
                for (int j = 0; j < secondNeuronLayer.GetLength(1); j++)
                {
                    secondNeuronLayer[i, j] = new Neuron(ActFunc.Clone());
                }
            }
        
        }

        #endregion

        #region Публичные свойства
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

                input[PosByWidth, PosByHeight] = value;
            }
        }
        #endregion

        #region Публичные методы

        public double Output()
        {
            // для каждого нейрона в слое копируем входные параметры
            for (int layer_i = 0; layer_i < firstNeuronLayer.GetLength(0); layer_i++)
            {
                for (int layer_j = 0; layer_j < firstNeuronLayer.GetLength(1); layer_j++)
                {
                    output[layer_i, layer_j] = firstNeuronLayer[layer_i, layer_j].Output(input[layer_i, layer_j]);
                }
            }
           

            double Summa = 0;
            for (int layer_i = 0; layer_i < output.GetLength(0); layer_i++)
            {
                for (int layer_j = 0; layer_j < output.GetLength(1); layer_j++)
                {
                    Summa += output[layer_i, layer_j];
                }
            }

            return Summa;
        }

        /// <summary>
        /// Функция для для слоя
        /// </summary>
        public void Training()
        {
            for (int layer_i = 0; layer_i < firstNeuronLayer.GetLength(0); layer_i++)
            {
                for (int layer_j = 0; layer_j < firstNeuronLayer.GetLength(1); layer_j++)
                {
                    // если точка закрашена, то увеличиваем значения веса на единицу, иначе - уменьшаем
                    firstNeuronLayer[layer_i, layer_j].Weight += input[layer_i, layer_j] >= 1 ? 1 : -1;
                }
            }            
        }

        // выгружает матрицу весов первого слоя в файл
        public void SaveFirstLayerToFile(string FileName)
        {
            
            System.IO.StreamWriter fs = new System.IO.StreamWriter(FileName);

            for (int layer_i = 0; layer_i < firstNeuronLayer.GetLength(0); layer_i++)
            {
                for (int layer_j = 0; layer_j < firstNeuronLayer.GetLength(1); layer_j++)
                {
                    fs.Write(firstNeuronLayer[layer_i, layer_j].Weight.ToString() + "\t");
                }
                fs.Write("\n\r");
            }

            fs.Close();
        }

        /// <summary>
        /// Преобразует матрицу весов черно-белое изображение
        /// </summary>
        /// <returns>Черно-белое изображение</returns>
        public Bitmap BitmapFromFirstLayer()
        {
            Bitmap bm = new Bitmap(firstNeuronLayer.GetLength(0), firstNeuronLayer.GetLength(1));

            double[,] ImageDouble = new double[firstNeuronLayer.GetLength(0), firstNeuronLayer.GetLength(1)];

            // переписываем матрицу весов в массив, заодно определяем наимеьший элемент
            double Minimal = 0;
            bool MinimalSet = false;
            for (int layer_i = 0; layer_i < firstNeuronLayer.GetLength(0); layer_i++)
            {
                for (int layer_j = 0; layer_j < firstNeuronLayer.GetLength(1); layer_j++)
                {
                    ImageDouble[layer_i, layer_j] = firstNeuronLayer[layer_i, layer_j].Weight;
                    
                    if (!MinimalSet)
                    {
                        Minimal = ImageDouble[layer_i, layer_j];
                        MinimalSet = true;
                    }
                    else
                    {
                        if (ImageDouble[layer_i, layer_j] < Minimal)
                        {
                            Minimal = ImageDouble[layer_i, layer_j];
                        }
                    }
                }
            }

            // если есть наименьший элемент и он отрицательный, то избавляемся от отрицательных значений, поднимая всё
            if (MinimalSet && Minimal < 0)
            {
                Minimal = Math.Abs(Minimal);
                for (int layer_i = 0; layer_i < ImageDouble.GetLength(0); layer_i++)
                {
                    for (int layer_j = 0; layer_j < ImageDouble.GetLength(1); layer_j++)
                    {
                        ImageDouble[layer_i, layer_j] += Minimal;   
                    }
                }
            }

            double Maximum = 0;
            bool MaximumSet = false;
            for (int layer_i = 0; layer_i < ImageDouble.GetLength(0); layer_i++)
            {
                for (int layer_j = 0; layer_j < ImageDouble.GetLength(1); layer_j++)
                {
                    if (!MaximumSet)
                    {
                        Maximum = ImageDouble[layer_i, layer_j];
                        MaximumSet = true;
                    }
                    else
                    {
                        if (ImageDouble[layer_i, layer_j] > Maximum)
                        {
                            Maximum = ImageDouble[layer_i, layer_j];
                        }
                    }
                }
            }
            
            // масштабируем до 0 до 255
            for (int layer_i = 0; layer_i < ImageDouble.GetLength(0); layer_i++)
            {
                for (int layer_j = 0; layer_j < ImageDouble.GetLength(1); layer_j++)
                {
                    ImageDouble[layer_i, layer_j] = 255 * ImageDouble[layer_i, layer_j] / Maximum;    
                }
            }

            for (int layer_i = 0; layer_i < ImageDouble.GetLength(0); layer_i++)
            {
                for (int layer_j = 0; layer_j < ImageDouble.GetLength(1); layer_j++)
                {
                    bm.SetPixel(layer_i,layer_j,Color.FromArgb((int)ImageDouble[layer_i, layer_j],
                        (int)ImageDouble[layer_i, layer_j], (int)ImageDouble[layer_i, layer_j]));
                }
            }

            return bm;
        }

        /// <summary>
        /// Сбрасывает матрицу весов до 0
        /// </summary>
        public void ClearWeight()
        {
            for (int layer_i = 0; layer_i < firstNeuronLayer.GetLength(0); layer_i++)
            {
                for (int layer_j = 0; layer_j < firstNeuronLayer.GetLength(1); layer_j++)
                {
                    firstNeuronLayer[layer_i, layer_j].Weight = 0;
                }
            }  
        }

        /// <summary>
        /// преобразует матрицу весов в массив байт
        /// </summary>
        /// <returns></returns>
        public byte[] GetBinary()
        {
            // Линеаризируем исходную матрицу весов
            double[] LineWeight = new double[firstNeuronLayer.GetLength(0) * firstNeuronLayer.GetLength(1)];
            for (int layer_i = 0; layer_i < firstNeuronLayer.GetLength(0); layer_i++)
            {
                for (int layer_j = 0; layer_j < firstNeuronLayer.GetLength(1); layer_j++)
                {
                    LineWeight[layer_i * firstNeuronLayer.GetLength(0) + layer_j] = firstNeuronLayer[layer_i, layer_j].Weight;
                }
            }

            // Массив байт на возвращение
            byte[] Result = new byte[firstNeuronLayer.GetLength(0) * firstNeuronLayer.GetLength(1) * sizeof(double)];

            // Копируем байты в выходной массив
            Buffer.BlockCopy(LineWeight, 0, Result, 0, Result.Length);

            return Result;
        }


        /// <summary>
        /// преобразует матрицу весов в массив байт
        /// </summary>
        /// <returns></returns>
        public void FromBinary(byte[] WeightBinary)
        {
            if ((firstNeuronLayer.GetLength(0) * firstNeuronLayer.GetLength(1) * sizeof(double)) != WeightBinary.Length)
            {
                ClearWeight();
            }

            double[] LineWeight = new double[WeightBinary.Length / sizeof(double)];

            Buffer.BlockCopy(WeightBinary, 0, LineWeight, 0, WeightBinary.Length);

            for (int layer_i = 0; layer_i < firstNeuronLayer.GetLength(0); layer_i++)
            {
                for (int layer_j = 0; layer_j < firstNeuronLayer.GetLength(1); layer_j++)
                {
                    firstNeuronLayer[layer_i, layer_j].Weight = LineWeight[layer_i * firstNeuronLayer.GetLength(0) + layer_j]; 
                }
            }
        }

        #endregion
    }
}
