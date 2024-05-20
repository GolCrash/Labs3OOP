using Microsoft.AspNetCore.Mvc;
using CloudGame.Components.ViewModels;

namespace CloudGame.Components.Components;

public sealed class TextEdit : ViewComponent
{
    public IViewComponentResult Invoke(TextEditViewModel model)
    {
        return View("TextEditView", model);
    }
}
