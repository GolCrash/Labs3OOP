using Microsoft.AspNetCore.Mvc;
using CloudGame.Components.ViewModels;

namespace CloudGame.Components.Components;

public sealed class Select : ViewComponent
{
    public IViewComponentResult Invoke(SelectViewModel model)
    {
        return View("SelectView", model);
    }
}
