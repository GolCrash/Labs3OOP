using CloudGame.Features.DtoModels.Owner;
using CloudGame.Features.DtoModels.Server;
using CloudGame.Features.DtoModels.User;
using CloudGame.Features.Interfaces.Manager;
using CloudGame.Logic.DtoModels.Filtres;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CloudGame.Controllers
{
    [Route("[controller]")]
    public class ManageController : Controller
    {
        private readonly IOwnerManager _ownerManager;
        private readonly IServerManager _serverManager;
        private readonly IUserManager _userManager;

        public const string Manage = "Manage";

        public ManageController(IOwnerManager ownerManager, IServerManager serverManager, IUserManager userManager)
        {
            _ownerManager = ownerManager;
            _serverManager = serverManager;
            _userManager = userManager;
        }

        #region Owner

        [HttpGet(nameof(GetListOwners), Name = nameof(GetListOwners))]
        public async Task<ActionResult<OwnerDto[]>> GetListOwners()
        {
            var list = await _ownerManager.GetListOwner(new OwnerFilter());

            return View(list);
        }

        [HttpGet(nameof(GetInfoOwners), Name = nameof(GetInfoOwners))]
        public async Task<ActionResult<InfoOwnerDto>> GetInfoOwners([FromQuery, Required] Guid isnOwner)
        {
            var model = await _ownerManager.GetInfoOwner(isnOwner);
            return View(model);
        }

        [HttpGet(nameof(Owner), Name = nameof(Owner))]
        public ActionResult Owner()
        {
            return View(new EditOwner());
        }

        [HttpGet(nameof(GetEditOwner), Name = nameof(GetEditOwner))]
        public async Task<ActionResult<EditOwner>> GetEditOwner([FromQuery, Required] Guid isnOwner)
        {
            var model = await _ownerManager.GetOwner(isnOwner);

            return View(nameof(Owner), model);
        }

        [HttpPost(nameof(CreateOwner), Name = nameof(CreateOwner))]
        public async Task<ActionResult> CreateOwner([FromForm] EditOwner model, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return View(nameof(Owner), model);

            await _ownerManager.Create(model, cancellationToken);

            return RedirectToAction(nameof(GetListOwners));
        }

        [HttpPost(nameof(UpdateOwner), Name = nameof(UpdateOwner))]
        public async Task<ActionResult> UpdateOwner([FromForm] EditOwner model, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return View(nameof(Owner), model);

            await _ownerManager.Update(model, cancellationToken);

            return RedirectToAction(nameof(GetListOwners));
        }

        [HttpGet(nameof(DeleteOwner), Name = nameof(DeleteOwner))]
        public async Task<ActionResult> DeleteOwner([FromQuery, Required] Guid isnOwner, CancellationToken cancellationToken)
        {
            await _ownerManager.Delete(isnOwner, cancellationToken);

            return RedirectToAction(nameof(GetListOwners));
        }

        #endregion

        #region Server

        [HttpGet(nameof(GetListServer), Name = nameof(GetListServer))]
        public async Task<ActionResult<ServerDto[]>> GetListServer()
        {
            var list = await _serverManager.GetListServers(new ServerrFilter());

            return View(list);
        }

        [HttpGet(nameof(GetInfoServers), Name = nameof(GetInfoServers))]
        public async Task<ActionResult<InfoServerDto>> GetInfoServers([FromQuery, Required] Guid isnServer)
        {
            var model = await _serverManager.GetInfoServer(isnServer);

            return View(model);
        }

        [HttpGet(nameof(Server), Name = nameof(Server))]
        public ActionResult Server()
        {
            return View(new EditServerDto());
        }

        [HttpGet(nameof(GetEditServer), Name = nameof(GetEditServer))]
        public async Task<ActionResult<EditServerDto>> GetEditServer([FromQuery, Required] Guid isnServer)
        {
            var model = await _serverManager.GetServer(isnServer);

            return View(nameof(Server), model);
        }

        [HttpPost(nameof(CreateServer), Name = nameof(CreateServer))]
        public async Task<ActionResult> CreateServer([FromForm] EditServerDto model, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return View(nameof(Server), model);

            await _serverManager.Create(model, cancellationToken);

            return RedirectToAction(nameof(GetListServer));
        }

        [HttpPost(nameof(UpdateServer), Name = nameof(UpdateServer))]
        public async Task<ActionResult> UpdateServer([FromForm] EditServerDto model, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return View(nameof(Server), model);

            await _serverManager.Update(model, cancellationToken);

            return RedirectToAction(nameof(GetListServer));
        }

        [HttpGet(nameof(DeleteServer), Name = nameof(DeleteServer))]
        public async Task<ActionResult> DeleteServer([FromQuery, Required] Guid isnServer, CancellationToken cancellationToken)
        {
            await _serverManager.Delete(isnServer, cancellationToken);

            return RedirectToAction(nameof(GetListServer));
        }

        #endregion

        #region User

        [HttpGet(nameof(GetListUsers), Name = nameof(GetListUsers))]
        public async Task<ActionResult<UserDto[]>> GetListUsers()
        {
            var list = await _userManager.GetListUser(new UserFilter());

            return View(list);
        }

        [HttpGet(nameof(GetInfoUsers), Name = nameof(GetInfoUsers))]
        public async Task<ActionResult<InfoUserDto>> GetInfoUsers([FromQuery, Required] Guid isnUser)
        {
            var model = await _userManager.GetInfoUser(isnUser);

            return View(model);
        }


        [HttpGet(nameof(User), Name = nameof(User))]
        public ActionResult User()
        {
            return View(new EditUserDto());
        }

        [HttpGet(nameof(GetEditUser), Name = nameof(GetEditUser))]
        public async Task<ActionResult<EditUserDto>> GetEditUser([FromQuery, Required] Guid isnUser)
        {
            var model = await _userManager.GetUser(isnUser);

            return View(nameof(User), model);
        }

        [HttpPost(nameof(CreateUser), Name = nameof(CreateUser))]
        public async Task<ActionResult> CreateUser([FromForm] EditUserDto model, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return View(nameof(User), model);

            await _userManager.Create(model, cancellationToken);

            return RedirectToAction(nameof(GetListUsers));
        }

        [HttpPost(nameof(UpdateUser), Name = nameof(UpdateUser))]
        public async Task<ActionResult> UpdateUser([FromForm] EditUserDto model, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return View(nameof(User), model);

            await _userManager.Update(model, cancellationToken);

            return RedirectToAction(nameof(GetListUsers));
        }

        [HttpGet(nameof(DeleteUser), Name = nameof(DeleteUser))]
        public async Task<ActionResult> DeleteUser([FromQuery, Required] Guid isnUser, CancellationToken cancellationToken)
        {
            await _userManager.Delete(isnUser, cancellationToken);

            return RedirectToAction(nameof(GetListUsers));
        }

        [HttpPost(nameof(SetBindWithServer), Name = nameof(SetBindWithServer))]
        public async Task<ActionResult> SetBindWithServer([FromBody] SetBlindWithServerDto model, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return Json(ModelState);

            await _userManager.SetBindWithServers(model, cancellationToken);

            return Ok();
        }

        [HttpGet(nameof(DeleteBindWithServer), Name = nameof(DeleteBindWithServer))]
        public async Task<ActionResult> DeleteBindWithServer([FromQuery] SetBlindWithServerDto model, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return Json(ModelState);

            await _userManager.SetBindWithServers(model, cancellationToken);

            return RedirectToAction(nameof(GetInfoUsers), new { isnUser = model.IsnUser });
        }
        #endregion
    }
}
