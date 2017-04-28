using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.LegacyAuthCookieCompat;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCoreApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
			string validationKey = "206B54597075C36D20DE4C802DFE4BA8219CD1B3394F1ED8DCAE6280E901BFE6C9D6D1193CB4E1D708F6C43D081B3C0541751F86F5EB445CC5E091137F9D0F8B";
			string decryptionKey = "6E331009878E66CAC29656461503AF8489F291738C97DB805E45B9B724CB670D";
			byte[] decryptionKeyBytes = HexUtils.HexToBinary(decryptionKey);
			byte[] validationKeyBytes = HexUtils.HexToBinary(validationKey);

			var legacyFormsAuthenticationTicketEncryptor =
				new LegacyFormsAuthenticationTicketEncryptor(decryptionKeyBytes, validationKeyBytes);

			FormsAuthenticationTicket decryptedFormsAuthenticationTicket =
				legacyFormsAuthenticationTicketEncryptor.DecryptCookie(Request.Cookies[".ASPXAUTH"]);


			return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
