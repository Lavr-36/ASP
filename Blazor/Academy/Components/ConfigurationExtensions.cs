using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Academy.Components;

public static class ConfigurationExtensions
{
    public static string GetNpgsqlConnectionString(this IConfiguration configuration, string sectionName)
    {
        var sectionPath = $"ConnectionStrings:{sectionName}";
        var dbConfig = configuration.GetSection(sectionPath);

        // 1. Проверяем, существует ли вообще секция
        if (!dbConfig.Exists())
        {
            throw new InvalidOperationException(
                $"Секция конфигурации '{sectionPath}' не найдена. " +
                $"Проверьте appsettings.json и User Secrets.");
        }

        // 2. Читаем значения через индексатор
        var host = dbConfig["Host"];
        var portStr = dbConfig["Port"];
        var database = dbConfig["Database"];
        var username = dbConfig["Username"];
        var password = dbConfig["Password"];

        // 3. Валидация обязательных полей
        if (string.IsNullOrWhiteSpace(host) || string.IsNullOrWhiteSpace(database))
        {
            throw new InvalidOperationException(
                $"В секции '{sectionPath}' не указаны обязательные поля Host или Database.");
        }

        // 4. Собираем строку
        var builder = new NpgsqlConnectionStringBuilder
        {
            Host = host,
            Database = database,
            Username = username,
            Password = password
        };

        // Порт обрабатываем отдельно, так как это число
        if (int.TryParse(portStr, out int port))
        {
            builder.Port = port;
        }

        return builder.ConnectionString;
    }
}