internal class DataElement
{
    public string? Name { get; set; }
    public List<DataElement> Children { get; set; } = [];
}