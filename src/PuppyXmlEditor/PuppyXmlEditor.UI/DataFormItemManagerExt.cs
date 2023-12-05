using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;
using Syncfusion.Maui.DataForm;

namespace PuppyXmlEditor.UI;

internal class DataFormItemManagerExt : DataFormItemManager
{
    Dictionary<string, object> dataFormDictionary;

    public DataFormItemManagerExt(Dictionary<string, object> dictionary)
    {
        dataFormDictionary = dictionary;
    }

    public override object GetValue(DataFormItem dataFormItem)
    {
        return dataFormDictionary[dataFormItem.FieldName];
    }

    public override void SetValue(DataFormItem dataFormItem, object value)
    {
        dataFormDictionary[dataFormItem.FieldName] = value;
    }
}

public class PropertyInfoExt : PropertyInfo
{
    public PropertyInfoExt(string name, Type declaringType)
    {
        Name = name;
        ReflectedType = declaringType;
        DeclaringType = declaringType;
    }

    public override object[] GetCustomAttributes(bool inherit)
    {
        return new[] { new StringLengthAttribute(5) };
    }

    public override object[] GetCustomAttributes(Type attributeType, bool inherit)
    {
        return new[] { new StringLengthAttribute(5) };
    }

    public override bool IsDefined(Type attributeType, bool inherit)
    {
        throw new NotImplementedException();
    }

    public override Type DeclaringType { get; }
    public override string Name { get; }
    public override Type ReflectedType { get; }
    public override MethodInfo[] GetAccessors(bool nonPublic)
    {
        throw new NotImplementedException();
    }

    public override MethodInfo GetGetMethod(bool nonPublic)
    {
        throw new NotImplementedException();
    }

    public override ParameterInfo[] GetIndexParameters()
    {
        throw new NotImplementedException();
    }

    public override MethodInfo GetSetMethod(bool nonPublic)
    {
        throw new NotImplementedException();
    }

    public override object GetValue(object obj, BindingFlags invokeAttr, Binder binder, object[] index, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    public override void SetValue(object obj, object value, BindingFlags invokeAttr, Binder binder, object[] index,
        CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    public override PropertyAttributes Attributes { get; }
    public override bool CanRead { get; }
    public override bool CanWrite { get; }
    public override Type PropertyType { get; }
}