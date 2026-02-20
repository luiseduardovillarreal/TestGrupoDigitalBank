using System.Collections.Generic;

/// <summary>
/// Descripción breve de CommonResultQuery
/// </summary>
public class ResultQuerie<T>
{
    public List<string> Columns { get; set; }
    public List<T> Data { get; set; }
}

public sealed class DTOQuerie<T>
{
    public bool State { get; set; }
    public ResultQuerie<T> Result { get; set; }
}

public sealed class StandarResponseDTO
{
    public bool State { get; set; }
    public string Message { get; set; }
}