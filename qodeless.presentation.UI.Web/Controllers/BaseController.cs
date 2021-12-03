using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using qodeless.Infra.CrossCutting.Identity.Data;
using qodeless.Infra.CrossCutting.Identity.DataModel;
using qodeless.presentation.UI.Web.Helpers;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using qodeless.domain.Entities;
using qodeless.presentation.UI.Web.Models;

namespace qodeless.presentation.UI.Web.Controllers
{
    public abstract class BaseController<TEntity,TViewModel> : Controller where TEntity : class where TViewModel : class, new()
    {
        protected readonly ApplicationDbContext Db;
        protected readonly IMapper _mapper;
        protected string ItemName { get; set; }
        protected string ItemDescription { get; set; }

        protected void SetName(string name) => ItemName = name;
        protected void SetDescription(string description) => ItemDescription = description;

        protected CrudState State = CrudState.Inserting;
        public BaseController(ApplicationDbContext db, IMapper mapper)
        {
            Db = db;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index() => View(Db.Set<TEntity>().ToList());
        [HttpGet]
        public IActionResult Create(Guid id)
        {
            BuildForm(LoadData(id));
            return View();
        }
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var item = Db.Set<TEntity>().Find(id);
            if (item == null) 
                return BadRequest();

            return View("Delete", ValidateDelete(item));
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(Guid id)
        {
            try
            {
                var item = Db.Set<TEntity>().Find(id);
                if (item == null) return BadRequest();
                Db.Set<TEntity>().Remove(item);
                Db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            NotifySuccess("Sucesso", "Registro removido com sucesso.");
            return View("Index", Db.Set<TEntity>().ToList());
        }
        
        public abstract void BuildForm(TViewModel vm);
        public abstract void LoadViewBags();
        public abstract bool Validate(TViewModel vm);
        public abstract DeleteViewModel ValidateDelete(TEntity vm);
        protected void ValidateInit(Guid id)
        {
            State = Guid.Empty == id ? CrudState.Inserting : CrudState.Editing;

            if (!ModelState.IsValid)
                NotifyError("Aviso", "Campos inválidos");

        }
        
        protected bool ValidateBase() => ModelState.ErrorCount == 0;
        [HttpPost]
        public IActionResult Create(TViewModel vm)
        {
            if (vm != null)
            {
                if (Validate(vm))
                {
                    if (SaveData(vm))
                    {
                        NotifySuccess("Sucesso:", "Registro inserido com sucesso!");
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        NotifyError("Erro:", "Falha ao salvar registro!");
                        BuildForm(vm);
                        return View(vm);
                    }
                }
                else
                {
                    foreach (var value in ModelState.Values.Where(_=>_.ValidationState == ModelValidationState.Invalid))
                    {
                        foreach (var erro in value.Errors)
                        {
                            var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                            if (!string.IsNullOrWhiteSpace(erroMsg))
                            {
                                NotifyWarning($"Campo Inválido", erroMsg);
                            }
                        }
                    }
                    BuildForm(vm);
                    return View(vm);
                }
            }
            else
            {
                BuildForm(vm);
                return View(vm);
            }
        }
        public abstract bool SaveData(TViewModel vm);
        protected void NotifySuccess(string titulo, string mensagem) => ModalHelper.ShowModal(titulo, mensagem, ModalHelper.Types.Message, ModalHelper.CssClass.Success);
        protected void NotifyError(string titulo, string mensagem) => ModalHelper.ShowModal(titulo, mensagem, ModalHelper.Types.Message, ModalHelper.CssClass.Danger);
        protected void NotifyWarning(string titulo, string mensagem) => ModalHelper.ShowModal(titulo, mensagem, ModalHelper.Types.Message, ModalHelper.CssClass.Warning);
        protected void NotifyFieldError(string fieldname, string mensagem) => ModelState.AddModelError(fieldname, mensagem);
        protected UserDataModel GetLoggedUser()
        {
            if (!User.Identity.IsAuthenticated) return null;
            return (
                from user in Db.Users
                where user.Email == User.Identity.Name
                select new UserDataModel()
                {
                    Email = user.Email,
                    UserId = user.Id,
                    UserName = user.UserName
                }
            ).FirstOrDefault();

        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewBag.User = GetLoggedUser();
            LoadViewBags();
            base.OnActionExecuting(context);
        }
        private TViewModel LoadData(Guid id)
        {
            State = Guid.Empty == id ? CrudState.Inserting : CrudState.Editing;
            
            var entity = Db.Set<TEntity>().Find(id);
            return entity != null ? _mapper.Map<TViewModel>(entity) : new TViewModel();
        }

        [HttpGet]
        public TViewModel GetById(Guid id)
        {
            State = CrudState.Deleting;
            return LoadData(id);
        }
    }

    public enum CrudState
    {
        Inserting = 1,
        Editing = 2,
        Deleting = 3
    }

}
