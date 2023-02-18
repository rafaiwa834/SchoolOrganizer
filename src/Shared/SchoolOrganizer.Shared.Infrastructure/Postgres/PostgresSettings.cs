using SchoolOrganizer.Shared.Abstractions.Settings;
using SchoolOrganizer.Shared.Infrastructure.Settings;

namespace SchoolOrganizer.Shared.Infrastructure.Postgres;

public class PostgresSettings : ISettings
{
    public string ConnectionString { get; set; }
    public static string SectionName => "Postgres";
}