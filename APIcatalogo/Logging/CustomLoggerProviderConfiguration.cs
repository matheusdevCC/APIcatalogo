namespace APIcatalogo.Logging
{
    public class CustomLoggerProviderConfiguration
    {
        //loglevel: define o nivel minimo de log a ser registrado, com o padrão LogLevel.Warning.
        public LogLevel LogLevel { get; set; } = LogLevel.Warning;
        //eventId: Defini o ID do evento de log, com o padrão sendo zero.
        public int EventId { get; set; } = 0;

    }
}
