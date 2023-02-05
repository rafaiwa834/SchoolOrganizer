namespace SchoolOrganizer.Shared.Infrastructure.Settings;

public class PostgresSettings : ISettings
{
    public string ConnectionString { get; set; }
    public static string SectionName => "Postgres";
}