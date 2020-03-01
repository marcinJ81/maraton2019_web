using Abstract_And_Model_Layer.Registration_Participant_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_And_Model_Layer
{
    public interface ICheckWerification
    {
        void saveTimeWerification(kartoteka_TMP _tmp);
        bool getTimeAndVerification(string imie, string naziwsko, string email);
    }
    public interface IDystans
    {
        List<Dystans> filtrDystans();

    }
    public interface IGrupa
    {
        List<grupa_kolarska> filtrGrupa();
        void addNewGrupa(grupa_kolarska newGroup);
    }
    public interface INewRecord
    {
        kartoteka2 createNewRecord(string imie, string nazwisko, string email, string dataUr
            , int? plec, string telefon, string uwagi, int? dys, int? group);
    }
    public interface IPlayerVerfication
    {
        bool searchPlayer(kartoteka2 kart);
   }
    public interface IPlec
    {
        List<Plec> filtrPlec();
    }
    public interface IRandomNumber
    {
        int generateNumber();
    }
    public interface IregistrationList
    {
        List<ExtModelRegistrationList> generateListZawodnik();
    }
    public interface IAddZawodnik
    {
        bool pKartotekaZawodnikaDodaj(kartoteka2 kart);
        bool addParticipantWithoutTimeRegistrationVerification(kartoteka2 kart);
    }
    public interface IKartoteka_TMP
    {
        kartoteka_TMP getInfoAboutTimeRegistrationForParticipant(string name, string surname, string email);
    }
    public interface IKartoteka2Info
    {
        List<kartoteka2> getInformationAboutAllParticipant();
        kartoteka2 getInformationAboutOneParticipantFromKartoteka2(IKartoteka2Info allParticipant, string name, string surname, string email);
        kartoteka2 getEmptyResult();
        kartoteka2 getOneParticipantById(IKartoteka2Info allParticipant, int kart_id);
    }
    public interface ISimpleAddingParticipant
    {
       bool AddNewParticipant(string name,string sname, string email, int dys_id);
        bool saveParticipantToBase { get; set; }
        string errorInformation { get; set; }
        bool validateFormatEmail(string email);
    }

    public interface ISimpleAddingParticipant2
    {
        bool AddNewParticipant(string name, string sname, string email, int dys_id,
            ISimpleAddingParticipant2 isimpleAdd, IPlayerVerfication iparticipant,
            IAddZawodnik iaddParticipant, INewRecord inewRecord);
        bool saveParticipantToBase { get; set; }
        string errorInformation { get; set; }
        bool validateFormatEmail(string email);
    }

    public interface IKartoteka2Info_Test
    {
        List<kartoteka2> getInformationAboutAllParticipant();
        kartoteka2 getEmptyResult();
        kartoteka2 getOneParticipantById(int kart_id);
    }


}
