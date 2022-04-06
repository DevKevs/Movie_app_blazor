// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Movie_app.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\Kevin Feliz\Desktop\repo\Movie_app_blazor\Movie_app\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Kevin Feliz\Desktop\repo\Movie_app_blazor\Movie_app\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Kevin Feliz\Desktop\repo\Movie_app_blazor\Movie_app\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Kevin Feliz\Desktop\repo\Movie_app_blazor\Movie_app\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Kevin Feliz\Desktop\repo\Movie_app_blazor\Movie_app\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Kevin Feliz\Desktop\repo\Movie_app_blazor\Movie_app\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Kevin Feliz\Desktop\repo\Movie_app_blazor\Movie_app\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Kevin Feliz\Desktop\repo\Movie_app_blazor\Movie_app\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Kevin Feliz\Desktop\repo\Movie_app_blazor\Movie_app\Client\_Imports.razor"
using Movie_app.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Kevin Feliz\Desktop\repo\Movie_app_blazor\Movie_app\Client\_Imports.razor"
using Movie_app.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Kevin Feliz\Desktop\repo\Movie_app_blazor\Movie_app\Client\_Imports.razor"
using Radzen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\Kevin Feliz\Desktop\repo\Movie_app_blazor\Movie_app\Client\_Imports.razor"
using Radzen.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Kevin Feliz\Desktop\repo\Movie_app_blazor\Movie_app\Client\Pages\Index.razor"
using Movie_app.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Kevin Feliz\Desktop\repo\Movie_app_blazor\Movie_app\Client\Pages\Index.razor"
using Movie_app.Shared.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Kevin Feliz\Desktop\repo\Movie_app_blazor\Movie_app\Client\Pages\Index.razor"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 219 "C:\Users\Kevin Feliz\Desktop\repo\Movie_app_blazor\Movie_app\Client\Pages\Index.razor"
      
    List<Pelicula_repo> Movies;
    Pelicula_repo Movie = new Pelicula_repo();
    List<Pelicula_repo> MoviesFilter = new List<Pelicula_repo>();
    Prestamo prestamo = new Prestamo();
    ResponsePrestamo response;
    private ResponseReader responseReader;
    public string Buscar { get; set; }
    protected override async Task OnInitializedAsync()
    {
        responseReader = await Http.GetFromJsonAsync<ResponseReader>("api/Peliculas/join");
        Movies = responseReader._peliculas;
        if (Movies != null)
        {
            foreach (var m in Movies)
            {
                MoviesFilter.Add(m);
            }
        }
    }
    public bool IsVisible(Pelicula_repo _pelicula)
    {
        if (string.IsNullOrEmpty(Buscar))  
            return true; 
        if (_pelicula.Titulo.ToString().Contains(Buscar, StringComparison.OrdinalIgnoreCase))  
            return true;
        if (_pelicula.Tipo.ToString().Contains(Buscar, StringComparison.OrdinalIgnoreCase))  
            return true;
        if (_pelicula.Sinopsis.ToString().Contains(Buscar, StringComparison.OrdinalIgnoreCase))  
            return true;
        return false;
    }
    void filter(string busqueda)
    {
        Movies = MoviesFilter.Where(e => e.Estado == busqueda).Select(a => a).ToList();
    }
    void limpiar()
    {
        Movies = MoviesFilter;
    }

    async Task Prestar()
    {
        prestamo.IdPelicula = Movie.Id;
        string json = JsonConvert.SerializeObject(prestamo);
        StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        var responses = await Http.PostAsync("api/Prestamos/Prestar", httpContent);
        response = await responses.Content.ReadFromJsonAsync<ResponsePrestamo>();
        if (response.ok)
        {
            await _reload();
            prestamo = new Prestamo();
        }

    }
    async Task Devolver()
    {
        prestamo.IdPelicula = Movie.Id;
        prestamo.Prestatario = "Un duro";
        string json = JsonConvert.SerializeObject(prestamo);
        StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        var responses = await Http.PostAsync("api/Prestamos/Devolver", httpContent);
        response = await responses.Content.ReadFromJsonAsync<ResponsePrestamo>();
        if (response.ok)
        {
            await _reload();
            prestamo = new Prestamo();
        }
        
    }
    async Task _reload()
    {
        Movies.Clear();
       responseReader = await Http.GetFromJsonAsync<ResponseReader>("api/Peliculas/join");
       Movies = responseReader._peliculas;
    }
    public class ResponsePrestamo
    {
        public string Message { get; set; }
        public bool ok { get; set; }
    }
     public class ResponseReader
     {
            public List<Pelicula_repo> _peliculas { get; set; }
            public bool ok { get; set; }
     }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591
