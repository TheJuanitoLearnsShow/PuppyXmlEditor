using System.Collections.Immutable;

namespace PuppyXmlEditor.Contracts;

public interface IPossibleValues
{
    
} 
public record LookupInfo(string ObjectForSearch, string SearchParameterName,
    string IdColumnName,string LabelColumnName, bool IsStoredProc, string ConnectionString) : IPossibleValues;
    
    
public record ValuesListFromDb(string ObjectForSearch, 
    string IdColumnName,string LabelColumnName, bool IsStoredProc, string ConnectionString) : IPossibleValues;
    
public record ValuesList(IReadOnlyList<ValueLabelPair> Values) : IPossibleValues;

public record ValueLabelPair(string Value, string Label)
{
}

public class PuppyEditor(PuppyPropertyType propertyType)
{
    private PuppyPropertyType _propertyType = propertyType;

    public string CurrentTextValue { get; set; } = string.Empty;
    
}

public interface IPuppyPropertyType
{
    
}

public record PuppyPrimitivePropertyType(
    string ParamName,
    bool Required,
    int Length,
    string ClrTypeName,
    int Decimals
)
{
};
public record PuppyObjectPropertyType(
    string ParamName,
    bool Required,
    string ClrTypeName,
    IImmutableList<IPuppyPropertyType> ChildrenProperties)
{
};

public record PuppyPropertyPossibleValuesType(
    string ParamName,
    bool Required,
    int Length,
    string ClrTypeName,
    int Decimals,
    string BaseSqlTypeName,
    IPossibleValues PossibleValues
) : PuppyPropertyType(ParamName, Required, Length, ClrTypeName, Decimals);
