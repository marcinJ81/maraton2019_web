using Abstract_And_Model_Layer;
using Abstract_And_Model_Layer.Registration_Participant_Model;
using maratonMszana_v4.VerificationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace maratonMszana_v4.Controllers
{
    public class VerificationEmailController : Controller
    {
        private readonly IUniqueException _ithrow; //te dwa razewm do jednej klasy
        private readonly IExceptionBase _ierorBase; //
        private readonly ISendingVerifyingEmail _isendingVer;
        private readonly ISendingConfirmationRegistrationEmail _isendingEnd;
        private readonly IAddZawodnik _iaddZaw;
        private readonly IUniqueException _iUexecp;
 
        public VerificationEmailController(ISendingVerifyingEmail isendingE, IUniqueException _ithrow,
            ISendingConfirmationRegistrationEmail _isending, IExceptionBase _erorBase, IAddZawodnik iaddZaw,
            IUniqueException iUexecp)
        {
            this._ithrow = _ithrow;
            this._isendingVer = isendingE;
            this._isendingEnd = _isending;
            this._ierorBase = _erorBase;
            this._iaddZaw = iaddZaw;
            this._iUexecp = iUexecp;
        }

        [HttpGet]
        public ActionResult VerificationNumber(bool visibleTrue, string errorMessage)
        {
            int randomNumber = -1;
            kartoteka2 kartoteka = new kartoteka2();
            if (Session["kartoteka"] != null)
            {
                kartoteka = (kartoteka2)Session["kartoteka"];
            }
            else
            {
                return RedirectToAction("Register", "Registration");
            }

                if (visibleTrue == true)
                {
                    if(Session["randomValue"] != null)
                    {
                        randomNumber = (int)Session["randomValue"];
                    }
                    ViewBag.visibleTrue = visibleTrue;
                    ViewBag.errorMessage = errorMessage;
                }
                else
                {
                    randomNumber = _isendingVer.sendEmailToVerification(kartoteka.kart_email, kartoteka.kart_nazwisko, kartoteka.kart_imie);
                }

            if (randomNumber > 0)
            {
                Session["randomValue"] = randomNumber;
                ViewBag.imie = kartoteka.kart_imie;
                ViewBag.nazwisko = kartoteka.kart_nazwisko;
                ViewBag.email = kartoteka.kart_email;
                return View(kartoteka);
            }
            else
            {
                return RedirectToAction("info2", new { messageWindow = "Adres Email nie poprawny" });
            }
        }

        private string getSystemMessage(int number)
        {
            Dictionary<int, string> systemMessage = new Dictionary<int, string>();
            systemMessage.Add(1, "Przekroczony limit czasu na wprowadzenie numeru. Zarejestruj się jeszcze raz.");
            systemMessage.Add(2, "Podany numer jest nieprawidłowy.Spróbuj jeszcze raz.");
            systemMessage.Add(3, "Taki zawodnik jest już zarejestrowany.Poszukaj na liście zawodników.");

            return systemMessage.Where(x => x.Key == number).FirstOrDefault().Value;
        }

        [HttpPost]
        public ActionResult VerificationNumber(int _number, kartoteka2 _kart)
        {
            try
            {
                int _randomNumber = Session["randomValue"] == null ? 0 : int.Parse(Session["randomValue"].ToString());
                if ((_randomNumber > 0) && (_number == _randomNumber))
                {
                    if (_iaddZaw.pKartotekaZawodnikaDodaj(_kart))
                    {
                        _isendingEnd.sendWelcomeEmail(_kart.kart_imie, _kart.kart_nazwisko, _kart.kart_email);
                        ViewBag.visibleTrue = true;
                        return RedirectToAction("RegistrationList", "RegistrationListUser");
                    }
                    else
                    {
                       ViewBag.visibleTrue = true;
                        _ierorBase.addExceptionToBase("przekroczono limit czasu: " + _kart.kart_email + " " + _kart.kart_nazwisko, "weryfikacja numeru");
                        return RedirectToAction("VerificationNumber", "VerificationEmail", new { visibleTrue = true, errorMessage = getSystemMessage(1) });
                    }
                }
                else
                {
                    ViewBag.visibleTrue = true;
                    _ierorBase.addExceptionToBase("niezgodność numeru: " + _kart.kart_email + " " + _kart.kart_nazwisko, "weryfikacja numeru");
                    return RedirectToAction("VerificationNumber","VerificationEmail", new { visibleTrue = true, errorMessage = getSystemMessage(2) });
                  
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    _iUexecp.setUniqueEcxeption("Rejestracja", ex.InnerException.Message);
                }
                _ierorBase.addExceptionToBase(ex.Message, "weryfikacja numeru");
                _ierorBase.addExceptionToBase("brak unikalności : " + _kart.kart_email + " " + _kart.kart_nazwisko, "weryfikacja numeru");
                return RedirectToAction("VerificationNumber", "VerificationEmail", new { visibleTrue = true, errorMessage = getSystemMessage(3) });
            }
        }

    }
}
