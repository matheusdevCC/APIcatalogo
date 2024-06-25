namespace APIcatalogo.Logging
{
    public class CustomerLogger : ILogger
    {

        readonly string LoggerName;

        readonly CustomLoggerProviderConfiguration LoggerConfig;

        public CustomerLogger(string name, CustomLoggerProviderConfiguration config) 
        {
         LoggerName = name;
         LoggerConfig = config;

        }

        public bool IsEnabled(LogLevel logLevel) 
        {
            return logLevel == LoggerConfig.LogLevel;
        }

        public IDisposable BeginScope<TState>(TState state) 
        {
            return null;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            string mensagem = $"{logLevel.ToString()}: {eventId.Id} - {formatter(state, exception)}";

            EscreverTextoNoArquivo(mensagem);
        }

        private void EscreverTextoNoArquivo(string mensagem)
        {
            string CaminhoArquivoLog = @"C:\Users\matheus.borges\Desktop\linux\TesteLog\testelog.text";

            using (StreamWriter streamWriter = new StreamWriter(CaminhoArquivoLog, true))
            {
                try 
                {
                    streamWriter.WriteLine(mensagem);
                    streamWriter.Close();

                }
                catch(Exception) 
                {
                    throw;
                }
            
            }
        }
    }
}
