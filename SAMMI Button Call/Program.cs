using SAMMI_Button_Call;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

System.Net.ServicePointManager.Expect100Continue = false; // https://sammi.solutions/docs/api/reference (SAMMI will not handle it properly)
var buttonId = "ID1";
using HttpClient client = new();
if (args.Length > 1)
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer ", args[1]);
if (args.Length > 0)
    buttonId = args[0];
var response = await client.PostAsync("http://localhost:9450/api", new StringContent(JsonSerializer.Serialize(new ButtonRequest
{
    request = "triggerButton",
    buttonID = buttonId
}), Encoding.UTF8, "text/json"));
Console.WriteLine("Trigger:" + response.StatusCode);
response = await client.PostAsync("http://localhost:9450/api", new StringContent(JsonSerializer.Serialize(new ButtonRequest
{
    request = "releaseButton",
    buttonID = buttonId
}), Encoding.UTF8, "text/json"));
Console.WriteLine("Release:" + response.StatusCode);
/*response = await client.PostAsync("http://localhost:9450/api", new StringContent(JsonSerializer.Serialize(new MessageRequest
{
    request = "popupMessage",
    message = "Test Nachricht"
}), Encoding.UTF8, "text/json"));
Console.WriteLine("Popup:" + response.StatusCode);*/
