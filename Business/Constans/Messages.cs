using Core.Entities.Concrete;
using Entities.Concrete;
using Newtonsoft.Json;

namespace Business.Constans
{
    public static class Messages
    {
        public static string SuccessCityAdded = JsonConvert.SerializeObject("Şehir başarıyla eklendi");
        public static string SuccessCityUpdated = JsonConvert.SerializeObject("Şehir başarıyla güncellendi");
        public static string SuccessCityDeleted = JsonConvert.SerializeObject("Şehir başarıyla silindi");
        public static string ErrorCityLength = JsonConvert.SerializeObject("Şehir ismi en az 2 karekter olmalıdır");
        public static string ErrorCityNull = JsonConvert.SerializeObject("Şehir ismi boş olamaz");
        public static string MaintanceTime = JsonConvert.SerializeObject("Bakım Zamanı");
        public static string CityListed = JsonConvert.SerializeObject("Şehirler başarıyla listelendi");
        public static string CitiesListed = JsonConvert.SerializeObject("Şehirler başarıyla listelendi");
        public static string SuccessCompanyAdded = JsonConvert.SerializeObject("Şirket başarıyla eklendi");
        public static string SuccessCompanyUpdated = JsonConvert.SerializeObject("Şirket başarıyla güncellendi");
        public static string SuccessCompanyDeleted = JsonConvert.SerializeObject("Şirket başarıyla silindi");
        public static string CompanyListed = JsonConvert.SerializeObject("Şirketler başarıyla listelendi");
        public static string CompaniesListed = JsonConvert.SerializeObject("Şirketler başarıyla listelendi");
        public static string CityNameAlreadyExist = JsonConvert.SerializeObject("Bu şehir ismi daha önce eklenmiş");
        public static string IsCountryCountLimitInvalid = JsonConvert.SerializeObject("Ülke sayısı 10 dan büyük olamaz");
        public static string AuthorizationDenied = JsonConvert.SerializeObject("Bu işlemi yapmak için yetkiniz bulunmamaktadır");
        public static string UserRegistered = JsonConvert.SerializeObject("Kayıt oldu");
        public static string UserNotFound = JsonConvert.SerializeObject("Kullanıcı bulunamadı");
        public static string PasswordError = JsonConvert.SerializeObject("Parola hatası");
        public static string SuccessfulLogin = JsonConvert.SerializeObject("Başarılı giriş");
        public static string UserAlreadyExists = JsonConvert.SerializeObject("Kullanıcı mevcut");
        public static string AccessTokenCreated = JsonConvert.SerializeObject("İşlem Başarılı");
        public static string PasswordNotSame = JsonConvert.SerializeObject("Password Alanları Aynı Değil");
        public static string SuccessPasswordChange= JsonConvert.SerializeObject("Password Başarıyla Değiştirildi");
        public static string CompanyNameAlreadyExist = JsonConvert.SerializeObject("Bu şirket ismi daha önce eklenmiş");
        public static string TaxNumberAlreadyExist = JsonConvert.SerializeObject("Bu vergi numarası daha önce eklenmiş");
        public static string UserCodeAlreadyUpdated = JsonConvert.SerializeObject("Kullanıcı seçimi daha önce yapılmış");
        public static string PersonelUserAlreadyExist = JsonConvert.SerializeObject("Kullanıcı daha önce eklenmiş");
        public static string PersonelUserNotFound = JsonConvert.SerializeObject("Kullanıcı bulunamadı.");
        public static string PermissionError = JsonConvert.SerializeObject("You do not have permission to view this data. Please contact your administrator.");
        public static string PasswordExist = JsonConvert.SerializeObject("Şifre Bir Önceki Şifre İle Aynı Olamaz.");
        public static string ImageNotFound = JsonConvert.SerializeObject("Resim Bulunamdı.");
    }
}
