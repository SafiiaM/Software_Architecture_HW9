// using System;
// using System.Collections.Generic;
// using System.Linq;

namespace MyAspNetApp.Models
{
    /// <summary>
    /// Объект на базе WeatherForecastHolder будет хранить список 
    /// показателей температуры
    /// </summary>
    public class WeatherForecastHolder
    {
        // Коллекция для хранения показателей температуры
        private List<WeatherForecast> _values;

        public WeatherForecastHolder()
        {
            // Инициализация коллекции для хранения показателей температуры
            _values = new List<WeatherForecast>();
        } 

        /// <summary>
        /// Добавить новый показатель температуры
        /// </summary>
        /// <param name="dateTime">Дата фиксации показателя температуры</param>
        /// <param name="TemperatureC">Показатель температуры</param>
        public void Add(DateTime dateTime, int TemperatureC)
        {
            WeatherForecast forecast = new WeatherForecast();
            forecast.TemperatureC = TemperatureC;
            forecast.Date = dateTime;

            _values.Add(forecast);
        } 

        /// <summary>
        /// Обновить показатель температуры
        /// </summary>
        /// <param name="date">Дата фиксации показания температуры</param>
        /// <param name="temperatureC">Новый показатель температуры</param>
        /// <returns>Результат выполнения операции</returns>
        public bool Update(DateTime date, int temperatureC)
        {
            foreach (WeatherForecast item in _values)
            {
                if (item.Date == date)
                {
                    item.TemperatureC = temperatureC;
                    return true;
                }
                
            }
            return false;
        }

        /// <summary>
        /// Получить показатели температцры за временной период
        /// </summary>
        /// <param name="dateFrom">Начальная дата</param>
        /// <param name="dateTo">Конечная дата</param>
        /// <returns>Коллекция показателей температуры</returns>
        public List<WeatherForecast> Get(DateTime dateFrom, DateTime dateTo)
        {
            List<WeatherForecast> list = new List<WeatherForecast>();
            foreach (WeatherForecast item in _values)
            {
                if (item.Date >= dateFrom && item.Date <= dateTo)
                    list.Add(item);
                
            }
            return list;
        }

        /// <summary>
        /// Удалить показатель температуры на дату
        /// </summary>
        /// <param name="date">Дата фиксации температуры</param>
        /// <returns>Результат выполнения операции</returns>
        public bool Delete(DateTime date)
        {
            var itemToDelete = _values.FirstOrDefault(item => item.Date == date);
            if (itemToDelete != null)
            {
                _values.Remove(itemToDelete);
                return true;
            }
            return false;
        }
    }
}