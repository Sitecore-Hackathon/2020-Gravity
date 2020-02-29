namespace Sitecore.Foundation.Accounts.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Security;
    using Sitecore.Foundation.Accounts.Models;
    using Sitecore.Diagnostics;
    using Sitecore.Foundation.Accounts.Attributes;
    using Sitecore.Foundation.Accounts.Repositories;
    using Sitecore.Foundation.Accounts.Services;
    using Sitecore.Foundation.Dictionary.Repositories;
    using Sitecore.Foundation.SitecoreExtensions.Attributes;
    using Sitecore.Foundation.SitecoreExtensions.Extensions;

    public class AccountsController : Controller
    {
        private IAccountRepository AccountRepository { get; }
        private IAccountsSettingsService AccountsSettingsService { get; }
        private IGetRedirectUrlService GetRedirectUrlService { get; }
        private  IUserProfileService userProfileService;

        public AccountsController(IAccountRepository accountRepository,IAccountsSettingsService accountsSettingsService, IGetRedirectUrlService getRedirectUrlService, IUserProfileService userProfileService)
        {
    
            this.AccountRepository = accountRepository;
           
            this.AccountsSettingsService = accountsSettingsService;
            this.GetRedirectUrlService = getRedirectUrlService;
            this.userProfileService = userProfileService;
        }

      

        public static string UserAlreadyExistsError => DictionaryPhraseRepository.Current.Get("/Accounts/Register/User Already Exists", "A user with specified e-mail address already exists");

        private static string ForgotPasswordEmailNotConfigured => DictionaryPhraseRepository.Current.Get("/Accounts/Forgot Password/Email Not Configured", "The Forgot Password E-mail has not been configured");

        private static string UserDoesNotExistError => DictionaryPhraseRepository.Current.Get("/Accounts/Forgot Password/User Does Not Exist", "User with specified e-mail address does not exist");


        [RedirectAuthenticated]
        public ActionResult Register()
        {
            return this.View();
        }


        private LoginInfo CreateLoginInfo(string returnUrl = null)
        {
            return new LoginInfo
            {
                ReturnUrl = returnUrl
            };
        }

        [HttpPost]
        [ValidateModel]
        [RedirectAuthenticated]
        [ValidateRenderingId]
        public ActionResult Register(RegistrationInfo registrationInfo)
        {
            if (this.AccountRepository.Exists(registrationInfo.Email))
            {
                this.ModelState.AddModelError(nameof(registrationInfo.Email), UserAlreadyExistsError);

                return this.View(registrationInfo);
            }

            try
            {
                this.AccountRepository.RegisterUser(registrationInfo.Email, registrationInfo.Password, this.userProfileService.GetUserDefaultProfileId());

                var link = this.GetRedirectUrlService.GetRedirectUrl(AuthenticationStatus.Authenticated);
                return this.Redirect(link);
            }
            catch (MembershipCreateUserException ex)
            {
                Log.Error($"Can't create user with {registrationInfo.Email}", ex, this);
                this.ModelState.AddModelError(nameof(registrationInfo.Email), ex.Message);

                return this.View(registrationInfo);
            }
        }

        [RedirectAuthenticated]
        public ActionResult Login(string returnUrl = null)
        {
            return this.View(this.CreateLoginInfo(returnUrl));
        }

      
        [HttpPost]
        [ValidateModel]
        [ValidateRenderingId]
        public ActionResult Login(LoginInfo loginInfo)
        {
            return this.Login(loginInfo, redirectUrl => new RedirectResult(redirectUrl));
        }

        protected virtual ActionResult Login(LoginInfo loginInfo, Func<string, ActionResult> redirectAction)
        {
            var user = this.AccountRepository.Login(loginInfo.Email, loginInfo.Password);
            if (user == null)
            {
                this.ModelState.AddModelError("invalidCredentials", DictionaryPhraseRepository.Current.Get("/Accounts/Login/User Not Found", "Username or password is not valid."));
                return this.View(loginInfo);
            }

            var redirectUrl = loginInfo.ReturnUrl;
            if (string.IsNullOrEmpty(redirectUrl))
            {
                redirectUrl = this.GetRedirectUrlService.GetRedirectUrl(AuthenticationStatus.Authenticated);
            }

            return redirectAction(redirectUrl);
        }

        

        [HttpPost]
        public ActionResult Logout()
        {
            this.AccountRepository.Logout();

            return this.Redirect(Context.Site.GetRootItem().Url());
        }

    }
}