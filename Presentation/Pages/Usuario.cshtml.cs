using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceReference1;
using ServiceReference2;

namespace Presentacion.Pages
{
    public class UsuarioModel : PageModel
    {
        public List<SelectListItem> Genders { get; set; } = new();

        public async Task OnGetAsync()
        {
            await GetGendersActivesAsync();
        }

        public async Task<IActionResult> OnPostSaveUserAsync(string names, string dateOfBirth, string idGender)
        {
            await GetGendersActivesAsync();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(names))
            {
                ViewData["namesError"] = "Los nombres son obligatorios.";
                isValid = false;
            } else if (names.Trim().Length < 3) {
                ViewData["namesError"] = "Ingrese un nombre válido (mínimo 3 caracteres).";
                isValid = false;
            }
            ViewData["namesValue"] = names;

            if (string.IsNullOrWhiteSpace(dateOfBirth))
            {
                ViewData["dateError"] = "La fecha de nacimiento es obligatoria.";
                isValid = false;
            } else if (DateTime.TryParse(dateOfBirth, out DateTime fecha)) {
                if (fecha > DateTime.Today)
                {
                    ViewData["dateError"] = "La fecha no puede ser futura.";
                    isValid = false;
                } else if (fecha.Year < 1900) {
                    ViewData["dateError"] = "Ingrese una fecha válida.";
                    isValid = false;
                }
            } else {
                ViewData["dateError"] = "Formato de fecha inválido.";
                isValid = false;
            }
            ViewData["dateValue"] = dateOfBirth;

            if (string.IsNullOrWhiteSpace(idGender))
            {
                ViewData["sexError"] = "Debe seleccionar un género.";
                isValid = false;
            }

            if (!isValid)
                return Page();

            var user = new UserDTO() 
            { 
                Names = names,
                DateOfBirth = DateTime.Parse(dateOfBirth),
                IdGender = Guid.Parse(idGender)
            };
            var client = new UserServiceClient();
            var response = await client.PostAsync(user);

            TempData["SuccessMessage"] = response.Message;
            return RedirectToPage();
        }

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
    }
}