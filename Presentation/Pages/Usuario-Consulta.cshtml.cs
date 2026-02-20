using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceReference1;
using ServiceReference2;
using UserDTO = Presentation.DTOs.UserDTO;

namespace Presentacion.Pages;

public class Usuario_ConsultaModel : PageModel
{
    public List<UserDTO> Users { get; set; } = new();
    public List<SelectListItem> Genders { get; set; } = new();

    private async Task GetGendersActivesAsync()
    {
        var client = new GenderServiceClient();
        var listGenders = await client.GetActivesAsync();

        Genders = listGenders.Select(g => new SelectListItem
        {
            Value = g.Id.ToString(),
            Text = g.Name
        }).ToList();

        await client.CloseAsync();
    }

    private async Task GetUsersAsync()
    {
        var client = new UserServiceClient();
        var listUsers = (await client.GetAsync()).ToList();
        foreach (var item in listUsers)
        {
            Users.Add(new()
            {
                Id = item.Id,
                Names = item.Names,
                DateOfBirth = item.DateOfBirth,
                Gender = new()
                {
                    Id = item.IdGender,
                    Name = item.NameGender
                },
                IsActive = item.IsActive,
                CreatedAt = item.CreatedAt,
                UpdatedAt = item.UpdatedAt
            });
        }
        await client.CloseAsync();
    }

    public async Task OnGetAsync()
    {
        await GetUsersAsync();
        await GetGendersActivesAsync();
    }

    public async Task<IActionResult> OnPostDeleteUserAsync(string id)
    {
        await GetGendersActivesAsync();

        var client = new UserServiceClient();
        var response = await client.DeleteAsync(Guid.Parse(id));

        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostUpdateUserAsync(string id, string names, string dateOfBirth, string idGender)
    {
        await GetGendersActivesAsync();

        var user = new ServiceReference2.UserDTO()
        {
            Id = Guid.Parse(id),
            Names = names,
            DateOfBirth = DateTime.Parse(dateOfBirth),
            IdGender = Guid.Parse(idGender)
        };
        var client = new UserServiceClient();
        var response = await client.PutAsync(user);

        return RedirectToPage();
    }
}