﻿namespace Autonoma.Domain.Entities
{
    public class AdapterType : Entity
    {
        /// <summary>
        /// Имя класса, хранящего настройки адаптера
        /// </summary>
        public string AssemblyQualifiedSettingsTypeName { get; set; } = "";

        /// <summary>
        /// Имя класса, хранящего настройки точки данных
        /// </summary>
        public string AssemblyQualifiedDataPointSettingsTypeName { get; set; } = "";

        /// <summary>
        /// Имя класса-адаптера
        /// </summary>
        /// <remarks>
        /// Заполняется только для "внутренних" адаптеров
        /// </remarks>
        public string AssemblyQualifiedAdapterTypeName { get; set; } = "";

        /// <summary>
        /// Наименование адаптера
        /// </summary>
        public string Name { get; set; } = "n/a";

        /// <summary>
        /// Команда для получения диагностики от внешнего процесса
        /// </summary>
        /// <remarks>
        /// Заполняется только для "внешних" адаптеров
        /// </remarks>
        public string ProcessWrapperDiagCommand { get; set; } = "";

        /// <summary>
        /// Команда для запуска внешнего процесса
        /// </summary>
        /// <remarks>
        /// Заполняется только для "внешних" адаптеров
        /// </remarks>
        public string ProcessWrapperStartCommand { get; set; } = "";

        /// <summary>
        /// Команда для останова внешнего процесса
        /// </summary>
        /// <remarks>
        /// Заполняется только для "внешних" адаптеров
        /// </remarks>
        public string ProcessWrapperStopCommand { get; set; } = "";
    }
}
