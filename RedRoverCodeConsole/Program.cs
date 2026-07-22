class Program
{
    private static readonly int TabSize = 2;
    private static readonly string PrintPrefix = "-";
    private static readonly string RootElementName = "root";

    static void Main(string[] args)
    {
        var defaultInput = "(id, name, email, type(id, name, customFields(c1, c2, c3)), externalId)";
        Console.WriteLine($"Enter input string [press enter for default: {defaultInput}]: ");

        var input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            input = defaultInput;
        }

        List<DataElement> result;
        try
        {
            result = ParseContent(input, true);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error parsing input: {ex.Message}");
            return;
        }

        Console.WriteLine($"The following input has been parsed: {input}");
        Console.WriteLine(FormatDataElementString(result, sortType: DataElementSortType.None));
        Console.WriteLine(FormatDataElementString(result, sortType: DataElementSortType.Ascending));

        Console.WriteLine("\nPress any key to close the console...");
        Console.ReadKey();
    }

    static List<DataElement> ParseContent(string content, bool initial = false)
    {
        var result = new List<DataElement>();

        var index = 0;
        var name = "";
        while (index < content.Length)
        {
            switch (content[index])
            {
                case '(':
                    var lastParenthesis = content.LastIndexOf(')');
                    if (lastParenthesis == -1)
                    {
                        var openParenErrorElement = initial ? RootElementName : name.Trim();
                        throw new ArgumentException($"A closing parenthesis is missing when navigating the [{openParenErrorElement}] element");
                    }

                    var contentSubstring = content[(index + 1)..lastParenthesis];
                    var children = ParseContent(contentSubstring);

                    if (initial)
                    {
                        result.AddRange(children);
                    }
                    else
                    {
                        result.Add(new DataElement
                        {
                            Name = name.Trim(),
                            Children = ParseContent(contentSubstring)
                        });
                    }

                    index = lastParenthesis;
                    name = "";
                    break;
                case ')':
                    var closeParenErrorElement = initial ? RootElementName : name.Trim();
                    throw new ArgumentException($"An unmatched clothing parethesis was found when navigating the [{closeParenErrorElement}] element");
                case ',':
                    if (name.Trim().Length > 0)
                    {
                        result.Add(new DataElement
                        {
                            Name = name.Trim()
                        });
                    }
                    name = "";
                    break;
                default:
                    name += content[index];
                    break;
            }
            index++;
        }

        if (name.Length > 0)
        {
            result.Add(new DataElement
            {
                Name = name.Trim()
            });
        }

        return result;
    }

    static string FormatDataElementString(List<DataElement> elements, int depth = 0, DataElementSortType sortType = DataElementSortType.None)
    {
        var result = "";
        var sortedElements = sortType switch
        {
            DataElementSortType.Ascending => [.. elements.OrderBy(e => e.Name)],
            _ => elements
        };

        foreach (var element in sortedElements)
        {
            if (!string.IsNullOrWhiteSpace(element.Name))
            {
                result += $"{new string(' ', depth * TabSize)}{PrintPrefix} {element.Name}\n";
            }

            if (element.Children?.Count > 0)
            {
                result += FormatDataElementString(element.Children, depth + 1, sortType);
            }
        }

        return result;
    }
}