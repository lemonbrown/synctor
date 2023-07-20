// See https://aka.ms/new-console-template for more information

using synctor;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

Synctor.ManualSync<Source>(
    "C:\\Users\\cambr\\Documents\\syncs\\origin\\source.json", 
    "C:\\Users\\cambr\\Documents\\syncs\\target\\source.json", 
    (documents) =>
{
    
    return documents;
});


class Source
{
    [JsonPropertyName("prop")]
    public string Prop { get; set; } = "";
}