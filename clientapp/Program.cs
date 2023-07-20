// See https://aka.ms/new-console-template for more information

using System.Text;
using System.Text.Json;


HttpClient http = new HttpClient();
IUsuarioService usuario = new UsuarioService(http);

// var idUsuario = await usuario.GuardarUsuario(new Usuario
// {
//     email = "esbgo97@gmail.com",
//     name = "Edward Bustos",
//     username = "esbgo97"
// });

var users = await usuario.ObtenerUsuarios();
foreach (var user in users)
{
    Console.WriteLine($"({user.username}) {user.name} {user.email}.");
}



interface IUsuarioService
{
    Task<int> GuardarUsuario(Usuario user);
    Task<List<Usuario>> ObtenerUsuarios();
}

class UsuarioService : IUsuarioService
{
    private readonly HttpClient httpClient;
    private readonly string apiurl = "https://jsonplaceholder.typicode.com/users";

    public UsuarioService(HttpClient http)
    {
        httpClient = http;
    }

    public async Task<int> GuardarUsuario(Usuario user)
    {
        try
        {
            var userJson = JsonSerializer.Serialize(user);
            var content = new StringContent(userJson, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(apiurl + "/save-endpoint", content);
            var dataJson = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<int>(dataJson);
            Console.WriteLine($"Se almacenó el usuario Correctamente!");
            return data;
        }
        catch (Exception ex)
        {
             Console.Error.WriteLine($"error:" + ex.Message);
            return 0;
        }
    }

    public async Task<List<Usuario>> ObtenerUsuarios()
    {

        var response = await httpClient.GetAsync(apiurl);
        var data = await response.Content.ReadAsByteArrayAsync();
        var users = JsonSerializer.Deserialize<List<Usuario>>(data);
        return users;
    }
}

class Usuario
{
    public string username { get; set; }
    public string email { get; set; }
    public string name { get; set; }
}