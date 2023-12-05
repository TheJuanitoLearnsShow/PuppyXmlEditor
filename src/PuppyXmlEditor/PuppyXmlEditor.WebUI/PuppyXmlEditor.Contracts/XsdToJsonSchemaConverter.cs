namespace PuppyXmlEditor.Contracts;

using System;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class XsdToJsonSchemaConverter
{
    public JObject ConvertXsdToJsonSchema(XmlDocument schemaDoc)
    {
        var jsonSchema = new JObject();
        jsonSchema["type"] = "object";
        var properties = new JObject();

        foreach (XmlNode element in schemaDoc.SelectNodes("//xs:element", GetNamespaceManager(xmlDoc)))
        {
            var property = new JObject();
            property["type"] = ConvertXsdTypeToJsonType(element.Attributes["type"]?.Value);
            properties[element.Attributes["name"].Value] = property;
        }

        jsonSchema["properties"] = properties;
        return jsonSchema;
    }

    private string ConvertXsdTypeToJsonType(string xsdType)
    {
        // Simple type mapping, needs to be expanded for full XSD support
        switch (xsdType)
        {
            case "xs:string":
                return "string";
            case "xs:int":
                return "integer";
            // Add more cases here
            default:
                return "string";
        }
    }

    private XmlNamespaceManager GetNamespaceManager(XmlDocument doc)
    {
        var nsmgr = new XmlNamespaceManager(doc.NameTable);
        nsmgr.AddNamespace("xs", "http://www.w3.org/2001/XMLSchema");
        return nsmgr;
    }
}

// // Usage
// var converter = new XsdToJsonSchemaConverter();
// var jsonSchema = converter.ConvertXsdToJsonSchema("path_to_your_xsd_file.xsd");
// Console.WriteLine(jsonSchema.ToString());
