using Newtonsoft.Json;

namespace ChessMasterQuiz.Misc;

public class AdminConfiguration
{
    public PasswordRequirementLevel PasswordRequirementLevel { get; set; }
    private const string Path = $"AdminConfig.json";
    public static AdminConfiguration? Read()
    {
        string json = File.ReadAllText(Path);
        AdminConfiguration? config = JsonConvert.DeserializeObject<AdminConfiguration>(json);

        if (config is null) return default;

        return config;
    }

    public static void Write(AdminConfiguration config)
    {
        File.WriteAllText(Path, JsonConvert.SerializeObject(config));
    }

    public void Write()
    {
        Write(this);
    }
}
